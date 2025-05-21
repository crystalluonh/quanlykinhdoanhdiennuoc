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
            LoadUserControl(new QLTK());
        }
        private void LoadUserControl(UserControl uc)
        {
            mainPanel.Controls.Clear();         // Xóa nội dung cũ
            uc.Dock = DockStyle.Fill;           // Đổ đầy panel
            mainPanel.Controls.Add(uc);         // Thêm vào panel
        }

       

        private void button5_Click(object sender, EventArgs e)
        {
            frmLogin f2 = new frmLogin();
            f2.Show();
            this.Close();
        }

        private void btnQLTK_Click(object sender, EventArgs e)
        {
            LoadUserControl(new QLTK());
        }
        private void btnQLCSĐN_Click(object sender, EventArgs e)
        {
            LoadUserControl(new QLCSĐN());
        }

        private void btnHĐ_Click(object sender, EventArgs e)
        {
            LoadUserControl(new QLHĐĐ());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadUserControl(new QLHĐN());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LoadUserControl(new QLTTHĐ());
        }

    }
}
