using Bai7;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO; 
using System.Linq;
using System.Windows.Forms;

namespace Bai7
{
    public partial class MainForm : Form
    {
        private bool isShowAll = true; 
        public MainForm()
        {
            InitializeComponent();
            LoadFoodList(); 
        }

     
        private void LoadFoodList()
        {
            flpContent.Controls.Clear();
            var allFoods = DataProvider.GetFoods();
            List<Food> displayList;

            if (isShowAll)
            {
                displayList = allFoods;
                btnTabAll.BackColor = Color.White;
                btnTabMy.BackColor = Color.Gainsboro;
            }
            else
            {
                displayList = allFoods.Where(x => x.CreatedBy == DataProvider.CurrentUser.Username).ToList();
                btnTabAll.BackColor = Color.Gainsboro;
                btnTabMy.BackColor = Color.White;
            }

            foreach (var item in displayList)
            {
                flpContent.Controls.Add(CreateFoodItem(item));
            }
        }

        private Panel CreateFoodItem(Food f)
        {
            Panel p = new Panel();
            p.Size = new Size(750, 150); 
            p.BorderStyle = BorderStyle.FixedSingle;
            p.Margin = new Padding(0, 0, 0, 10);
            p.BackColor = Color.White;

            PictureBox pb = new PictureBox();
            pb.Size = new Size(140, 140);
            pb.Location = new Point(5, 5);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;

            if (!string.IsNullOrEmpty(f.ImageUrl) && File.Exists(f.ImageUrl))
            {
                pb.Image = Image.FromFile(f.ImageUrl);
            }
            else
            {
                pb.BackColor = Color.LightGray;
            }

            Label lblName = new Label();
            lblName.Text = f.Name;
            lblName.Font = new Font("Arial", 14, FontStyle.Bold);
            lblName.Location = new Point(160, 10);
            lblName.AutoSize = true;

            Label lblPrice = new Label();
            lblPrice.Text = "Giá: " + f.Price + " VND";
            lblPrice.Font = new Font("Arial", 10, FontStyle.Regular);
            lblPrice.Location = new Point(160, 50);
            lblPrice.AutoSize = true;

            Label lblAddress = new Label();
            lblAddress.Text = "Địa chỉ: " + f.Address;
            lblAddress.Font = new Font("Arial", 10, FontStyle.Regular);
            lblAddress.Location = new Point(160, 80);
            lblAddress.AutoSize = true;

            Label lblUser = new Label();
            lblUser.Text = "Đóng góp: " + f.CreatedBy;
            lblUser.ForeColor = Color.Green;
            lblUser.Location = new Point(160, 110);
            lblUser.AutoSize = true;

            p.Controls.Add(pb);
            p.Controls.Add(lblName);
            p.Controls.Add(lblPrice);
            p.Controls.Add(lblAddress);
            p.Controls.Add(lblUser);

            return p;
        }


        private void btnTabAll_Click(object sender, EventArgs e)
        {
            isShowAll = true;
            LoadFoodList();
        }

        private void btnTabMy_Click(object sender, EventArgs e)
        {
            isShowAll = false;
            LoadFoodList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ThemMonAn frm = new ThemMonAn();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadFoodList(); 
            }
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            var list = DataProvider.GetFoods();
            if (!isShowAll)
            {
                list = list.Where(x => x.CreatedBy == DataProvider.CurrentUser.Username).ToList();
            }
            if (list.Count > 0)
            {
                Random rnd = new Random();
                var randomFood = list[rnd.Next(list.Count)];
                string title = isShowAll ? "Gợi ý cho bạn" : "Món ngon của bạn";

                MessageBox.Show($"Hôm nay ăn món:\n\n{randomFood.Name}\nGiá: {randomFood.Price}", title);
            }
            else
            {
                if (!isShowAll)
                    MessageBox.Show("Bạn chưa đóng góp món nào nên không thể random!");
                else
                    MessageBox.Show("Chưa có dữ liệu món ăn nào!");
            }
        }
    }
}