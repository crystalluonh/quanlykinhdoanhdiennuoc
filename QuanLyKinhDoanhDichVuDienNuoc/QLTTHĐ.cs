using System;
using System.Data;
using System.Data.SqlClient;
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
            LoadDienData();
            LoadNuocData();
        }

        private void LoadNuocData()
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
    u.Username AS TenTaiKhoan,
    hd.TenKhachHang,
    hd.PhuongXa, 
    hd.DiaChi, 
    hd.ChiSoNuoc AS ChiSo, 
    hd.TongTien,
    CASE 
        WHEN hd.TrangThaiThanhToan = 1 THEN N'Đã thanh toán'
        ELSE N'Chưa thanh toán'
    END AS TrangThaiThanhToan,
    hd.NgayThanhToan
FROM HoaDonNuoc hd
JOIN DichVuNuoc dv ON hd.MaDV = dv.MaDV
LEFT JOIN Users u ON hd.UserID = u.UserID";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvNuoc.AutoGenerateColumns = false;
                    dgvNuoc.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu nước: " + ex.Message);
                }
            }
        }

        private void LoadDienData()
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
    u.Username AS TenTaiKhoan,
    hd.TenKhachHang,
    hd.PhuongXa, 
    hd.DiaChi, 
    hd.ChiSoDien AS ChiSo, 
    hd.TongTien,
    CASE 
        WHEN hd.TrangThaiThanhToan = 1 THEN N'Đã thanh toán'
        ELSE N'Chưa thanh toán'
    END AS TrangThaiThanhToan,
    hd.NgayThanhToan
FROM HoaDonDien hd
JOIN DichVuDien dv ON hd.MaDV = dv.MaDV
LEFT JOIN Users u ON hd.UserID = u.UserID";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvDien.AutoGenerateColumns = false;
                    dgvDien.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu điện: " + ex.Message);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                try
                {
                    conn.Open();

                    // Truy vấn hóa đơn nước
                    string queryNuoc = @"
SELECT 
    hd.MaHoaDon, 
    dv.TenDichVu AS LoaiDichVu,
    hd.ThoiGian,
    u.Username AS TenTaiKhoan,
    hd.TenKhachHang,
    hd.PhuongXa, 
    hd.DiaChi, 
    hd.ChiSoNuoc AS ChiSo, 
    hd.TongTien,
    CASE 
        WHEN hd.TrangThaiThanhToan = 1 THEN N'Đã thanh toán'
        ELSE N'Chưa thanh toán'
    END AS TrangThaiThanhToan,
    hd.NgayThanhToan
FROM HoaDonNuoc hd
JOIN DichVuNuoc dv ON hd.MaDV = dv.MaDV
LEFT JOIN Users u ON hd.UserID = u.UserID";

                    // Thêm điều kiện tìm kiếm nếu có từ khóa
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        queryNuoc += @"
 WHERE 
    hd.MaHoaDon LIKE @keyword OR
    u.Username LIKE @keyword OR
    hd.TenKhachHang LIKE @keyword OR
    hd.PhuongXa LIKE @keyword OR
    hd.DiaChi LIKE @keyword OR
    dv.TenDichVu LIKE @keyword OR
    CONVERT(VARCHAR, hd.ThoiGian, 120) LIKE @keyword OR
    CONVERT(VARCHAR, hd.NgayThanhToan, 120) LIKE @keyword";
                    }

                    SqlDataAdapter adapterNuoc = new SqlDataAdapter(queryNuoc, conn);
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        adapterNuoc.SelectCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    }

                    DataTable dtNuoc = new DataTable();
                    adapterNuoc.Fill(dtNuoc);
                    dgvNuoc.DataSource = dtNuoc;

                    // Truy vấn hóa đơn điện
                    string queryDien = @"
SELECT 
    hd.MaHoaDon, 
    dv.TenDichVu AS LoaiDichVu,
    hd.ThoiGian,
    u.Username AS TenTaiKhoan,
    hd.TenKhachHang,
    hd.PhuongXa, 
    hd.DiaChi, 
    hd.ChiSoDien AS ChiSo, 
    hd.TongTien,
    CASE 
        WHEN hd.TrangThaiThanhToan = 1 THEN N'Đã thanh toán'
        ELSE N'Chưa thanh toán'
    END AS TrangThaiThanhToan,
    hd.NgayThanhToan
FROM HoaDonDien hd
JOIN DichVuDien dv ON hd.MaDV = dv.MaDV
LEFT JOIN Users u ON hd.UserID = u.UserID";

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        queryDien += @"
 WHERE 
    hd.MaHoaDon LIKE @keyword OR
    u.Username LIKE @keyword OR
    hd.TenKhachHang LIKE @keyword OR
    hd.PhuongXa LIKE @keyword OR
    hd.DiaChi LIKE @keyword OR
    dv.TenDichVu LIKE @keyword OR
    CONVERT(VARCHAR, hd.ThoiGian, 120) LIKE @keyword OR
    CONVERT(VARCHAR, hd.NgayThanhToan, 120) LIKE @keyword";
                    }

                    SqlDataAdapter adapterDien = new SqlDataAdapter(queryDien, conn);
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        adapterDien.SelectCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    }

                    DataTable dtDien = new DataTable();
                    adapterDien.Fill(dtDien);
                    dgvDien.DataSource = dtDien;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
                }
            }
        }


        private void dgvAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý khi click ô trong DataGridView nếu cần
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
