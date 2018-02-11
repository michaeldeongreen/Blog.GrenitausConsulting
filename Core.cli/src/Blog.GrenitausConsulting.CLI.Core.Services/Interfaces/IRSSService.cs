namespace Blog.GrenitausConsulting.CLI.Core.Services.Interfaces
{
    public interface IRSSService
    {
        void Generate(string domain, string rssOutputPath);
    }
}
