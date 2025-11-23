using System;
using System.Linq;
using System.Windows.Forms;

namespace Bai7
{
    public partial class SignupForm : Form
    {
        public SignupForm()
        {
            InitializeComponent();
            cboLang.SelectedIndex = 0; 
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUser.Clear(); txtPass.Clear(); txtEmail.Clear();
            txtFirst.Clear(); txtLast.Clear(); txtPhone.Clear();
            dtpBirth.Value = DateTime.Now;
            cboLang.SelectedIndex = 0;
            rdoMale.Checked = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Vui lòng nhập Username và Password!");
                return;
            }

            var users = DataProvider.GetUsers();
            if (users.Any(u => u.Username == txtUser.Text))
            {
                MessageBox.Show("Username này đã có người dùng!");
                return;
            }
            User newUser = new User
            {
                Username = txtUser.Text,
                Password = txtPass.Text,
                Email = txtEmail.Text,
                FirstName = txtFirst.Text,
                LastName = txtLast.Text,
                Phone = txtPhone.Text,
                Birthday = dtpBirth.Value,
                Language = cboLang.Text,
                Sex = rdoMale.Checked ? "Male" : "Female"
            };

            DataProvider.SaveUser(newUser);
            MessageBox.Show("Đăng ký thành công!");
            this.Close();
        }

        private void grpInfo_Enter(object sender, EventArgs e)
        {

        }
    }
}