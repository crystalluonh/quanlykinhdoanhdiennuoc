using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


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
            LoadData();
            dgvTaiKhoan.RowPrePaint += new DataGridViewRowPrePaintEventHandler(dgvTaiKhoan_RowPrePaint);
            dgvTaiKhoan.SelectionChanged += new EventHandler(dgvTaiKhoan_SelectionChanged);
        }

        private void dgvTaiKhoan_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (!dgvTaiKhoan.Rows[e.RowIndex].IsNewRow)
            {
                dgvTaiKhoan.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
            }
        }

        private void dgvTaiKhoan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvTaiKhoan.SelectedRows[0];
                textUser.Text = selectedRow.Cells["usernameDataGridViewTextBoxColumn"].Value?.ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

       

      

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string role = cbRole.SelectedItem != null ? cbRole.SelectedItem.ToString().Trim() : "";

            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Vui lòng nhập username hoặc chọn role để tìm kiếm!");
                return;
            }

            string connectionString = "Data Source=DESKTOP-0C1U9KG;Initial Catalog=dien_nuoc;Integrated Security=True";
            string query = "SELECT Username, Password, Role FROM Users WHERE 1=1";

            if (!string.IsNullOrEmpty(username))
                query += " AND Username LIKE @Username";
            if (!string.IsNullOrEmpty(role))
                query += " AND Role = @Role";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(username))
                        cmd.Parameters.AddWithValue("@Username", "%" + username + "%");
                    if (!string.IsNullOrEmpty(role))
                        cmd.Parameters.AddWithValue("@Role", role);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvTaiKhoan.DataSource = dt;
                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

      

       

        private void pnlMainContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void dgvTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadData()
        {
            string connectionString = "Data Source=DESKTOP-0C1U9KG;Initial Catalog=dien_nuoc;Integrated Security=True";
            string query = "SELECT Username, Password, Role FROM Users";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvTaiKhoan.DataSource = dt;
            }
        }

        private void textUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.SelectedRows.Count > 0)
            {
                // Lấy Username gốc của dòng được chọn
                DataGridViewRow selectedRow = dgvTaiKhoan.SelectedRows[0];
                string oldUsername = selectedRow.Cells["usernameDataGridViewTextBoxColumn"].Value?.ToString();

                // Lấy dữ liệu mới từ các TextBox
                string newUsername = textUser.Text.Trim();
                string newPassword = txtPassword.Text.Trim();
                string role = cbRole.SelectedItem?.ToString().Trim();

                if (string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(role))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }

                string connectionString = "Data Source=DESKTOP-0C1U9KG;Initial Catalog=dien_nuoc;Integrated Security=True";
                string query = "UPDATE Users SET Username = @NewUsername, Password = @Password, Role = @Role WHERE Username = @OldUsername";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NewUsername", newUsername);
                        cmd.Parameters.AddWithValue("@Password", newPassword);
                        cmd.Parameters.AddWithValue("@Role", role);
                        cmd.Parameters.AddWithValue("@OldUsername", oldUsername);

                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        conn.Close();

                        if (result > 0)
                        {
                            MessageBox.Show("Sửa tài khoản thành công!");
                            LoadData(); // Cập nhật lại DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Sửa tài khoản thất bại!");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để sửa!");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = cbRole.SelectedItem?.ToString().Trim() ?? "";

           

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            string connectionString = "Data Source=DESKTOP-0C1U9KG;Initial Catalog=dien_nuoc;Integrated Security=True";
            string query = "INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Role", role);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (result > 0)
                    {
                        MessageBox.Show("Thêm tài khoản thành công!");
                        LoadData(); // Cập nhật lại DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Thêm tài khoản thất bại!");
                    }
                }
            }
        }

        private void QLTK_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.SelectedRows.Count > 0)
            {
                // Lấy Username của dòng được chọn
                DataGridViewRow selectedRow = dgvTaiKhoan.SelectedRows[0];
                string username = selectedRow.Cells["usernameDataGridViewTextBoxColumn"].Value?.ToString();

                if (string.IsNullOrEmpty(username))
                {
                    MessageBox.Show("Không tìm thấy tài khoản để xóa!");
                    return;
                }

                // Xác nhận xóa
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.No)
                    return;

                string connectionString = "Data Source=DESKTOP-0C1U9KG;Initial Catalog=dien_nuoc;Integrated Security=True";
                string query = "DELETE FROM Users WHERE Username = @Username";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);

                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        conn.Close();

                        if (result > 0)
                        {
                            MessageBox.Show("Xóa tài khoản thành công!");
                            LoadData(); // Cập nhật lại DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Xóa tài khoản thất bại!");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để xóa!");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            textUser.Text = "";      // Reset ô "Đã chọn"
            txtUsername.Text = "";   // Reset ô nhập username
            txtPassword.Text = "";   // Reset ô nhập password
            cbRole.SelectedIndex = -1; // Bỏ chọn ComboBox
            LoadData(); // Hiển thị lại toàn bộ dữ liệu
        }

        
    }
}
