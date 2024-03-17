namespace QuanLyVatTu
{
    partial class frmPhieuNhap
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
            System.Windows.Forms.Label mANVLabel;
            System.Windows.Forms.Label mAPNLabel;
            System.Windows.Forms.Label nGAYLabel;
            System.Windows.Forms.Label nhaCCLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhieuNhap));
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dS = new QuanLyVatTu.DS();
            this.tableAdapterManager = new QuanLyVatTu.DSTableAdapters.TableAdapterManager();
            this.mAPNTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.nGAYDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.datHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.datHangTableAdapter = new QuanLyVatTu.DSTableAdapters.DatHangTableAdapter();
            this.nhaCCTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.bdsCTPS = new System.Windows.Forms.BindingSource(this.components);
            this.cTPNTableAdapter = new QuanLyVatTu.DSTableAdapters.CTPNTableAdapter();
            this.colMAPN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasoDDH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMANV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dgvCTPS = new System.Windows.Forms.DataGridView();
            this.mAPNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mAVTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sOLUONGDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dONGIADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowguidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnSua = new DevExpress.XtraBars.BarButtonItem();
            this.btnGhi = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhucHoi = new DevExpress.XtraBars.BarButtonItem();
            this.btnReload = new DevExpress.XtraBars.BarButtonItem();
            this.btnIn = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            mANVLabel = new System.Windows.Forms.Label();
            mAPNLabel = new System.Windows.Forms.Label();
            nGAYLabel = new System.Windows.Forms.Label();
            nhaCCLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mAPNTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGAYDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGAYDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datHangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhaCCTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCTPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 62);
            this.barDockControlTop.Manager = null;
            this.barDockControlTop.Size = new System.Drawing.Size(1808, 0);
            // 
            // bar4
            // 
            this.bar4.BarName = "Custom 5";
            this.bar4.DockCol = 0;
            this.bar4.DockRow = 0;
            this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar4.Text = "Custom 5";
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 5";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Custom 5";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(0, 62);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1788, 259);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAPN,
            this.colNGAY,
            this.colMasoDDH,
            this.colMANV});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // mANVLabel
            // 
            mANVLabel.AutoSize = true;
            mANVLabel.Location = new System.Drawing.Point(452, 133);
            mANVLabel.Name = "mANVLabel";
            mANVLabel.Size = new System.Drawing.Size(0, 16);
            mANVLabel.TabIndex = 18;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(nhaCCLabel);
            this.groupBox1.Controls.Add(this.nhaCCTextEdit);
            this.groupBox1.Controls.Add(nGAYLabel);
            this.groupBox1.Controls.Add(this.nGAYDateEdit);
            this.groupBox1.Controls.Add(mAPNLabel);
            this.groupBox1.Controls.Add(this.mAPNTextEdit);
            this.groupBox1.Controls.Add(mANVLabel);
            this.groupBox1.Location = new System.Drawing.Point(0, 327);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(873, 484);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // dS
            // 
            this.dS.DataSetName = "DS";
            this.dS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ChiNhanhTableAdapter = null;
            this.tableAdapterManager.CTDDHTableAdapter = null;
            this.tableAdapterManager.CTPNTableAdapter = this.cTPNTableAdapter;
            this.tableAdapterManager.CTPXTableAdapter = null;
            this.tableAdapterManager.DatHangTableAdapter = this.datHangTableAdapter;
            this.tableAdapterManager.KhoTableAdapter = null;
            this.tableAdapterManager.NhanVienTableAdapter = null;
            this.tableAdapterManager.PhieuNhapTableAdapter = null;
            this.tableAdapterManager.PhieuXuatTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = QuanLyVatTu.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VattuTableAdapter = null;
            // 
            // mAPNLabel
            // 
            mAPNLabel.AutoSize = true;
            mAPNLabel.Location = new System.Drawing.Point(30, 59);
            mAPNLabel.Name = "mAPNLabel";
            mAPNLabel.Size = new System.Drawing.Size(45, 16);
            mAPNLabel.TabIndex = 18;
            mAPNLabel.Text = "MAPN:";
            // 
            // mAPNTextEdit
            // 
            this.mAPNTextEdit.Location = new System.Drawing.Point(81, 56);
            this.mAPNTextEdit.Name = "mAPNTextEdit";
            this.mAPNTextEdit.Size = new System.Drawing.Size(125, 22);
            this.mAPNTextEdit.TabIndex = 19;
            // 
            // nGAYLabel
            // 
            nGAYLabel.AutoSize = true;
            nGAYLabel.Location = new System.Drawing.Point(333, 64);
            nGAYLabel.Name = "nGAYLabel";
            nGAYLabel.Size = new System.Drawing.Size(43, 16);
            nGAYLabel.TabIndex = 19;
            nGAYLabel.Text = "NGAY:";
            // 
            // nGAYDateEdit
            // 
            this.nGAYDateEdit.EditValue = null;
            this.nGAYDateEdit.Location = new System.Drawing.Point(382, 61);
            this.nGAYDateEdit.Name = "nGAYDateEdit";
            this.nGAYDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nGAYDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nGAYDateEdit.Size = new System.Drawing.Size(125, 22);
            this.nGAYDateEdit.TabIndex = 20;
            // 
            // datHangBindingSource
            // 
            this.datHangBindingSource.DataMember = "DatHang";
            this.datHangBindingSource.DataSource = this.dS;
            // 
            // datHangTableAdapter
            // 
            this.datHangTableAdapter.ClearBeforeFill = true;
            // 
            // nhaCCLabel
            // 
            nhaCCLabel.AutoSize = true;
            nhaCCLabel.Location = new System.Drawing.Point(333, 133);
            nhaCCLabel.Name = "nhaCCLabel";
            nhaCCLabel.Size = new System.Drawing.Size(54, 16);
            nhaCCLabel.TabIndex = 20;
            nhaCCLabel.Text = "Nha CC:";
            // 
            // nhaCCTextEdit
            // 
            this.nhaCCTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.datHangBindingSource, "NhaCC", true));
            this.nhaCCTextEdit.Location = new System.Drawing.Point(393, 130);
            this.nhaCCTextEdit.Name = "nhaCCTextEdit";
            this.nhaCCTextEdit.Size = new System.Drawing.Size(125, 22);
            this.nhaCCTextEdit.TabIndex = 21;
            // 
            // cTPNTableAdapter
            // 
            this.cTPNTableAdapter.ClearBeforeFill = true;
            // 
            // colMAPN
            // 
            this.colMAPN.FieldName = "MAPN";
            this.colMAPN.MinWidth = 25;
            this.colMAPN.Name = "colMAPN";
            this.colMAPN.Visible = true;
            this.colMAPN.VisibleIndex = 0;
            this.colMAPN.Width = 94;
            // 
            // colNGAY
            // 
            this.colNGAY.FieldName = "NGAY";
            this.colNGAY.MinWidth = 25;
            this.colNGAY.Name = "colNGAY";
            this.colNGAY.Visible = true;
            this.colNGAY.VisibleIndex = 1;
            this.colNGAY.Width = 94;
            // 
            // colMasoDDH
            // 
            this.colMasoDDH.FieldName = "MasoDDH";
            this.colMasoDDH.MinWidth = 25;
            this.colMasoDDH.Name = "colMasoDDH";
            this.colMasoDDH.Visible = true;
            this.colMasoDDH.VisibleIndex = 2;
            this.colMasoDDH.Width = 94;
            // 
            // colMANV
            // 
            this.colMANV.FieldName = "MANV";
            this.colMANV.MinWidth = 25;
            this.colMANV.Name = "colMANV";
            this.colMANV.Visible = true;
            this.colMANV.VisibleIndex = 3;
            this.colMANV.Width = 94;
            // 
            // dgvCTPS
            // 
            this.dgvCTPS.AllowUserToAddRows = false;
            this.dgvCTPS.AllowUserToDeleteRows = false;
            this.dgvCTPS.AutoGenerateColumns = false;
            this.dgvCTPS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTPS.DataSource = this.bdsCTPS;
            this.dgvCTPS.Location = new System.Drawing.Point(879, 327);
            this.dgvCTPS.Name = "dgvCTPS";
            this.dgvCTPS.RowHeadersWidth = 51;
            this.dgvCTPS.RowTemplate.Height = 24;
            this.dgvCTPS.Size = new System.Drawing.Size(909, 484);
            this.dgvCTPS.TabIndex = 11;
            // 
            // mAPNDataGridViewTextBoxColumn
            // 
            this.mAPNDataGridViewTextBoxColumn.DataPropertyName = "MAPN";
            this.mAPNDataGridViewTextBoxColumn.HeaderText = "MAPN";
            this.mAPNDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.mAPNDataGridViewTextBoxColumn.Name = "mAPNDataGridViewTextBoxColumn";
            this.mAPNDataGridViewTextBoxColumn.Width = 125;
            // 
            // mAVTDataGridViewTextBoxColumn
            // 
            this.mAVTDataGridViewTextBoxColumn.DataPropertyName = "MAVT";
            this.mAVTDataGridViewTextBoxColumn.HeaderText = "MAVT";
            this.mAVTDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.mAVTDataGridViewTextBoxColumn.Name = "mAVTDataGridViewTextBoxColumn";
            this.mAVTDataGridViewTextBoxColumn.Width = 125;
            // 
            // sOLUONGDataGridViewTextBoxColumn
            // 
            this.sOLUONGDataGridViewTextBoxColumn.DataPropertyName = "SOLUONG";
            this.sOLUONGDataGridViewTextBoxColumn.HeaderText = "SOLUONG";
            this.sOLUONGDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.sOLUONGDataGridViewTextBoxColumn.Name = "sOLUONGDataGridViewTextBoxColumn";
            this.sOLUONGDataGridViewTextBoxColumn.Width = 125;
            // 
            // dONGIADataGridViewTextBoxColumn
            // 
            this.dONGIADataGridViewTextBoxColumn.DataPropertyName = "DONGIA";
            this.dONGIADataGridViewTextBoxColumn.HeaderText = "DONGIA";
            this.dONGIADataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dONGIADataGridViewTextBoxColumn.Name = "dONGIADataGridViewTextBoxColumn";
            this.dONGIADataGridViewTextBoxColumn.Width = 125;
            // 
            // rowguidDataGridViewTextBoxColumn
            // 
            this.rowguidDataGridViewTextBoxColumn.DataPropertyName = "rowguid";
            this.rowguidDataGridViewTextBoxColumn.HeaderText = "rowguid";
            this.rowguidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.rowguidDataGridViewTextBoxColumn.Name = "rowguidDataGridViewTextBoxColumn";
            this.rowguidDataGridViewTextBoxColumn.Width = 125;
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
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1808, 62);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 741);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3,
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControl1);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControl2);
            this.barManager1.DockWindowTabFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5,
            this.barButtonItem6,
            this.barButtonItem8,
            this.barButtonItem2,
            this.barButtonItem7});
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
            // bar2
            // 
            this.bar2.BarName = "Custom 5";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem5),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem6),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem7),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem8)});
            this.bar2.Text = "Custom 5";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Thêm";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.ImageOptions.SvgImageSize = new System.Drawing.Size(30, 30);
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem1.Size = new System.Drawing.Size(80, 50);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Sửa";
            this.barButtonItem2.Id = 7;
            this.barButtonItem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem2.ImageOptions.SvgImage")));
            this.barButtonItem2.ImageOptions.SvgImageSize = new System.Drawing.Size(30, 30);
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem2.Size = new System.Drawing.Size(80, 50);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Ghi";
            this.barButtonItem3.Id = 2;
            this.barButtonItem3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem3.ImageOptions.SvgImage")));
            this.barButtonItem3.ImageOptions.SvgImageSize = new System.Drawing.Size(30, 30);
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem3.Size = new System.Drawing.Size(80, 50);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Xóa";
            this.barButtonItem4.Id = 3;
            this.barButtonItem4.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem4.ImageOptions.SvgImage")));
            this.barButtonItem4.ImageOptions.SvgImageSize = new System.Drawing.Size(30, 30);
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem4.Size = new System.Drawing.Size(80, 50);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Phục hồi";
            this.barButtonItem5.Id = 4;
            this.barButtonItem5.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem5.ImageOptions.SvgImage")));
            this.barButtonItem5.ImageOptions.SvgImageSize = new System.Drawing.Size(30, 30);
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem5.Size = new System.Drawing.Size(100, 50);
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Reolad";
            this.barButtonItem6.Id = 5;
            this.barButtonItem6.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem6.ImageOptions.SvgImage")));
            this.barButtonItem6.ImageOptions.SvgImageSize = new System.Drawing.Size(30, 30);
            this.barButtonItem6.Name = "barButtonItem6";
            this.barButtonItem6.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem6.Size = new System.Drawing.Size(80, 50);
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "In danh sách nhân viên";
            this.barButtonItem7.Id = 8;
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "Thoát";
            this.barButtonItem8.Id = 6;
            this.barButtonItem8.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem8.ImageOptions.SvgImage")));
            this.barButtonItem8.ImageOptions.SvgImageSize = new System.Drawing.Size(30, 30);
            this.barButtonItem8.Name = "barButtonItem8";
            this.barButtonItem8.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem8.Size = new System.Drawing.Size(80, 50);
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Manager = this.barManager1;
            this.barDockControl1.Size = new System.Drawing.Size(1808, 62);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 803);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1808, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 62);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 741);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl2.Location = new System.Drawing.Point(1808, 62);
            this.barDockControl2.Manager = this.barManager1;
            this.barDockControl2.Size = new System.Drawing.Size(0, 741);
            // 
            // frmPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1808, 823);
            this.Controls.Add(this.dgvCTPS);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControl1);
            this.Name = "frmPhieuNhap";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "frmPhieuNhap";
            this.Load += new System.EventHandler(this.frmPhieuNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mAPNTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGAYDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGAYDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datHangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhaCCTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCTPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.Bar bar4;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DS dS;
        private System.Windows.Forms.GroupBox groupBox1;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraEditors.DateEdit nGAYDateEdit;
        private DevExpress.XtraEditors.TextEdit mAPNTextEdit;
        private DSTableAdapters.DatHangTableAdapter datHangTableAdapter;
        private System.Windows.Forms.BindingSource datHangBindingSource;
        private DevExpress.XtraEditors.TextEdit nhaCCTextEdit;
        private DSTableAdapters.CTPNTableAdapter cTPNTableAdapter;
        private System.Windows.Forms.BindingSource bdsCTPS;
        private DevExpress.XtraGrid.Columns.GridColumn colMAPN;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAY;
        private DevExpress.XtraGrid.Columns.GridColumn colMasoDDH;
        private DevExpress.XtraGrid.Columns.GridColumn colMANV;
        private System.Windows.Forms.DataGridView dgvCTPS;
        private System.Windows.Forms.DataGridViewTextBoxColumn mAPNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mAVTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sOLUONGDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dONGIADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowguidDataGridViewTextBoxColumn;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnSua;
        private DevExpress.XtraBars.BarButtonItem btnGhi;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnPhucHoi;
        private DevExpress.XtraBars.BarButtonItem btnReload;
        private DevExpress.XtraBars.BarButtonItem btnIn;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
    }
}