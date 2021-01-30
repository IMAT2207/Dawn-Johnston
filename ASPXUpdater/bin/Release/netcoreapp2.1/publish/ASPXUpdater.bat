@ECHO ON
SET a=%~dp0
SET b=%a%ASPXUpdater.exe
cd /d %a%
cd ..\
start %b%
exit