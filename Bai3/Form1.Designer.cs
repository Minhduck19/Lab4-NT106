namespace Bai3
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Guna.UI2.WinForms.Guna2TextBox txtUrl;
        private Guna.UI2.WinForms.Guna2Button btnGo;
        private Guna.UI2.WinForms.Guna2Button btnDownloadHtml;
        private Guna.UI2.WinForms.Guna2Button btnDownloadImages;
        private Guna.UI2.WinForms.Guna2Button btnViewSource;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private Guna.UI2.WinForms.Guna2Panel topPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                webView?.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.topPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.txtUrl = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnGo = new Guna.UI2.WinForms.Guna2Button();
            this.btnDownloadHtml = new Guna.UI2.WinForms.Guna2Button();
            this.btnDownloadImages = new Guna.UI2.WinForms.Guna2Button();
            this.btnViewSource = new Guna.UI2.WinForms.Guna2Button();
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            this.SuspendLayout();

            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.FillColor = System.Drawing.Color.WhiteSmoke;
            this.topPanel.Padding = new System.Windows.Forms.Padding(8);
            this.topPanel.Height = 55;

            this.txtUrl.BorderRadius = 6;
            this.txtUrl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUrl.PlaceholderText = "Nhập URL...";
            this.txtUrl.Location = new System.Drawing.Point(10, 10);
            this.txtUrl.Size = new System.Drawing.Size(480, 35);
            this.txtUrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUrl_KeyDown);

            this.btnGo.Text = "Go";
            this.btnGo.BorderRadius = 6;
            this.btnGo.FillColor = System.Drawing.Color.FromArgb(60, 140, 255);
            this.btnGo.ForeColor = System.Drawing.Color.White;
            this.btnGo.Location = new System.Drawing.Point(500, 10);
            this.btnGo.Size = new System.Drawing.Size(60, 35);
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);

            this.btnDownloadHtml.Text = "Download HTML";
            this.btnDownloadHtml.BorderRadius = 6;
            this.btnDownloadHtml.FillColor = System.Drawing.Color.FromArgb(0, 160, 100);
            this.btnDownloadHtml.ForeColor = System.Drawing.Color.White;
            this.btnDownloadHtml.Location = new System.Drawing.Point(565, 10);
            this.btnDownloadHtml.Size = new System.Drawing.Size(120, 35);
            this.btnDownloadHtml.Click += new System.EventHandler(this.btnDownloadHtml_Click);

            this.btnDownloadImages.Text = "Download Images";
            this.btnDownloadImages.BorderRadius = 6;
            this.btnDownloadImages.FillColor = System.Drawing.Color.FromArgb(240, 150, 10);
            this.btnDownloadImages.ForeColor = System.Drawing.Color.White;
            this.btnDownloadImages.Location = new System.Drawing.Point(690, 10);
            this.btnDownloadImages.Size = new System.Drawing.Size(130, 35);
            this.btnDownloadImages.Click += new System.EventHandler(this.btnDownloadImages_Click);

            this.btnViewSource.Text = "View Source";
            this.btnViewSource.BorderRadius = 6;
            this.btnViewSource.FillColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.btnViewSource.ForeColor = System.Drawing.Color.White;
            this.btnViewSource.Location = new System.Drawing.Point(825, 10);
            this.btnViewSource.Size = new System.Drawing.Size(110, 35);
            this.btnViewSource.Click += new System.EventHandler(this.btnViewSource_Click);

            this.webView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView.ZoomFactor = 1D;

            this.topPanel.Controls.Add(this.txtUrl);
            this.topPanel.Controls.Add(this.btnGo);
            this.topPanel.Controls.Add(this.btnDownloadHtml);
            this.topPanel.Controls.Add(this.btnDownloadImages);
            this.topPanel.Controls.Add(this.btnViewSource);

            this.Controls.Add(this.webView);
            this.Controls.Add(this.topPanel);

            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(950, 600);
            this.MinimumSize = new System.Drawing.Size(950, 600);
            this.Name = "Form1";
            this.Text = "MiniBrowser - Bài 3";

            this.topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
