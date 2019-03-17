<#
Powershell script is uses azure-cli to deploy the Blog Web API and Blog Web Client.
Parameters are:
1. $username: Service Principal Username
2. $password: Service Principal Password
3. $tenant: Tenant Id
4. $resourcegroup: WebApp Resource Group
5. $webapiname: WebApp Web API Name
6. $webclientname: WebApp Web Client Name
7. $workingdirectory: Release Pipeline Working Directory
8. $builddefinitionname: Build Pipeline Definition Name
#>
param([string]$username,[string]$password,[string]$tenant,[string]$resourcegroup,[string]$webapiname,
[string]$webclientname,[string]$workingdirectory,[string]$builddefinitionname)

# Initialize variables
$webapiZipFile = "$workingdirectory\_$builddefinitionname\drop\webapi.zip"
$webclientZipFile = "$workingdirectory\_$builddefinitionname\drop\webclient.zip"

# Login via Service Principal
az login --service-principal --username $username --password $password --tenant $tenant

# Deploy Web Client files to Azure
az webapp deployment source config-zip --name $webclientname --resource-group $resourcegroup --src $webclientZipFile

# Deploy Web API files to Azure
az webapp deployment source config-zip --name $webapiname --resource-group $resourcegroup --src $webclientZipFile