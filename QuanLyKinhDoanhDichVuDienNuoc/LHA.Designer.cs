﻿namespace QuanLyKinhDoanhDichVuDienNuoc
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
            this.bt_lienhe = new System.Windows.Forms.Button();
            this.btEmail = new System.Windows.Forms.Button();
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
            this.bt_lienhe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.bt_lienhe.Location = new System.Drawing.Point(266, 276);
            this.bt_lienhe.Name = "bt_lienhe";
            this.bt_lienhe.Size = new System.Drawing.Size(101, 54);
            this.bt_lienhe.TabIndex = 5;
            this.bt_lienhe.Text = "Liên hệ";
            this.bt_lienhe.UseVisualStyleBackColor = true;
            // 
            // btEmail
            // 
            this.btEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btEmail.Location = new System.Drawing.Point(503, 276);
            this.btEmail.Name = "btEmail";
            this.btEmail.Size = new System.Drawing.Size(101, 54);
            this.btEmail.TabIndex = 4;
            this.btEmail.Text = "Email";
            this.btEmail.UseVisualStyleBackColor = true;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btEmail;
        private System.Windows.Forms.Button bt_lienhe;
    }
}