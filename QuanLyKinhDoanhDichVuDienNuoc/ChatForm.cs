using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKinhDoanhDichVuDienNuoc
{
    public partial class ChatForm : Form
    {
        public ChatForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userEmail = textBox1.Text.Trim();
            string message = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(userEmail) || string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Gmail và lời nhắn.");
                return;
            }

            try
            {
                // Email người gửi (bạn)
                string fromEmail = "bahp123456789@gmail.com";
                // Mật khẩu ứng dụng từ Google
                string appPassword = "sywt pbcs wkha kaag";
                // Email admin nhận phản hồi
                string toEmail = "bahp12345678@gmail.com";
                // Chủ đề email
                string subject = "Phản hồi từ người dùng";
                // Nội dung email
                string body = $"Gmail người gửi: {userEmail}\nLời nhắn: {message}";

                // Thiết lập SMTP client
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(fromEmail, appPassword);

                // Tạo và gửi email
                MailMessage mail = new MailMessage(fromEmail, toEmail, subject, body);
                client.Send(mail);

                MessageBox.Show("Gửi phản hồi thành công!");
                textBox1.Clear();
                textBox2.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi email: {ex.Message}");
            }
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {

        }
    }
}
