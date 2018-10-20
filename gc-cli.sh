if [ $1 == "-dev" ]
then
apiurl="http://localhost:4200"
else
apiurl="http://blog.grenitausconsulting.com"
fi

configdir="C:\\Git\\Blog.GrenitausConsulting\\Core.WebApi\\src\\Blog.GrenitausConsulting.Core.Web.Api\\AppData"
outputdir="C:\\Git\\Blog.GrenitausConsulting\\Client\\src"

"C:/Git/Blog.GrenitausConsulting/Core.cli/src/gc-cli/bin/Release/netcoreapp2.0/win10-x64/publish/gc-cli.exe" "-apiurl" $apiurl "-configdir" $configdir "-outputdir" $outputdir