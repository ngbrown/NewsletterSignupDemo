if "%ProgramFiles(x86)%"=="" set ProgramFiles(x86)=%ProgramFiles%

call "%ProgramFiles(x86)%\Microsoft Visual Studio 10.0\vc\vcvarsall.bat"

devenv NewsletterSignupDemo.sln /Rebuild Debug /Out build.log

pause