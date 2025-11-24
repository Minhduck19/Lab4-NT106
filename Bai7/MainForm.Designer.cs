namespace Bai7
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnTabAll = new System.Windows.Forms.Button();
            this.btnTabMy = new System.Windows.Forms.Button();
            this.btnRandom = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.flpContent = new System.Windows.Forms.FlowLayoutPanel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.IndianRed;
            this.lblTitle.Location = new System.Drawing.Point(27, 25);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(345, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HÔM NAY ĂN GÌ?";
            // 
            // btnTabAll
            // 
            this.btnTabAll.BackColor = System.Drawing.Color.LightYellow;
            this.btnTabAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabAll.Location = new System.Drawing.Point(36, 86);
            this.btnTabAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnTabAll.Name = "btnTabAll";
            this.btnTabAll.Size = new System.Drawing.Size(107, 37);
            this.btnTabAll.TabIndex = 1;
            this.btnTabAll.Text = "All";
            this.btnTabAll.UseVisualStyleBackColor = false;
            this.btnTabAll.Click += new System.EventHandler(this.btnTabAll_Click);
            // 
            // btnTabMy
            // 
            this.btnTabMy.BackColor = System.Drawing.Color.LightYellow;
            this.btnTabMy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabMy.Location = new System.Drawing.Point(141, 86);
            this.btnTabMy.Margin = new System.Windows.Forms.Padding(4);
            this.btnTabMy.Name = "btnTabMy";
            this.btnTabMy.Size = new System.Drawing.Size(160, 37);
            this.btnTabMy.TabIndex = 2;
            this.btnTabMy.Text = "Tôi đóng góp";
            this.btnTabMy.UseVisualStyleBackColor = false;
            this.btnTabMy.Click += new System.EventHandler(this.btnTabMy_Click);
            // 
            // btnRandom
            // 
            this.btnRandom.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnRandom.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnRandom.Location = new System.Drawing.Point(600, 25);
            this.btnRandom.Margin = new System.Windows.Forms.Padding(4);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(200, 62);
            this.btnRandom.TabIndex = 3;
            this.btnRandom.Text = "Ăn gì giờ?";
            this.btnRandom.UseVisualStyleBackColor = false;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.btnAdd.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Location = new System.Drawing.Point(827, 25);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(200, 62);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Thêm món ăn";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // flpContent
            // 
            this.flpContent.AutoScroll = true;
            this.flpContent.BackColor = System.Drawing.Color.Gainsboro;
            this.flpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpContent.Location = new System.Drawing.Point(0, 123);
            this.flpContent.Margin = new System.Windows.Forms.Padding(4);
            this.flpContent.Name = "flpContent";
            this.flpContent.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.flpContent.Size = new System.Drawing.Size(1067, 615);
            this.flpContent.TabIndex = 1;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelTop.Controls.Add(this.btnAdd);
            this.panelTop.Controls.Add(this.btnRandom);
            this.panelTop.Controls.Add(this.btnTabMy);
            this.panelTop.Controls.Add(this.btnTabAll);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1067, 123);
            this.panelTop.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 738);
            this.Controls.Add(this.flpContent);
            this.Controls.Add(this.panelTop);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hôm nay ăn gì?";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnTabAll;
        private System.Windows.Forms.Button btnTabMy;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.FlowLayoutPanel flpContent;
    }
}