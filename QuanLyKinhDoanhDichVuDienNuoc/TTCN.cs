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
    public partial class TTCN : UserControl
    {
        public TTCN()
        {
            InitializeComponent();
        }

        private void LoadUserData()
        {
            int userId = CurrentUser.UserID;

            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                string query = "SELECT Username, Password, FullName, Email, Phone, Address FROM Users WHERE UserID = @UserID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);

                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            textB_username.Text = reader["Username"].ToString();
                            textB_password.Text = reader["Password"].ToString();
                            textB_fullName.Text = reader["FullName"].ToString();
                            textB_email.Text = reader["Email"].ToString();
                            textB_phone.Text = reader["Phone"].ToString();
                            textB_address.Text = reader["Address"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin người dùng.", "Thông báo");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message);
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TTCN_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bt_luu_Click(object sender, EventArgs e)
        {
            int userId = CurrentUser.UserID;

            string username = textB_username.Text.Trim();
            string password = textB_password.Text.Trim();
            string fullName = textB_fullName.Text.Trim();
            string email = textB_email.Text.Trim();
            string phone = textB_phone.Text.Trim();
            string address = textB_address.Text.Trim();

            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                string query = @"UPDATE Users 
                         SET Username = @Username, Password = @Password, 
                             FullName = @FullName, Email = @Email, 
                             Phone = @Phone, Address = @Address 
                         WHERE UserID = @UserID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@UserID", userId);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo");
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thất bại. Vui lòng thử lại.", "Lỗi");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật thông tin: " + ex.Message);
                    }
                }
            }
        }
    }
}
