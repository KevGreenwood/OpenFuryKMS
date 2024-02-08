$KMS_Servers = @("kms.chinancce.com", "kms.digiboy.ir", "kms.ddns.net", "xykz.f3322.org", "dimanyakms.sytes.net", "kms.03k.org", "ms8.us.to", "s8.uk.to", "s9.us.to", "kms9.msguides.com", "kms8.msguides.com", "kms7.msguides.com")

$activationSuccessful = $false

foreach ($Server in $KMS_Servers)
{
    if (!$activationSuccessful)
    {
        for ($i = 0; $i -lt 10; $i++)
        {
            cscript //nologo ospp.vbs /sethst:$KMS 2>&1

            $output = cscript //nologo ospp.vbs /act

            if ($output -like "*successful*")
            {
                Write-Output $output
                $activationSuccessful = $true
                break
            }
            else
            {
                Write-Output "The connection to $Server failed! Trying to connect to another one..."
            }
        }
    }
    else
    {
        break
    }
}