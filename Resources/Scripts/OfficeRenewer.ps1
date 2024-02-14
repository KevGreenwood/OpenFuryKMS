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
    if (!($output -match "Licensed"))
    {
        cscript //nologo ospp.vbs /act
    }
}