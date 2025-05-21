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
    public partial class QLCSĐN : UserControl
    {
        public QLCSĐN()
        {
            InitializeComponent();
        }

        
        private void LoadDichVuDien()
        {
            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                try
                {
                    string query = "SELECT MaDV, TenDichVu, DonVi, NgayBatDau, DonGia, TrangThai, MoTa FROM DichVuDien";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvDien.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu dịch vụ điện: " + ex.Message);
                }
            }
        }
        private void LoadDichVuNuoc()
        {
            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                try
                {
                    string query = "SELECT MaDV, TenDichVu, DonVi, NgayBatDau, DonGia, TrangThai, MoTa FROM DichVuNuoc";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvNuoc.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu dịch vụ nước: " + ex.Message);
                }
            }
        }

        private void QLCSĐN_Load(object sender, EventArgs e)
        {
            LoadDichVuDien();
            LoadDichVuNuoc();
        }

        private void dgvDichVuDien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDien.Rows.Count)
            {
                DataGridViewRow row = dgvDien.Rows[e.RowIndex];

                txtMaDichVu.Text = row.Cells[0].Value?.ToString() ?? "";           // MaDV
                txtTenDichVu.Text = row.Cells[1].Value?.ToString() ?? "";          // TenDichVu
                txtDonVi.Text = row.Cells[2].Value?.ToString() ?? "";              // DonVi

                if (DateTime.TryParse(row.Cells[3].Value?.ToString(), out DateTime ngayBatDau))
                {
                    dtNgayBatDau.Value = ngayBatDau;
                }

                txtDonGia.Text = row.Cells[4].Value?.ToString() ?? "";             // DonGia
                cbTrangThai.Text = row.Cells[5].Value?.ToString() ?? "";           // TrangThai
                txtMoTa.Text = row.Cells[6].Value?.ToString() ?? "";               // MoTa

                // Vô hiệu hóa sửa mã dịch vụ
                txtMaDichVu.Enabled = false;
            }
        }

       
        private void ClearInputFields()
        {
            txtMaDichVu.Clear();
            txtTenDichVu.Clear();
            txtDonVi.Text = "kWh"; // mặc định
            txtDonGia.Clear();
            txtMoTa.Clear();
            cbTrangThai.SelectedIndex = 0;
            dtNgayBatDau.Value = DateTime.Now;
        }

        private void btnThemDien_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO DichVuDien (MaDV, TenDichVu, DonVi, NgayBatDau, DonGia, TrangThai, MoTa) " +
                                   "VALUES (@MaDV, @TenDichVu, @DonVi, @NgayBatDau, @DonGia, @TrangThai, @MoTa)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Truyền tham số
                    cmd.Parameters.AddWithValue("@MaDV", txtMaDichVu.Text.Trim());
                    cmd.Parameters.AddWithValue("@TenDichVu", txtTenDichVu.Text.Trim());
                    cmd.Parameters.AddWithValue("@DonVi", txtDonVi.Text.Trim());
                    cmd.Parameters.AddWithValue("@NgayBatDau", dtNgayBatDau.Value);
                    cmd.Parameters.AddWithValue("@DonGia", Convert.ToDecimal(txtDonGia.Text.Trim()));
                    cmd.Parameters.AddWithValue("@TrangThai", cbTrangThai.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@MoTa", txtMoTa.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm dịch vụ điện thành công!");
                        LoadDichVuDien(); // Refresh lại DataGridView
                        ClearInputFields();
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm dịch vụ.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO DichVuNuoc (MaDV, TenDichVu, DonVi, NgayBatDau, DonGia, TrangThai, MoTa) " +
                                   "VALUES (@MaDV, @TenDichVu, @DonVi, @NgayBatDau, @DonGia, @TrangThai, @MoTa)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Truyền tham số
                    cmd.Parameters.AddWithValue("@MaDV", txtMaDichVuNuoc.Text.Trim());
                    cmd.Parameters.AddWithValue("@TenDichVu", txtTenDichVuNuoc.Text.Trim());
                    cmd.Parameters.AddWithValue("@DonVi", cbDonViNuoc.Text.Trim());
                    cmd.Parameters.AddWithValue("@NgayBatDau", dtNgayBatDauNuoc.Value);
                    cmd.Parameters.AddWithValue("@DonGia", Convert.ToDecimal(txtDonGiaNuoc.Text.Trim()));
                    cmd.Parameters.AddWithValue("@TrangThai", cbTrangThaiNuoc.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@MoTa", txtMoTaNuoc.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm dịch vụ nước thành công!");
                        LoadDichVuNuoc(); // Refresh lại DataGridView
                        ClearInputFields();
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm dịch vụ.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.ToString());
                }
            }
        }

        private void dgvNuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDien.Rows.Count)
            {
                DataGridViewRow row = dgvNuoc.Rows[e.RowIndex];

                txtMaDichVuNuoc.Text = row.Cells[0].Value?.ToString() ?? "";           // MaDV
                txtTenDichVuNuoc.Text = row.Cells[1].Value?.ToString() ?? "";          // TenDichVu
                cbDonViNuoc.Text = row.Cells[2].Value?.ToString() ?? "";              // DonVi

                if (DateTime.TryParse(row.Cells[3].Value?.ToString(), out DateTime ngayBatDau))
                {
                    dtNgayBatDauNuoc.Value = ngayBatDau;
                }

                txtDonGiaNuoc.Text = row.Cells[4].Value?.ToString() ?? "";             // DonGia
                cbTrangThaiNuoc.Text = row.Cells[5].Value?.ToString() ?? "";           // TrangThai
                txtMoTaNuoc.Text = row.Cells[6].Value?.ToString() ?? "";               // MoTa

                // Vô hiệu hóa sửa mã dịch vụ
                txtMaDichVuNuoc.Enabled = false;
            }
        }

        private void btnSuaDien_Click(object sender, EventArgs e)
        {
            string maDV = txtMaDichVu.Text.Trim();
            string tenDichVu = txtTenDichVu.Text.Trim();
            string donVi = txtDonVi.Text.Trim();
            DateTime ngayBatDau = dtNgayBatDau.Value;
            string donGiaText = txtDonGia.Text.Trim();
            string trangThai = cbTrangThai.Text.Trim();
            string moTa = txtMoTa.Text.Trim();

            if (string.IsNullOrEmpty(maDV))
            {
                MessageBox.Show("Vui lòng chọn dịch vụ để sửa.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                string query = @"UPDATE DichVuDien
                         SET TenDichVu = @TenDichVu,
                             DonVi = @DonVi,
                             NgayBatDau = @NgayBatDau,
                             DonGia = @DonGia,
                             TrangThai = @TrangThai,
                             MoTa = @MoTa
                         WHERE MaDV = @MaDV";

                SqlCommand cmd = new SqlCommand(query, conn);

                // Truyền tham số
                cmd.Parameters.AddWithValue("@MaDV", maDV);
                cmd.Parameters.AddWithValue("@TenDichVu", tenDichVu);
                cmd.Parameters.AddWithValue("@DonVi", donVi);
                cmd.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);
                cmd.Parameters.AddWithValue("@DonGia", string.IsNullOrEmpty(donGiaText) ? 0 : Convert.ToDecimal(donGiaText));
                cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                cmd.Parameters.AddWithValue("@MoTa", moTa);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Cập nhật dịch vụ điện thành công!");
                        LoadDichVuDien(); // Refresh lại DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dịch vụ để cập nhật.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string maDV = txtMaDichVuNuoc.Text.Trim();
            string tenDichVu = txtTenDichVuNuoc.Text.Trim();
            string donVi = cbDonViNuoc.Text.Trim();
            DateTime ngayBatDau = dtNgayBatDauNuoc.Value;
            string donGiaText = txtDonGiaNuoc.Text.Trim();
            string trangThai = cbTrangThaiNuoc.Text.Trim();
            string moTa = txtMoTaNuoc.Text.Trim();

            if (string.IsNullOrEmpty(maDV))
            {
                MessageBox.Show("Vui lòng chọn dịch vụ để sửa.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                string query = @"UPDATE DichVuNuoc
                         SET TenDichVu = @TenDichVu,
                             DonVi = @DonVi,
                             NgayBatDau = @NgayBatDau,
                             DonGia = @DonGia,
                             TrangThai = @TrangThai,
                             MoTa = @MoTa
                         WHERE MaDV = @MaDV";

                SqlCommand cmd = new SqlCommand(query, conn);

                // Truyền tham số
                cmd.Parameters.AddWithValue("@MaDV", maDV);
                cmd.Parameters.AddWithValue("@TenDichVu", tenDichVu);
                cmd.Parameters.AddWithValue("@DonVi", donVi);
                cmd.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);
                cmd.Parameters.AddWithValue("@DonGia", string.IsNullOrEmpty(donGiaText) ? 0 : Convert.ToDecimal(donGiaText));
                cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                cmd.Parameters.AddWithValue("@MoTa", moTa);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Cập nhật dịch vụ nước thành công!");
                        LoadDichVuNuoc(); // Refresh lại DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dịch vụ để cập nhật.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                }
            }
        }

        private void btnXoaDien_Click(object sender, EventArgs e)
        {
            string maDV = txtMaDichVu.Text.Trim();

            if (string.IsNullOrEmpty(maDV))
            {
                MessageBox.Show("Vui lòng chọn dịch vụ để xóa.");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dịch vụ này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(DB.connectionString))
                {
                    string query = "DELETE FROM DichVuDien WHERE MaDV = @MaDV";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDV", maDV);

                        try
                        {
                            conn.Open();
                            int rows = cmd.ExecuteNonQuery();
                            if (rows > 0)
                            {
                                MessageBox.Show("Xóa dịch vụ điện thành công!");
                                ClearInputFields();     // Xóa các ô nhập
                                LoadDichVuDien();       // Refresh lại bảng dữ liệu
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy dịch vụ để xóa.");
                            }
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string maDV = txtMaDichVuNuoc.Text.Trim();

            if (string.IsNullOrEmpty(maDV))
            {
                MessageBox.Show("Vui lòng chọn dịch vụ để xóa.");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dịch vụ này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(DB.connectionString))
                {
                    string query = "DELETE FROM DichVuNuoc WHERE MaDV = @MaDV";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDV", maDV);

                        try
                        {
                            conn.Open();
                            int rows = cmd.ExecuteNonQuery();
                            if (rows > 0)
                            {
                                MessageBox.Show("Xóa dịch vụ điện thành công!");
                                ClearInputFields();     // Xóa các ô nhập
                                LoadDichVuNuoc();       // Refresh lại bảng dữ liệu
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy dịch vụ để xóa.");
                            }
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaDichVu.Enabled = true;
            txtMaDichVu.Text = "";
            txtTenDichVu.Text = "";
            txtDonVi.Text = "kWh"; // hoặc "" nếu là combo box
            dtNgayBatDau.Value = DateTime.Now;
            txtDonGia.Text = "";
            cbTrangThai.SelectedIndex = 0; // hoặc -1 nếu muốn không chọn gì
            txtMoTa.Text = "";
        }

        private void btnLamMoiNuoc_Click(object sender, EventArgs e)
        {
            txtMaDichVuNuoc.Enabled = true;
            txtMaDichVuNuoc.Text = "";
            txtTenDichVuNuoc.Text = "";
            cbDonViNuoc.Text = "kWh"; // hoặc "" nếu là combo box
            dtNgayBatDauNuoc.Value = DateTime.Now;
            txtDonGiaNuoc.Text = "";
            cbTrangThaiNuoc.SelectedIndex = 0; // hoặc -1 nếu muốn không chọn gì
            txtMoTaNuoc.Text = "";
        }
    }
}
