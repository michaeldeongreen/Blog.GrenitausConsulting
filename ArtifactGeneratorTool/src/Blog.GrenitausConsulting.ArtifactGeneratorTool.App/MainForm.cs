using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blog.GrenitausConsulting.ArtifactGeneratorTool.App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnGenerateSitemapAndRSS_Click(object sender, EventArgs e)
        {
            GenerateSitemapForm form = new GenerateSitemapForm();
            form.ShowDialog();
        }
    }
}
