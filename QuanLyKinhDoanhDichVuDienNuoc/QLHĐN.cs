using ClosedXML.Excel;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QuanLyKinhDoanhDichVuDienNuoc
{
    public partial class QLHĐN : UserControl
    {
        public QLHĐN()
        {
            InitializeComponent();
        }

        private void QLHĐN_Load(object sender, EventArgs e)
        {
            LoadDichVuNuoc();
            LoadAllData();

            // Tự động sinh mã hóa đơn mới khi load form
            txtMaHoaDon.Text = GenerateNewMaHoaDon();

            // Khóa ô mã hóa đơn để người dùng không sửa
        }

        private string GenerateNewMaHoaDon()
        {
            string newMaHoaDon = "HDN0001"; // mặc định nếu chưa có mã nào
            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                string query = "SELECT TOP 1 MaHoaDon FROM HoaDonNuoc WHERE MaHoaDon LIKE 'HDN%' ORDER BY MaHoaDon DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string lastMa = result.ToString(); // ví dụ "HDN0012"
                        string numberPart = lastMa.Substring(3); // lấy phần số, ví dụ "0012"
                        if (int.TryParse(numberPart, out int lastNumber))
                        {
                            int newNumber = lastNumber + 1;
                            newMaHoaDon = "HDN" + newNumber.ToString("D4"); // vd: HDN0013
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tạo mã hóa đơn tự động: " + ex.Message);
                }
            }
            return newMaHoaDon;
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
                    hd.ChiSoNuoc, 
                    hd.TongTien
                FROM HoaDonNuoc hd
                JOIN DichVuNuoc dv ON hd.MaDV = dv.MaDV";

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

        private void LoadDichVuNuoc()
        {
            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                try
                {
                    string query = "SELECT MaDV, TenDichVu FROM DichVuNuoc";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cbLoaiDichVu.DataSource = dt;
                    cbLoaiDichVu.DisplayMember = "TenDichVu";
                    cbLoaiDichVu.ValueMember = "MaDV";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi load danh sách dịch vụ: " + ex.Message);
                }
            }
        }

        private decimal LayDonGiaTheoMaDV(string maDV)
        {
            decimal donGia = 0;

            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                string query = "SELECT DonGia FROM DichVuNuoc WHERE MaDV = @MaDV";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDV", maDV);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && decimal.TryParse(result.ToString(), out decimal gia))
                    {
                        donGia = gia;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy đơn giá: " + ex.Message);
                }
            }

            return donGia;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string maHoaDon = txtMaHoaDon.Text.Trim();
            string maDV = cbLoaiDichVu.SelectedValue.ToString();
            string tenKhachHang = txtTenKH.Text.Trim();
            string thoiGian = dtThoiGian.Value.ToString("MM/yyyy");
            string phuongXa = txtWard.Text.Trim();
            string diaChi = txtAddress.Text.Trim();

            if (!int.TryParse(txtChiSoNuoc.Text.Trim(), out int chiSoNuoc))
            {
                MessageBox.Show("Chỉ số nước không hợp lệ.");
                return;
            }

            decimal donGia = LayDonGiaTheoMaDV(maDV);
            decimal tongTien = donGia * chiSoNuoc;

            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                string query = @"INSERT INTO HoaDonNuoc 
            (MaHoaDon, MaDV, ThoiGian, TenKhachHang, PhuongXa, DiaChi, ChiSoNuoc, TongTien)
            VALUES 
            (@MaHoaDon, @MaDV, @ThoiGian, @TenKhachHang, @PhuongXa, @DiaChi, @ChiSoNuoc, @TongTien)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                cmd.Parameters.AddWithValue("@MaDV", maDV);
                cmd.Parameters.AddWithValue("@ThoiGian", thoiGian);
                cmd.Parameters.AddWithValue("@TenKhachHang", tenKhachHang);
                cmd.Parameters.AddWithValue("@PhuongXa", phuongXa);
                cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                cmd.Parameters.AddWithValue("@ChiSoNuoc", chiSoNuoc);
                cmd.Parameters.AddWithValue("@TongTien", tongTien);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm hóa đơn nước thành công!");

                    // Cấp mã hóa đơn mới cho lần thêm tiếp theo
                    txtMaHoaDon.Text = GenerateNewMaHoaDon();

                    // Reset các trường nhập liệu
                    txtTenKH.Text = "";
                    txtWard.Text = "";
                    txtAddress.Text = "";
                    txtChiSoNuoc.Text = "";
                    cbLoaiDichVu.SelectedIndex = -1;

                    LoadAllData();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi thêm hóa đơn: " + ex.Message);
                }
            }
        }

        private void dgvAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvAccounts.Rows.Count)
            {
                DataGridViewRow row = dgvAccounts.Rows[e.RowIndex];

                txtMaHoaDon.Text = row.Cells[0].Value?.ToString() ?? "";
                string tenDichVu = row.Cells[1].Value?.ToString() ?? "";
                cbLoaiDichVu.Text = tenDichVu;
                string thoiGian = row.Cells[2].Value?.ToString() ?? "";
                txtTenKH.Text = row.Cells[3].Value?.ToString() ?? "";
                txtWard.Text = row.Cells[4].Value?.ToString() ?? "";
                txtAddress.Text = row.Cells[5].Value?.ToString() ?? "";
                txtChiSoNuoc.Text = row.Cells[6].Value?.ToString() ?? "";

                txtMaHoaDon.Enabled = false;

                if (DateTime.TryParseExact("01/" + thoiGian, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
                {
                    dtThoiGian.Value = parsedDate;
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
                    hd.ChiSoNuoc, 
                    hd.TongTien
                FROM HoaDonNuoc hd
                JOIN DichVuNuoc dv ON hd.MaDV = dv.MaDV
                WHERE hd.MaHoaDon LIKE @keyword
                   OR dv.TenDichVu LIKE @keyword
                   OR hd.TenKhachHang LIKE @keyword
                   OR hd.DiaChi LIKE @keyword
                   OR hd.PhuongXa LIKE @keyword";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvAccounts.AutoGenerateColumns = false;
                    dgvAccounts.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn phù hợp.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm hóa đơn: " + ex.Message);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string maHoaDon = txtMaHoaDon.Text.Trim();
            string maDV = cbLoaiDichVu.SelectedValue.ToString();
            string tenKhachHang = txtTenKH.Text.Trim();
            string thoiGian = dtThoiGian.Value.ToString("MM/yyyy");
            string phuongXa = txtWard.Text.Trim();
            string diaChi = txtAddress.Text.Trim();

            if (!int.TryParse(txtChiSoNuoc.Text.Trim(), out int chiSoNuoc))
            {
                MessageBox.Show("Chỉ số nước không hợp lệ.");
                return;
            }

            decimal donGia = LayDonGiaTheoMaDV(maDV);
            decimal tongTien = donGia * chiSoNuoc;

            if (string.IsNullOrEmpty(maHoaDon))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để sửa.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                string query = @"
        UPDATE HoaDonNuoc SET
            MaDV = @MaDV,
            ThoiGian = @ThoiGian,
            TenKhachHang = @TenKhachHang,
            PhuongXa = @PhuongXa,
            DiaChi = @DiaChi,
            ChiSoNuoc = @ChiSoNuoc,
            TongTien = @TongTien
        WHERE MaHoaDon = @MaHoaDon";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDV", maDV);
                cmd.Parameters.AddWithValue("@ThoiGian", thoiGian);
                cmd.Parameters.AddWithValue("@TenKhachHang", tenKhachHang);
                cmd.Parameters.AddWithValue("@PhuongXa", phuongXa);
                cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                cmd.Parameters.AddWithValue("@ChiSoNuoc", chiSoNuoc);
                cmd.Parameters.AddWithValue("@TongTien", tongTien);
                cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Cập nhật hóa đơn thành công!");
                        LoadAllData();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn cần sửa.");
                    }
                }
                catch (Exception ex)
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
                MessageBox.Show("Vui lòng chọn hóa đơn để xóa.");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(DB.connectionString))
                {
                    string query = "DELETE FROM HoaDonNuoc WHERE MaHoaDon = @MaHoaDon";
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
                            txtMaHoaDon.Text = GenerateNewMaHoaDon();

                            // Reset các trường nhập liệu
                            txtTenKH.Text = "";
                            txtWard.Text = "";
                            txtAddress.Text = "";
                            txtChiSoNuoc.Text = "";
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

        private void btnThemFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                        });

                        DataTable dataTable = result.Tables[0];

                        foreach (DataRow row in dataTable.Rows)
                        {
                            try
                            {
                                string maHoaDon = row["MaHoaDon"].ToString().Trim();
                                string loaiDichVu = row["LoaiDichVu"].ToString().Trim();
                                string thoiGianStr = row["ThoiGian"].ToString().Trim();
                                string tenKH = row["TenKhachHang"].ToString().Trim();
                                string phuongXa = row["PhuongXa"].ToString().Trim();
                                string diaChi = row["DiaChi"].ToString().Trim();

                                if (!int.TryParse(row["ChiSoNuoc"].ToString().Trim(), out int chiSoNuoc) || chiSoNuoc <= 0)
                                    throw new Exception("Chỉ số nước không hợp lệ");
                                if (!decimal.TryParse(row["TongTien"].ToString().Trim(), out decimal tongTien) || tongTien < 0)
                                    throw new Exception("Tổng tiền không hợp lệ");

                                using (SqlConnection conn = new SqlConnection(DB.connectionString))
                                {
                                    conn.Open();

                                    // Lấy MaDV từ LoaiDichVu
                                    string maDV = "";
                                    string queryGetMaDV = "SELECT MaDV FROM DichVuNuoc WHERE TenDichVu = @LoaiDichVu";
                                    using (SqlCommand cmdGetMaDV = new SqlCommand(queryGetMaDV, conn))
                                    {
                                        cmdGetMaDV.Parameters.AddWithValue("@LoaiDichVu", loaiDichVu);
                                        object resultMaDV = cmdGetMaDV.ExecuteScalar();
                                        if (resultMaDV == null)
                                        {
                                            MessageBox.Show($"Không tìm thấy Mã DV cho loại dịch vụ: {loaiDichVu}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            continue;
                                        }
                                        maDV = resultMaDV.ToString();
                                    }

                                    string queryInsert = @"
                            INSERT INTO HoaDonNuoc (MaHoaDon, MaDV, ThoiGian, TenKhachHang,
                                                    PhuongXa, DiaChi, ChiSoNuoc, TongTien, UserId)
                            VALUES (@MaHoaDon, @MaDV, @ThoiGian, @TenKhachHang,
                                    @PhuongXa, @DiaChi, @ChiSoNuoc, @TongTien, @UserId)";
                                    using (SqlCommand cmdInsert = new SqlCommand(queryInsert, conn))
                                    {
                                        cmdInsert.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                                        cmdInsert.Parameters.AddWithValue("@MaDV", maDV);
                                        cmdInsert.Parameters.AddWithValue("@ThoiGian", thoiGianStr);
                                        cmdInsert.Parameters.AddWithValue("@TenKhachHang", tenKH);
                                        cmdInsert.Parameters.AddWithValue("@PhuongXa", phuongXa);
                                        cmdInsert.Parameters.AddWithValue("@DiaChi", diaChi);
                                        cmdInsert.Parameters.AddWithValue("@ChiSoNuoc", chiSoNuoc);
                                        cmdInsert.Parameters.AddWithValue("@TongTien", tongTien);
                                        cmdInsert.Parameters.AddWithValue("@UserId", DBNull.Value); // Cập nhật nếu có userId

                                        cmdInsert.ExecuteNonQuery();
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi khi import hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        MessageBox.Show("Import Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAllData(); // Hàm reload lại dữ liệu dgv
                    }
                }
            }
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Workbook|*.xlsx";
            saveFileDialog.Title = "Lưu file Excel";
            saveFileDialog.FileName = "HoaDonNuoc.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook workbook = new XLWorkbook())
                    {
                        DataTable dt = new DataTable();

                        // Tạo cột từ DataGridView
                        foreach (DataGridViewColumn col in dgvAccounts.Columns)
                        {
                            dt.Columns.Add(col.HeaderText);
                        }

                        // Thêm dữ liệu từ DataGridView vào DataTable
                        foreach (DataGridViewRow row in dgvAccounts.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                DataRow dataRow = dt.NewRow();
                                for (int i = 0; i < dgvAccounts.Columns.Count; i++)
                                {
                                    dataRow[i] = row.Cells[i].Value?.ToString();
                                }
                                dt.Rows.Add(dataRow);
                            }
                        }

                        // Ghi vào Excel
                        workbook.Worksheets.Add(dt, "HoaDonNuoc");
                        workbook.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaHoaDon.Text = GenerateNewMaHoaDon();
            txtTenKH.Text = "";
            txtWard.Text = "";
            txtAddress.Text = "";
            txtChiSoNuoc.Text = "";
            cbLoaiDichVu.SelectedIndex = -1;
            dtThoiGian.Value = DateTime.Now;

            txtMaHoaDon.Enabled = false;
            dgvAccounts.ClearSelection();
        }
    }
}
