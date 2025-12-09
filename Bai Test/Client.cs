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
                userName = textBox1.Text.Trim();
                if (userName == "")
                {
                    MessageBox.Show("Vui lòng nhập tên người dùng!\n");
                    return;
                }

                // Kết nối đến server
                client = new TcpClient("127.0.0.1", 13000);
                stream = client.GetStream();

                // Gửi tên người dùng
                byte[] data = Encoding.UTF8.GetBytes("[USER]" + userName);
                stream.Write(data, 0, data.Length);

                MessageBox.Show("Đã kết nối đến máy chủ.\n");

                // Bắt đầu thread nhận dữ liệu
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
            try
            {
                if (stream == null)
                {
                    MessageBox.Show("Chưa kết nối server!");
                    return;
                }

                // Kiểm tra có chọn dòng chưa
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Hãy chọn một món ăn trong bảng!");
                    return;
                }

                // Lấy dữ liệu từ dòng được chọn
                string tenMon = dataGridView1.SelectedRows[0].Cells["Ten mon"].Value.ToString();
                int giaTien = (int)dataGridView1.SelectedRows[0].Cells["Gia tien"].Value;
                int soLuong = (int)dataGridView1.SelectedRows[0].Cells["So luong"].Value;

                // Gửi order
                string sendMessage = $"[ORDER]{userName}|{tenMon}|{giaTien}|{soLuong}";
                byte[] data = Encoding.UTF8.GetBytes(sendMessage);

                stream.Write(data, 0, data.Length);

                MessageBox.Show("Đã gửi đơn hàng!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi đơn hàng: " + ex.Message);
            }
        }

        private void Client_Load(object sender, EventArgs e)
        {
            // Tạo bảng món ăn
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Ten mon", typeof(string));
            dataTable.Columns.Add("Gia tien", typeof(int));
            dataTable.Columns.Add("So luong", typeof(int));

            // Add menu mẫu
            dataTable.Rows.Add("Phở bò", 30000, 1);
            dataTable.Rows.Add("Bánh mì", 15000, 1);
            dataTable.Rows.Add("Cà phê sữa", 20000, 1);
            dataTable.Rows.Add("Trà đào", 25000, 1);

            dataGridView1.DataSource = dataTable;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
