using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyKinhDoanhDichVuDienNuoc
{
    public partial class QLHĐĐ : UserControl
    {
        public QLHĐĐ()
        {
            InitializeComponent();
        }

        private void QLHĐĐ_Load(object sender, EventArgs e)
        {
            LoadDichVuDien();
            LoadAllData();
            txtMaHoaDon.Text = TaoMaHoaDonMoi();
        }

        private decimal LayDonGiaTheoMaDV(string maDV)
        {
            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                string query = "SELECT DonGia FROM DichVuDien WHERE MaDV = @MaDV";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDV", maDV);
                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToDecimal(result) : 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy đơn giá: " + ex.Message);
                    return 0;
                }
            }
        }

        private void LoadDichVuDien()
        {
            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                try
                {
                    string query = "SELECT MaDV, TenDichVu FROM DichVuDien";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cbLoaiDichVu.DataSource = dt;
                    cbLoaiDichVu.DisplayMember = "TenDichVu";
                    cbLoaiDichVu.ValueMember = "MaDV";
                    cbLoaiDichVu.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi load danh sách dịch vụ: " + ex.Message);
                }
            }
        }

        private void LoadAllData()
        {
            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                try
                {
                    string query = @"
                        SELECT hd.MaHoaDon, dv.TenDichVu AS LoaiDichVu, hd.ThoiGian,
                               hd.TenKhachHang, hd.PhuongXa, hd.DiaChi, hd.ChiSoDien, hd.TongTien
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out string maHoaDon, out string maDV, out string tenKH,
                               out string thoiGian, out string phuongXa, out string diaChi,
                               out int chiSoDien, out decimal donGia, out decimal tongTien)) return;

            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                string query = @"
                    INSERT INTO HoaDonDien (MaHoaDon, MaDV, ThoiGian, TenKhachHang, 
                                            PhuongXa, DiaChi, ChiSoDien, TongTien, UserId)
                    VALUES (@MaHoaDon, @MaDV, @ThoiGian, @TenKhachHang, 
                            @PhuongXa, @DiaChi, @ChiSoDien, @TongTien, @UserId)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                cmd.Parameters.AddWithValue("@MaDV", maDV);
                cmd.Parameters.AddWithValue("@ThoiGian", thoiGian);
                cmd.Parameters.AddWithValue("@TenKhachHang", tenKH);
                cmd.Parameters.AddWithValue("@PhuongXa", phuongXa);
                cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                cmd.Parameters.AddWithValue("@ChiSoDien", chiSoDien);
                cmd.Parameters.AddWithValue("@TongTien", tongTien);
                cmd.Parameters.AddWithValue("@UserId", DBNull.Value);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm hóa đơn điện thành công!");
                    ResetForm();
                    LoadAllData();
                    txtMaHoaDon.Text = TaoMaHoaDonMoi();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi thêm hóa đơn: " + ex.Message);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out string maHoaDon, out string maDV, out string tenKH,
                               out string thoiGian, out string phuongXa, out string diaChi,
                               out int chiSoDien, out decimal donGia, out decimal tongTien)) return;

            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                string query = @"
                    UPDATE HoaDonDien SET 
                        MaDV = @MaDV, ThoiGian = @ThoiGian, TenKhachHang = @TenKhachHang,
                        PhuongXa = @PhuongXa, DiaChi = @DiaChi, ChiSoDien = @ChiSoDien, TongTien = @TongTien
                    WHERE MaHoaDon = @MaHoaDon";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                cmd.Parameters.AddWithValue("@MaDV", maDV);
                cmd.Parameters.AddWithValue("@ThoiGian", thoiGian);
                cmd.Parameters.AddWithValue("@TenKhachHang", tenKH);
                cmd.Parameters.AddWithValue("@PhuongXa", phuongXa);
                cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                cmd.Parameters.AddWithValue("@ChiSoDien", chiSoDien);
                cmd.Parameters.AddWithValue("@TongTien", tongTien);

                try
                {
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Cập nhật hóa đơn thành công!");
                        LoadAllData();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn để cập nhật.");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật hóa đơn: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string maHoaDon = txtMaHoaDon.Text.Trim();
            if (string.IsNullOrEmpty(maHoaDon))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xóa.");
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa hóa đơn \"{maHoaDon}\"?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(DB.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM HoaDonDien WHERE MaHoaDon = @MaHoaDon", conn);
                    cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);

                    try
                    {
                        conn.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Xóa hóa đơn thành công!");
                            ResetForm();
                            LoadAllData();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy hóa đơn để xóa.");
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Lỗi khi xóa hóa đơn: " + ex.Message);
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadAllData();
                return;
            }

            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                string query = @"
                    SELECT hd.MaHoaDon, dv.TenDichVu AS LoaiDichVu, hd.ThoiGian,
                           hd.TenKhachHang, hd.PhuongXa, hd.DiaChi, hd.ChiSoDien, hd.TongTien
                    FROM HoaDonDien hd
                    JOIN DichVuDien dv ON hd.MaDV = dv.MaDV
                    WHERE hd.MaHoaDon LIKE @kw OR dv.TenDichVu LIKE @kw OR
                          hd.TenKhachHang LIKE @kw OR hd.DiaChi LIKE @kw OR hd.PhuongXa LIKE @kw";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvAccounts.DataSource = dt;

                if (dt.Rows.Count == 0)
                    MessageBox.Show("Không tìm thấy hóa đơn phù hợp.");
            }
        }

        private void dgvAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvAccounts.Rows[e.RowIndex];
            txtMaHoaDon.Text = row.Cells[0].Value?.ToString();
            cbLoaiDichVu.Text = row.Cells[1].Value?.ToString();
            txtTenKH.Text = row.Cells[3].Value?.ToString();
            txtWard.Text = row.Cells[4].Value?.ToString();
            txtAddress.Text = row.Cells[5].Value?.ToString();
            txtChiSoDien.Text = row.Cells[6].Value?.ToString();

            txtMaHoaDon.Enabled = false;

            if (DateTime.TryParseExact("01/" + row.Cells[2].Value.ToString(), "dd/MM/yyyy",
                null, System.Globalization.DateTimeStyles.None, out DateTime dt))
            {
                dtThoiGian.Value = dt;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
            LoadAllData();
            txtMaHoaDon.Text = TaoMaHoaDonMoi();
        }

        private string TaoMaHoaDonMoi()
        {
            string prefix = "HDD-" + dtThoiGian.Value.ToString("yyyyMM") + "-";
            int stt = 1;

            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                string query = "SELECT TOP 1 MaHoaDon FROM HoaDonDien WHERE MaHoaDon LIKE @prefix + '%' ORDER BY MaHoaDon DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@prefix", prefix);
                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string[] parts = result.ToString().Split('-');
                        if (parts.Length == 3 && int.TryParse(parts[2], out int soCuoi))
                        {
                            stt = soCuoi + 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tạo mã hóa đơn: " + ex.Message);
                }
            }
            return prefix + stt.ToString("D3");
        }

        private bool ValidateInput(out string maHoaDon, out string maDV, out string tenKH,
                                   out string thoiGian, out string phuongXa, out string diaChi,
                                   out int chiSoDien, out decimal donGia, out decimal tongTien)
        {
            maHoaDon = txtMaHoaDon.Text.Trim();
            maDV = cbLoaiDichVu.SelectedValue?.ToString() ?? "";
            tenKH = txtTenKH.Text.Trim();
            thoiGian = dtThoiGian.Value.ToString("MM/yyyy");
            phuongXa = txtWard.Text.Trim();
            diaChi = txtAddress.Text.Trim();
            donGia = 0;
            tongTien = 0;
            chiSoDien = 0;

            if (string.IsNullOrEmpty(maHoaDon) || string.IsNullOrEmpty(maDV) ||
                string.IsNullOrEmpty(tenKH) || string.IsNullOrEmpty(phuongXa) || string.IsNullOrEmpty(diaChi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return false;
            }

            if (!int.TryParse(txtChiSoDien.Text.Trim(), out chiSoDien))
            {
                MessageBox.Show("Chỉ số điện không hợp lệ.");
                return false;
            }

            donGia = LayDonGiaTheoMaDV(maDV);
            tongTien = donGia * chiSoDien;
            return true;
        }

        private void ResetForm()
        {
            txtMaHoaDon.Text = "";
            txtTenKH.Text = "";
            txtWard.Text = "";
            txtAddress.Text = "";
            txtChiSoDien.Text = "";
            txtSearch.Text = "";
            cbLoaiDichVu.SelectedIndex = -1;
            txtMaHoaDon.Enabled = true;
            dtThoiGian.Value = DateTime.Now;
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            string maHoaDon = txtMaHoaDon.Text.Trim();

            if (string.IsNullOrEmpty(maHoaDon))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để xóa.");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(DB.connectionString))
                {
                    string query = "DELETE FROM HoaDonDien WHERE MaHoaDon = @MaHoaDon";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);

                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Xóa hóa đơn thành công!");
                            LoadAllData();

                            // Cấp mã mới cho ô nhập mã hóa đơn
                            txtMaHoaDon.Text = TaoMaHoaDonMoi();

                            // Reset các trường nhập liệu
                            txtTenKH.Text = "";
                            txtWard.Text = "";
                            txtAddress.Text = "";
                            txtChiSoDien.Text = "";
                            cbLoaiDichVu.SelectedIndex = -1;
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy hóa đơn cần xóa.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa hóa đơn: " + ex.Message);
                    }
                }
            }
        }
    }
}
