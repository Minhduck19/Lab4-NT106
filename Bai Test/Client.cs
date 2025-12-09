using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai_Test
{
    public partial class Client : Form
    {
        TcpClient client;
        NetworkStream stream;
        Thread receiveThread;
        string userName;
        public Client()
        {
            InitializeComponent();
        }

        private void btnConnectSever_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy tên người dùng
                userName = textBox1.Text;
                if (userName == "")
                {
                    MessageBox.Show("Vui lòng nhập tên người dùng!\n");
                    return;
                }

                // Kết nối đến server
                client = new TcpClient("127.0.0.1", 13000);
                stream = client.GetStream();

                // Gửi tên người dùng cho server
                byte[] data = Encoding.UTF8.GetBytes(userName);
                stream.Write(data, 0, data.Length);

                MessageBox.Show("Đã kết nối đến máy chủ.\n");

                // Tạo luồng để nhận dữ liệu
                receiveThread = new Thread(NhanDuLieu);
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message + "\n");
            }
        }
        private void btnOrder_Click(object sender, EventArgs e)
        {

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Client_Load(object sender, EventArgs e)
        {
            // Tạo DataTable
            DataTable dataTable = new DataTable();

            // Thêm các cột vào DataTable
            dataTable.Columns.Add("Ten mon", typeof(string));
            dataTable.Columns.Add("Gia tien", typeof(int));
            dataTable.Columns.Add("So luong", typeof(int));


        }
    }
}
