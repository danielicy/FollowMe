@ECHO OFF

REM The following directory is for .NET 2.0
set DOTNETFX2=%SystemRoot%\Microsoft.NET\Framework\v4.0.30319
set PATH=%PATH%;%DOTNETFX2%

echo Installing FollowMeService...
echo ---------------------------------------------------
InstallUtil /i FollowMyRDP.exe REM Sender_Mail Recipient_Mail Sender_Password
echo ---------------------------------------------------
echo Done.
pause