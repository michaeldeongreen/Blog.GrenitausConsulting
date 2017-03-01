namespace Blog.GrenitausConsulting.SitemapTool.App
{
    partial class GenerateSitemapForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtDomainName = new System.Windows.Forms.TextBox();
            this.lblDomainName = new System.Windows.Forms.Label();
            this.lblConfigurationFiles = new System.Windows.Forms.Label();
            this.txtConfigurationFiles = new System.Windows.Forms.TextBox();
            this.btnBrowseConfigurationFiles = new System.Windows.Forms.Button();
            this.btnGenerateSitemap = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblSitemapOutput = new System.Windows.Forms.Label();
            this.txtSitemapOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtDomainName
            // 
            this.txtDomainName.Location = new System.Drawing.Point(168, 32);
            this.txtDomainName.Name = "txtDomainName";
            this.txtDomainName.Size = new System.Drawing.Size(469, 20);
            this.txtDomainName.TabIndex = 0;
            this.txtDomainName.Text = "http://test.grenitausconsulting.com";
            // 
            // lblDomainName
            // 
            this.lblDomainName.AutoSize = true;
            this.lblDomainName.Location = new System.Drawing.Point(35, 35);
            this.lblDomainName.Name = "lblDomainName";
            this.lblDomainName.Size = new System.Drawing.Size(77, 13);
            this.lblDomainName.TabIndex = 1;
            this.lblDomainName.Text = "Domain Name:";
            // 
            // lblConfigurationFiles
            // 
            this.lblConfigurationFiles.AutoSize = true;
            this.lblConfigurationFiles.Location = new System.Drawing.Point(35, 84);
            this.lblConfigurationFiles.Name = "lblConfigurationFiles";
            this.lblConfigurationFiles.Size = new System.Drawing.Size(127, 13);
            this.lblConfigurationFiles.TabIndex = 3;
            this.lblConfigurationFiles.Text = "Configuration Files (.json):";
            // 
            // txtConfigurationFiles
            // 
            this.txtConfigurationFiles.Location = new System.Drawing.Point(168, 81);
            this.txtConfigurationFiles.Name = "txtConfigurationFiles";
            this.txtConfigurationFiles.Size = new System.Drawing.Size(469, 20);
            this.txtConfigurationFiles.TabIndex = 2;
            this.txtConfigurationFiles.Text = "C:\\Git\\Blog.GrenitausConsulting\\WebApi\\src\\Blog.GrenitausConsulting.Web.Api\\App_D" +
    "ata";
            // 
            // btnBrowseConfigurationFiles
            // 
            this.btnBrowseConfigurationFiles.Image = global::Blog.GrenitausConsulting.SitemapTool.App.Properties.Resources.Avosoft_Warm_Toolbar_Folder_open;
            this.btnBrowseConfigurationFiles.Location = new System.Drawing.Point(658, 66);
            this.btnBrowseConfigurationFiles.Name = "btnBrowseConfigurationFiles";
            this.btnBrowseConfigurationFiles.Size = new System.Drawing.Size(71, 35);
            this.btnBrowseConfigurationFiles.TabIndex = 4;
            this.btnBrowseConfigurationFiles.UseVisualStyleBackColor = true;
            this.btnBrowseConfigurationFiles.Click += new System.EventHandler(this.btnBrowseConfigurationFiles_Click);
            // 
            // btnGenerateSitemap
            // 
            this.btnGenerateSitemap.Location = new System.Drawing.Point(540, 207);
            this.btnGenerateSitemap.Name = "btnGenerateSitemap";
            this.btnGenerateSitemap.Size = new System.Drawing.Size(189, 34);
            this.btnGenerateSitemap.TabIndex = 5;
            this.btnGenerateSitemap.Text = "Generate Sitemaps & RSS";
            this.btnGenerateSitemap.UseVisualStyleBackColor = true;
            this.btnGenerateSitemap.Click += new System.EventHandler(this.btnGenerateSitemap_Click);
            // 
            // button1
            // 
            this.button1.Image = global::Blog.GrenitausConsulting.SitemapTool.App.Properties.Resources.Avosoft_Warm_Toolbar_Folder_open;
            this.button1.Location = new System.Drawing.Point(658, 118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 35);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblSitemapOutput
            // 
            this.lblSitemapOutput.AutoSize = true;
            this.lblSitemapOutput.Location = new System.Drawing.Point(35, 136);
            this.lblSitemapOutput.Name = "lblSitemapOutput";
            this.lblSitemapOutput.Size = new System.Drawing.Size(83, 13);
            this.lblSitemapOutput.TabIndex = 7;
            this.lblSitemapOutput.Text = "Sitemap Output:";
            // 
            // txtSitemapOutput
            // 
            this.txtSitemapOutput.Location = new System.Drawing.Point(168, 133);
            this.txtSitemapOutput.Name = "txtSitemapOutput";
            this.txtSitemapOutput.Size = new System.Drawing.Size(469, 20);
            this.txtSitemapOutput.TabIndex = 6;
            this.txtSitemapOutput.Text = "C:\\Git\\Blog.GrenitausConsulting\\Client\\src";
            // 
            // GenerateSitemapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 314);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblSitemapOutput);
            this.Controls.Add(this.txtSitemapOutput);
            this.Controls.Add(this.btnGenerateSitemap);
            this.Controls.Add(this.btnBrowseConfigurationFiles);
            this.Controls.Add(this.lblConfigurationFiles);
            this.Controls.Add(this.txtConfigurationFiles);
            this.Controls.Add(this.lblDomainName);
            this.Controls.Add(this.txtDomainName);
            this.Name = "GenerateSitemapForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generate Sitemaps";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDomainName;
        private System.Windows.Forms.Label lblDomainName;
        private System.Windows.Forms.Label lblConfigurationFiles;
        private System.Windows.Forms.TextBox txtConfigurationFiles;
        private System.Windows.Forms.Button btnBrowseConfigurationFiles;
        private System.Windows.Forms.Button btnGenerateSitemap;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblSitemapOutput;
        private System.Windows.Forms.TextBox txtSitemapOutput;
    }
}

