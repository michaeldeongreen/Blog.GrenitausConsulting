using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BatchGuy.App.ThirdParty.FolderSelectDialog;
using Blog.GrenitausConsulting.SitemapTool.App.Services.Interfaces;
using Blog.GrenitausConsulting.SitemapTool.App.Services;

namespace Blog.GrenitausConsulting.SitemapTool.App
{
    public partial class GenerateSitemapForm : Form
    {
        public GenerateSitemapForm()
        {
            InitializeComponent();
        }

        private void btnBrowseConfigurationFiles_Click(object sender, EventArgs e)
        {
            try
            {
                var fsd = new FolderSelectDialog();
                fsd.Title = "Configuration Files Location";
                if (fsd.ShowDialog(IntPtr.Zero))
                {
                    txtConfigurationFiles.Text = fsd.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error trying to set the configuration files location", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerateSitemap_Click(object sender, EventArgs e)
        {
            try
            {
                string domain = txtDomainName.Text;
                string configurationPath = txtConfigurationFiles.Text;
                string outputPath = txtSitemapOutput.Text;

                ISitemapService sitemapService = new SitemapService();
                IRSSService rssService = new RSSService();


                sitemapService.Generate(domain,configurationPath,outputPath);
                rssService.Generate(domain, outputPath);

                MessageBox.Show("Sitmaps and rss feed have been generated!", "Sitemaps & RSS Created!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error trying to generate the sitemaps and rss feed", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var fsd = new FolderSelectDialog();
                fsd.Title = "Sitemaps Output Location";
                if (fsd.ShowDialog(IntPtr.Zero))
                {
                  txtSitemapOutput.Text = fsd.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error trying to set the sitemap output location", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
