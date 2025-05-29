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
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.btnXacNhan = new RoundButton();
            this.SuspendLayout();
            // 
            // cbPhuongThuc
            // 
            this.cbPhuongThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbPhuongThuc.Location = new System.Drawing.Point(380, 47);
            this.cbPhuongThuc.Name = "cbPhuongThuc";
            this.cbPhuongThuc.Size = new System.Drawing.Size(239, 33);
            this.cbPhuongThuc.TabIndex = 1;
            this.cbPhuongThuc.SelectedIndexChanged += new System.EventHandler(this.cbPhuongThuc_SelectedIndexChanged);
            // 
            // panelNoiDung
            // 
            this.panelNoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.panelNoiDung.Location = new System.Drawing.Point(98, 86);
            this.panelNoiDung.Name = "panelNoiDung";
            this.panelNoiDung.Size = new System.Drawing.Size(521, 200);
            this.panelNoiDung.TabIndex = 2;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTieuDe.Location = new System.Drawing.Point(98, 51);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(276, 23);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Chọn phương thức thanh toán:";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.AutoSize = true;
            this.btnXacNhan.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnXacNhan.BorderColor = System.Drawing.Color.White;
            this.btnXacNhan.BorderRadius = 30;
            this.btnXacNhan.BorderThickness = 2;
            this.btnXacNhan.FlatAppearance.BorderSize = 0;
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(85)))), ((int)(((byte)(174)))));
            this.btnXacNhan.Location = new System.Drawing.Point(276, 308);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(123, 35);
            this.btnXacNhan.TabIndex = 52;
            this.btnXacNhan.Text = "Thanh toán";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
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
            this.Size = new System.Drawing.Size(742, 517);
            this.Load += new System.EventHandler(this.TTO_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.ComboBox cbPhuongThuc;
        private System.Windows.Forms.Panel panelNoiDung;
        private System.Windows.Forms.Label lblTieuDe;
        private RoundButton btnXacNhan;
        #endregion
    }
}
