Set-Location "C:\Windows\System32"

$output = cscript //nologo slmgr.vbs /dli

if (!($output -match "Licensed"))
{
    cscript //nologo slmgr.vbs /ato
}