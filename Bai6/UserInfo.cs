using System;
using System.Windows.Forms;

namespace Bai6
{
    public partial class UserInfo : Form
    {
        public UserInfo()
        {
            InitializeComponent();
        }

        private async void btnGetInfo_Click(object sender, EventArgs e)
        {
            string type = txtTokenType.Text.Trim();
            string token = txtAccessToken.Text.Trim();

            if (type == "" || token == "")
            {
                MessageBox.Show("Vui lòng nhập Token Type và Access Token!");
                return;
            }

            try
            {
                var api = new UserApiService();
                var user = await api.GetUserAsync(type, token);

                txtUsername.Text = user.Username;
                txtFullname.Text = user.Fullname;
                txtEmail.Text = user.Email;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi API: " + ex.Message);
            }
        }
    }
}
