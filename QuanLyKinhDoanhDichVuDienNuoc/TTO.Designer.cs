namespace QuanLyKinhDoanhDichVuDienNuoc
{
    partial class TTO
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbPhuongThuc = new System.Windows.Forms.ComboBox();
            this.panelNoiDung = new System.Windows.Forms.Panel();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbPhuongThuc
            // 
            this.cbPhuongThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbPhuongThuc.Location = new System.Drawing.Point(389, 60);
            this.cbPhuongThuc.Name = "cbPhuongThuc";
            this.cbPhuongThuc.Size = new System.Drawing.Size(239, 33);
            this.cbPhuongThuc.TabIndex = 1;
            this.cbPhuongThuc.SelectedIndexChanged += new System.EventHandler(this.cbPhuongThuc_SelectedIndexChanged);
            // 
            // panelNoiDung
            // 
            this.panelNoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.panelNoiDung.Location = new System.Drawing.Point(107, 99);
            this.panelNoiDung.Name = "panelNoiDung";
            this.panelNoiDung.Size = new System.Drawing.Size(521, 200);
            this.panelNoiDung.TabIndex = 2;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXacNhan.Location = new System.Drawing.Point(245, 319);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(120, 35);
            this.btnXacNhan.TabIndex = 3;
            this.btnXacNhan.Text = "Xác nhận thanh toán";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTieuDe.Location = new System.Drawing.Point(107, 64);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(276, 23);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Chọn phương thức thanh toán:";
            // 
            // TTO
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.cbPhuongThuc);
            this.Controls.Add(this.panelNoiDung);
            this.Controls.Add(this.btnXacNhan);
            this.Name = "TTO";
            this.Size = new System.Drawing.Size(657, 517);
            this.Load += new System.EventHandler(this.TTO_Load);
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.ComboBox cbPhuongThuc;
        private System.Windows.Forms.Panel panelNoiDung;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Label lblTieuDe;
        #endregion
    }
}
