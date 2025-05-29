namespace QuanLyKinhDoanhDichVuDienNuoc
{
    partial class LHA
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_lienhe = new RoundButton();
            this.btEmail = new RoundButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.bt_lienhe);
            this.panel1.Controls.Add(this.btEmail);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(876, 636);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // bt_lienhe
            // 
            this.bt_lienhe.AutoSize = true;
            this.bt_lienhe.BackColor = System.Drawing.Color.MidnightBlue;
            this.bt_lienhe.BorderColor = System.Drawing.Color.White;
            this.bt_lienhe.BorderRadius = 25;
            this.bt_lienhe.BorderThickness = 2;
            this.bt_lienhe.FlatAppearance.BorderSize = 0;
            this.bt_lienhe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_lienhe.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.bt_lienhe.ForeColor = System.Drawing.Color.White;
            this.bt_lienhe.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(85)))), ((int)(((byte)(174)))));
            this.bt_lienhe.Location = new System.Drawing.Point(267, 293);
            this.bt_lienhe.Name = "bt_lienhe";
            this.bt_lienhe.Size = new System.Drawing.Size(95, 52);
            this.bt_lienhe.TabIndex = 52;
            this.bt_lienhe.Text = "Liên hệ";
            this.bt_lienhe.UseVisualStyleBackColor = false;
            this.bt_lienhe.Click += new System.EventHandler(this.bt_lienhe_Click);
            // 
            // btEmail
            // 
            this.btEmail.AutoSize = true;
            this.btEmail.BackColor = System.Drawing.Color.MidnightBlue;
            this.btEmail.BorderColor = System.Drawing.Color.White;
            this.btEmail.BorderRadius = 25;
            this.btEmail.BorderThickness = 2;
            this.btEmail.FlatAppearance.BorderSize = 0;
            this.btEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEmail.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btEmail.ForeColor = System.Drawing.Color.White;
            this.btEmail.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(85)))), ((int)(((byte)(174)))));
            this.btEmail.Location = new System.Drawing.Point(490, 293);
            this.btEmail.Name = "btEmail";
            this.btEmail.Size = new System.Drawing.Size(95, 52);
            this.btEmail.TabIndex = 52;
            this.btEmail.Text = "Email";
            this.btEmail.UseVisualStyleBackColor = false;
            this.btEmail.Click += new System.EventHandler(this.btEmail_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label3.Location = new System.Drawing.Point(243, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(378, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Website: cskh.npc.com.vn - Email: cskh@npc.com.vn";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(174, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(512, 94);
            this.label2.TabIndex = 1;
            this.label2.Text = "TỔNG ĐÀI: 0945 876 583";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(168, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(551, 95);
            this.label1.TabIndex = 0;
            this.label1.Text = "TRUNG TÂM CHĂM SÓC KHÁCH HÀNG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LHA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "LHA";
            this.Size = new System.Drawing.Size(876, 636);
            this.Load += new System.EventHandler(this.LHA_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private RoundButton bt_lienhe;
        private RoundButton btEmail;
    }
}