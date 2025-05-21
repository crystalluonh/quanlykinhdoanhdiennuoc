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
    public partial class frmRegister : Form
    {
        SqlConnection conn = new SqlConnection(DB.connectionString);
        public frmRegister()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            Font commonFont = new Font("Segoe UI", 16); // Gọn, đều, hiện đại
            txtPassword.Height = 28;
            txtConfirmPassword.Height = 28;
            txtPassword.Font = commonFont;
            txtConfirmPassword.Font = commonFont;
            txtUsername.Font = commonFont;

            txtPassword.PasswordChar = '•';
            txtConfirmPassword.PasswordChar = '•';
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            frmLogin f2 = new frmLogin();
            f2.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string hashedPassword = maHoaMatKhau.HashPassword(password);

            // 1. Kiểm tra các trường không để trống
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            // 2. Kiểm tra định dạng Username (chữ + số, 4-20 ký tự)
            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9]{4,20}$"))
            {
                MessageBox.Show("Username phải từ 4 đến 20 ký tự, chỉ gồm chữ cái và số.");
                return;
            }

            // 3. Kiểm tra định dạng Password (ít nhất 6 ký tự, có chữ hoa, thường và số)
            if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$"))
            {
                MessageBox.Show("Password phải từ 6 ký tự trở lên và bao gồm chữ hoa, chữ thường và số.");
                return;
            }

            // 4. Kiểm tra mật khẩu xác nhận
            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.");
                return;
            }

            // 5. Ghi vào SQL
            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                string query = "INSERT INTO Users (Username, Password, Role) VALUES (@user, @pass, 'User')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", hashedPassword);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đăng ký thành công!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi đăng ký: " + ex.Message);
                }
            }

            frmLogin f2 = new frmLogin();
            f2.Show();
            this.Hide();
        }

        private void cbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = cbShowPass.Checked;

            if (isChecked)
            {
                txtPassword.PasswordChar = '\0'; // Hiện mật khẩu (bỏ ký tự thay thế)
                txtConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•'; // Ẩn mật khẩu bằng ký tự gọn
                txtConfirmPassword.PasswordChar = '•';
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
