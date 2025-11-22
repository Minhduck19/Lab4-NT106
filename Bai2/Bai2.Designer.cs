namespace Bai2
{
    partial class Bai2
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
            this.components = new System.ComponentModel.Container();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtUrl = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSave = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.htmlBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.lblTitle);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.Color.RoyalBlue;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(950, 70);
            this.guna2Panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Transparent;
            this.lblTitle.Location = new System.Drawing.Point(21, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(157, 39);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Bài 2";
            // 
            // txtUrl
            // 
            this.txtUrl.BorderRadius = 8;
            this.txtUrl.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUrl.DefaultText = "";
            this.txtUrl.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUrl.Location = new System.Drawing.Point(27, 92);
            this.txtUrl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.PlaceholderText = "Nhập URL trang web...";
            this.txtUrl.SelectedText = "";
            this.txtUrl.Size = new System.Drawing.Size(759, 50);
            this.txtUrl.TabIndex = 1;
            // 
            // txtSave
            // 
            this.txtSave.BorderRadius = 8;
            this.txtSave.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSave.DefaultText = "";
            this.txtSave.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSave.Location = new System.Drawing.Point(27, 161);
            this.txtSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSave.Name = "txtSave";
            this.txtSave.PlaceholderText = "Đường dẫn lưu file HTML (VD: D:\\output.html)";
            this.txtSave.SelectedText = "";
            this.txtSave.Size = new System.Drawing.Size(759, 50);
            this.txtSave.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 8;
            this.btnSave.FillColor = System.Drawing.Color.SeaGreen;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(808, 92);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 50);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "SAVE";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // htmlBox
            // 
            this.htmlBox.BackColor = System.Drawing.Color.White;
            this.htmlBox.BorderRadius = 8;
            this.htmlBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.htmlBox.DefaultText = "";
            this.htmlBox.Font = new System.Drawing.Font("Consolas", 10.5F);
            this.htmlBox.Location = new System.Drawing.Point(28, 220);
            this.htmlBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.htmlBox.Multiline = true;
            this.htmlBox.Name = "htmlBox";
            this.htmlBox.PlaceholderText = "Nội dung HTML sẽ hiển thị tại đây...";
            this.htmlBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.htmlBox.SelectedText = "";
            this.htmlBox.Size = new System.Drawing.Size(910, 400);
            this.htmlBox.TabIndex = 5;
            // 
            // Bai2
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(950, 650);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.txtSave);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.htmlBox);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Bai2";
            this.Text = " ";
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lblTitle;

        private Guna.UI2.WinForms.Guna2TextBox txtUrl;
        private Guna.UI2.WinForms.Guna2TextBox txtSave;
        private Guna.UI2.WinForms.Guna2Button btnSave;

        private Guna.UI2.WinForms.Guna2TextBox htmlBox;

        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
    }
}

