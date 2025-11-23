using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Bai5
{
    public partial class Bai5 : Form
    {
        public Bai5()
        {
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string apiUrl = "https://nt106.uitiot.vn/auth/token";
            string username = UserName.Text.Trim();
            string password = Password.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập username và password!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Answer.Clear();
            Answer.AppendText("Đang gửi yêu cầu đăng nhập..." + Environment.NewLine);

            try
            {
                using (var client = new HttpClient())
                {
                    var content = new MultipartFormDataContent
                    {
                        { new StringContent(username), "username" },
                        { new StringContent(password), "password" }
                    };

                    var response = await client.PostAsync(apiUrl, content);
                    string responseString = await response.Content.ReadAsStringAsync();

                    var json = JObject.Parse(responseString);

                    if (!response.IsSuccessStatusCode)
                    {
                        string detail = json["detail"]?.ToString();
                        Answer.AppendText(detail ?? "Đăng nhập thất bại.");
                        return;
                    }

                    string tokenType = json["token_type"]?.ToString();
                    string accessToken = json["access_token"]?.ToString();

                    Answer.AppendText($"{tokenType} {accessToken}" + Environment.NewLine);
                    Answer.AppendText("Đăng nhập thành công!");
                }
            }
            catch (Exception ex)
            {
                Answer.AppendText("Lỗi khi kết nối API: " + ex.Message);
            }
        }
    }
}
