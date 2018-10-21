if [ $1 == "-dev" ]
then
blogurl="http://localhost:4200"
else
blogurl="http://blog.grenitausconsulting.com"
fi

configdir="C:\\Git\\Blog.GrenitausConsulting\\Core.WebApi\\src\\Blog.GrenitausConsulting.Core.Web.Api\\AppData"
outputdir="C:\\Git\\Blog.GrenitausConsulting\\Client\\src"

"C:/Git/Blog.GrenitausConsulting/Core.cli/src/gc-cli/bin/Release/netcoreapp2.0/win10-x64/publish/gc-cli.exe" "-blogurl" $blogurl "-configdir" $configdir "-outputdir" $outputdir