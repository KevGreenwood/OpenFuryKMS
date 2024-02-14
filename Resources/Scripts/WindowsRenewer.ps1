Set-Location "C:\Windows\System32"

$output = cscript //nologo slmgr.vbs /dli

Write-Host $output

if (!($output -match "Licensed"))
{
    Write-Host "========================================================================"
    Write-Host "`nRenewing The License..."

    $finalOutput = cscript //nologo slmgr.vbs /ato

    if (($finalOutput -match "successful"))
    {
        Write-Host $finalOutput
    }
    else
    {
        Write-Error "There was a problem renewing the license. Please check the error details:"
        Write-Host $finalOutput
    }
}
