using Blog.GrenitausConsulting.CLI.Services.Interfaces;
using Blog.GrenitausConsulting.Common;
using Blog.GrenitausConsulting.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.GrenitausConsulting.CLI.Services
{
    public class HtmlService : IHtmlService
    {
        private string _htmlOutputPath;
        private string _domain;
        private string _angularCliSrcPath;
        private string _staticPageHtmlPath;

        public void Generate(string domain, string htmlOutputPath, string angularCliSrcPath)
        {
            _domain = domain;
            _staticPageHtmlPath = "static-pages";
            _htmlOutputPath = string.Format(@"{0}\{1}", htmlOutputPath,_staticPageHtmlPath);
            _angularCliSrcPath = angularCliSrcPath;

            if (!Directory.Exists(_htmlOutputPath))
                Directory.CreateDirectory(_htmlOutputPath);

            WriteHtml();
            CopyAssets();
        }

        private void WriteHtml()
        {
            foreach (var post in BlogContextManager.PostSummaries.Where(p => p.IsActive == true))
            {
                string file = string.Format(@"{0}\{1}.html", _htmlOutputPath, post.Link);

                using (StreamWriter sw = new StreamWriter(file, false, Encoding.UTF8))
                {
                    PostHtml postHtml = BlogContextManager.PostHtmlList.Where(h => h.Link == post.Link).SingleOrDefault();

                    sw.WriteLine(WriteHead(post));

                    sw.WriteLine("<body>");

                    sw.WriteLine(WriteHeader());

                    sw.WriteLine("<div class=\"container\">"); //container
                    sw.WriteLine("<div class=\"row\">"); //row

                    sw.WriteLine("<div class=\"col-md-12\">");
                    sw.WriteLine(WritePost(post,postHtml));
                    sw.WriteLine("</div>");

                    //Gonna roll with the slimmed-down version
                    /*sw.WriteLine("<div class=\"col-md-4\">");
                    sw.WriteLine(WriteCategories());
                    sw.WriteLine("</div>");*/

                    sw.WriteLine("</div>"); //row
                    sw.WriteLine("<hr>");
                    sw.WriteLine(WriteFooter());
                    sw.WriteLine("</div>"); //container

                    sw.WriteLine("</body>");
                    sw.WriteLine("</html>");
                }
            }
        }

        private string WriteHead(PostSummary post)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<!doctype html>");
            sb.AppendLine("<html lang=\"en\">");
            sb.AppendLine("<head>");
            sb.AppendLine("<meta charset=\"utf-8\">");
            sb.AppendLine(string.Format("<title>{0}</title>", post.Title));
            sb.AppendLine("<meta name=\"viewport\" content=\"width=device-width, initial-scale = 1\">");
            sb.AppendLine("<meta http-equiv=\"Content-Language\"content=\"en\">");
            sb.AppendLine(string.Format("<meta name=\"description\" content=\"{0}\">", post.Snippet));
            sb.AppendLine("<meta property=\"og:locale\" content=\"en_US\">");
            sb.AppendLine("<meta property=\"og:type\" content=\"article\">");
            sb.AppendLine(string.Format("<meta property=\"og:title\" content=\"{0}\">", post.Title));
            sb.AppendLine(string.Format("<meta property=\"og:description\" content=\"{0}\">", post.Snippet));
            sb.AppendLine(string.Format("<meta property=\"og:url\" content=\"{0}\">", post.Images[0].Url));
            sb.AppendLine("<meta property=\"og:site_name\" content=\"Grenitaus Consulting, LLC\">");

            foreach (var tag in post.Tags)
            {
                sb.AppendLine(string.Format("<meta name=\"article:tage\" content=\"{0}\">", tag.Name));
            }

            foreach (var category in post.Categories)
            {
                sb.AppendLine(string.Format("<meta name=\"article:section\" content=\"{0}\">", category.Name));
            }

            sb.AppendLine(string.Format("<meta property=\"og:image\" content=\"{0}\">", post.Images[0].Url));
            sb.AppendLine("<meta name=\"twitter:card\" content=\"summary\">");
            sb.AppendLine(string.Format("<meta name=\"twitter:description\" content=\"{0}\">", post.Snippet));
            sb.AppendLine(string.Format("<meta name=\"twitter:title\" content=\"{0}\">", post.Title));

            sb.AppendLine(WriteStyles());
            sb.AppendLine(WriteScripts());

            sb.AppendLine("</head>");

            return sb.ToString();
        }

        private string WriteStyles()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<link rel=\"stylesheet\" type=\"text/css\" href=\"styles.css\">");
            sb.AppendLine("<link rel=\"stylesheet\" type=\"text/css\" href=\"assets\\css\\bootstrap.css\">");
            sb.AppendLine("<link rel=\"stylesheet\" type=\"text/css\" href=\"assets\\css\\blog-home.css\">");
            sb.AppendLine("<link rel=\"stylesheet\" type=\"text/css\" href=\"assets\\css\\prism.css\">");

            return sb.ToString();
        }

        private string WriteScripts()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<script src=\"assets\\js\\jquery.js\"></script>");
            sb.AppendLine("<script src=\"assets\\js\\bootstrap.min.js\"></script>");
            sb.AppendLine("<script src=\"assets\\js\\prism.js\"></script>");

            return sb.ToString();
        }

        private string WriteHeader()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<nav class=\"navbar navbar-inverse navbar-fixed-top\" role=\"navigation\">");
            sb.AppendLine("<div class=\"pull-left\">");
            sb.AppendLine(string.Format("<a href=\"{0}\"><img src=\"{0}/assets/images/grenitaus-consulting-logo-small.png\" alt=\"Grenitaus Consulting Blog\"/></a>",_domain));
            sb.AppendLine("</div>  ");
            sb.AppendLine("<div class=\"container\">");
            sb.AppendLine("<div class=\"navbar-header\">");
            sb.AppendLine("<button type=\"button\" class=\"navbar-toggle\" data-toggle=\"collapse\" data-target=\"#bs-example-navbar-collapse-1\">");
            sb.AppendLine("<span class=\"sr-only\">Toggle navigation</span>");
            sb.AppendLine("<span class=\"icon-bar\"></span>");
            sb.AppendLine("<span class=\"icon-bar\"></span>");
            sb.AppendLine("<span class=\"icon-bar\"></span>");
            sb.AppendLine("</button>");
            sb.AppendLine(string.Format("<a class=\"navbar-brand\" href=\"{0}\">Home</a>",_domain));
            sb.AppendLine("</div>");
            sb.AppendLine("<div class=\"collapse navbar-collapse\" id=\"bs-example-navbar-collapse-1\">");
            sb.AppendLine("<ul class=\"nav navbar-nav\">");
            sb.AppendLine(string.Format("<li><a class=\"social-media-header\" href=\"{0}/About\">About</a></li>",_domain));
            sb.AppendLine("<li><a href =\"http://grenitausconsulting.com\" target=\"_blank\">Services</a></li>");
            sb.AppendLine("</ul>");
            sb.AppendLine("<ul class=\"nav navbar-nav pull-right\">");
            sb.AppendLine(string.Format("<li><a style =\"padding-right:2px;\" href=\"https://www.facebook.com/profile.php?id=100014250101566\" target=\"_blank\"><img src=\"{0}/assets/images/facebook_vecteezy.png\" width=\"28\" height=\"28\"/></a></li>",_domain));
            sb.AppendLine(string.Format("<li><a style =\"padding-right:2px;\" href=\"https://twitter.com/mikedeongreen\" target=\"_blank\"><img src=\"{0}/assets/images/twitter_vecteezy.png\" width=\"28\" height=\"28\" /></a></li>", _domain));
            sb.AppendLine(string.Format("<li><a style =\"padding-right:2px;\" href=\"https://www.linkedin.com/in/michael-d-green\" target=\"_blank\"><img src=\"{0}/assets/images/linkedin_vecteezy.png\" width=\"28\" height=\"28\" /></a></li>", _domain));
            sb.AppendLine(string.Format("<li><a style =\"padding-right:2px;\" href=\"https://github.com/michaeldeongreen\" target=\"_blank\"><img src=\"{0}/assets/images/github_vecteezy.png\" width=\"28\" height=\"28\" /></a></li>", _domain));
            sb.AppendLine(string.Format("<li><a style =\"padding-right:2px;\" href=\"{0}/rss.xml\" target=\"_blank\"><img src=\"{0}/assets/images/rss.png\" width=\"28\" height=\"28\"/></a></li>", _domain));
            sb.AppendLine("</ul>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</nav>");

            return sb.ToString();
        }

        private string WritePost(PostSummary post, PostHtml postHtml)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<div class=\"container\">"); //container
            sb.AppendLine("<div class=\"row\">");
            sb.AppendLine("<div class=\"col-md-12\">"); //in the slimmed down version, this is 8
            sb.AppendLine(string.Format("<h1 class=\"page-header\">{0}</h1>",post.Title));
            sb.AppendLine("<div>");
            sb.AppendLine(string.Format("<p class=\"lead\">by <a href=\"{0}/about\">{1}</a></p>", _domain, post.Author));
            sb.AppendLine(string.Format("<p><span class=\"glyphicon glyphicon-time\"></span> {0}</p>", post.PostDate.ToString("MM/dd/yyyy")));
            sb.AppendLine("<div>");

            sb.Append("<small>Posted in </small><span>");
            for (int i = 0; i < post.Categories.Count(); i++)
            {
                if (post.Categories.Count() == 1 || i + 1 == post.Categories.Count())
                    sb.AppendLine(string.Format("<a href=\"{0}/category/{1}\">{1}</a>", _domain, post.Categories[i].Name));
                else
                    sb.AppendLine(string.Format("<a href=\"{0}/category/{1}\">{1}, </a>", _domain, post.Categories[i].Name));
            }
            sb.AppendLine("</span>");

            sb.Append("<small>Tagged </small><span>");
            for (int i = 0; i < post.Tags.Count(); i++)
            {
                if (post.Tags.Count() == 1 || i + 1 == post.Tags.Count())
                    sb.AppendLine(string.Format("<a href=\"{0}/tag/{1}\">{1}</a>", _domain, post.Tags[i].Name));
                else
                    sb.AppendLine(string.Format("<a href=\"{0}/tag/{1}\">{1}, </a>", _domain, post.Tags[i].Name));

            }
            sb.AppendLine("</span>");

            sb.AppendLine("</div>");

            sb.AppendLine("<hr>");
            sb.AppendLine(string.Format("<p>{0}</p>", postHtml.Hmtl));
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("<br />");

            sb.AppendLine("<div class=\"row\">");
            sb.AppendLine("<span>");
            sb.AppendLine(string.Format("<a style=\"text-decoration:none;\" href=\"mailto:?Subject={0}&amp;Body=I%20saw%20this%20and%20thought%20of%20you!%20 {1}.html\"><img src=\"assets/images/email.png\" alt=\"Email\" width=\"48\" height=\"48\"/></a>",post.Title,post.Link));
            sb.AppendLine(string.Format("<a style=\"text-decoration:none;\" href=\"http://www.linkedin.com/shareArticle?mini=true&amp;url={0}/{1}/{2}.html\" target=\"_blank\"><img src=\"assets/images/linkedin.png\" alt=\"LinkedIn\" width=\"48\" height=\"48\" /></a>",_domain,_staticPageHtmlPath,post.Link ));
            sb.AppendLine(string.Format("<a style=\"text-decoration:none;\" href=\"https://plus.google.com/share?url={0}/{1}/{2}.html\" target=\"_blank\"><img src=\"assets/images/google.png\" alt=\"Google\" width=\"48\" height=\"48\" /></a>",_domain, _staticPageHtmlPath,post.Link));
            sb.AppendLine(string.Format("<a href=\"http://www.facebook.com/sharer.php?u={0}/{1}/{2}.html\" target=\"_blank\"><img src=\"assets/images/facebook.png\" alt=\"Facebook\" width=\"48\" height=\"48\" /></a>",_domain,_staticPageHtmlPath, post.Link));
            sb.AppendLine("<a style=\"text-decoration:none;\" href=\"javascript:void((function()%7Bvar%20e=document.createElement('script');e.setAttribute('type','text/javascript');e.setAttribute('charset','UTF-8');e.setAttribute('src','http://assets.pinterest.com/js/pinmarklet.js?r='+Math.random()*99999999);document.body.appendChild(e)%7D)());\"><img src=\"assets/images/pinterest.png\" alt=\"Pinterest\" width=\"48\" height=\"48\" /></a>");
            sb.AppendLine(string.Format("<a style=\"text-decoration:none;\" href=\"http://reddit.com/submit?url={0}/{1}/{2}.html&amp;title={3}\" target=\"_blank\"><img src=\"assets/images/reddit.png\" alt=\"Reddit\" width=\"48\" height=\"48\" /></a>",_domain,_staticPageHtmlPath,post.Link, post.Title));
            sb.AppendLine(string.Format("<a style=\"text-decoration:none;\" href=\"http://www.tumblr.com/share/link?url={0}/{1}/{2}.html&amp;title={3}\" target=\"_blank\"><img src=\"assets/images/tumblr.png\" alt=\"Tumblr\" width=\"48\" height=\"48\" /></a>", _domain,_staticPageHtmlPath,post.Link, post.Title));
            sb.AppendLine(string.Format("<a style=\"text-decoration:none;\" href=\"https://twitter.com/share?url={0}/{1}/{2}.html&amp;text={3}&amp;hashtags=grenitausconsulting\" target=\"_blank\"><img src=\"assets/images/twitter.png\" alt=\"Twitter\" width=\"48\" height=\"48\" /></a>",_domain,_staticPageHtmlPath,post.Link,post.Title ));
            sb.AppendLine("</span>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>"); //container
            
            return sb.ToString();
        }

        private string WriteCategories()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<div class=\"well\">"); //well
            sb.AppendLine("<h4>Categories</h4>");
            sb.AppendLine("<div class=\"row\">");
            sb.AppendLine("<div class=\"col-lg-6\">");
            sb.AppendLine("<ul class=\"list-unstyled\">");
            foreach (var category in BlogContextManager.Categories.OrderBy(c => c.Name))
            {
                sb.AppendLine("<li class=\"side-widgets-padding-top\">");
                sb.AppendLine(string.Format("<a class=\"anchor-pointer\" a href=\"{0}/category/{1}\">{1}</a>",_domain,category.Name));
            }
            sb.AppendLine("</li>");
            sb.AppendLine("</ul>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");

            return sb.ToString();
        }

        private string WriteFooter()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<footer>");
            sb.AppendLine("<div class=\"row\">");
            sb.AppendLine("<div class=\"col-lg-12\">");
            sb.AppendLine("<p>Copyright &copy; Grenitaus Consulting, LLC 2017</p>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</footer>");

            return sb.ToString();
        }

        private void CopyAssets()
        {
            string[] assetFolders = new string[] {"css","images","js", "fonts"};
            File.Copy(string.Format(@"{0}\styles.css", _angularCliSrcPath), string.Format(@"{0}\styles.css",_htmlOutputPath),true);
            foreach (var assetFolder in assetFolders)
            {
                string sourcePath = string.Format(@"{0}\assets\{1}",_angularCliSrcPath, assetFolder);
                string destPath = string.Format(@"{0}\assets\{1}", _htmlOutputPath, assetFolder);

                DirectoryInfo sourceDirInfo = new DirectoryInfo(sourcePath);
                DirectoryInfo destDirInfo = new DirectoryInfo(destPath);

                if (!destDirInfo.Exists)
                    destDirInfo.Create();

                foreach (var file in sourceDirInfo.GetFiles())
                {
                    file.CopyTo(string.Format(@"{0}\{1}", destPath, file.Name), true);
                }
            }
        }
    }
       
}
