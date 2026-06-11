@echo off
title Reloj para Pruebas - Colegio Calasanz
:: Intentar abrir con Google Chrome en sus rutas comunes de instalacion
if exist "%ProgramFiles%\Google\Chrome\Application\chrome.exe" (
    start "" "%ProgramFiles%\Google\Chrome\Application\chrome.exe" --app="file:///%~dp0index.html" --window-size=820,950
) else if exist "%ProgramFiles(x86)%\Google\Chrome\Application\chrome.exe" (
    start "" "%ProgramFiles(x86)%\Google\Chrome\Application\chrome.exe" --app="file:///%~dp0index.html" --window-size=820,950
) else if exist "%LocalAppData%\Google\Chrome\Application\chrome.exe" (
    start "" "%LocalAppData%\Google\Chrome\Application\chrome.exe" --app="file:///%~dp0index.html" --window-size=820,950
) else (
    :: Fallback a Microsoft Edge (instalado por defecto en Windows 10/11)
    start msedge --app="file:///%~dp0index.html" --window-size=820,950
)
