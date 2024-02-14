function DirChecker {
    $officePaths = @(
        "C:\Program Files\Microsoft Office\Office16",
        "C:\Program Files\Microsoft Office\Office15",
        "C:\Program Files (x86)\Microsoft Office\Office16",
        "C:\Program Files (x86)\Microsoft Office\Office15"
    )

    foreach ($officePath in $officePaths) {
        if (Test-Path $officePath) {
            Set-Location $officePath
            return $true
        }
    }

    return $false
}

if (DirChecker)
{
    $output = cscript //nologo ospp.vbs /dstatus

    Write-Host $output

    if (!($output -match "Licensed"))
    {
        Write-Host "========================================================================"
        Write-Host "`nRenewing The License..."

        $finalOutput = cscript //nologo ospp.vbs /act

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
}