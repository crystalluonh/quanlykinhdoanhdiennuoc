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

            string hashedPassword = password;

            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                string query = "SELECT UserID, Role FROM Users WHERE Username = @user AND Password = @pass";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", hashedPassword);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int userId = Convert.ToInt32(reader["UserID"]);
                        string role = reader["Role"].ToString().Trim().ToLower();

                        CurrentUser.UserID = userId;
                        CurrentUser.Username = username;

                        if (role == "admin")
                        {
                            MessageBox.Show("Đăng nhập Admin thành công!");
                            frmAdminMain adminForm = new frmAdminMain();
                            adminForm.Show();
                        }
                        else if (role == "user")
                        {
                            MessageBox.Show("Đăng nhập User thành công!");
                            userMain userForm = new userMain(username); // Có thể bỏ username nếu không cần
                            userForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản không có quyền truy cập hợp lệ.");
                            return;
                        }

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
