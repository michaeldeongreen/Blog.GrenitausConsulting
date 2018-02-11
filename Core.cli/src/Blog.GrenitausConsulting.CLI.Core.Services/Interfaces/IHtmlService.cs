namespace Blog.GrenitausConsulting.CLI.Core.Services.Interfaces
{
    public interface IHtmlService
    {
        void Generate(string domain, string htmlOutputPath, string angularCliSrcPath);
    }
}
