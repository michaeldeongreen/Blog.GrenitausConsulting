cd "C:\Git\Blog.GrenitausConsulting\cli\gc-cli"

dotnet publish -c Release -r win10-x64

if [ $1 == "-dev" ]
then
blogurl="http://localhost:4200"
else
blogurl="https://blog.michaeldeongreen.com"
fi

configdir="C:\\Git\\Blog.GrenitausConsulting\\WebApi\\Blog.GrenitausConsulting.Core.Web.Api\\AppData"
outputdir="C:\\Git\\Blog.GrenitausConsulting\\WebClient\\src"

"C:/Git/Blog.GrenitausConsulting/cli/gc-cli/bin/Release/netcoreapp2.0/win10-x64/publish/gc-cli.exe" "-blogurl" $blogurl "-configdir" $configdir "-outputdir" $outputdir