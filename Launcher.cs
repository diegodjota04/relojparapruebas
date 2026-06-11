using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Net;
using System.Text;
using System.Threading;

namespace RelojLauncher
{
    static class Program
    {
        private static HttpListener listener;
        private static string documentsPath;
        private static ManualResetEvent exitEvent = new ManualResetEvent(false);

        [STAThread]
        static void Main()
        {
            try
            {
                // Kill other instances of this program to release the port
                Process current = Process.GetCurrentProcess();
                foreach (Process p in Process.GetProcessesByName(current.ProcessName))
                {
                    if (p.Id != current.Id)
                    {
                        try { p.Kill(); } catch { }
                    }
                }

                documentsPath = @"\\192.168.50.6\secundaria$\Reloj para pruebas\Logs de reloj";
                if (!Directory.Exists(documentsPath))
                {
                    Directory.CreateDirectory(documentsPath);
                }

                // Start HTTP Server
                StartServer();

                // Read the embedded index.html resource
                Assembly assembly = Assembly.GetExecutingAssembly();
                string resourceName = "index.html";
                Stream htmlStream = null;
                
                foreach (string name in assembly.GetManifestResourceNames())
                {
                    if (name.EndsWith(resourceName))
                    {
                        htmlStream = assembly.GetManifestResourceStream(name);
                        break;
                    }
                }

                if (htmlStream == null) return;
                
                try
                {
                    ExtractAndLaunch(htmlStream);
                }
                catch (Exception ex)
                {
                    try
                    {
                        string logDir = Path.Combine(Path.GetTempPath(), "RelojCalasanz");
                        if (!Directory.Exists(logDir)) Directory.CreateDirectory(logDir);
                        File.AppendAllText(Path.Combine(logDir, "error_log.txt"), DateTime.Now + ": Browser launch error: " + ex.ToString() + Environment.NewLine);
                    }
                    catch {}
                }

                // Wait for exit signal
                exitEvent.WaitOne();

                // Stop server
                if (listener != null && listener.IsListening)
                {
                    listener.Stop();
                }
            }
            catch (Exception)
            {
                // Silently ignore or handle exceptions
            }
        }

        static void StartServer()
        {
            try
            {
                listener = new HttpListener();
                listener.Prefixes.Add("http://localhost:5005/");
                listener.Start();
                listener.BeginGetContext(new AsyncCallback(ListenerCallback), listener);
            }
            catch (Exception)
            {
                // If port is already in use or listener fails to start
            }
        }

