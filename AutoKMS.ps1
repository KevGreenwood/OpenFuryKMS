Set-Location "C:\Program Files\Microsoft Office\Office16"

$KMS_Servers = @("kms.digiboy.ir", "kms.chinancce.com", "kms.ddns.net", "xykz.f3322.org", "dimanyakms.sytes.net", "kms.03k.org", "ms8.us.to", "s8.uk.to", "s9.us.to", "kms9.msguides.com", "kms8.msguides.com")

for ($i = 0; $i -lt 10; $i++)
{
    foreach ($KMS in $KMS_Servers)
    {
        $output = cscript //nologo ospp.vbs /sethst:$KMS 2>&1
        if ($output -like "*successful*")
        {
            Write-Output "Activación exitosa con el servidor $KMS"
            break
        }
        else
        {
            Write-Output "La activación falló con el servidor $KMS. Intentando con el siguiente servidor..."
        }
    }
}