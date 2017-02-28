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
    }
}
