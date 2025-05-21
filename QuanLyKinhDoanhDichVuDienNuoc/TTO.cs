using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKinhDoanhDichVuDienNuoc
{
    public partial class TTO : UserControl
    {
        public string MaHoaDon { get; set; }  // ✅ Dùng để nhận mã hóa đơn từ ngoài
        public int CurrentUserID { get; set; }
        public TTO()
        {
            InitializeComponent();
            
            
        }

        private void TTO_Load(object sender, EventArgs e)
        {
            cbPhuongThuc.Items.AddRange(new string[] {
                "Thẻ ngân hàng",
                "Ví điện tử",
                "Chuyển khoản ngân hàng"
            });
            cbPhuongThuc.SelectedIndex = 0; // Mặc định
             
        }

        private void cbPhuongThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelNoiDung.Controls.Clear();
            string selected = cbPhuongThuc.SelectedItem.ToString();

            if (selected == "Thẻ ngân hàng")
            {
                AddTextBox("Số thẻ:");
                AddTextBox("Tên chủ thẻ:");
                AddTextBox("Ngày hết hạn:");
                AddTextBox("CVV:");
            }
            else if (selected == "Ví điện tử")
            {
                AddTextBox("Số điện thoại ví:");
                AddTextBox("Mã OTP:");
            }
            else if (selected == "Chuyển khoản ngân hàng")
            {
                AddTextBox("Ngân hàng:");
                AddTextBox("Tên người chuyển:");
                AddTextBox("Mã giao dịch:");
            }
        }
        private void AddTextBox(string label)
        {
            int count = panelNoiDung.Controls.Count / 2;
            Label lbl = new Label()
            {
                Text = label,
                Location = new System.Drawing.Point(10, 10 + count * 40),
                AutoSize = true
            };
            TextBox txt = new TextBox()
            {
                Name = "txt" + count,
                Location = new System.Drawing.Point(150, 10 + count * 40),
                Width = 200
            };
            panelNoiDung.Controls.Add(lbl);
            panelNoiDung.Controls.Add(txt);
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // Kiểm tra đầy đủ thông tin
            foreach (Control c in panelNoiDung.Controls)
            {
                if (c is TextBox && string.IsNullOrWhiteSpace(c.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string maHoaDon = MaHoaDon?.Trim();
            bool success = CapNhatTrangThaiThanhToan(maHoaDon, CurrentUserID);


            if (success)
            {
                MessageBox.Show("Thanh toán thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tìm control cha là userMain thay vì ép kiểu từ FindForm
                Control parent = this.Parent;
                while (parent != null && !(parent is userMain))
                {
                    parent = parent.Parent;
                }

                if (parent is userMain frmMain)
                {
                    TTHĐ tTHĐ = new TTHĐ();
                    frmMain.LoadUserControl(tTHĐ);
                }
            }
            else
            {
                MessageBox.Show("Cập nhật trạng thái thanh toán thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private bool CapNhatTrangThaiThanhToan(string maHoaDon, int userID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DB.connectionString))
                {
                    conn.Open();

                    string queryDien = @"
    UPDATE HoaDonDien 
    SET TrangThaiThanhToan = 1, NgayThanhToan = @ngayThanhToan, UserID = @userID
    WHERE MaHoaDon = @maHoaDon AND (UserID IS NULL OR UserID = 0)";

                    string queryNuoc = @"
    UPDATE HoaDonNuoc 
    SET TrangThaiThanhToan = 1, NgayThanhToan = @ngayThanhToan, UserID = @userID
    WHERE MaHoaDon = @maHoaDon AND (UserID IS NULL OR UserID = 0)";

                    DateTime now = DateTime.Now;

                    // Cập nhật bảng Hóa Đơn Điện
                    using (SqlCommand cmd = new SqlCommand(queryDien, conn))
                    {
                        cmd.Parameters.AddWithValue("@ngayThanhToan", now);
                        cmd.Parameters.AddWithValue("@maHoaDon", maHoaDon);
                        cmd.Parameters.AddWithValue("@userID", userID);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0) return true;
                    }

                    // Cập nhật bảng Hóa Đơn Nước
                    using (SqlCommand cmd = new SqlCommand(queryNuoc, conn))
                    {
                        cmd.Parameters.AddWithValue("@ngayThanhToan", now);
                        cmd.Parameters.AddWithValue("@maHoaDon", maHoaDon);
                        cmd.Parameters.AddWithValue("@userID", userID);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0) return true;
                    }

                    MessageBox.Show("Không tìm thấy mã hóa đơn trong cả hai bảng!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thanh toán: " + ex.Message);
            }

            return false;
        }



    }
}
