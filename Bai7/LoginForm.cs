using Bai7;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Bai7
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var users = DataProvider.GetUsers();

            var u = users.FirstOrDefault(x => x.Username == txtUser.Text && x.Password == txtPass.Text);

            if (u != null)
            {
                DataProvider.CurrentUser = u;
                MessageBox.Show("Đăng nhập thành công!");

                this.Hide(); 

                MainForm main = new MainForm();
                main.ShowDialog();

                this.Close(); 
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            SignupForm frm = new SignupForm();
            frm.ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}