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
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace QuanLyKinhDoanhDichVuDienNuoc
{
    public partial class LHA : UserControl
    {
        private string hotlineNumber = "0945876583";
        private string smsMessage = "Tôi muốn nhận mã Hóa đơn điện nước.";

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

        private void bt_sms_Click(object sender, EventArgs e)
        {
            // Thông tin Twilio
            const string accountSid = "ACffd1b8ce0538760ce2f84bb35d14f5b6";
            const string authToken = "62c40d58bb699db6cd58cefce1088038";
            const string twilioPhoneNumber = "+12315155561";

            var adminPhoneNumber = new PhoneNumber("+84945876583");
            var maHoaDon = "HD123456";
            var messageBody = $"Mã hóa đơn điện nước của bạn là: {maHoaDon}";
            try
            {
                TwilioClient.Init(accountSid, authToken);

                var message = MessageResource.Create(
                    to: adminPhoneNumber,
                    from: new PhoneNumber(twilioPhoneNumber),
                    body: messageBody
                );

                MessageBox.Show("Đã gửi SMS thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi SMS: {ex.Message}");
            }
        }

        private void bt_lienhe_Click(object sender, EventArgs e)
        {
            try
            {
                // Gọi điện qua ứng dụng mặc định (chỉ hoạt động nếu có ứng dụng hỗ trợ như trên thiết bị có SIM hoặc ứng dụng VOIP)
                Process.Start($"tel:{hotlineNumber}");
            }
            catch
            {
                MessageBox.Show("Không thể thực hiện cuộc gọi trên thiết bị này.");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
