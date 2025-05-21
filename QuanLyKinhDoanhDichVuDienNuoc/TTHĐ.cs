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
    public partial class TTHĐ : UserControl
    {
        public TTHĐ()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string maHD = txtMaHoaDon.Text.Trim();

            if (string.IsNullOrEmpty(maHD))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                conn.Open();
                SqlCommand cmd;
                SqlDataReader reader;
                bool found = false;

                // 1. Tìm trong bảng HoaDonDien
                string queryDien = @"
            SELECT hd.MaHoaDon, dv.TenDichVu, hd.ThoiGian, hd.TenKhachHang, hd.PhuongXa, hd.DiaChi, 
                   hd.ChiSoDien AS ChiSo, hd.TongTien, hd.TrangThaiThanhToan, hd.NgayThanhToan
            FROM HoaDonDien hd
            JOIN DichVuDien dv ON hd.MaDV = dv.MaDV
            WHERE hd.MaHoaDon = @maHD";

                cmd = new SqlCommand(queryDien, conn);
                cmd.Parameters.AddWithValue("@maHD", maHD);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    found = true;
                    string tenKH = reader["TenKhachHang"].ToString();
                    string loaiDV = reader["TenDichVu"].ToString();
                    string thoiGian = reader["ThoiGian"].ToString();
                    string chiSo = reader["ChiSo"].ToString() + " kWh";
                    string phuongXa = reader["PhuongXa"].ToString();
                    string diaChi = reader["DiaChi"].ToString();
                    bool trangThaiThanhToan = Convert.ToBoolean(reader["TrangThaiThanhToan"]);
                    DateTime? ngayThanhToan = reader["NgayThanhToan"] != DBNull.Value
                        ? Convert.ToDateTime(reader["NgayThanhToan"])
                        : (DateTime?)null;
                    string tongTien = Convert.ToDecimal(reader["TongTien"]).ToString("N0");

                    userMain frmMain = (userMain)this.FindForm();
                    HĐ hĐ = new HĐ();
                    frmMain.LoadUserControl(hĐ);
                    hĐ.HienThiHoaDon(maHD, tenKH, loaiDV, thoiGian, chiSo, phuongXa, diaChi, trangThaiThanhToan, ngayThanhToan, tongTien);
                }
                reader.Close();

                // 2. Nếu chưa tìm thấy trong điện, tìm tiếp trong nước
                if (!found)
                {
                    string queryNuoc = @"
                SELECT hd.MaHoaDon, dv.TenDichVu, hd.ThoiGian, hd.TenKhachHang, hd.PhuongXa, hd.DiaChi, 
                       hd.ChiSoNuoc AS ChiSo, hd.TongTien, hd.TrangThaiThanhToan, hd.NgayThanhToan
                FROM HoaDonNuoc hd
                JOIN DichVuNuoc dv ON hd.MaDV = dv.MaDV
                WHERE hd.MaHoaDon = @maHD";

                    cmd = new SqlCommand(queryNuoc, conn);
                    cmd.Parameters.AddWithValue("@maHD", maHD);
                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        found = true;
                        string tenKH = reader["TenKhachHang"].ToString();
                        string loaiDV = reader["TenDichVu"].ToString();
                        string thoiGian = reader["ThoiGian"].ToString();
                        string chiSo = reader["ChiSo"].ToString() + " m³";
                        string phuongXa = reader["PhuongXa"].ToString();
                        string diaChi = reader["DiaChi"].ToString();
                        bool trangThaiThanhToan = Convert.ToBoolean(reader["TrangThaiThanhToan"]);
                        DateTime? ngayThanhToan = reader["NgayThanhToan"] != DBNull.Value
                            ? Convert.ToDateTime(reader["NgayThanhToan"])
                            : (DateTime?)null;
                        string tongTien = Convert.ToDecimal(reader["TongTien"]).ToString("N0");

                        userMain frmMain = (userMain)this.FindForm();
                        HĐ hĐ = new HĐ();
                        frmMain.LoadUserControl(hĐ);
                        hĐ.HienThiHoaDon(maHD, tenKH, loaiDV, thoiGian, chiSo, phuongXa, diaChi, trangThaiThanhToan, ngayThanhToan, tongTien);
                    }
                    reader.Close();
                }

                if (!found)
                {
                    MessageBox.Show("Không tìm thấy mã hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void TTHĐ_Load(object sender, EventArgs e)
        {

        }
    }
}
