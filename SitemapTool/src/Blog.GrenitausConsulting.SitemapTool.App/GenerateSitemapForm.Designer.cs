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
            this.btnGenerateSitemap.Location = new System.Drawing.Point(540, 150);
            this.btnGenerateSitemap.Name = "btnGenerateSitemap";
            this.btnGenerateSitemap.Size = new System.Drawing.Size(189, 34);
            this.btnGenerateSitemap.TabIndex = 5;
            this.btnGenerateSitemap.Text = "Generate Sitemap";
            this.btnGenerateSitemap.UseVisualStyleBackColor = true;
            // 
            // GenerateSitemapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 204);
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
    }
}

