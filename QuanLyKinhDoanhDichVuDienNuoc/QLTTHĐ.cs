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
    public partial class QLTTHĐ : UserControl
    {
        public QLTTHĐ()
        {
            InitializeComponent();
        }

        private void QLTTHĐ_Load(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private void LoadAllData()
        {
            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                try
                {
                    string query = @"
                SELECT 
                    hd.MaHoaDon, 
                    dv.TenDichVu AS LoaiDichVu,
                    hd.ThoiGian,
                    hd.TenKhachHang, 
                    hd.PhuongXa, 
                    hd.DiaChi, 
                    hd.ChiSoNuoc AS ChiSo, 
                    hd.TongTien,
                    CASE 
                        WHEN hd.TrangThaiThanhToan = 1 THEN N'Đã thanh toán'
                        ELSE N'Chưa thanh toán'
                    END AS TrangThaiThanhToan,
                    hd.NgayThanhToan,
                    N'Nước' AS LoaiHoaDon
                FROM HoaDonNuoc hd
                JOIN DichVuNuoc dv ON hd.MaDV = dv.MaDV

                UNION ALL

                SELECT 
                    hd.MaHoaDon, 
                    dv.TenDichVu AS LoaiDichVu,
                    hd.ThoiGian,
                    hd.TenKhachHang, 
                    hd.PhuongXa, 
                    hd.DiaChi, 
                    hd.ChiSoDien AS ChiSo, 
                    hd.TongTien,
                    CASE 
                        WHEN hd.TrangThaiThanhToan = 1 THEN N'Đã thanh toán'
                        ELSE N'Chưa thanh toán'
                    END AS TrangThaiThanhToan,
                    hd.NgayThanhToan,
                    N'Điện' AS LoaiHoaDon
                FROM HoaDonDien hd
                JOIN DichVuDien dv ON hd.MaDV = dv.MaDV";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvAccounts.AutoGenerateColumns = false;
                    dgvAccounts.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                // Nếu không nhập gì, load lại tất cả dữ liệu
                LoadAllData();
                return;
            }

            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                try
                {
                    string query = @"
                SELECT 
                    hd.MaHoaDon, 
                    dv.TenDichVu AS LoaiDichVu,
                    hd.ThoiGian,
                    hd.TenKhachHang, 
                    hd.PhuongXa, 
                    hd.DiaChi, 
                    hd.ChiSoNuoc AS ChiSo, 
                    hd.TongTien,
                    CASE 
                        WHEN hd.TrangThaiThanhToan = 1 THEN N'Đã thanh toán'
                        ELSE N'Chưa thanh toán'
                    END AS TrangThaiThanhToan,
                    hd.NgayThanhToan,
                    N'Nước' AS LoaiHoaDon
                FROM HoaDonNuoc hd
                JOIN DichVuNuoc dv ON hd.MaDV = dv.MaDV
                WHERE hd.MaHoaDon LIKE @keyword OR hd.TenKhachHang LIKE @keyword

                UNION ALL

                SELECT 
                    hd.MaHoaDon, 
                    dv.TenDichVu AS LoaiDichVu,
                    hd.ThoiGian,
                    hd.TenKhachHang, 
                    hd.PhuongXa, 
                    hd.DiaChi, 
                    hd.ChiSoDien AS ChiSo, 
                    hd.TongTien,
                    CASE 
                        WHEN hd.TrangThaiThanhToan = 1 THEN N'Đã thanh toán'
                        ELSE N'Chưa thanh toán'
                    END AS TrangThaiThanhToan,
                    hd.NgayThanhToan,
                    N'Điện' AS LoaiHoaDon
                FROM HoaDonDien hd
                JOIN DichVuDien dv ON hd.MaDV = dv.MaDV
                WHERE hd.MaHoaDon LIKE @keyword OR hd.TenKhachHang LIKE @keyword
            ";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvAccounts.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
                }
            }
        }

       
    }
}
