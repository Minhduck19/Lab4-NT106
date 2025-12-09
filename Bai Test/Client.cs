using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Bai_Test
{
    public partial class Client : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private bool isConnected = false;
        private bool isReceiving = false;

        public Client()
        {
            InitializeComponent();
        }

        private void btnConnectSever_Click_1(object sender, EventArgs e)
        {
            if (stream == null)
            {
                try
                {
                    client = new TcpClient();
                    client.Connect("127.0.0.1", 8080);
                    stream = client.GetStream();
                    isConnected = true;
                    isReceiving = true;

                    TrangThai.Text = "Đã kết nối thành công!";
                    TrangThai.ForeColor = System.Drawing.Color.Green;
                    MessageBox.Show("Đã kết nối tới Server thành công!");

                    // Nhận menu từ server
                    Thread receiveMenuThread = new Thread(new ThreadStart(ReceiveMenu));
                    receiveMenuThread.IsBackground = true;
                    receiveMenuThread.Start();

                    // Bắt đầu nhận dữ liệu từ server
                    Thread receiveMessagesThread = new Thread(new ThreadStart(ReceiveMessagesFromServer));
                    receiveMessagesThread.IsBackground = true;
                    receiveMessagesThread.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                    isConnected = false;
                    isReceiving = false;
                }
            }
            else
            {
                MessageBox.Show("Đã kết nối rồi!");
            }
        }

        void ReceiveMenu()
        {
            try
            {
                byte[] buffer = new byte[4096];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                if (bytesRead > 0)
                {
                    string menuText = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    if (InvokeRequired)
                    {
                        Invoke(new Action<string>(DisplayMenuInDataGridView), menuText);
                    }
                    else
                    {
                        DisplayMenuInDataGridView(menuText);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhận menu: " + ex.Message);
            }
        }

        void DisplayMenuInDataGridView(string menuText)
        {
            // Xóa dữ liệu cũ
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // Tạo các cột
            dataGridView1.Columns.Add("STT", "STT");
            dataGridView1.Columns.Add("MonAn", "Món Ăn");
            dataGridView1.Columns.Add("Gia", "Giá (VNĐ)");

            // Tạo checkbox column
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.HeaderText = "Chọn";
            checkColumn.Name = "Chon";
            dataGridView1.Columns.Add(checkColumn);

            // Dữ liệu menu
            string[] menuItems = new string[]
            {
                "1|Phở|50,000",
                "2|Bánh mì|25,000",
                "3|Cơm tấm|40,000",
                "4|Bún chả|45,000",
                "5|Mì Hoành Thánh|35,000",
                "6|Cơm gà|38,000",
                "7|Canh cua|30,000"
            };

            // Thêm dữ liệu vào DataGridView
            foreach (string item in menuItems)
            {
                string[] parts = item.Split('|');
                dataGridView1.Rows.Add(parts[0], parts[1], parts[2], false);
            }

            // Điều chỉnh độ rộng cột
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 60;

            MessageBox.Show("Menu đã được tải thành công!");
        }

        void ReceiveMessagesFromServer()
        {
            try
            {
                byte[] buffer = new byte[4096];
                int bytesRead;

                while (isReceiving && stream != null && stream.CanRead)
                {
                    try
                    {
                        bytesRead = stream.Read(buffer, 0, buffer.Length);
                        if (bytesRead > 0)
                        {
                            string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                            if (InvokeRequired)
                            {
                                Invoke(new Action<string>(DisplayMessageFromServer), message);
                            }
                            else
                            {
                                DisplayMessageFromServer(message);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (IOException)
                    {
                        // Connection closed
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                if (isReceiving)
                {
                    MessageBox.Show("Lỗi nhận dữ liệu từ server: " + ex.Message);
                }
            }
        }

        void DisplayMessageFromServer(string message)
        {
            MessageBox.Show($"Từ Server: {message}");
        }

        private void btnOrder_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (client == null || !client.Connected)
                {
                    MessageBox.Show("Chưa kết nối Server!");
                    return;
                }

                // Lấy số bàn
                string tableNumber = textBox1.Text.Trim();
                if (string.IsNullOrWhiteSpace(tableNumber))
                {
                    MessageBox.Show("Vui lòng nhập số bàn!");
                    return;
                }

                // Lấy danh sách các món được chọn
                string selectedDishes = GetSelectedDishes();
                if (string.IsNullOrWhiteSpace(selectedDishes))
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một món ăn!");
                    return;
                }

                // Tạo tin nhắn đơn hàng: "Bàn X: Món1, Món2, ..."
                string orderMessage = $"Bàn {tableNumber}: {selectedDishes}";

                MessageBox.Show($"Gửi: {orderMessage}");

                // Gửi đến server
                byte[] data = Encoding.UTF8.GetBytes(orderMessage);
                stream.Write(data, 0, data.Length);
                stream.Flush(); // Đảm bảo dữ liệu được gửi ngay lập tức

                MessageBox.Show("Đã gửi đơn hàng thành công!");
                textBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi đơn hàng: " + ex.Message);
            }
        }

        string GetSelectedDishes()
        {
            string selectedDishes = "";

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                object chonValue = row.Cells["Chon"].Value;
                object monAnValue = row.Cells["MonAn"].Value;

                if (chonValue != null && (bool)chonValue && monAnValue != null)
                {
                    string dishName = monAnValue.ToString();
                    if (selectedDishes.Length > 0)
                    {
                        selectedDishes += ", ";
                    }
                    selectedDishes += dishName;
                }
            }

            return selectedDishes;
        }

        private void btnQuit_Click_1(object sender, EventArgs e)
        {
            if (client != null && client.Connected)
            {
                isReceiving = false;
                Thread.Sleep(500); // Đợi thread receive kết thúc

                try
                {
                    client.Close();
                    stream = null;
                }
                catch { }

                isConnected = false;
                TrangThai.Text = "Đã ngắt kết nối";
                TrangThai.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show("Đã ngắt kết nối.");
            }
            else
            {
                MessageBox.Show("Chưa kết nối mà ngắt!");
            }
        }
    }
}