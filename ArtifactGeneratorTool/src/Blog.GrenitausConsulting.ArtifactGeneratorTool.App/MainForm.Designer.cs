namespace Blog.GrenitausConsulting.ArtifactGeneratorTool.App
{
    partial class MainForm
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
            this.btnGenerateSitemapAndRSS = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGenerateSitemapAndRSS
            // 
            this.btnGenerateSitemapAndRSS.Location = new System.Drawing.Point(46, 40);
            this.btnGenerateSitemapAndRSS.Name = "btnGenerateSitemapAndRSS";
            this.btnGenerateSitemapAndRSS.Size = new System.Drawing.Size(349, 38);
            this.btnGenerateSitemapAndRSS.TabIndex = 0;
            this.btnGenerateSitemapAndRSS.Text = "Generate Sitemaps & RSS";
            this.btnGenerateSitemapAndRSS.UseVisualStyleBackColor = true;
            this.btnGenerateSitemapAndRSS.Click += new System.EventHandler(this.btnGenerateSitemapAndRSS_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 133);
            this.Controls.Add(this.btnGenerateSitemapAndRSS);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateSitemapAndRSS;
    }
}