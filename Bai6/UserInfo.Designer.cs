namespace Bai6
{
    partial class UserInfo
    {
        private System.ComponentModel.IContainer components = null;

        private Guna.UI2.WinForms.Guna2Panel panel;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;

        private Guna.UI2.WinForms.Guna2TextBox txtTokenType;
        private Guna.UI2.WinForms.Guna2TextBox txtAccessToken;
        private Guna.UI2.WinForms.Guna2Button btnGetInfo;

        private Guna.UI2.WinForms.Guna2HtmlLabel lblUser;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private Guna.UI2.WinForms.Guna2TextBox txtFullname;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();

            this.txtTokenType = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtAccessToken = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnGetInfo = new Guna.UI2.WinForms.Guna2Button();

            this.lblUser = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtFullname = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();

            this.SuspendLayout();

            // Panel
            this.panel.BorderRadius = 15;
            this.panel.FillColor = System.Drawing.Color.WhiteSmoke;
            this.panel.Size = new System.Drawing.Size(520, 540);
            this.panel.Location = new System.Drawing.Point(40, 25);

            // Title
            this.lblTitle.Text = "Bài 6 - Get User Info";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(150, 20);

            // Token Type
            this.txtTokenType.PlaceholderText = "Token Type (VD: Bearer)";
            this.txtTokenType.BorderRadius = 8;
            this.txtTokenType.Location = new System.Drawing.Point(40, 80);
            this.txtTokenType.Size = new System.Drawing.Size(430, 40);

            // Access Token
            this.txtAccessToken.PlaceholderText = "Access Token";
            this.txtAccessToken.BorderRadius = 8;
            this.txtAccessToken.Location = new System.Drawing.Point(40, 130);
            this.txtAccessToken.Size = new System.Drawing.Size(430, 40);

            // Button
            this.btnGetInfo.Text = "Lấy Thông Tin";
            this.btnGetInfo.BorderRadius = 10;
            this.btnGetInfo.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnGetInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGetInfo.Location = new System.Drawing.Point(170, 190);
            this.btnGetInfo.Size = new System.Drawing.Size(170, 45);
            this.btnGetInfo.Click += new System.EventHandler(this.btnGetInfo_Click);

            // Label
            this.lblUser.Text = "Thông tin người dùng:";
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUser.Location = new System.Drawing.Point(40, 260);

            // Username
            this.txtUsername.PlaceholderText = "Username";
            this.txtUsername.BorderRadius = 8;
            this.txtUsername.Location = new System.Drawing.Point(40, 290);
            this.txtUsername.Size = new System.Drawing.Size(430, 40);

            // Fullname
            this.txtFullname.PlaceholderText = "Fullname";
            this.txtFullname.BorderRadius = 8;
            this.txtFullname.Location = new System.Drawing.Point(40, 340);
            this.txtFullname.Size = new System.Drawing.Size(430, 40);

            // Email
            this.txtEmail.PlaceholderText = "Email";
            this.txtEmail.BorderRadius = 8;
            this.txtEmail.Location = new System.Drawing.Point(40, 390);
            this.txtEmail.Size = new System.Drawing.Size(430, 40);

            // Add controls
            this.panel.Controls.Add(lblTitle);
            this.panel.Controls.Add(txtTokenType);
            this.panel.Controls.Add(txtAccessToken);
            this.panel.Controls.Add(btnGetInfo);
            this.panel.Controls.Add(lblUser);
            this.panel.Controls.Add(txtUsername);
            this.panel.Controls.Add(txtFullname);
            this.panel.Controls.Add(txtEmail);

            this.Controls.Add(panel);

            // Form
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Text = "User Info";
            this.ResumeLayout(false);
        }
    }
}
