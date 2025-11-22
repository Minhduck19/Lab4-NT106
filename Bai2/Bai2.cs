using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai2
{
    public partial class Bai2 : Form
    {
        public Bai2()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text.Trim();
            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("Vui lòng nhập URL trang web!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                htmlBox.Text = reader.ReadToEnd();
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể lấy nội dung trang web!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Title = "Lưu file HTML",
                Filter = "File HTML (*.html)|*.html|All Files (*.*)|*.*",
                FileName = "webpage.html"
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                // Người dùng bấm Cancel
                return;
            }

            string savePath = saveFileDialog.FileName;

            

            if (string.IsNullOrWhiteSpace(savePath))
            {
                MessageBox.Show("Vui lòng nhập đường dẫn lưu file!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            txtSave.Text = savePath;
            try
            {
                using (WebClient client = new WebClient())
                {
                    // Tải file về với tên do người dùng chọn
                    client.DownloadFile(url, savePath);
                }

                MessageBox.Show("Tải file thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải file:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
