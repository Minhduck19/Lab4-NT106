using System;
using System.IO; 
using System.Net; 
using System.Windows.Forms;

namespace Bai1
{
    public partial class Formm : System.Windows.Forms.Form
    {
        public Formm()
        {
            InitializeComponent();
        }

        private void btnGetHtml_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text.Trim();

            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Vui lòng nhập URL");
                return;
            }

            if (!url.StartsWith("http")) url = "http://" + url;

            try
            {
                rtbHtml.Text = "Đang tải dữ liệu...";
                Application.DoEvents(); 
                string html = getHTML(url);
                rtbHtml.Text = html;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                rtbHtml.Text = "";
            }
        }
        private string getHTML(string szURL)
        {
            WebRequest request = WebRequest.Create(szURL);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }

        private void rtbHtml_TextChanged(object sender, EventArgs e)
        {

        }
    }
}