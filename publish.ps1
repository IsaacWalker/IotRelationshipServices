
$services = "Setting", "Scan", "Portal", "Device", "Display"

Foreach($service in $services)
{
    
    $serviceName = $service + "Service"
    $publishProject = ".\IotRelationshipServices\" + $serviceName + "\Web.Iot." + $serviceName  + ".csproj"
    $servicePoolName = $serviceName + "Pool"
    $siteName = $serviceName + "Site"
    $hostName = "www." + $service.ToLower() + ".iotrelationshipfyp.com"
    $websitePath = "$(get-location)\Website\" + $serviceName

    Remove-Website -Name $siteName
    Remove-WebAppPool $servicePoolName
    Remove-Item -Force -Recurse $websitePath

    dotnet publish $publishProject -o Website\$serviceName
    New-WebAppPool $servicePoolName
    Set-ItemProperty IIS:\AppPools\$servicePoolName managedRuntimeVersion ""
    New-Website -Name $siteName -Port 80 -HostHeader $hostName -PhysicalPath $websitePath -ApplicationPool $servicePoolName
}

