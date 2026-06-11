# Build script for Reloj para Pruebas
# Generates index.html from index_template.html and compiles Launcher.cs into Reloj.exe

Write-Host "Iniciando proceso de construcción..." -ForegroundColor Cyan

# 1. Convert resources/logo.png to base64
$logoPath = "Resources\logo.png"
if (-Not (Test-Path $logoPath)) {
    Write-Error "No se pudo encontrar el archivo del logo en $logoPath"
    exit 1
}

Write-Host "Codificando logo.png en base64..." -ForegroundColor Yellow
$logoBytes = [System.IO.File]::ReadAllBytes($logoPath)
$logoBase64 = [System.Convert]::ToBase64String($logoBytes)

# 2. Load index_template.html and replace placeholder
$templatePath = "index_template.html"
if (-Not (Test-Path $templatePath)) {
    Write-Error "No se pudo encontrar index_template.html"
    exit 1
}

Write-Host "Generando index.html..." -ForegroundColor Yellow
$templateContent = [System.IO.File]::ReadAllText($templatePath, [System.Text.Encoding]::UTF8)
$htmlContent = $templateContent.Replace("{{LOGO_BASE64}}", $logoBase64)
[System.IO.File]::WriteAllText("index.html", $htmlContent, [System.Text.Encoding]::UTF8)
Write-Host "index.html generado exitosamente." -ForegroundColor Green

# 3. Locate csc.exe (C# Compiler)
$cscPath = "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe"
if (-Not (Test-Path $cscPath)) {
    # Fallback to Framework (32-bit)
    $cscPath = "C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe"
}

if (-Not (Test-Path $cscPath)) {
    Write-Error "No se pudo encontrar el compilador de C# (csc.exe)"
    exit 1
}

# 4. Compile Launcher.cs with embedded index.html
Write-Host "Compilando Launcher.cs a Reloj.exe..." -ForegroundColor Yellow
$iconParam = ""
if (Test-Path "hourglass_86336.ico") {
    $iconParam = "/win32icon:hourglass_86336.ico"
}

# Run compiler
$cmd = "& `"$cscPath`" /target:winexe /out:Reloj.exe /resource:index.html $iconParam Launcher.cs"
Invoke-Expression $cmd

if ($LASTEXITCODE -eq 0) {
    Write-Host "Construcción completada exitosamente. Se ha generado Reloj.exe." -ForegroundColor Green
} else {
    Write-Error "La compilación falló."
    exit 1
}
