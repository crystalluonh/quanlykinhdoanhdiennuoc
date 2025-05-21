using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System;
using static QuanLyKinhDoanhDichVuDienNuoc.frmLogin;

namespace QuanLyKinhDoanhDichVuDienNuoc
{
    public partial class LSTT : UserControl
    {
        public LSTT()
        {
            InitializeComponent();
            Load += LSTT_Load;
        }

        // ✅ Lấy UserID hiện tại từ phiên làm việc
        private int GetCurrentUserID()
        {
            return UserSession.CurrentUserID;
        }

        private void LSTT_Load(object sender, EventArgs e)
        {
            LoadLichSuThanhToan();
        }

        private void LoadLichSuThanhToan()
        {
            string connectionString = DB.connectionString;
            int currentUserID = GetCurrentUserID(); // Lấy UserID hiện tại
            string query = @"
SELECT 
    hd.MaHoaDon, 
    dv.TenDichVu AS LoaiDichVu,
    hd.ThoiGian,
    hd.TenKhachHang,  
    hd.TongTien,
    CASE 
        WHEN hd.TrangThaiThanhToan = 1 THEN N'Đã thanh toán'
        ELSE N'Chưa thanh toán'
    END AS TrangThaiThanhToan,
    hd.NgayThanhToan
FROM HoaDonNuoc hd
JOIN DichVuNuoc dv ON hd.MaDV = dv.MaDV
WHERE hd.TrangThaiThanhToan = 1 AND hd.UserID = @UserID

UNION ALL

SELECT 
    hd.MaHoaDon, 
    dv.TenDichVu AS LoaiDichVu,
    hd.ThoiGian,
    hd.TenKhachHang, 
    hd.TongTien,
    CASE 
        WHEN hd.TrangThaiThanhToan = 1 THEN N'Đã thanh toán'
        ELSE N'Chưa thanh toán'
    END AS TrangThaiThanhToan,
    hd.NgayThanhToan
FROM HoaDonDien hd
JOIN DichVuDien dv ON hd.MaDV = dv.MaDV
WHERE hd.TrangThaiThanhToan = 1 AND hd.UserID = @UserID

ORDER BY NgayThanhToan DESC";


            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // ✅ Gán UserID thay vì TenKhachHang
                        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = currentUserID;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }

                dgvAccounts.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch sử thanh toán: " + ex.Message);
            }
        }
    }
}
