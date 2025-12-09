using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Bai_Test
{
    public partial class Sever : Form
    {
        private int orderCount = 0;
        private TcpListener listener;
        private bool isServerRunning = false;
        private Dictionary<string, decimal> dishPrices;
        private Dictionary<int, string> orderDetails = new Dictionary<int, string>();
        private Dictionary<string, NetworkStream> clientStreams = new Dictionary<string, NetworkStream>();

        public Sever()
        {
            InitializeComponent();
            InitializeDishPrices();
        }

        void InitializeDishPrices()
        {
            dishPrices = new Dictionary<string, decimal>
            {
                { "Phở", 50000 },
                { "Bánh mì", 25000 },
                { "Cơm tấm", 40000 },
                { "Bún chả", 45000 },
                { "Mì Hoành Thánh", 35000 },
                { "Cơm gà", 38000 },
                { "Canh cua", 30000 }
            };
        }

        private void btnStartSever_Click(object sender, EventArgs e)
        {
            if (!isServerRunning)
            {
                CheckForIllegalCrossThreadCalls = false;
                Thread serverThread = new Thread(new ThreadStart(StartServer));
                serverThread.IsBackground = true;
                serverThread.Start();
            }
            else
            {
                MessageBox.Show("Server đã được khởi động rồi!");
            }
        }

        void StartServer()
        {
            int port = 8080;
            try
            {
                listener = new TcpListener(IPAddress.Any, port);
                listener.Start();
                isServerRunning = true;

                LogMessage($"Server khởi động thành công! Listening on port {port}");
                label1.Text = $"Listening on port {port}";
                label1.ForeColor = System.Drawing.Color.Green;

                while (isServerRunning)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    LogMessage($"Client kết nối từ {client.Client.RemoteEndPoint}");

                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClient));
                    clientThread.IsBackground = true;
                    clientThread.Start(client);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Server: " + ex.Message);
                isServerRunning = false;
            }
        }

        void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            string clientId = client.Client.RemoteEndPoint.ToString();
            try
            {
                NetworkStream stream = client.GetStream();
                clientStreams[clientId] = stream;

                // Gửi menu đến client
                SendMenuToClient(stream);

                // Nhận đơn hàng từ client
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string orderText = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    LogMessage($"Nhận đơn hàng từ {clientId}: {orderText}");
                    DisplayOrderInDataGridView(orderText, clientId);
             
                }

                if (clientStreams.ContainsKey(clientId))
                {
                    clientStreams.Remove(clientId);
                }
                client.Close();
            }
            catch (Exception ex)
            {
                LogMessage($"Lỗi xử lý client: {ex.Message}");
                if (clientStreams.ContainsKey(clientId))
                {
                    clientStreams.Remove(clientId);
                }
            }
        }

        void SendMenuToClient(NetworkStream stream)
        {
            string menu = "===== DANH SÁCH MÓN ĂN =====\n" +
                         "STT | Tên Món | Giá (VNĐ)\n" +
                         "===========================\n" +
                         "1 | Phở | 50000\n" +
                         "2 | Bánh mì | 25000\n" +
                         "3 | Cơm tấm | 40000\n" +
                         "4 | Bún chả | 45000\n" +
                         "5 | Mì Hoành Thánh | 35000\n" +
                         "6 | Cơm gà | 38000\n" +
                         "7 | Canh cua | 30000\n" +
                         "===========================\n";

            byte[] menuBytes = Encoding.UTF8.GetBytes(menu);
            stream.Write(menuBytes, 0, menuBytes.Length);
            LogMessage("Menu đã được gửi đến client");
        }

       

        void DisplayOrderInDataGridView(string orderText, string clientId)
        {
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke(new Action<string, string>(DisplayOrderInDataGridView), orderText, clientId);
            }
            else
            {
                // Tạo cột nếu chưa có
                if (dataGridView1.Columns.Count == 0)
                {
                    dataGridView1.Columns.Add("OrderID", "Mã Đơn");
                    dataGridView1.Columns.Add("TableNumber", "Số Bàn");
                    dataGridView1.Columns.Add("Dishes", "Danh Sách Món");
                    dataGridView1.Columns.Add("Status", "Trạng Thái");
                    dataGridView1.Columns.Add("OrderTime", "Thời Gian");
                    dataGridView1.Columns.Add("ClientID", "Client ID");

                    dataGridView1.Columns[0].Width = 80;
                    dataGridView1.Columns[1].Width = 80;
                    dataGridView1.Columns[2].Width = 300;
                    dataGridView1.Columns[3].Width = 100;
                    dataGridView1.Columns[4].Width = 130;
                    dataGridView1.Columns[5].Visible = false;
                }

                // Parse order: "Bàn X: Món1, Món2, ..."
                string[] parts = orderText.Split(':');
                if (parts.Length >= 2)
                {
                    string tableInfo = parts[0].Trim();
                    string dishInfo = string.Join(":", parts, 1, parts.Length - 1).Trim();

                    string orderId = $"ĐH{orderCount.ToString("D3")}";
                    string status = "Chưa thanh toán";
                    string orderTime = DateTime.Now.ToString("HH:mm:ss");

                    dataGridView1.Rows.Add(orderId, tableInfo, dishInfo, status, orderTime, clientId);
                }
            }
        }

        

        void SendInvoiceToClient(string clientId, string invoiceContent)
        {
            try
            {
                if (clientStreams.ContainsKey(clientId) && clientStreams[clientId] != null && clientStreams[clientId].CanWrite)
                {
                    byte[] invoiceBytes = Encoding.UTF8.GetBytes(invoiceContent);
                    clientStreams[clientId].Write(invoiceBytes, 0, invoiceBytes.Length);
                    clientStreams[clientId].Flush();
                    LogMessage($"Hoá đơn đã được gửi đến client {clientId}");
                }
                else
                {
                    LogMessage($"Không thể gửi hoá đơn đến client {clientId} - Client không kết nối");
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Lỗi gửi hoá đơn: {ex.Message}");
            }
        }



        void ExportInvoiceToFile(string orderId, string invoiceContent)
        {
            try
            {
                string fileName = $"HoaDon_{orderId}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);

                File.WriteAllText(filePath, invoiceContent, Encoding.UTF8);

                MessageBox.Show($"Hoá đơn đã được xuất tại:\n{filePath}", "Xuất hoá đơn thành công");
                LogMessage($"Hoá đơn {orderId} đã được xuất tại {filePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất hoá đơn: " + ex.Message);
                LogMessage($"Lỗi xuất hoá đơn: {ex.Message}");
            }
        }

        void LogMessage(string msg)
        {
            if (listView1.InvokeRequired)
            {
                listView1.Invoke(new Action<string>(LogMessage), msg);
            }
            else
            {
                listView1.Items.Add($"[{DateTime.Now:HH:mm:ss}] {msg}");
                listView1.EnsureVisible(listView1.Items.Count - 1);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThanhToan_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng!");
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            string orderId = selectedRow.Cells["OrderID"].Value?.ToString() ?? "";
            string tableNumber = selectedRow.Cells["TableNumber"].Value?.ToString() ?? "";
            string dishInfo = selectedRow.Cells["Dishes"].Value?.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(orderId))
            {
                MessageBox.Show("Không thể lấy mã đơn!");
                return;
            }

            decimal totalAmount = 0;
            string dishDetails = "";

            if (!string.IsNullOrWhiteSpace(dishInfo))
            {
                string[] dishes = dishInfo.Split(',');
                foreach (string dish in dishes)
                {
                    string dishName = dish.Trim();
                    if (dishPrices.ContainsKey(dishName))
                    {
                        decimal price = dishPrices[dishName];
                        dishDetails += $"  {dishName} ................... {price:N0} VNĐ\n";
                        totalAmount += price;
                    }
                }
            }

            string invoice = $"=====================================\n" +
                           $"       HÓA ĐƠN THANH TOÁN\n" +
                           $"=====================================\n" +
                           $"Mã Đơn: {orderId}\n" +
                           $"{tableNumber}\n" +
                           $"Thời Gian: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n" +
                           $"=====================================\n" +
                           $"CHI TIẾT ĐƠN HÀNG:\n" +
                           dishDetails +
                           $"=====================================\n" +
                           $"TỔNG CỘNG: {totalAmount:N0} VNĐ\n" +
                           $"=====================================\n" +
                           $"Cảm ơn bạn đã sử dụng dịch vụ!\n" +
                           $"=====================================\n";

            ExportInvoiceToFile(orderId, invoice);
        }
    }
}