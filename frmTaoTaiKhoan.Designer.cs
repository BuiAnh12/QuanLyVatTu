namespace QuanLyVatTu
{
    partial class frmTaoTaiKhoan
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label hOTENLabel;
            System.Windows.Forms.Label mANVLabel;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            this.label1 = new System.Windows.Forms.Label();
            this.nhanVienDS = new QuanLyVatTu.NhanVienDS();
            this.bdsHoTenNV = new System.Windows.Forms.BindingSource(this.components);
            this.hoTenNVTableAdapter = new QuanLyVatTu.NhanVienDSTableAdapters.HoTenNVTableAdapter();
            this.tableAdapterManager = new QuanLyVatTu.NhanVienDSTableAdapters.TableAdapterManager();
            this.cmbHoTenNV = new System.Windows.Forms.ComboBox();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.btnTaoTK = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoaTK = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.cmbPhanQuyen = new System.Windows.Forms.ComboBox();
            this.cmbChiNhanhMain = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bdsNhanVien = new System.Windows.Forms.BindingSource(this.components);
            this.nhanVienTableAdapter = new QuanLyVatTu.NhanVienDSTableAdapters.NhanVienTableAdapter();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.fKDatHangNhanVien1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.datHangTableAdapter = new QuanLyVatTu.NhanVienDSTableAdapters.DatHangTableAdapter();
            this.txtTaiKhoan = new DevExpress.XtraEditors.TextEdit();
            this.txtMatKhau = new DevExpress.XtraEditors.TextEdit();
            hOTENLabel = new System.Windows.Forms.Label();
            mANVLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsHoTenNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fKDatHangNhanVien1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaiKhoan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // hOTENLabel
            // 
            hOTENLabel.AutoSize = true;
            hOTENLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            hOTENLabel.Location = new System.Drawing.Point(7, 92);
            hOTENLabel.Name = "hOTENLabel";
            hOTENLabel.Size = new System.Drawing.Size(162, 23);
            hOTENLabel.TabIndex = 1;
            hOTENLabel.Text = "Họ tên nhân viên: ";
            hOTENLabel.Click += new System.EventHandler(this.hOTENLabel_Click);
            // 
            // mANVLabel
            // 
            mANVLabel.AutoSize = true;
            mANVLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            mANVLabel.Location = new System.Drawing.Point(742, 92);
            mANVLabel.Name = "mANVLabel";
            mANVLabel.Size = new System.Drawing.Size(76, 23);
            mANVLabel.TabIndex = 3;
            mANVLabel.Text = "Mã NV:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(7, 157);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(101, 23);
            label2.TabIndex = 5;
            label2.Text = "Tài khoản:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(7, 229);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(98, 23);
            label3.TabIndex = 7;
            label3.Text = "Mật khẩu:";
            label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(7, 300);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(121, 23);
            label4.TabIndex = 9;
            label4.Text = "Nhóm quyền:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(279, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(601, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "TẠO TÀI KHOẢN ĐĂNG NHẬP";
            // 
            // nhanVienDS
            // 
            this.nhanVienDS.DataSetName = "NhanVienDS";
            this.nhanVienDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsHoTenNV
            // 
            this.bdsHoTenNV.DataMember = "HoTenNV";
            this.bdsHoTenNV.DataSource = this.nhanVienDS;
            // 
            // hoTenNVTableAdapter
            // 
            this.hoTenNVTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.CTPNTableAdapter = null;
            this.tableAdapterManager.CTPXTableAdapter = null;
            this.tableAdapterManager.DatHangTableAdapter = null;
            this.tableAdapterManager.NhanVienTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = QuanLyVatTu.NhanVienDSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // cmbHoTenNV
            // 
            this.cmbHoTenNV.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsHoTenNV, "HOTEN", true));
            this.cmbHoTenNV.DataSource = this.bdsHoTenNV;
            this.cmbHoTenNV.DisplayMember = "HOTEN";
            this.cmbHoTenNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHoTenNV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHoTenNV.FormattingEnabled = true;
            this.cmbHoTenNV.Location = new System.Drawing.Point(228, 90);
            this.cmbHoTenNV.Name = "cmbHoTenNV";
            this.cmbHoTenNV.Size = new System.Drawing.Size(440, 30);
            this.cmbHoTenNV.TabIndex = 2;
            this.cmbHoTenNV.ValueMember = "MANV";
            this.cmbHoTenNV.SelectedIndexChanged += new System.EventHandler(this.cmbHoTenNV_SelectedIndexChanged);
            // 
            // txtMaNV
            // 
            this.txtMaNV.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsHoTenNV, "MANV", true));
            this.txtMaNV.Enabled = false;
            this.txtMaNV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNV.Location = new System.Drawing.Point(824, 90);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(155, 30);
            this.txtMaNV.TabIndex = 4;
            this.txtMaNV.TextChanged += new System.EventHandler(this.txtMaNV_TextChanged);
            // 
            // btnTaoTK
            // 
            this.btnTaoTK.Location = new System.Drawing.Point(228, 361);
            this.btnTaoTK.Name = "btnTaoTK";
            this.btnTaoTK.Size = new System.Drawing.Size(173, 42);
            this.btnTaoTK.TabIndex = 11;
            this.btnTaoTK.Text = "Tạo tài khoản";
            this.btnTaoTK.Click += new System.EventHandler(this.btnTaoTK_Click);
            // 
            // btnXoaTK
            // 
            this.btnXoaTK.Location = new System.Drawing.Point(495, 361);
            this.btnXoaTK.Name = "btnXoaTK";
            this.btnXoaTK.Size = new System.Drawing.Size(173, 42);
            this.btnXoaTK.TabIndex = 12;
            this.btnXoaTK.Text = "Xóa tài khoản";
            this.btnXoaTK.Click += new System.EventHandler(this.btnXoaTK_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(746, 361);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(173, 42);
            this.btnThoat.TabIndex = 13;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // cmbPhanQuyen
            // 
            this.cmbPhanQuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPhanQuyen.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPhanQuyen.FormattingEnabled = true;
            this.cmbPhanQuyen.Location = new System.Drawing.Point(228, 292);
            this.cmbPhanQuyen.Name = "cmbPhanQuyen";
            this.cmbPhanQuyen.Size = new System.Drawing.Size(440, 30);
            this.cmbPhanQuyen.TabIndex = 14;
            // 
            // cmbChiNhanhMain
            // 
            this.cmbChiNhanhMain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChiNhanhMain.Enabled = false;
            this.cmbChiNhanhMain.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cmbChiNhanhMain.FormattingEnabled = true;
            this.cmbChiNhanhMain.Location = new System.Drawing.Point(228, 41);
            this.cmbChiNhanhMain.Margin = new System.Windows.Forms.Padding(4);
            this.cmbChiNhanhMain.Name = "cmbChiNhanhMain";
            this.cmbChiNhanhMain.Size = new System.Drawing.Size(440, 30);
            this.cmbChiNhanhMain.TabIndex = 16;
            this.cmbChiNhanhMain.SelectedIndexChanged += new System.EventHandler(this.cmbChiNhanhMain_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(6, 43);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 23);
            this.label5.TabIndex = 15;
            this.label5.Text = "Chi nhánh";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // bdsNhanVien
            // 
            this.bdsNhanVien.DataMember = "NhanVien";
            this.bdsNhanVien.DataSource = this.nhanVienDS;
            // 
            // nhanVienTableAdapter
            // 
            this.nhanVienTableAdapter.ClearBeforeFill = true;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtMatKhau);
            this.groupControl1.Controls.Add(this.txtTaiKhoan);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.btnThoat);
            this.groupControl1.Controls.Add(this.cmbPhanQuyen);
            this.groupControl1.Controls.Add(this.btnXoaTK);
            this.groupControl1.Controls.Add(this.cmbChiNhanhMain);
            this.groupControl1.Controls.Add(this.btnTaoTK);
            this.groupControl1.Controls.Add(this.cmbHoTenNV);
            this.groupControl1.Controls.Add(hOTENLabel);
            this.groupControl1.Controls.Add(this.txtMaNV);
            this.groupControl1.Controls.Add(label4);
            this.groupControl1.Controls.Add(mANVLabel);
            this.groupControl1.Controls.Add(label2);
            this.groupControl1.Controls.Add(label3);
            this.groupControl1.Location = new System.Drawing.Point(128, 103);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1020, 408);
            this.groupControl1.TabIndex = 17;
            // 
            // fKDatHangNhanVien1BindingSource
            // 
            this.fKDatHangNhanVien1BindingSource.DataMember = "FK_DatHang_NhanVien1";
            this.fKDatHangNhanVien1BindingSource.DataSource = this.bdsHoTenNV;
            // 
            // datHangTableAdapter
            // 
            this.datHangTableAdapter.ClearBeforeFill = true;
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Location = new System.Drawing.Point(228, 152);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaiKhoan.Properties.Appearance.Options.UseFont = true;
            this.txtTaiKhoan.Size = new System.Drawing.Size(440, 28);
            this.txtTaiKhoan.TabIndex = 17;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(228, 227);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.Properties.Appearance.Options.UseFont = true;
            this.txtMatKhau.Size = new System.Drawing.Size(440, 28);
            this.txtMatKhau.TabIndex = 18;
            // 
            // frmTaoTaiKhoan
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 532);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmTaoTaiKhoan";
            this.Text = "frmTaoTaiKhoan";
            this.Load += new System.EventHandler(this.frmTaoTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsHoTenNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fKDatHangNhanVien1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaiKhoan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private NhanVienDS nhanVienDS;
        private System.Windows.Forms.BindingSource bdsHoTenNV;
        private NhanVienDSTableAdapters.HoTenNVTableAdapter hoTenNVTableAdapter;
        private NhanVienDSTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ComboBox cmbHoTenNV;
        private System.Windows.Forms.TextBox txtMaNV;
        private DevExpress.XtraEditors.SimpleButton btnTaoTK;
        private DevExpress.XtraEditors.SimpleButton btnXoaTK;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private System.Windows.Forms.ComboBox cmbPhanQuyen;
        private System.Windows.Forms.ComboBox cmbChiNhanhMain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource bdsNhanVien;
        private NhanVienDSTableAdapters.NhanVienTableAdapter nhanVienTableAdapter;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.BindingSource fKDatHangNhanVien1BindingSource;
        private NhanVienDSTableAdapters.DatHangTableAdapter datHangTableAdapter;
        private DevExpress.XtraEditors.TextEdit txtMatKhau;
        private DevExpress.XtraEditors.TextEdit txtTaiKhoan;
    }
}