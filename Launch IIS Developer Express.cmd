@echo off
if "%ProgramFiles(x86)%"=="" set ProgramFiles(x86)=%ProgramFiles%

"%ProgramFiles(x86)%\Microsoft Webmatrix\iisexpress" /path:"%CD%\web" /port:8081 /clr:v2.0