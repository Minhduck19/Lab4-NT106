using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sever tmp = new Sever();
            tmp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client tmp = new Client();
            tmp.Show();
        }
    }
}
