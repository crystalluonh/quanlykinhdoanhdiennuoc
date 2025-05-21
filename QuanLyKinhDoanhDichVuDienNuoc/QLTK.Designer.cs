using System.Windows.Forms;

namespace QuanLyKinhDoanhDichVuDienNuoc
{
    partial class QLTK
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvAccounts = new System.Windows.Forms.DataGridView();
            this.colUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPasswword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblWard = new System.Windows.Forms.Label();
            this.txtWard = new System.Windows.Forms.ComboBox();
            this.lblStreet = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSearch
            // 
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblSearch.Location = new System.Drawing.Point(111, 15);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(41, 19);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Tìm:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(158, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 22);
            this.txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(464, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(77, 33);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Tìm Kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvAccounts
            // 
            this.dgvAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAccounts.ColumnHeadersHeight = 50;
            this.dgvAccounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUsername,
            this.colPasswword,
            this.colFullname,
            this.colEmail,
            this.colPhone,
            this.colWard,
            this.colAddress});
            this.dgvAccounts.Location = new System.Drawing.Point(13, 67);
            this.dgvAccounts.Name = "dgvAccounts";
            this.dgvAccounts.RowHeadersWidth = 51;
            this.dgvAccounts.Size = new System.Drawing.Size(637, 175);
            this.dgvAccounts.TabIndex = 3;
            this.dgvAccounts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAccounts_CellContentClick);
            // 
            // colUsername
            // 
            this.colUsername.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colUsername.HeaderText = "Tên đăng nhập";
            this.colUsername.MinimumWidth = 6;
            this.colUsername.Name = "colUsername";
            this.colUsername.Width = 117;
            // 
            // colPasswword
            // 
            this.colPasswword.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colPasswword.HeaderText = "Mật Khẩu";
            this.colPasswword.MinimumWidth = 6;
            this.colPasswword.Name = "colPasswword";
            this.colPasswword.Width = 84;
            // 
            // colFullname
            // 
            this.colFullname.HeaderText = "Họ tên";
            this.colFullname.MinimumWidth = 6;
            this.colFullname.Name = "colFullname";
            // 
            // colEmail
            // 
            this.colEmail.HeaderText = "Email";
            this.colEmail.MinimumWidth = 6;
            this.colEmail.Name = "colEmail";
            // 
            // colPhone
            // 
            this.colPhone.HeaderText = "SĐT";
            this.colPhone.MinimumWidth = 6;
            this.colPhone.Name = "colPhone";
            // 
            // colWard
            // 
            this.colWard.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colWard.HeaderText = "Phường/Xã";
            this.colWard.MinimumWidth = 6;
            this.colWard.Name = "colWard";
            this.colWard.Width = 102;
            // 
            // colAddress
            // 
            this.colAddress.HeaderText = "Địa chỉ";
            this.colAddress.MinimumWidth = 6;
            this.colAddress.Name = "colAddress";
            // 
            // lblUsername
            // 
            this.lblUsername.Location = new System.Drawing.Point(13, 265);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(110, 23);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "Tên đăng nhập:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(140, 262);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(434, 22);
            this.txtUsername.TabIndex = 5;
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(15, 332);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(100, 23);
            this.lblFullName.TabIndex = 6;
            this.lblFullName.Text = "Họ tên:";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(142, 335);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(432, 22);
            this.txtFullName.TabIndex = 7;
            this.txtFullName.TextChanged += new System.EventHandler(this.txtFullName_TextChanged);
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(15, 367);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(100, 23);
            this.lblEmail.TabIndex = 8;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(142, 364);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(432, 22);
            this.txtEmail.TabIndex = 9;
            // 
            // lblPhone
            // 
            this.lblPhone.Location = new System.Drawing.Point(15, 402);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(100, 23);
            this.lblPhone.TabIndex = 10;
            this.lblPhone.Text = "Số điện thoại:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(142, 399);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(432, 22);
            this.txtPhone.TabIndex = 11;
            // 
            // lblWard
            // 
            this.lblWard.Location = new System.Drawing.Point(15, 434);
            this.lblWard.Name = "lblWard";
            this.lblWard.Size = new System.Drawing.Size(100, 23);
            this.lblWard.TabIndex = 12;
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
            this.txtWard.Location = new System.Drawing.Point(142, 431);
            this.txtWard.Name = "txtWard";
            this.txtWard.Size = new System.Drawing.Size(150, 24);
            this.txtWard.TabIndex = 13;
            // 
            // lblStreet
            // 
            this.lblStreet.Location = new System.Drawing.Point(314, 434);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(70, 23);
            this.lblStreet.TabIndex = 14;
            this.lblStreet.Text = "Địa chỉ:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(401, 431);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(173, 22);
            this.txtAddress.TabIndex = 15;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(18, 469);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 30);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(142, 469);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(90, 30);
            this.btnEdit.TabIndex = 17;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(265, 469);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 30);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "Xoá";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(385, 469);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(90, 30);
            this.btnReset.TabIndex = 19;
            this.btnReset.Text = "Làm mới";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 23);
            this.label1.TabIndex = 20;
            this.label1.Text = "Mật khẩu:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(140, 297);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(434, 22);
            this.txtPassword.TabIndex = 21;
            // 
            // QLTK
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvAccounts);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblWard);
            this.Controls.Add(this.txtWard);
            this.Controls.Add(this.lblStreet);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnReset);
            this.Name = "QLTK";
            this.Size = new System.Drawing.Size(657, 517);
            this.Load += new System.EventHandler(this.QLTK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvAccounts;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblWard;
        private ComboBox txtWard;
        private Label lblStreet;
        private TextBox txtAddress;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnReset;
        private Label label1;
        private TextBox txtPassword;
        private DataGridViewTextBoxColumn colUsername;
        private DataGridViewTextBoxColumn colPasswword;
        private DataGridViewTextBoxColumn colFullname;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colPhone;
        private DataGridViewTextBoxColumn colWard;
        private DataGridViewTextBoxColumn colAddress;
    }
}