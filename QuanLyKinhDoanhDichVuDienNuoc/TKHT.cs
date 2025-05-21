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
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyKinhDoanhDichVuDienNuoc
{
    public partial class TKHT : UserControl
    {
        public TKHT()
        {
            InitializeComponent();
        }

        private void TKHT_Load(object sender, EventArgs e)
        {
            LoadBieuDoChiSoDienVaNuoc(frmLogin.UserSession.CurrentUserID);
        }
        private void LoadBieuDoChiSoDienVaNuoc(int userID)
        {
            chartThongKe.Series.Clear();
            chartThongKe.ChartAreas.Clear();
            chartThongKe.Titles.Clear();

            chartThongKe.ChartAreas.Add("MainArea");
            chartThongKe.Titles.Add("Biểu đồ thống kê chỉ số điện và nước theo tháng dựa trên lịch sử thanh toán");

            // Series cho điện
            Series seriesDien = new Series("Chỉ số điện");
            seriesDien.ChartType = SeriesChartType.Column;
            seriesDien.XValueType = ChartValueType.String;

            // Series cho nước
            Series seriesNuoc = new Series("Chỉ số nước");
            seriesNuoc.ChartType = SeriesChartType.Column;
            seriesNuoc.XValueType = ChartValueType.String;

            // Lấy dữ liệu chỉ số điện
            using (SqlConnection conn = new SqlConnection(DB.connectionString))
            {
                string queryDien = @"
            SELECT 
                FORMAT(CONVERT(date, '01/' + ThoiGian, 103), 'MM/yyyy') AS ThangNam,
                SUM(ChiSoDien) AS TongChiSoDien
            FROM HoaDonDien
            WHERE UserID = @UserID AND YEAR(CONVERT(date, '01/' + ThoiGian, 103)) = @NamHienTai
            GROUP BY FORMAT(CONVERT(date, '01/' + ThoiGian, 103), 'MM/yyyy')
            ORDER BY ThangNam";

                SqlCommand cmdDien = new SqlCommand(queryDien, conn);
                cmdDien.Parameters.AddWithValue("@UserID", userID);
                cmdDien.Parameters.AddWithValue("@NamHienTai", DateTime.Now.Year);

                conn.Open();
                SqlDataReader readerDien = cmdDien.ExecuteReader();
                while (readerDien.Read())
                {
                    string thangNam = readerDien.GetString(0);
                    int tongChiSoDien = readerDien.GetInt32(1);
                    seriesDien.Points.AddXY(thangNam, tongChiSoDien);
                }
                readerDien.Close();

                // Lấy dữ liệu chỉ số nước
                string queryNuoc = @"
            SELECT 
                FORMAT(CONVERT(date, '01/' + ThoiGian, 103), 'MM/yyyy') AS ThangNam,
                SUM(ChiSoNuoc) AS TongChiSoNuoc
            FROM HoaDonNuoc
            WHERE UserID = @UserID AND YEAR(CONVERT(date, '01/' + ThoiGian, 103)) = @NamHienTai
            GROUP BY FORMAT(CONVERT(date, '01/' + ThoiGian, 103), 'MM/yyyy')
            ORDER BY ThangNam";

                SqlCommand cmdNuoc = new SqlCommand(queryNuoc, conn);
                cmdNuoc.Parameters.AddWithValue("@UserID", userID);
                cmdNuoc.Parameters.AddWithValue("@NamHienTai", DateTime.Now.Year);

                SqlDataReader readerNuoc = cmdNuoc.ExecuteReader();
                while (readerNuoc.Read())
                {
                    string thangNam = readerNuoc.GetString(0);
                    int tongChiSoNuoc = readerNuoc.GetInt32(1);
                    seriesNuoc.Points.AddXY(thangNam, tongChiSoNuoc);
                }
                readerNuoc.Close();
                conn.Close();
            }

            chartThongKe.Series.Add(seriesDien);
            chartThongKe.Series.Add(seriesNuoc);
        }


    }
}

