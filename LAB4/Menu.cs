using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB4
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Bai1.Formm f1 = new Bai1.Formm();
            f1.Show();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            Bai2.Bai2 f2 = new Bai2.Bai2();
            f2.Show();
        }
    }
}
