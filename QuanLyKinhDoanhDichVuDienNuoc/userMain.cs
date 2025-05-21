using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyKinhDoanhDichVuDienNuoc
{

    public partial class userMain : Form
    {
        private string currentUsername;
        public string currentUser = "";

        public userMain(string username)
        {
            InitializeComponent();
            currentUsername = username;

            // Hiển thị tên người dùng trên label (ví dụ label2)
            label2.Text = $"Xin chào {currentUsername}!";
            LoadUserControl(new TTCN());
        }

        

        public void LoadUserControl(UserControl uc)
        {
            mainPanel.Controls.Clear();         // Xóa nội dung cũ
            uc.Dock = DockStyle.Fill;           // Đổ đầy panel
            mainPanel.Controls.Add(uc);         // Thêm vào panel
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmLogin f2 = new frmLogin();
            f2.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadUserControl(new TTCN());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadUserControl(new LSTT());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadUserControl(new TKHT());

        }
        private void button4_Click(object sender, EventArgs e)
        {
            LoadUserControl(new TTHĐ());

        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadUserControl(new LHA());

        }

        private void userMain_Load(object sender, EventArgs e)
        {

        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

