namespace Bai5
{
    partial class Bai5
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
            this.UserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.Password = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.Answer = new Guna.UI2.WinForms.Guna2TextBox();
            this.Url = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.lblTitle.Text = "Bài 5";
            // 
            // UserName
            // 
            this.UserName.BorderRadius = 8;
            this.UserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.UserName.DefaultText = "";
            this.UserName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.UserName.Location = new System.Drawing.Point(28, 158);
            this.UserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UserName.Name = "UserName";
            this.UserName.PlaceholderText = " UserName";
            this.UserName.SelectedText = "";
            this.UserName.Size = new System.Drawing.Size(759, 50);
            this.UserName.TabIndex = 1;
            // 
            // Password
            // 
            this.Password.BorderRadius = 8;
            this.Password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Password.DefaultText = "";
            this.Password.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Password.Location = new System.Drawing.Point(28, 227);
            this.Password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Password.Name = "Password";
            this.Password.PlaceholderText = "Password";
            this.Password.SelectedText = "";
            this.Password.Size = new System.Drawing.Size(759, 50);
            this.Password.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 8;
            this.btnSave.FillColor = System.Drawing.Color.SeaGreen;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(808, 173);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 82);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "LOGIN";
            btnSave.Click += btnSave_Click;

            // 
            // Answer
            // 
            this.Answer.BackColor = System.Drawing.Color.White;
            this.Answer.BorderRadius = 8;
            this.Answer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Answer.DefaultText = "";
            this.Answer.Font = new System.Drawing.Font("Consolas", 10.5F);
            this.Answer.Location = new System.Drawing.Point(28, 297);
            this.Answer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Answer.Multiline = true;
            this.Answer.Name = "Answer";
            this.Answer.PlaceholderText = "Kết quả đăng nhập....";
            this.Answer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Answer.SelectedText = "";
            this.Answer.Size = new System.Drawing.Size(910, 323);
            this.Answer.TabIndex = 5;
            // 
            // Url
            // 
            this.Url.BorderRadius = 8;
            this.Url.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Url.DefaultText = "https://nt106.uitiot.vn/auth/token";
            this.Url.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Url.Location = new System.Drawing.Point(136, 89);
            this.Url.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Url.Name = "Url";
            this.Url.PlaceholderText = "";
            this.Url.SelectedText = "";
            this.Url.Size = new System.Drawing.Size(801, 50);
            this.Url.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 50);
            this.label1.TabIndex = 7;
            this.label1.Text = "Url:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Bai5
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(950, 650);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Url);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.Answer);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Bai5";
            this.Text = " ";
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lblTitle;

        private Guna.UI2.WinForms.Guna2TextBox UserName;
        private Guna.UI2.WinForms.Guna2TextBox Password;
        private Guna.UI2.WinForms.Guna2Button btnSave;

        private Guna.UI2.WinForms.Guna2TextBox Answer;

        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2TextBox Url;
        private System.Windows.Forms.Label label1;
    }
}

