using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Bai7
{
    public partial class ThemMonAn : Form
    {
        private string sourceImagePath = "";

        public ThemMonAn()
        {
            InitializeComponent();
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            opf.Title = "Chọn hình ảnh món ăn";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                sourceImagePath = opf.FileName;
                txtImage.Text = sourceImagePath; 
                pbPreview.ImageLocation = sourceImagePath; 
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtPrice.Clear();
            txtAddress.Clear();
            txtImage.Clear();
            txtDesc.Clear();
            pbPreview.Image = null;
            sourceImagePath = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên và Giá món ăn!");
                return;
            }

            string finalImagePath = "";

            if (!string.IsNullOrEmpty(sourceImagePath) && File.Exists(sourceImagePath))
            {
                try
                {
                    string folderPath = Path.Combine(Application.StartupPath, "Images");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(sourceImagePath);
                    string destPath = Path.Combine(folderPath, fileName);

                    File.Copy(sourceImagePath, destPath, true);
                    finalImagePath = destPath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu ảnh: " + ex.Message);
                    return;
                }
            }

            Food newFood = new Food
            {
                Name = txtName.Text,
                Price = txtPrice.Text,
                Address = txtAddress.Text,
                ImageUrl = finalImagePath, 
                Description = txtDesc.Text,
                CreatedBy = DataProvider.CurrentUser.Username
            };

            DataProvider.AddFood(newFood);

            MessageBox.Show("Thêm món thành công!");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ThemMonAn_Load(object sender, EventArgs e)
        {

        }
    }
}