using System.Windows.Forms;

namespace Bai3
{
    public partial class FormSource : Form
    {
        public FormSource(string html)
        {
            InitializeComponent();
            richTextBoxSource.Text = html;
            richTextBoxSource.Select(0, 0);
        }
    }
}
