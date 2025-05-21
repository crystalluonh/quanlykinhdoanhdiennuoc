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

namespace QuanLyKinhDoanhDichVuDienNuoc
{
    public partial class TTCN : UserControl
    {
        public TTCN()
        {
            InitializeComponent();
        }

       
        private void LoadUserInfo()
        {
            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                string query = "SELECT * FROM Users WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", CurrentUser.Username);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtFullName.Text = reader["FullName"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                        txtPhone.Text = reader["Phone"].ToString();
                        txtAddress.Text = reader["Address"].ToString();
                        txtWard.Text = reader["Ward"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải thông tin người dùng: " + ex.Message);
                }
            }
        }
        private void TTCN_Load(object sender, EventArgs e)
        {
            txtUsername.Text = CurrentUser.Username;
            txtUsername.Enabled = false; // nếu không muốn cho sửa
            LoadUserInfo();
            txtWard.Items.AddRange(new string[]
   {
        "Hà Cầu", "La Khê", "Mộ Lao", "Nguyễn Trãi", "Phú La", "Phúc La",
        "Quang Trung", "Vạn Phúc", "Văn Quán", "Yết Kiêu",
        "Biên Giang", "Đồng Mai", "Dương Nội", "Kiến Hưng", "Phú Lãm",
        "Phú Lương", "Yên Nghĩa"
   });
        }
        

        private void bt_luu_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();
            string ward = txtWard.Text.Trim();
            string role = "User";  // Mặc định Role là User
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }

