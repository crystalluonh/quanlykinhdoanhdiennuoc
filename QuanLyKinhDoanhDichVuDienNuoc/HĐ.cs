using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace QuanLyKinhDoanhDichVuDienNuoc
{
    public partial class HĐ : UserControl
    {
        public HĐ()
        {
            InitializeComponent();
        }

        private void HĐ_Load(object sender, EventArgs e)
        {

        }
        public void HienThiHoaDon(string maHD, string tenKH, string loaiDV, string thoiGian, string chiSo, string phuongXa, string diaChi, bool trangThaiThanhToan, DateTime? ngayThanhToan, string tongTien)
        {
            lblMaHD1.Text = maHD;
            lblTenKH1.Text = tenKH;
            lblLoaiDV1.Text = loaiDV;
            lblThoiGian1.Text = thoiGian;
            lblChiSo1.Text = chiSo;
            lblPhuong1.Text = phuongXa;
            lblDiaChi1.Text = diaChi;
            lblTrangThai1.Text = trangThaiThanhToan ? "Đã thanh toán" : "Chưa thanh toán";
            lblNgayThanhToan1.Text = ngayThanhToan.HasValue ? ngayThanhToan.Value.ToString("dd/MM/yyyy") : " ";
            lblTongTien1.Text = tongTien + " VNĐ";

            btnThanhToanOnline.Enabled = !trangThaiThanhToan;

            // ✅ Đổi hình nền theo loại dịch vụ
            if (loaiDV.Trim().ToLower().Contains("điện"))
            {
                this.BackgroundImage = Properties.Resources.bgDien;
            }
            else if (loaiDV.Trim().ToLower().Contains("nước"))
            {
                this.BackgroundImage = Properties.Resources.bgNuoc;
            }

            // Đặt chế độ hiển thị hình nền (Stretch cho vừa khung)
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThanhToanOnline_Click(object sender, EventArgs e)
        {
            userMain frmMain = (userMain)this.FindForm();
            TTO tTO = new TTO();
            tTO.CurrentUserID = frmLogin.UserSession.CurrentUserID;  // Lấy từ session
            frmMain.LoadUserControl(tTO);
            string maHD = lblMaHD1.Text.Replace("Mã hóa đơn:", "").Trim();
            tTO.MaHoaDon = maHD;
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            userMain frmMain = (userMain)this.FindForm();
            TTHĐ tt = new TTHĐ();
            frmMain.LoadUserControl(tt);
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            // Mở hộp thoại lưu file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt";
            saveFileDialog.Title = "Xuất hóa đơn ra file";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    // Nội dung file hóa đơn
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("===== HÓA ĐƠN THANH TOÁN =====");
                    sb.AppendLine(lblMaHD.Text + lblMaHD1.Text);
                    sb.AppendLine(lblTenKH.Text + lblTenKH1.Text);
                    sb.AppendLine(lblLoaiDV.Text + lblLoaiDV1.Text);
                    sb.AppendLine(lblThoiGian.Text + lblThoiGian1.Text);
                    sb.AppendLine(lblChiSo.Text + lblChiSo1.Text);
                    sb.AppendLine(lblPhuong.Text + lblPhuong1.Text);
                    sb.AppendLine(lblDiaChi.Text + lblDiaChi1.Text);
                    sb.AppendLine(lblTrangThai.Text + lblTrangThai1.Text);
                    sb.AppendLine(lblNgayThanhToan.Text + lblNgayThanhToan1.Text);
                    sb.AppendLine(lblTongTien.Text + lblTongTien1.Text);
                    sb.AppendLine("==============================");

                    // Ghi vào file
                    File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);

                    MessageBox.Show("Xuất file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
