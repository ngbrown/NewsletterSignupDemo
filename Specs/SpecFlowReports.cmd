@echo off
if "%ProgramFiles(x86)%"=="" set ProgramFiles(x86)=%ProgramFiles%

"%ProgramFiles(x86)%\NUnit 2.5.2\bin\net-2.0\nunit-console-x86.exe" Specs.csproj

"%ProgramFiles(x86)%\TechTalk\SpecFlow\specflow.exe" nunitexecutionreport Specs.csproj

TestResult.html