        static void ListenerCallback(IAsyncResult ar)
        {
            try
            {
                HttpListener l = (HttpListener)ar.AsyncState;
                if (l == null || !l.IsListening) return;

                HttpListenerContext context = l.EndGetContext(ar);
                l.BeginGetContext(new AsyncCallback(ListenerCallback), l);

                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                // Add CORS headers
                response.Headers.Add("Access-Control-Allow-Origin", "*");
                response.Headers.Add("Access-Control-Allow-Methods", "POST, OPTIONS");
                response.Headers.Add("Access-Control-Allow-Headers", "Content-Type");

                if (request.HttpMethod == "OPTIONS")
                {
                    response.StatusCode = (int)HttpStatusCode.OK;
                    response.Close();
                    return;
                }

                if (request.HttpMethod == "POST" && request.Url.LocalPath == "/exit")
                {
                    response.StatusCode = (int)HttpStatusCode.OK;
                    byte[] buffer = Encoding.UTF8.GetBytes("{\"status\":\"exiting\"}");
                    response.ContentLength64 = buffer.Length;
                    response.ContentType = "application/json";
                    response.OutputStream.Write(buffer, 0, buffer.Length);
                    response.Close();
                    
                    // Give other requests (like /save-pdf) time to finish
                    Thread.Sleep(500);
                    exitEvent.Set();
                    return;
                }

                if (request.HttpMethod == "POST" && request.Url.LocalPath == "/save-pdf")
                {
                    try
                    {
                        using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
                        {
                            string json = reader.ReadToEnd();
                            string filename = GetJsonValue(json, "filename");
                            string pdfBase64 = GetJsonValue(json, "pdfBase64");

                            if (!string.IsNullOrEmpty(filename) && !string.IsNullOrEmpty(pdfBase64))
                            {
                                byte[] bytes = Convert.FromBase64String(pdfBase64);
                                if (!Directory.Exists(documentsPath))
                                {
                                    Directory.CreateDirectory(documentsPath);
                                }
                                string filePath = Path.Combine(documentsPath, filename);
                                File.WriteAllBytes(filePath, bytes);

                                string responseString = "{\"status\":\"success\"}";
                                byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                                response.ContentLength64 = buffer.Length;
                                response.ContentType = "application/json";
                                response.OutputStream.Write(buffer, 0, buffer.Length);
                            }
                            else
                            {
                                response.StatusCode = (int)HttpStatusCode.BadRequest;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            string logDir = Path.Combine(Path.GetTempPath(), "RelojCalasanz");
                            if (!Directory.Exists(logDir)) Directory.CreateDirectory(logDir);
                            string logPath = Path.Combine(logDir, "error_log.txt");
                            File.AppendAllText(logPath, DateTime.Now + ": Error saving PDF - " + ex.ToString() + Environment.NewLine);
                        }
                        catch {}

                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        byte[] errorBuffer = Encoding.UTF8.GetBytes("{\"error\":\"" + ex.Message.Replace("\"", "\\\"") + "\"}");
                        response.ContentLength64 = errorBuffer.Length;
                        response.ContentType = "application/json";
                        response.OutputStream.Write(errorBuffer, 0, errorBuffer.Length);
                    }
                    response.Close();
                }
                else
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Close();
                }
            }
            catch (Exception ex)
            {
                try
                {
                    string logDir = Path.Combine(Path.GetTempPath(), "RelojCalasanz");
                    if (!Directory.Exists(logDir)) Directory.CreateDirectory(logDir);
                    string logPath = Path.Combine(logDir, "error_log.txt");
                    File.AppendAllText(logPath, DateTime.Now + ": Thread Callback Exception - " + ex.ToString() + Environment.NewLine);
                }
                catch {}
            }
        }

        private static string GetJsonValue(string json, string key)
        {
            try
            {
                string searchKey = "\"" + key + "\"";
                int keyIndex = json.IndexOf(searchKey);
                if (keyIndex == -1) return null;

                int colonIndex = json.IndexOf(':', keyIndex + searchKey.Length);
                if (colonIndex == -1) return null;

                int valueStart = json.IndexOf('"', colonIndex);
                if (valueStart == -1) return null;
                valueStart++;

                int valueEnd = json.IndexOf('"', valueStart);
                if (valueEnd == -1) return null;

                return json.Substring(valueStart, valueEnd - valueStart);
            }
            catch (Exception)
            {
                return null;
            }
        }

        static void ExtractAndLaunch(Stream stream)
        {
            string tempDir = Path.Combine(Path.GetTempPath(), "RelojCalasanz");
            if (!Directory.Exists(tempDir))
            {
                Directory.CreateDirectory(tempDir);
            }
            
            string tempHtmlPath = Path.Combine(tempDir, "index.html");
            
            // Extract the embedded HTML to the temp folder, replacing the computer name placeholder
            string htmlContent;
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                htmlContent = reader.ReadToEnd();
            }

            string computerName = Environment.MachineName;
            htmlContent = htmlContent.Replace("{{COMPUTER_NAME}}", computerName);

            File.WriteAllText(tempHtmlPath, htmlContent, Encoding.UTF8);

            // Launch browser in app mode
            string chromePath = GetChromePath();
            string browserPath = string.IsNullOrEmpty(chromePath) ? "msedge" : chromePath;
            
            Process.Start(new ProcessStartInfo
            {
                FileName = browserPath,
                Arguments = string.Format("--app=\"file:///{0}\" --window-size=820,950", tempHtmlPath),
                UseShellExecute = false,
                CreateNoWindow = true
            });
        }

        static string GetChromePath()
        {
            string path1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), @"Google\Chrome\Application\chrome.exe");
            if (File.Exists(path1)) return path1;

            string path2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"Google\Chrome\Application\chrome.exe");
            if (File.Exists(path2)) return path2;

            string path3 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Google\Chrome\Application\chrome.exe");
            if (File.Exists(path3)) return path3;

            return null;
        }
    }
}
