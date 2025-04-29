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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            frmRegister f2 = new frmRegister();
            f2.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu.");
                return;
            }

            // Nếu là tài khoản admin cứng
            if (username == "admin" && password == "123456")
            {
                MessageBox.Show("Đăng nhập admin thành công!");
                frmAdminMain adminForm = new frmAdminMain();
                adminForm.Show();
                this.Hide();
                return;
            }

            // Nếu không phải admin thì kiểm tra trong database
            string hashedPassword = maHoaMatKhau.HashPassword(password);

            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @user AND Password = @pass";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", hashedPassword);

                try
                {
                    conn.Open();
                    int result = (int)cmd.ExecuteScalar();

                    if (result > 0)
                    {
                        MessageBox.Show("Đăng nhập người dùng thành công!");
                        userMain userForm = new userMain(username);
                        userForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đăng nhập: " + ex.Message);
                }
            }
        }

        

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void cbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = cbShowPass.Checked;
            txtPassword.UseSystemPasswordChar = !isChecked;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
