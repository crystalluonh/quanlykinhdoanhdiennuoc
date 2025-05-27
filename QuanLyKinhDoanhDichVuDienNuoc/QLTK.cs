using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ExcelDataReader;
using ClosedXML.Excel;
namespace QuanLyKinhDoanhDichVuDienNuoc
{
    public partial class QLTK : UserControl
    {
        public QLTK()
        {
            InitializeComponent();
        }

        private void QLTK_Load(object sender, EventArgs e)
        {
            LoadAllData();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                // Nếu không nhập gì, tải lại toàn bộ dữ liệu
                LoadAllData();
                return;
            }

            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                try
                {
                    string query = @"SELECT Username, Password, FullName, Email, Phone, Ward, Address  
                             FROM Users
                             WHERE Username LIKE @keyword
                                OR FullName LIKE @keyword
                                OR Email LIKE @keyword
                                OR Phone LIKE @keyword
                                OR Address LIKE @keyword
                                OR Ward LIKE @keyword";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Giữ nguyên cấu hình cột như khi load toàn bộ
                    dgvAccounts.AutoGenerateColumns = false;
                    dgvAccounts.Columns.Clear();

                    dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Username",
                        HeaderText = "Tên đăng nhập"
                    });
                    dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Password",
                        HeaderText = "Mật khẩu"
                    });
                    dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "FullName",
                        HeaderText = "Họ và tên"
                    });
                    dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Email",
                        HeaderText = "Email"
                    });
                    dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Phone",
                        HeaderText = "Số điện thoại"
                    });
                    dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Address",
                        HeaderText = "Địa chỉ"
                    });
                    dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Ward",
                        HeaderText = "Phường/Xã"
                    });

                    dgvAccounts.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy kết quả phù hợp.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
                }
            }
        }
        private void LoadAllData()
        {
            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                try
                {
                    string query = "SELECT Username, Password, FullName, Email, Phone, Ward, Address  FROM Users";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Tắt tự động tạo cột
                    dgvAccounts.AutoGenerateColumns = false;

                    // Xóa các cột hiện tại (nếu có)
                    dgvAccounts.Columns.Clear();

                    // Thêm cột thủ công
                    dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Username",
                        HeaderText = "Tên đăng nhập"
                    });
                    dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Password",
                        HeaderText = "Mật khẩu"
                    });
                    dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "FullName",
                        HeaderText = "Họ và tên"
                    });
                    dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Email",
                        HeaderText = "Email"
                    });
                    dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Phone",
                        HeaderText = "Số điện thoại"
                    });
                    dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Address",
                        HeaderText = "Địa chỉ"
                    });
                    dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Ward",
                        HeaderText = "Phường/Xã"
                    });

                    // Gán dữ liệu
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
            // TODO: Xử lý tìm kiếm tài khoản ở đây
            MessageBox.Show("Đã nhấn nút Tìm!");
        }
        private void ClearInputFields()
        {
            txtUsername.Enabled = true;
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtWard.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng chọn tài khoản để xóa.");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(DB.connectionString))
                {
                    string query = "DELETE FROM Users WHERE Username = @Username";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);

                        try
                        {
                            conn.Open();
                            int rows = cmd.ExecuteNonQuery();
                            if (rows > 0)
                            {
                                MessageBox.Show("Xóa tài khoản thành công!");
                                ClearInputFields();
                                LoadAllData();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy tài khoản để xóa.");
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
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.Enabled = true;
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtWard.Text = "";
        }

        private void dgvAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvAccounts.Rows.Count)
            {
                DataGridViewRow row = dgvAccounts.Rows[e.RowIndex];
                txtUsername.Text = row.Cells[0].Value?.ToString() ?? ""; // Username
                txtPassword.Text = ""; // Không hiển thị mật khẩu mã hóa
                txtFullName.Text = row.Cells[2].Value?.ToString() ?? ""; // FullName
                txtEmail.Text = row.Cells[3].Value?.ToString() ?? "";    // Email
                txtPhone.Text = row.Cells[4].Value?.ToString() ?? "";    // Phone
                txtAddress.Text = row.Cells[5].Value?.ToString() ?? "";  // Address
                txtWard.Text = row.Cells[6].Value?.ToString() ?? "";     // Ward

                txtUsername.Enabled = false;
            }
        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();
            string ward = txtWard.Text.Trim();
            string role = "User";  // Mặc định Role là User

            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập Username và Password.");
                return;
            }

            // Kiểm tra định dạng Username (chỉ chữ, số, dấu gạch dưới; độ dài 5-20 ký tự)
            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9]{4,20}$"))
            {
                MessageBox.Show("Username phải từ 4 đến 20 ký tự, chỉ gồm chữ cái và số.");
                return;
            }

            // Kiểm tra định dạng Password (ít nhất 8 ký tự, có chữ hoa, chữ thường, số, ký tự đặc biệt)
            if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$"))
            {
                MessageBox.Show("Password phải từ 6 ký tự trở lên và bao gồm chữ hoa, chữ thường và số.");
                return;
            }

            // Kiểm tra định dạng Email
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không hợp lệ.");
                return;
            }

            // Kiểm tra định dạng Phone (chỉ số, 10-11 chữ số)
            if (!Regex.IsMatch(phone, @"^\d{10,11}$"))
            {
                MessageBox.Show("Số điện thoại phải gồm 10 hoặc 11 chữ số.");
                return;
            }

            // Mã hóa mật khẩu
            string hashedPassword = maHoaMatKhau.HashPassword(password);

            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                string query = @"INSERT INTO Users (Username, Password, FullName, Email, Phone, Address, Ward, Role) 
                 VALUES (@Username, @Password, @FullName, @Email, @Phone, @Address, @Ward, @Role)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", hashedPassword);
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@Ward", ward);
                cmd.Parameters.AddWithValue("@Role", role);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm người dùng thành công!");

                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtFullName.Text = "";
                    txtEmail.Text = "";
                    txtPhone.Text = "";
                    txtAddress.Text = "";
                    txtWard.Text = "";

                    // Tải lại dữ liệu vào DataGridView
                    LoadAllData();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi thêm người dùng: " + ex.Message);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim(); // Có thể để trống nếu không muốn đổi mật khẩu
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();
            string ward = txtWard.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng chọn tài khoản để sửa.");
                return;
            }

            // Validate các thông tin khác
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không hợp lệ.");
                return;
            }

            if (!Regex.IsMatch(phone, @"^\d{10,11}$"))
            {
                MessageBox.Show("Số điện thoại phải gồm 10 hoặc 11 chữ số.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                string query;

                SqlCommand cmd;

                if (!string.IsNullOrEmpty(password))
                {
                    // Có nhập mật khẩu mới → validate và cập nhật luôn
                    if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$"))
                    {
                        MessageBox.Show("Password phải từ 6 ký tự trở lên và bao gồm chữ hoa, chữ thường và số.");
                        return;
                    }

                    string hashedPassword = maHoaMatKhau.HashPassword(password);

                    query = @"UPDATE Users 
                      SET Password = @Password, 
                          FullName = @FullName, 
                          Email = @Email, 
                          Phone = @Phone, 
                          Address = @Address, 
                          Ward = @Ward 
                      WHERE Username = @Username";

                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);
                }
                else
                {
                    // Không cập nhật mật khẩu
                    query = @"UPDATE Users 
                      SET FullName = @FullName, 
                          Email = @Email, 
                          Phone = @Phone, 
                          Address = @Address, 
                          Ward = @Ward 
                      WHERE Username = @Username";

                    cmd = new SqlCommand(query, conn);
                }

                // Các parameter chung
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@Ward", ward);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin người dùng thành công!");
                        LoadAllData();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy người dùng để cập nhật.");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
                            string username = row["Username"].ToString().Trim();
                            string password = row["Password"].ToString().Trim();
                            string fullName = row["FullName"].ToString().Trim();
                            string email = row["Email"].ToString().Trim();
                            string phone = row["Phone"].ToString().Trim();
                            string address = row["Address"].ToString().Trim();
                            string ward = row["Ward"].ToString().Trim();
                            string role = "User";

                            // Mã hóa password trước khi lưu
                            string hashedPassword = maHoaMatKhau.HashPassword(password);

                            using (SqlConnection conn = new SqlConnection(DB.connectionString))
                            {
                                string query = @"INSERT INTO Users (Username, Password, FullName, Email, Phone, Address, Ward, Role)
                                         VALUES (@Username, @Password, @FullName, @Email, @Phone, @Address, @Ward, @Role)";
                                using (SqlCommand cmd = new SqlCommand(query, conn))
                                {
                                    cmd.Parameters.AddWithValue("@Username", username);
                                    cmd.Parameters.AddWithValue("@Password", hashedPassword);
                                    cmd.Parameters.AddWithValue("@FullName", fullName);
                                    cmd.Parameters.AddWithValue("@Email", email);
                                    cmd.Parameters.AddWithValue("@Phone", phone);
                                    cmd.Parameters.AddWithValue("@Address", address);
                                    cmd.Parameters.AddWithValue("@Ward", ward);
                                    cmd.Parameters.AddWithValue("@Role", role);

                                    try
                                    {
                                        conn.Open();
                                        cmd.ExecuteNonQuery();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show($"Lỗi thêm user {username}: {ex.Message}");
                                    }
                                }
                            }
                        }

                        MessageBox.Show("Import Excel thành công!");
                        LoadAllData(); // Load lại bảng
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
            saveFileDialog.FileName = "DanhSachTaiKhoan.xlsx";

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
                        workbook.Worksheets.Add(dt, "TaiKhoan");
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
    }
}
