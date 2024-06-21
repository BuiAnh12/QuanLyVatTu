namespace QuanLyVatTu
{
    partial class frmDatHang
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
            System.Windows.Forms.Label masoDDHLabel1;
            System.Windows.Forms.Label sOLUONGLabel;
            System.Windows.Forms.Label dONGIALabel;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDatHang));
            this.masoDDHLabel = new System.Windows.Forms.Label();
            this.nGAYLabel = new System.Windows.Forms.Label();
            this.nhaCCLabel = new System.Windows.Forms.Label();
            this.mAKHOLabel = new System.Windows.Forms.Label();
            this.mANVLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PanelControl = new DevExpress.XtraEditors.PanelControl();
            this.cmbChiNhanhMain = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.datHangDS = new QuanLyVatTu.DatHangDS();
            this.bdsDatHang = new System.Windows.Forms.BindingSource(this.components);
            this.datHangTableAdapter = new QuanLyVatTu.DatHangDSTableAdapters.DatHangTableAdapter();
            this.tableAdapterManager = new QuanLyVatTu.DatHangDSTableAdapters.TableAdapterManager();
            this.gcDatHang = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMasoDDH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNhaCC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMANV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAKHO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDDH = new DevExpress.XtraEditors.GroupControl();
            this.cmbTenKho = new System.Windows.Forms.ComboBox();
            this.bdsKho = new System.Windows.Forms.BindingSource(this.components);
            this.cmbHoTenNV = new System.Windows.Forms.ComboBox();
            this.bdsHoTen = new System.Windows.Forms.BindingSource(this.components);
            this.nhanVienDS = new QuanLyVatTu.NhanVienDS();
            this.txtMaNV = new DevExpress.XtraEditors.TextEdit();
            this.txtMaKho = new DevExpress.XtraEditors.TextEdit();
            this.txtNhaCC = new DevExpress.XtraEditors.TextEdit();
            this.deNgay = new DevExpress.XtraEditors.DateEdit();
            this.txtMSDDH = new DevExpress.XtraEditors.TextEdit();
            this.hoTenNVTableAdapter = new QuanLyVatTu.NhanVienDSTableAdapters.HoTenNVTableAdapter();
            this.tableAdapterManager1 = new QuanLyVatTu.NhanVienDSTableAdapters.TableAdapterManager();
            this.khoTableAdapter = new QuanLyVatTu.DatHangDSTableAdapters.KhoTableAdapter();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnSua = new DevExpress.XtraBars.BarButtonItem();
            this.btnGhi = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhucHoi = new DevExpress.XtraBars.BarButtonItem();
            this.btnReload = new DevExpress.XtraBars.BarButtonItem();
            this.btnIn = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gcCTDDH = new DevExpress.XtraEditors.GroupControl();
            this.gcTTCTDDH = new DevExpress.XtraEditors.GroupControl();
            this.txtMSDDH_sub = new DevExpress.XtraEditors.TextEdit();
            this.bdsCTDDH = new System.Windows.Forms.BindingSource(this.components);
            this.txtMaVT_sub = new DevExpress.XtraEditors.TextEdit();
            this.txtSoLuong_sub = new DevExpress.XtraEditors.TextEdit();
            this.cmbTenVT_sub = new System.Windows.Forms.ComboBox();
            this.bdsVatTu = new System.Windows.Forms.BindingSource(this.components);
            this.txtDonGia_sub = new DevExpress.XtraEditors.TextEdit();
            this.btnPhucHoi_sub = new System.Windows.Forms.Button();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.gvChiTietDonDatHang = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnThemCTDH = new System.Windows.Forms.ToolStripMenuItem();
            this.btnXoaCTDH = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGhiCTDH = new System.Windows.Forms.ToolStripMenuItem();
            this.CTDDHTableAdapter = new QuanLyVatTu.DatHangDSTableAdapters.CTDDHTableAdapter();
            this.vattuTableAdapter = new QuanLyVatTu.DatHangDSTableAdapters.VattuTableAdapter();
            this.bdsNhanVien = new System.Windows.Forms.BindingSource(this.components);
            this.nhanVienTableAdapter = new QuanLyVatTu.DatHangDSTableAdapters.NhanVienTableAdapter();
            this.bdsPhieuNhap = new System.Windows.Forms.BindingSource(this.components);
            this.phieuNhapTableAdapter = new QuanLyVatTu.DatHangDSTableAdapters.PhieuNhapTableAdapter();
            masoDDHLabel1 = new System.Windows.Forms.Label();
            sOLUONGLabel = new System.Windows.Forms.Label();
            dONGIALabel = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControl)).BeginInit();
            this.PanelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datHangDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDatHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDatHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDDH)).BeginInit();
            this.gcDDH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsHoTen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaKho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhaCC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMSDDH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcCTDDH)).BeginInit();
            this.gcCTDDH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTTCTDDH)).BeginInit();
            this.gcTTCTDDH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMSDDH_sub.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCTDDH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaVT_sub.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuong_sub.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsVatTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonGia_sub.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChiTietDonDatHang)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPhieuNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // masoDDHLabel1
            // 
            masoDDHLabel1.AutoSize = true;
            masoDDHLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            masoDDHLabel1.Location = new System.Drawing.Point(5, 70);
            masoDDHLabel1.Name = "masoDDHLabel1";
            masoDDHLabel1.Size = new System.Drawing.Size(107, 22);
            masoDDHLabel1.TabIndex = 1;
            masoDDHLabel1.Text = "Maso DDH:";
            // 
            // sOLUONGLabel
            // 
            sOLUONGLabel.AutoSize = true;
            sOLUONGLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sOLUONGLabel.Location = new System.Drawing.Point(5, 178);
            sOLUONGLabel.Name = "sOLUONGLabel";
            sOLUONGLabel.Size = new System.Drawing.Size(93, 22);
            sOLUONGLabel.TabIndex = 5;
            sOLUONGLabel.Text = "Số lượng: ";
            // 
            // dONGIALabel
            // 
            dONGIALabel.AutoSize = true;
            dONGIALabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dONGIALabel.Location = new System.Drawing.Point(5, 229);
            dONGIALabel.Name = "dONGIALabel";
            dONGIALabel.Size = new System.Drawing.Size(84, 22);
            dONGIALabel.TabIndex = 7;
            dONGIALabel.Text = "Đơn giá: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(361, 73);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(68, 22);
            label4.TabIndex = 3;
            label4.Text = "MAVT:";
            label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(5, 123);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(96, 22);
            label5.TabIndex = 9;
            label5.Text = "Tên vật tư:";
            // 
            // masoDDHLabel
            // 
            this.masoDDHLabel.AutoSize = true;
            this.masoDDHLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masoDDHLabel.Location = new System.Drawing.Point(20, 63);
            this.masoDDHLabel.Name = "masoDDHLabel";
            this.masoDDHLabel.Size = new System.Drawing.Size(117, 22);
            this.masoDDHLabel.TabIndex = 0;
            this.masoDDHLabel.Text = "Mã số DDH: ";
            this.masoDDHLabel.Click += new System.EventHandler(this.masoDDHLabel_Click);
            // 
            // nGAYLabel
            // 
            this.nGAYLabel.AutoSize = true;
            this.nGAYLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nGAYLabel.Location = new System.Drawing.Point(20, 124);
            this.nGAYLabel.Name = "nGAYLabel";
            this.nGAYLabel.Size = new System.Drawing.Size(62, 22);
            this.nGAYLabel.TabIndex = 2;
            this.nGAYLabel.Text = "Ngày: ";
            // 
            // nhaCCLabel
            // 
            this.nhaCCLabel.AutoSize = true;
            this.nhaCCLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhaCCLabel.Location = new System.Drawing.Point(20, 178);
            this.nhaCCLabel.Name = "nhaCCLabel";
            this.nhaCCLabel.Size = new System.Drawing.Size(84, 22);
            this.nhaCCLabel.TabIndex = 4;
            this.nhaCCLabel.Text = "Nhà CC: ";
            // 
            // mAKHOLabel
            // 
            this.mAKHOLabel.AutoSize = true;
            this.mAKHOLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mAKHOLabel.Location = new System.Drawing.Point(544, 303);
            this.mAKHOLabel.Name = "mAKHOLabel";
            this.mAKHOLabel.Size = new System.Drawing.Size(75, 22);
            this.mAKHOLabel.TabIndex = 8;
            this.mAKHOLabel.Text = "Mã kho:";
            // 
            // mANVLabel
            // 
            this.mANVLabel.AutoSize = true;
            this.mANVLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mANVLabel.Location = new System.Drawing.Point(544, 244);
            this.mANVLabel.Name = "mANVLabel";
            this.mANVLabel.Size = new System.Drawing.Size(78, 22);
            this.mANVLabel.TabIndex = 9;
            this.mANVLabel.Text = "Mã NV: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 22);
            this.label1.TabIndex = 12;
            this.label1.Text = "Họ tên nhân viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 22);
            this.label2.TabIndex = 14;
            this.label2.Text = "Tên kho";
            // 
            // PanelControl
            // 
            this.PanelControl.AutoSize = true;
            this.PanelControl.Controls.Add(this.cmbChiNhanhMain);
            this.PanelControl.Controls.Add(this.label3);
            this.PanelControl.Location = new System.Drawing.Point(0, 68);
            this.PanelControl.Name = "PanelControl";
            this.PanelControl.Size = new System.Drawing.Size(1928, 66);
            this.PanelControl.TabIndex = 4;
            // 
            // cmbChiNhanhMain
            // 
            this.cmbChiNhanhMain.Enabled = false;
            this.cmbChiNhanhMain.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cmbChiNhanhMain.FormattingEnabled = true;
            this.cmbChiNhanhMain.Location = new System.Drawing.Point(110, 20);
            this.cmbChiNhanhMain.Margin = new System.Windows.Forms.Padding(4);
            this.cmbChiNhanhMain.Name = "cmbChiNhanhMain";
            this.cmbChiNhanhMain.Size = new System.Drawing.Size(512, 30);
            this.cmbChiNhanhMain.TabIndex = 9;
            this.cmbChiNhanhMain.SelectedIndexChanged += new System.EventHandler(this.cmbChiNhanhMain_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(14, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 22);
            this.label3.TabIndex = 8;
            this.label3.Text = "Chi nhánh";
            // 
            // datHangDS
            // 
            this.datHangDS.DataSetName = "DatHangDS";
            this.datHangDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsDatHang
            // 
            this.bdsDatHang.DataMember = "DatHang";
            this.bdsDatHang.DataSource = this.datHangDS;
            // 
            // datHangTableAdapter
            // 
            this.datHangTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CTDDHTableAdapter = null;
            this.tableAdapterManager.DatHangTableAdapter = this.datHangTableAdapter;
            this.tableAdapterManager.KhoTableAdapter = null;
            this.tableAdapterManager.NhanVienTableAdapter = null;
            this.tableAdapterManager.PhieuNhapTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = QuanLyVatTu.DatHangDSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VattuTableAdapter = null;
            // 
            // gcDatHang
            // 
            this.gcDatHang.DataSource = this.bdsDatHang;
            this.gcDatHang.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(1);
            this.gcDatHang.Location = new System.Drawing.Point(-12, 5);
            this.gcDatHang.MainView = this.gridView1;
            this.gcDatHang.Name = "gcDatHang";
            this.gcDatHang.Size = new System.Drawing.Size(1940, 231);
            this.gcDatHang.TabIndex = 6;
            this.gcDatHang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gcDatHang.Click += new System.EventHandler(this.datHangGridControl_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMasoDDH,
            this.colNGAY,
            this.colNhaCC,
            this.colMANV,
            this.colMAKHO});
            this.gridView1.GridControl = this.gcDatHang;
            this.gridView1.Name = "gridView1";
            // 
            // colMasoDDH
            // 
            this.colMasoDDH.FieldName = "MasoDDH";
            this.colMasoDDH.MinWidth = 25;
            this.colMasoDDH.Name = "colMasoDDH";
            this.colMasoDDH.OptionsColumn.ReadOnly = true;
            this.colMasoDDH.Visible = true;
            this.colMasoDDH.VisibleIndex = 0;
            this.colMasoDDH.Width = 94;
            // 
            // colNGAY
            // 
            this.colNGAY.FieldName = "NGAY";
            this.colNGAY.MinWidth = 25;
            this.colNGAY.Name = "colNGAY";
            this.colNGAY.OptionsColumn.ReadOnly = true;
            this.colNGAY.Visible = true;
            this.colNGAY.VisibleIndex = 1;
            this.colNGAY.Width = 94;
            // 
            // colNhaCC
            // 
            this.colNhaCC.FieldName = "NhaCC";
            this.colNhaCC.MinWidth = 25;
            this.colNhaCC.Name = "colNhaCC";
            this.colNhaCC.OptionsColumn.ReadOnly = true;
            this.colNhaCC.Visible = true;
            this.colNhaCC.VisibleIndex = 2;
            this.colNhaCC.Width = 94;
            // 
            // colMANV
            // 
            this.colMANV.FieldName = "MANV";
            this.colMANV.MinWidth = 25;
            this.colMANV.Name = "colMANV";
            this.colMANV.OptionsColumn.ReadOnly = true;
            this.colMANV.Visible = true;
            this.colMANV.VisibleIndex = 3;
            this.colMANV.Width = 94;
            // 
            // colMAKHO
            // 
            this.colMAKHO.FieldName = "MAKHO";
            this.colMAKHO.MinWidth = 25;
            this.colMAKHO.Name = "colMAKHO";
            this.colMAKHO.OptionsColumn.ReadOnly = true;
            this.colMAKHO.Visible = true;
            this.colMAKHO.VisibleIndex = 4;
            this.colMAKHO.Width = 94;
            // 
            // gcDDH
            // 
            this.gcDDH.Controls.Add(this.label2);
            this.gcDDH.Controls.Add(this.cmbTenKho);
            this.gcDDH.Controls.Add(this.label1);
            this.gcDDH.Controls.Add(this.cmbHoTenNV);
            this.gcDDH.Controls.Add(this.mANVLabel);
            this.gcDDH.Controls.Add(this.txtMaNV);
            this.gcDDH.Controls.Add(this.mAKHOLabel);
            this.gcDDH.Controls.Add(this.txtMaKho);
            this.gcDDH.Controls.Add(this.nhaCCLabel);
            this.gcDDH.Controls.Add(this.txtNhaCC);
            this.gcDDH.Controls.Add(this.nGAYLabel);
            this.gcDDH.Controls.Add(this.deNgay);
            this.gcDDH.Controls.Add(this.masoDDHLabel);
            this.gcDDH.Controls.Add(this.txtMSDDH);
            this.gcDDH.Location = new System.Drawing.Point(0, 388);
            this.gcDDH.Name = "gcDDH";
            this.gcDDH.Size = new System.Drawing.Size(781, 350);
            this.gcDDH.TabIndex = 11;
            this.gcDDH.Text = "Thông tin đơn đặt hàng";
            // 
            // cmbTenKho
            // 
            this.cmbTenKho.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bdsDatHang, "MAKHO", true));
            this.cmbTenKho.DataSource = this.bdsKho;
            this.cmbTenKho.DisplayMember = "TENKHO";
            this.cmbTenKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTenKho.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTenKho.FormattingEnabled = true;
            this.cmbTenKho.Location = new System.Drawing.Point(178, 295);
            this.cmbTenKho.Name = "cmbTenKho";
            this.cmbTenKho.Size = new System.Drawing.Size(305, 30);
            this.cmbTenKho.TabIndex = 13;
            this.cmbTenKho.ValueMember = "MAKHO";
            // 
            // bdsKho
            // 
            this.bdsKho.DataMember = "Kho";
            this.bdsKho.DataSource = this.datHangDS;
            // 
            // cmbHoTenNV
            // 
            this.cmbHoTenNV.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bdsDatHang, "MANV", true));
            this.cmbHoTenNV.DataSource = this.bdsHoTen;
            this.cmbHoTenNV.DisplayMember = "HOTEN";
            this.cmbHoTenNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHoTenNV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHoTenNV.FormattingEnabled = true;
            this.cmbHoTenNV.Location = new System.Drawing.Point(178, 241);
            this.cmbHoTenNV.Name = "cmbHoTenNV";
            this.cmbHoTenNV.Size = new System.Drawing.Size(305, 30);
            this.cmbHoTenNV.TabIndex = 11;
            this.cmbHoTenNV.ValueMember = "MANV";
            this.cmbHoTenNV.SelectedIndexChanged += new System.EventHandler(this.cmbHoTenNV_SelectedIndexChanged);
            // 
            // bdsHoTen
            // 
            this.bdsHoTen.DataMember = "HoTenNV";
            this.bdsHoTen.DataSource = this.nhanVienDS;
            // 
            // nhanVienDS
            // 
            this.nhanVienDS.DataSetName = "NhanVienDS";
            this.nhanVienDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtMaNV
            // 
            this.txtMaNV.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsDatHang, "MANV", true));
            this.txtMaNV.Enabled = false;
            this.txtMaNV.Location = new System.Drawing.Point(628, 241);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNV.Properties.Appearance.Options.UseFont = true;
            this.txtMaNV.Size = new System.Drawing.Size(125, 28);
            this.txtMaNV.TabIndex = 10;
            // 
            // txtMaKho
            // 
            this.txtMaKho.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsDatHang, "MAKHO", true));
            this.txtMaKho.Enabled = false;
            this.txtMaKho.Location = new System.Drawing.Point(628, 300);
            this.txtMaKho.Name = "txtMaKho";
            this.txtMaKho.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaKho.Properties.Appearance.Options.UseFont = true;
            this.txtMaKho.Size = new System.Drawing.Size(125, 28);
            this.txtMaKho.TabIndex = 9;
            // 
            // txtNhaCC
            // 
            this.txtNhaCC.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsDatHang, "NhaCC", true));
            this.txtNhaCC.Location = new System.Drawing.Point(178, 175);
            this.txtNhaCC.Name = "txtNhaCC";
            this.txtNhaCC.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhaCC.Properties.Appearance.Options.UseFont = true;
            this.txtNhaCC.Size = new System.Drawing.Size(305, 28);
            this.txtNhaCC.TabIndex = 5;
            // 
            // deNgay
            // 
            this.deNgay.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsDatHang, "NGAY", true));
            this.deNgay.EditValue = null;
            this.deNgay.Location = new System.Drawing.Point(178, 118);
            this.deNgay.Name = "deNgay";
            this.deNgay.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deNgay.Properties.Appearance.Options.UseFont = true;
            this.deNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deNgay.Size = new System.Drawing.Size(203, 28);
            this.deNgay.TabIndex = 3;
            // 
            // txtMSDDH
            // 
            this.txtMSDDH.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsDatHang, "MasoDDH", true));
            this.txtMSDDH.Location = new System.Drawing.Point(178, 60);
            this.txtMSDDH.Name = "txtMSDDH";
            this.txtMSDDH.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMSDDH.Properties.Appearance.Options.UseFont = true;
            this.txtMSDDH.Size = new System.Drawing.Size(203, 28);
            this.txtMSDDH.TabIndex = 1;
            // 
            // hoTenNVTableAdapter
            // 
            this.hoTenNVTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.CTPNTableAdapter = null;
            this.tableAdapterManager1.CTPXTableAdapter = null;
            this.tableAdapterManager1.DatHangTableAdapter = null;
            this.tableAdapterManager1.NhanVienTableAdapter = null;
            this.tableAdapterManager1.UpdateOrder = QuanLyVatTu.NhanVienDSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // khoTableAdapter
            // 
            this.khoTableAdapter.ClearBeforeFill = true;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3,
            this.bar4});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockWindowTabFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThem,
            this.btnGhi,
            this.btnXoa,
            this.btnPhucHoi,
            this.btnReload,
            this.btnThoat,
            this.btnSua,
            this.btnIn});
            this.barManager1.MaxItemId = 9;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // bar4
            // 
            this.bar4.BarName = "Custom 5";
            this.bar4.DockCol = 0;
            this.bar4.DockRow = 0;
            this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar4.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSua),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGhi),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnXoa),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPhucHoi),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnReload),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnIn),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnThoat)});
            this.bar4.Text = "Custom 5";
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 0;
            this.btnThem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThem.ImageOptions.SvgImage")));
            this.btnThem.ImageOptions.SvgImageSize = new System.Drawing.Size(30, 30);
            this.btnThem.Name = "btnThem";
            this.btnThem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnThem.Size = new System.Drawing.Size(80, 50);
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // btnSua
            // 
            this.btnSua.Caption = "Sửa";
            this.btnSua.Id = 7;
            this.btnSua.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSua.ImageOptions.SvgImage")));
            this.btnSua.ImageOptions.SvgImageSize = new System.Drawing.Size(30, 30);
            this.btnSua.Name = "btnSua";
            this.btnSua.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnSua.Size = new System.Drawing.Size(80, 50);
            this.btnSua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSua_ItemClick);
            // 
            // btnGhi
            // 
            this.btnGhi.Caption = "Ghi";
            this.btnGhi.Id = 2;
            this.btnGhi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGhi.ImageOptions.SvgImage")));
            this.btnGhi.ImageOptions.SvgImageSize = new System.Drawing.Size(30, 30);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnGhi.Size = new System.Drawing.Size(80, 50);
            this.btnGhi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGhi_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 3;
            this.btnXoa.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnXoa.ImageOptions.SvgImage")));
            this.btnXoa.ImageOptions.SvgImageSize = new System.Drawing.Size(30, 30);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnXoa.Size = new System.Drawing.Size(80, 50);
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btnPhucHoi
            // 
            this.btnPhucHoi.Caption = "Phục hồi";
            this.btnPhucHoi.Id = 4;
            this.btnPhucHoi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPhucHoi.ImageOptions.SvgImage")));
            this.btnPhucHoi.ImageOptions.SvgImageSize = new System.Drawing.Size(30, 30);
            this.btnPhucHoi.Name = "btnPhucHoi";
            this.btnPhucHoi.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnPhucHoi.Size = new System.Drawing.Size(100, 50);
            this.btnPhucHoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPhucHoi_ItemClick);
            // 
            // btnReload
            // 
            this.btnReload.Caption = "Reolad";
            this.btnReload.Id = 5;
            this.btnReload.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnReload.ImageOptions.SvgImage")));
            this.btnReload.ImageOptions.SvgImageSize = new System.Drawing.Size(30, 30);
            this.btnReload.Name = "btnReload";
            this.btnReload.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnReload.Size = new System.Drawing.Size(80, 50);
            this.btnReload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReload_ItemClick);
            // 
            // btnIn
            // 
            this.btnIn.Caption = "In danh sách nhân viên";
            this.btnIn.Id = 8;
            this.btnIn.Name = "btnIn";
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 6;
            this.btnThoat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThoat.ImageOptions.SvgImage")));
            this.btnThoat.ImageOptions.SvgImageSize = new System.Drawing.Size(30, 30);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnThoat.Size = new System.Drawing.Size(80, 50);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1940, 62);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 757);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1940, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 62);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 695);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1940, 62);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 695);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gcDatHang);
            this.panelControl1.Location = new System.Drawing.Point(0, 141);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1940, 241);
            this.panelControl1.TabIndex = 16;
            // 
            // gcCTDDH
            // 
            this.gcCTDDH.Controls.Add(this.gcTTCTDDH);
            this.gcCTDDH.Controls.Add(this.btnPhucHoi_sub);
            this.gcCTDDH.Controls.Add(this.textEdit1);
            this.gcCTDDH.Controls.Add(this.gvChiTietDonDatHang);
            this.gcCTDDH.Location = new System.Drawing.Point(787, 388);
            this.gcCTDDH.Name = "gcCTDDH";
            this.gcCTDDH.Size = new System.Drawing.Size(1153, 369);
            this.gcCTDDH.TabIndex = 25;
            this.gcCTDDH.Text = "Chi tiết đơn đặt hàng";
            // 
            // gcTTCTDDH
            // 
            this.gcTTCTDDH.Controls.Add(masoDDHLabel1);
            this.gcTTCTDDH.Controls.Add(this.txtMSDDH_sub);
            this.gcTTCTDDH.Controls.Add(this.txtMaVT_sub);
            this.gcTTCTDDH.Controls.Add(label4);
            this.gcTTCTDDH.Controls.Add(this.txtSoLuong_sub);
            this.gcTTCTDDH.Controls.Add(this.cmbTenVT_sub);
            this.gcTTCTDDH.Controls.Add(sOLUONGLabel);
            this.gcTTCTDDH.Controls.Add(label5);
            this.gcTTCTDDH.Controls.Add(this.txtDonGia_sub);
            this.gcTTCTDDH.Controls.Add(dONGIALabel);
            this.gcTTCTDDH.Location = new System.Drawing.Point(561, 31);
            this.gcTTCTDDH.Name = "gcTTCTDDH";
            this.gcTTCTDDH.Size = new System.Drawing.Size(580, 266);
            this.gcTTCTDDH.TabIndex = 15;
            this.gcTTCTDDH.Text = "groupControl3";
            // 
            // txtMSDDH_sub
            // 
            this.txtMSDDH_sub.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsCTDDH, "MasoDDH", true));
            this.txtMSDDH_sub.Location = new System.Drawing.Point(118, 67);
            this.txtMSDDH_sub.MenuManager = this.barManager1;
            this.txtMSDDH_sub.Name = "txtMSDDH_sub";
            this.txtMSDDH_sub.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMSDDH_sub.Properties.Appearance.Options.UseFont = true;
            this.txtMSDDH_sub.Size = new System.Drawing.Size(221, 28);
            this.txtMSDDH_sub.TabIndex = 2;
            // 
            // bdsCTDDH
            // 
            this.bdsCTDDH.DataMember = "FK_CTDDH_DatHang";
            this.bdsCTDDH.DataSource = this.bdsDatHang;
            // 
            // txtMaVT_sub
            // 
            this.txtMaVT_sub.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsCTDDH, "MAVT", true));
            this.txtMaVT_sub.Location = new System.Drawing.Point(435, 70);
            this.txtMaVT_sub.MenuManager = this.barManager1;
            this.txtMaVT_sub.Name = "txtMaVT_sub";
            this.txtMaVT_sub.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaVT_sub.Properties.Appearance.Options.UseFont = true;
            this.txtMaVT_sub.Size = new System.Drawing.Size(91, 28);
            this.txtMaVT_sub.TabIndex = 4;
            // 
            // txtSoLuong_sub
            // 
            this.txtSoLuong_sub.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsCTDDH, "SOLUONG", true));
            this.txtSoLuong_sub.Location = new System.Drawing.Point(118, 172);
            this.txtSoLuong_sub.MenuManager = this.barManager1;
            this.txtSoLuong_sub.Name = "txtSoLuong_sub";
            this.txtSoLuong_sub.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuong_sub.Properties.Appearance.Options.UseFont = true;
            this.txtSoLuong_sub.Size = new System.Drawing.Size(221, 28);
            this.txtSoLuong_sub.TabIndex = 6;
            // 
            // cmbTenVT_sub
            // 
            this.cmbTenVT_sub.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bdsCTDDH, "MAVT", true));
            this.cmbTenVT_sub.DataSource = this.bdsVatTu;
            this.cmbTenVT_sub.DisplayMember = "TENVT";
            this.cmbTenVT_sub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTenVT_sub.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTenVT_sub.FormattingEnabled = true;
            this.cmbTenVT_sub.Location = new System.Drawing.Point(118, 118);
            this.cmbTenVT_sub.Name = "cmbTenVT_sub";
            this.cmbTenVT_sub.Size = new System.Drawing.Size(408, 30);
            this.cmbTenVT_sub.TabIndex = 10;
            this.cmbTenVT_sub.ValueMember = "MAVT";
            this.cmbTenVT_sub.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // bdsVatTu
            // 
            this.bdsVatTu.DataMember = "Vattu";
            this.bdsVatTu.DataSource = this.datHangDS;
            // 
            // txtDonGia_sub
            // 
            this.txtDonGia_sub.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsCTDDH, "DONGIA", true));
            this.txtDonGia_sub.Location = new System.Drawing.Point(118, 226);
            this.txtDonGia_sub.MenuManager = this.barManager1;
            this.txtDonGia_sub.Name = "txtDonGia_sub";
            this.txtDonGia_sub.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDonGia_sub.Properties.Appearance.Options.UseFont = true;
            this.txtDonGia_sub.Size = new System.Drawing.Size(221, 28);
            this.txtDonGia_sub.TabIndex = 8;
            // 
            // btnPhucHoi_sub
            // 
            this.btnPhucHoi_sub.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhucHoi_sub.Location = new System.Drawing.Point(561, 303);
            this.btnPhucHoi_sub.Name = "btnPhucHoi_sub";
            this.btnPhucHoi_sub.Size = new System.Drawing.Size(89, 43);
            this.btnPhucHoi_sub.TabIndex = 14;
            this.btnPhucHoi_sub.Text = "Phục hồi";
            this.btnPhucHoi_sub.UseVisualStyleBackColor = true;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(1296, 98);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Size = new System.Drawing.Size(91, 28);
            this.textEdit1.TabIndex = 4;
            // 
            // gvChiTietDonDatHang
            // 
            this.gvChiTietDonDatHang.AllowUserToAddRows = false;
            this.gvChiTietDonDatHang.AllowUserToDeleteRows = false;
            this.gvChiTietDonDatHang.AutoGenerateColumns = false;
            this.gvChiTietDonDatHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvChiTietDonDatHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.gvChiTietDonDatHang.ContextMenuStrip = this.contextMenuStrip1;
            this.gvChiTietDonDatHang.DataSource = this.bdsCTDDH;
            this.gvChiTietDonDatHang.Location = new System.Drawing.Point(0, 31);
            this.gvChiTietDonDatHang.Name = "gvChiTietDonDatHang";
            this.gvChiTietDonDatHang.RowHeadersWidth = 51;
            this.gvChiTietDonDatHang.RowTemplate.Height = 24;
            this.gvChiTietDonDatHang.Size = new System.Drawing.Size(555, 319);
            this.gvChiTietDonDatHang.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MasoDDH";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã số DDH";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "MAVT";
            this.dataGridViewTextBoxColumn2.DataSource = this.bdsVatTu;
            this.dataGridViewTextBoxColumn2.DisplayMember = "TENVT";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên vật tư";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn2.ValueMember = "MAVT";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SOLUONG";
            this.dataGridViewTextBoxColumn3.HeaderText = "Số lượng";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DONGIA";
            this.dataGridViewTextBoxColumn4.HeaderText = "Đơn giá";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThemCTDH,
            this.btnXoaCTDH,
            this.btnGhiCTDH});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(234, 76);
            // 
            // btnThemCTDH
            // 
            this.btnThemCTDH.Name = "btnThemCTDH";
            this.btnThemCTDH.Size = new System.Drawing.Size(233, 24);
            this.btnThemCTDH.Text = "Thêm chi tiết đơn hàng";
            this.btnThemCTDH.Click += new System.EventHandler(this.btnThemCTDH_Click);
            // 
            // btnXoaCTDH
            // 
            this.btnXoaCTDH.Name = "btnXoaCTDH";
            this.btnXoaCTDH.Size = new System.Drawing.Size(233, 24);
            this.btnXoaCTDH.Text = "Xóa chi tiết đơn hàng";
            this.btnXoaCTDH.Click += new System.EventHandler(this.btnXoaCTDH_Click);
            // 
            // btnGhiCTDH
            // 
            this.btnGhiCTDH.Name = "btnGhiCTDH";
            this.btnGhiCTDH.Size = new System.Drawing.Size(233, 24);
            this.btnGhiCTDH.Text = "Ghi chi tiết đơn hàng";
            this.btnGhiCTDH.Click += new System.EventHandler(this.btnGhiCTDH_Click);
            // 
            // CTDDHTableAdapter
            // 
            this.CTDDHTableAdapter.ClearBeforeFill = true;
            // 
            // vattuTableAdapter
            // 
            this.vattuTableAdapter.ClearBeforeFill = true;
            // 
            // bdsNhanVien
            // 
            this.bdsNhanVien.DataMember = "NhanVien";
            this.bdsNhanVien.DataSource = this.datHangDS;
            // 
            // nhanVienTableAdapter
            // 
            this.nhanVienTableAdapter.ClearBeforeFill = true;
            // 
            // bdsPhieuNhap
            // 
            this.bdsPhieuNhap.DataMember = "FK_PhieuNhap_DatHang";
            this.bdsPhieuNhap.DataSource = this.bdsDatHang;
            // 
            // phieuNhapTableAdapter
            // 
            this.phieuNhapTableAdapter.ClearBeforeFill = true;
            // 
            // frmDatHang
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1940, 777);
            this.Controls.Add(this.gcCTDDH);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gcDDH);
            this.Controls.Add(this.PanelControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmDatHang";
            this.Text = "frmDatHang";
            this.Load += new System.EventHandler(this.frmDatHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PanelControl)).EndInit();
            this.PanelControl.ResumeLayout(false);
            this.PanelControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datHangDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDatHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDatHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDDH)).EndInit();
            this.gcDDH.ResumeLayout(false);
            this.gcDDH.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsHoTen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaKho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhaCC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMSDDH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcCTDDH)).EndInit();
            this.gcCTDDH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcTTCTDDH)).EndInit();
            this.gcTTCTDDH.ResumeLayout(false);
            this.gcTTCTDDH.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMSDDH_sub.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCTDDH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaVT_sub.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuong_sub.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsVatTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonGia_sub.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChiTietDonDatHang)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bdsNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPhieuNhap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl PanelControl;
        private System.Windows.Forms.ComboBox cmbChiNhanhMain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource bdsDatHang;
        private DatHangDS datHangDS;
        private DatHangDSTableAdapters.DatHangTableAdapter datHangTableAdapter;
        private DatHangDSTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl gcDatHang;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMasoDDH;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAY;
        private DevExpress.XtraGrid.Columns.GridColumn colNhaCC;
        private DevExpress.XtraGrid.Columns.GridColumn colMANV;
        private DevExpress.XtraGrid.Columns.GridColumn colMAKHO;
        private DevExpress.XtraEditors.GroupControl gcDDH;
        private DevExpress.XtraEditors.TextEdit txtMaNV;
        private DevExpress.XtraEditors.TextEdit txtMaKho;
        private DevExpress.XtraEditors.TextEdit txtNhaCC;
        private DevExpress.XtraEditors.DateEdit deNgay;
        private DevExpress.XtraEditors.TextEdit txtMSDDH;
        private System.Windows.Forms.ComboBox cmbTenKho;
        private System.Windows.Forms.ComboBox cmbHoTenNV;
        private NhanVienDS nhanVienDS;
        private System.Windows.Forms.BindingSource bdsHoTen;
        private NhanVienDSTableAdapters.HoTenNVTableAdapter hoTenNVTableAdapter;
        private NhanVienDSTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.Label masoDDHLabel;
        private System.Windows.Forms.Label nGAYLabel;
        private System.Windows.Forms.Label nhaCCLabel;
        private System.Windows.Forms.Label mAKHOLabel;
        private System.Windows.Forms.Label mANVLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource bdsKho;
        private DatHangDSTableAdapters.KhoTableAdapter khoTableAdapter;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.Bar bar4;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnSua;
        private DevExpress.XtraBars.BarButtonItem btnGhi;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnPhucHoi;
        private DevExpress.XtraBars.BarButtonItem btnReload;
        private DevExpress.XtraBars.BarButtonItem btnIn;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl gcCTDDH;
        private System.Windows.Forms.BindingSource bdsCTDDH;
        private DatHangDSTableAdapters.CTDDHTableAdapter CTDDHTableAdapter;
        private System.Windows.Forms.DataGridView gvChiTietDonDatHang;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnThemCTDH;
        private System.Windows.Forms.ToolStripMenuItem btnXoaCTDH;
        private System.Windows.Forms.ToolStripMenuItem btnGhiCTDH;
        private System.Windows.Forms.BindingSource bdsVatTu;
        private DatHangDSTableAdapters.VattuTableAdapter vattuTableAdapter;
        private DevExpress.XtraEditors.TextEdit txtDonGia_sub;
        private DevExpress.XtraEditors.TextEdit txtSoLuong_sub;
        private DevExpress.XtraEditors.TextEdit txtMSDDH_sub;
        private System.Windows.Forms.ComboBox cmbTenVT_sub;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.TextEdit txtMaVT_sub;
        private System.Windows.Forms.Button btnPhucHoi_sub;
        private DevExpress.XtraEditors.GroupControl gcTTCTDDH;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.BindingSource bdsNhanVien;
        private DatHangDSTableAdapters.NhanVienTableAdapter nhanVienTableAdapter;
        private System.Windows.Forms.BindingSource bdsPhieuNhap;
        private DatHangDSTableAdapters.PhieuNhapTableAdapter phieuNhapTableAdapter;
    }
}