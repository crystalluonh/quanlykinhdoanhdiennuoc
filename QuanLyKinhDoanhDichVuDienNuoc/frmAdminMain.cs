using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKinhDoanhDichVuDienNuoc
{
    public partial class frmAdminMain : Form
    {
        public frmAdminMain()
        {
            InitializeComponent();
        }
        private void LoadUserControl(UserControl uc)
        {
            mainPanel.Controls.Clear();         // Xóa nội dung cũ
            uc.Dock = DockStyle.Fill;           // Đổ đầy panel
            mainPanel.Controls.Add(uc);         // Thêm vào panel
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmLogin f2 = new frmLogin();
            f2.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnQLTK_Click(object sender, EventArgs e)
        {
            LoadUserControl(new QLTK());
        }

        private void btnQLKH_Click(object sender, EventArgs e)
        {
            LoadUserControl(new QLKH());
        }

        private void btnQLCSĐN_Click(object sender, EventArgs e)
        {
            LoadUserControl(new QLCSĐN());
        }

        private void btnHĐ_Click(object sender, EventArgs e)
        {
            LoadUserControl(new QLHĐ());
        }
    }
}
