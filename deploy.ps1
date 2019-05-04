<#
Powershell script is uses azure-cli to deploy the Blog Web API and Blog Web Client.
Parameters are:
* $username: Service Principal Username
* $password: Service Principal Password
* $tenant: Tenant Id
* $resourcegroup: WebApp Resource Group
* $webapiname: WebApp Web API Name
* $webclientname: WebApp Web Client Name
* $dropdirectory: Release Pipeline Drop Working Directory
#>
param(
    [Parameter(Mandatory=$true)]    
    [string]$username=$(throw "username is mandatory"),
    
    [Parameter(Mandatory=$true)]
    [string]$password=$(throw "password is mandatory"),

    [Parameter(Mandatory=$true)]
    [string]$tenant=$(throw "tenant is mandatory"),

    [Parameter(Mandatory=$true)]
    [string]$resourcegroup=$(throw "resourcegroup is mandatory"),

    [Parameter(Mandatory=$true)]
    [string]$webapiname=$(throw "webapiname is mandatory"),

    [Parameter(Mandatory=$true)]
    [string]$webclientname=$(throw "webclientname is mandatory"),

    [Parameter(Mandatory=$true)]
    [string]$dropdirectory=$(throw "dropdirectory is mandatory")
)

# Initialize variables
$webapiZipFile = "$dropdirectory\webapi.zip"
$webclientZipFile = "$dropdirectory\webclient.zip"

# Login via Service Principal
az login --service-principal --username $username --password $password --tenant $tenant

# Deploy Web Client files to Azure
az webapp deployment source config-zip --name $webclientname --resource-group $resourcegroup --src $webclientZipFile

# Deploy Web API files to Azure
az webapp deployment source config-zip --name $webapiname --resource-group $resourcegroup --src $webapiZipFile