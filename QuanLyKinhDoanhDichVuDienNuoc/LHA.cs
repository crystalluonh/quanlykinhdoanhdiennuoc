using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;


namespace QuanLyKinhDoanhDichVuDienNuoc
{
    public partial class LHA : UserControl
    {
        

        public LHA()
        {
            InitializeComponent();
        }

        private void LHA_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btEmail_Click(object sender, EventArgs e)
        {
            try
            {

            // Cấu hình email gửi đi
                //https://myaccount.google.com/apppasswords
                string fromEmail = "bahp123456789@gmail.com"; // Thay bằng email bạn
                string toEmail = "bahp12345678@gmail.com"; // Email người nhận
                string subject = "Mã hóa đơn điện nước";
                string body = "Mã hóa đơn của bạn là: HD123456";

                // Cấu hình SMTP client (dùng Gmail)
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(fromEmail, "sywt pbcs wkha kaag"); // Dùng mật khẩu ứng dụng

                MailMessage mail = new MailMessage(fromEmail, toEmail, subject, body);
                client.Send(mail);

                MessageBox.Show("Đã gửi email thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi email: {ex.Message}");
            }
        }
    }
}