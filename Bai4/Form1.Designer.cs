namespace Bai4
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnCrawl = new System.Windows.Forms.Button();
            this.flpMovies = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTop.Controls.Add(this.progressBar1);
            this.pnlTop.Controls.Add(this.btnCrawl);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1312, 74);
            this.pnlTop.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(240, 15);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(667, 43);
            this.progressBar1.TabIndex = 1;
            // 
            // btnCrawl
            // 
            this.btnCrawl.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCrawl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrawl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrawl.ForeColor = System.Drawing.Color.White;
            this.btnCrawl.Location = new System.Drawing.Point(16, 15);
            this.btnCrawl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCrawl.Name = "btnCrawl";
            this.btnCrawl.Size = new System.Drawing.Size(200, 43);
            this.btnCrawl.TabIndex = 0;
            this.btnCrawl.Text = "Lấy dữ liệu phim";
            this.btnCrawl.UseVisualStyleBackColor = false;
            this.btnCrawl.Click += new System.EventHandler(this.btnCrawl_Click);
            // 
            // flpMovies
            // 
            this.flpMovies.AutoScroll = true;
            this.flpMovies.BackColor = System.Drawing.Color.White;
            this.flpMovies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMovies.Location = new System.Drawing.Point(0, 74);
            this.flpMovies.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flpMovies.Name = "flpMovies";
            this.flpMovies.Padding = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.flpMovies.Size = new System.Drawing.Size(1312, 616);
            this.flpMovies.TabIndex = 1;
            this.flpMovies.Paint += new System.Windows.Forms.PaintEventHandler(this.flpMovies_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 690);
            this.Controls.Add(this.flpMovies);
            this.Controls.Add(this.pnlTop);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Beta Cinemas Scraper - Bài 1";
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnCrawl;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.FlowLayoutPanel flpMovies;
    }
}