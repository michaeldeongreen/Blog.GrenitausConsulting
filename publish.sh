cd "C:/Git/Blog.GrenitausConsulting/Core.cli/src/gc-cli/bin/Release/netcoreapp2.0/win10-x64/publish"
gc-cli build -prod

rm -rf "c:/temp/My Blog Uploads/dist/api" && mkdir "c:/temp/My Blog Uploads/dist/api"
dotnet publish "C:\Git\Blog.GrenitausConsulting\Core.WebApi\src\Blog.GrenitausConsulting.Core.Web.Api" -c Release -o "C:\temp\My Blog Uploads\dist\api"

cd c:/Git/Blog.GrenitausConsulting/Client
ng build -prod --output-path "C:\temp\My Blog Uploads\dist\client"

exit 0