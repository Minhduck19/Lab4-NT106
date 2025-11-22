using HtmlAgilityPack;
using Microsoft.Web.WebView2.Core;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Bai3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                await webView.EnsureCoreWebView2Async(null);
                txtUrl.Text = "https://www.bing.com";
                webView.CoreWebView2.Navigate(txtUrl.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo WebView2: " + ex.Message);
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text.Trim();
            if (string.IsNullOrEmpty(url)) return;
            if (!url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
                !url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                url = "https://" + url;
            }

            try
            {
                webView.CoreWebView2.Navigate(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể điều hướng: " + ex.Message);
            }
        }

        private async void btnDownloadHtml_Click(object sender, EventArgs e)
        {
            try
            {
                string raw = await webView.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML;");
                string html = UnwrapJsResult(raw);

                using (SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "HTML File|*.html",
                    FileName = "page.html"
                })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(sfd.FileName, html);
                        MessageBox.Show("Đã lưu HTML tại: " + sfd.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải HTML: " + ex.Message);
            }
        }

        private async void btnDownloadImages_Click(object sender, EventArgs e)
        {
            try
            {
                string raw = await webView.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML;");
                string html = UnwrapJsResult(raw);

                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                var imgNodes = doc.DocumentNode.SelectNodes("//img");
                if (imgNodes == null || imgNodes.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy ảnh trên trang.");
                    return;
                }

                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    fbd.Description = "Chọn thư mục để lưu ảnh";
                    if (fbd.ShowDialog() != DialogResult.OK) return;

                    int downloaded = 0;
                    foreach (var img in imgNodes)
                    {
                        string src = img.GetAttributeValue("src", null);
                        if (string.IsNullOrWhiteSpace(src)) continue;

                        // Convert relative -> absolute
                        try
                        {
                            Uri baseUri = new Uri(webView.Source.AbsoluteUri);
                            Uri resolved = new Uri(baseUri, src);
                            string url = resolved.ToString();

                            string ext = Path.GetExtension(resolved.LocalPath);
                            if (string.IsNullOrEmpty(ext)) ext = ".jpg";

                            string fname = Path.Combine(fbd.SelectedPath, $"img_{downloaded}{ext}");

                            using (WebClient wc = new WebClient())
                            {
                                wc.DownloadFile(url, fname);
                            }

                            downloaded++;
                        }
                        catch
                        {

                        }
                    }

                    MessageBox.Show($"Hoàn tất. Số ảnh tải về: {downloaded}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message);
            }
        }

        private async void btnViewSource_Click(object sender, EventArgs e)
        {
            try
            {
                string raw = await webView.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML;");
                string html = UnwrapJsResult(raw);

                var frm = new FormSource(html);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy source: " + ex.Message);
            }
        }

        /// <summary>
        /// ExecuteScriptAsync returns a JSON-style quoted string. This helper unwraps it.
        /// It's simple and handles common escape sequences.
        /// </summary>
        private string UnwrapJsResult(string jsResult)
        {
            if (string.IsNullOrEmpty(jsResult)) return string.Empty;

            // If it starts and ends with quotes, remove them
            if (jsResult.Length >= 2 && jsResult[0] == '"' && jsResult[jsResult.Length - 1] == '"')
            {
                string s = jsResult.Substring(1, jsResult.Length - 2);
                // Replace common escape sequences
                s = s.Replace("\\n", "\n")
                     .Replace("\\r", "\r")
                     .Replace("\\t", "\t")
                     .Replace("\\\"", "\"")
                     .Replace("\\'", "'")
                     .Replace("\\\\", "\\");
                return s;
            }

            return jsResult;
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGo.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true; 
            }
        }
    }
}
