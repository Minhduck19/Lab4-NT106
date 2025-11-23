using HtmlAgilityPack; 
using Newtonsoft.Json; 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Bai4
{
    public partial class Form1 : Form
    {
        private const string TargetUrl = "https://betacinemas.vn/phim.htm";
        private const string JsonPath = "movies.json";

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnCrawl_Click(object sender, EventArgs e)
        {
            btnCrawl.Enabled = false;
            progressBar1.Value = 0;
            flpMovies.Controls.Clear();

            try
            {
                List<Movie> movies = await CrawlMoviesAsync(TargetUrl);

                string json = JsonConvert.SerializeObject(movies, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(JsonPath, json);
                RenderUI(movies);

                MessageBox.Show($"Đã lấy thành công {movies.Count} phim.\nĐã lưu tại: {Path.GetFullPath(JsonPath)}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                btnCrawl.Enabled = true;
                progressBar1.Value = 100;
            }
        }

        private async Task<List<Movie>> CrawlMoviesAsync(string url)
        {
            var list = new List<Movie>();
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");

            progressBar1.Value = 20;
            string html = await http.GetStringAsync(url);
            progressBar1.Value = 50;

            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            var nodes = doc.DocumentNode.SelectNodes("//div[contains(@class, 'col-lg-4') or contains(@class, 'col-md-3')]");

            if (nodes == null) return list;

            int count = 0;
            int total = nodes.Count;

            foreach (var node in nodes)
            {
                var m = new Movie();
                var linkNode = node.SelectSingleNode(".//h3/a");
                if (linkNode == null) continue;

                m.Title = linkNode.InnerText.Trim();
                m.DetailUrl = "https://betacinemas.vn" + linkNode.GetAttributeValue("href", "");
                var imgNode = node.SelectSingleNode(".//img");
                if (imgNode != null)
                    m.ImageUrl = imgNode.GetAttributeValue("src", "");
                var genreNode = node.SelectSingleNode(".//ul/li");
                m.Genre = genreNode != null ? genreNode.InnerText.Trim() : "Phim chiếu rạp";

                list.Add(m);

                count++;
                int p = 50 + (int)((double)count / total * 50);
                progressBar1.Value = Math.Min(p, 90);
            }
            return list;
        }
        private void RenderUI(List<Movie> movies)
        {
            foreach (var m in movies)
            {
                Panel p = new Panel { Width = 200, Height = 350, Margin = new Padding(10), BackColor = Color.WhiteSmoke };

                PictureBox pb = new PictureBox { Width = 180, Height = 250, Location = new Point(10, 10), SizeMode = PictureBoxSizeMode.StretchImage, Cursor = Cursors.Hand };
                try { pb.LoadAsync(m.ImageUrl); } catch { }
                pb.Click += (s, ev) => System.Diagnostics.Process.Start(m.DetailUrl);
                Label lbl = new Label { Text = m.Title, Location = new Point(10, 265), Width = 180, Height = 40, Font = new Font("Arial", 9, FontStyle.Bold) };
                Button btn = new Button { Text = "Đặt vé", Location = new Point(10, 310), Width = 180, BackColor = Color.Orange, ForeColor = Color.White };
                

                p.Controls.Add(pb);
                p.Controls.Add(lbl);
                flpMovies.Controls.Add(p);
            }
        }
        
    }   
}