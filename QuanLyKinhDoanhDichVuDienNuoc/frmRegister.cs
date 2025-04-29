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
    public partial class frmRegister : Form
    {
        SqlConnection conn = new SqlConnection(DB.connectionString);
        public frmRegister()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
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

            // 2. Kiểm tra mật khẩu xác nhận
            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.");
                return;
            }

            // 3. Ghi vào SQL
            using (SqlConnection conn = new SqlConnection(DB.connectionString)) // dùng connection từ lớp DB
            {
                string query = "INSERT INTO Users (Username, Password) VALUES (@user, @pass)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", hashedPassword); // Có thể mã hóa trước

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

            txtPassword.UseSystemPasswordChar = !isChecked;
            txtConfirmPassword.UseSystemPasswordChar = !isChecked;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
