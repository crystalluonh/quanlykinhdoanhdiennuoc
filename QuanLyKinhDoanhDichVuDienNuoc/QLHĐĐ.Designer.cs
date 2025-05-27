namespace QuanLyKinhDoanhDichVuDienNuoc
{
    partial class QLHĐĐ
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvAccounts = new System.Windows.Forms.DataGridView();
            this.colUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiDichVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtMaHoaDon = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.lblWard = new System.Windows.Forms.Label();
            this.txtWard = new System.Windows.Forms.ComboBox();
            this.lblStreet = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.cbLoaiDichVu = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtChiSoDien = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtThoiGian = new System.Windows.Forms.DateTimePicker();
            this.btnThemFile = new System.Windows.Forms.Button();
            this.btnXuatFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 305);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 23);
            this.label1.TabIndex = 42;
            this.label1.Text = "Loại dịch vụ:";
            // 
            // lblSearch
            // 
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblSearch.Location = new System.Drawing.Point(108, 20);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(41, 19);
            this.lblSearch.TabIndex = 22;
            this.lblSearch.Text = "Tìm:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(155, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 22);
            this.txtSearch.TabIndex = 23;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(461, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(77, 33);
            this.btnSearch.TabIndex = 24;
            this.btnSearch.Text = "Tìm Kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvAccounts
            // 
            this.dgvAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAccounts.ColumnHeadersHeight = 65;
            this.dgvAccounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUsername,
            this.LoaiDichVu,
            this.Column1,
            this.TenKhachHang,
            this.colWard,
            this.colAddress,
            this.Column2,
            this.Column3});
            this.dgvAccounts.Location = new System.Drawing.Point(3, 70);
            this.dgvAccounts.Name = "dgvAccounts";
            this.dgvAccounts.RowHeadersWidth = 51;
            this.dgvAccounts.Size = new System.Drawing.Size(651, 175);
            this.dgvAccounts.TabIndex = 25;
            this.dgvAccounts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAccounts_CellContentClick);
            // 
            // colUsername
            // 
            this.colUsername.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colUsername.DataPropertyName = "MaHoaDon";
            this.colUsername.HeaderText = "Mã hóa đơn";
            this.colUsername.MinimumWidth = 6;
            this.colUsername.Name = "colUsername";
            this.colUsername.Width = 40;
            // 
            // LoaiDichVu
            // 
            this.LoaiDichVu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LoaiDichVu.DataPropertyName = "LoaiDichVu";
            this.LoaiDichVu.HeaderText = "Loại dịch vụ";
            this.LoaiDichVu.MinimumWidth = 6;
            this.LoaiDichVu.Name = "LoaiDichVu";
            this.LoaiDichVu.Width = 80;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.DataPropertyName = "ThoiGian";
            dataGridViewCellStyle1.Format = "M";
            dataGridViewCellStyle1.NullValue = null;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Thời gian";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 70;
            // 
            // TenKhachHang
            // 
            this.TenKhachHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TenKhachHang.DataPropertyName = "TenKhachHang";
            this.TenKhachHang.HeaderText = "Tên khách hàng";
            this.TenKhachHang.MinimumWidth = 6;
            this.TenKhachHang.Name = "TenKhachHang";
            this.TenKhachHang.Width = 120;
            // 
            // colWard
            // 
            this.colWard.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colWard.DataPropertyName = "PhuongXa";
            this.colWard.HeaderText = "Phường/Xã";
            this.colWard.MinimumWidth = 6;
            this.colWard.Name = "colWard";
            this.colWard.Width = 80;
            // 
            // colAddress
            // 
            this.colAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colAddress.DataPropertyName = "DiaChi";
            this.colAddress.HeaderText = "Địa chỉ";
            this.colAddress.MinimumWidth = 6;
            this.colAddress.Name = "colAddress";
            this.colAddress.Width = 125;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.DataPropertyName = "ChiSoDien";
            this.Column2.HeaderText = "Chỉ số điện";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 40;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.DataPropertyName = "TongTien";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column3.HeaderText = "Tổng tiền";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 90;
            // 
            // lblUsername
            // 
            this.lblUsername.Location = new System.Drawing.Point(10, 270);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(110, 23);
            this.lblUsername.TabIndex = 26;
            this.lblUsername.Text = "Mã hóa đơn:";
            // 
            // txtMaHoaDon
            // 
            this.txtMaHoaDon.Location = new System.Drawing.Point(137, 267);
            this.txtMaHoaDon.Name = "txtMaHoaDon";
            this.txtMaHoaDon.Size = new System.Drawing.Size(517, 22);
            this.txtMaHoaDon.TabIndex = 27;
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(7, 339);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(108, 23);
            this.lblFullName.TabIndex = 28;
            this.lblFullName.Text = "Tên khách hàng:";
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(139, 340);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(515, 22);
            this.txtTenKH.TabIndex = 29;
            // 
            // lblWard
            // 
            this.lblWard.Location = new System.Drawing.Point(10, 381);
            this.lblWard.Name = "lblWard";
            this.lblWard.Size = new System.Drawing.Size(100, 23);
            this.lblWard.TabIndex = 34;
            this.lblWard.Text = "Phường/Xã:";
            // 
            // txtWard
            // 
            this.txtWard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtWard.Items.AddRange(new object[] {
            "Hà Cầu",
            "La Khê",
            "Mộ Lao",
            "Nguyễn Trãi",
            "Phú La",
            "Phúc La",
            "Quang Trung",
            "Vạn Phúc",
            "Văn Quán",
            "Yết Kiêu",
            "Biên Giang",
            "Đồng Mai",
            "Dương Nội",
            "Kiến Hưng",
            "Phú Lãm",
            "Phú Lương",
            "Yên Nghĩa"});
            this.txtWard.Location = new System.Drawing.Point(137, 378);
            this.txtWard.Name = "txtWard";
            this.txtWard.Size = new System.Drawing.Size(150, 24);
            this.txtWard.TabIndex = 35;
            // 
            // lblStreet
            // 
            this.lblStreet.Location = new System.Drawing.Point(309, 385);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(70, 23);
            this.lblStreet.TabIndex = 36;
            this.lblStreet.Text = "Địa chỉ:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(385, 381);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(269, 22);
            this.txtAddress.TabIndex = 37;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(10, 468);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(72, 31);
            this.btnAdd.TabIndex = 38;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(123, 468);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(72, 31);
            this.btnEdit.TabIndex = 39;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(236, 468);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(72, 31);
            this.btnDelete.TabIndex = 40;
            this.btnDelete.Text = "Xoá";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(354, 468);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(72, 31);
            this.btnReset.TabIndex = 41;
            this.btnReset.Text = "Làm mới";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cbLoaiDichVu
            // 
            this.cbLoaiDichVu.FormattingEnabled = true;
            this.cbLoaiDichVu.Location = new System.Drawing.Point(139, 305);
            this.cbLoaiDichVu.Name = "cbLoaiDichVu";
            this.cbLoaiDichVu.Size = new System.Drawing.Size(515, 24);
            this.cbLoaiDichVu.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 421);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 44;
            this.label2.Text = "Chỉ số điện:";
            // 
            // txtChiSoDien
            // 
            this.txtChiSoDien.Location = new System.Drawing.Point(137, 418);
            this.txtChiSoDien.Name = "txtChiSoDien";
            this.txtChiSoDien.Size = new System.Drawing.Size(150, 22);
            this.txtChiSoDien.TabIndex = 48;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(309, 421);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 49;
            this.label3.Text = "Thời gian:";
            // 
            // dtThoiGian
            // 
            this.dtThoiGian.CustomFormat = "MM/yyyy";
            this.dtThoiGian.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtThoiGian.Location = new System.Drawing.Point(385, 418);
            this.dtThoiGian.Name = "dtThoiGian";
            this.dtThoiGian.ShowUpDown = true;
            this.dtThoiGian.Size = new System.Drawing.Size(269, 22);
            this.dtThoiGian.TabIndex = 50;
            // 
            // btnThemFile
            // 
            this.btnThemFile.Location = new System.Drawing.Point(461, 468);
            this.btnThemFile.Name = "btnThemFile";
            this.btnThemFile.Size = new System.Drawing.Size(72, 31);
            this.btnThemFile.TabIndex = 51;
            this.btnThemFile.Text = "Thêm file";
            this.btnThemFile.UseVisualStyleBackColor = true;
            this.btnThemFile.Click += new System.EventHandler(this.btnThemFile_Click);
            // 
            // btnXuatFile
            // 
            this.btnXuatFile.Location = new System.Drawing.Point(571, 468);
            this.btnXuatFile.Name = "btnXuatFile";
            this.btnXuatFile.Size = new System.Drawing.Size(72, 31);
            this.btnXuatFile.TabIndex = 52;
            this.btnXuatFile.Text = "Xuất file";
            this.btnXuatFile.UseVisualStyleBackColor = true;
            this.btnXuatFile.Click += new System.EventHandler(this.btnXuatFile_Click);
            // 
            // QLHĐĐ
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.btnXuatFile);
            this.Controls.Add(this.btnThemFile);
            this.Controls.Add(this.dtThoiGian);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtChiSoDien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbLoaiDichVu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvAccounts);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtMaHoaDon);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtTenKH);
            this.Controls.Add(this.lblWard);
            this.Controls.Add(this.txtWard);
            this.Controls.Add(this.lblStreet);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnReset);
            this.Name = "QLHĐĐ";
            this.Size = new System.Drawing.Size(657, 517);
            this.Load += new System.EventHandler(this.QLHĐĐ_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvAccounts;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtMaHoaDon;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label lblWard;
        private System.Windows.Forms.ComboBox txtWard;
        private System.Windows.Forms.Label lblStreet;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ComboBox cbLoaiDichVu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtChiSoDien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtThoiGian;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiDichVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWard;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button btnThemFile;
        private System.Windows.Forms.Button btnXuatFile;
    }
}
