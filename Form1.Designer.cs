namespace QuanLyVatTu
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.S = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnDangNhap = new DevExpress.XtraBars.BarButtonItem();
            this.btnTaoTk = new DevExpress.XtraBars.BarButtonItem();
            this.btnDangXuat = new DevExpress.XtraBars.BarButtonItem();
            this.nhanVienBtn = new DevExpress.XtraBars.BarButtonItem();
            this.khoBtn = new DevExpress.XtraBars.BarButtonItem();
            this.vatTuBtn = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhieuNhanVienLapTheoNam = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.chiTietNhanVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnDanhSachNV = new DevExpress.XtraBars.BarButtonItem();
            this.btnDanhSachVatTu = new DevExpress.XtraBars.BarButtonItem();
            this.btnDonHangKoPhieuNhap = new DevExpress.XtraBars.BarButtonItem();
            this.btnTHNX = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonMiniToolbar1 = new DevExpress.XtraBars.Ribbon.RibbonMiniToolbar(this.components);
            this.systemPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.groupAction = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup11 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup12 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.categoryPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup10 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.reportPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.manv = new System.Windows.Forms.ToolStripStatusLabel();
            this.hoten = new System.Windows.Forms.ToolStripStatusLabel();
            this.nhom = new System.Windows.Forms.ToolStripStatusLabel();
            this.xtraTabControl = new DevExpress.XtraTab.XtraTabControl();
            this.btnTongHopNhapXuat = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageCategory1 = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup13 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup14 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.S)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).BeginInit();
            this.SuspendLayout();
            // 
            // S
            // 
            this.S.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(105, 92, 105, 92);
            this.S.ExpandCollapseItem.Id = 0;
            this.S.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.S.ExpandCollapseItem,
            this.btnDangNhap,
            this.btnTaoTk,
            this.btnDangXuat,
            this.nhanVienBtn,
            this.khoBtn,
            this.vatTuBtn,
            this.btnPhieuNhanVienLapTheoNam,
            this.barButtonItem1,
            this.barButtonItem2,
            this.chiTietNhanVien,
            this.btnDanhSachNV,
            this.btnDanhSachVatTu,
            this.btnDonHangKoPhieuNhap,
            this.btnTHNX,
            this.barButtonItem3,
            this.barButtonItem4});
            this.S.Location = new System.Drawing.Point(0, 0);
            this.S.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.S.MaxItemId = 22;
            this.S.MiniToolbars.Add(this.ribbonMiniToolbar1);
            this.S.Name = "S";
            this.S.OptionsMenuMinWidth = 1155;
            this.S.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.systemPage,
            this.categoryPage,
            this.reportPage});
            // 
            // 
            // 
            this.S.SearchEditItem.AccessibleName = "Search Item";
            this.S.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.S.SearchEditItem.EditWidth = 150;
            this.S.SearchEditItem.Id = -5000;
            this.S.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.S.Size = new System.Drawing.Size(1384, 193);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Caption = "Đăng nhập";
            this.btnDangNhap.Id = 1;
            this.btnDangNhap.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDangNhap.ImageOptions.SvgImage")));
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDangNhap_ItemClick);
            // 
            // btnTaoTk
            // 
            this.btnTaoTk.Caption = "Tạo tài khoản";
            this.btnTaoTk.Id = 2;
            this.btnTaoTk.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTaoTk.ImageOptions.SvgImage")));
            this.btnTaoTk.Name = "btnTaoTk";
            this.btnTaoTk.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTaoTk_ItemClick);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Caption = "Đăng xuất";
            this.btnDangXuat.Id = 3;
            this.btnDangXuat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDangXuat.ImageOptions.SvgImage")));
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDangXuat_ItemClick);
            // 
            // nhanVienBtn
            // 
            this.nhanVienBtn.Caption = "Nhân viên";
            this.nhanVienBtn.Id = 4;
            this.nhanVienBtn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nhanVienBtn.ImageOptions.SvgImage")));
            this.nhanVienBtn.Name = "nhanVienBtn";
            this.nhanVienBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // khoBtn
            // 
            this.khoBtn.Caption = "Kho";
            this.khoBtn.Id = 5;
            this.khoBtn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("khoBtn.ImageOptions.SvgImage")));
            this.khoBtn.Name = "khoBtn";
            this.khoBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.khoBtn_ItemClick);
            // 
            // vatTuBtn
            // 
            this.vatTuBtn.Caption = "Vật tư";
            this.vatTuBtn.Id = 6;
            this.vatTuBtn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("vatTuBtn.ImageOptions.SvgImage")));
            this.vatTuBtn.Name = "vatTuBtn";
            this.vatTuBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.vatTuBtn_ItemClick);
            // 
            // btnPhieuNhanVienLapTheoNam
            // 
            this.btnPhieuNhanVienLapTheoNam.Caption = "In DS Phiếu NV theo năm";
            this.btnPhieuNhanVienLapTheoNam.Id = 7;
            this.btnPhieuNhanVienLapTheoNam.Name = "btnPhieuNhanVienLapTheoNam";
            this.btnPhieuNhanVienLapTheoNam.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPhieuNhanVienLapTheoNam_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Đặt hàng";
            this.barButtonItem1.Id = 8;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick_1);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Chi tiết số lượng trị giá nhập xuất";
            this.barButtonItem2.Id = 9;
            this.barButtonItem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem2.ImageOptions.SvgImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // chiTietNhanVien
            // 
            this.chiTietNhanVien.Caption = "Chi tiết hoạt động của nhân viên";
            this.chiTietNhanVien.Id = 11;
            this.chiTietNhanVien.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("chiTietNhanVien.ImageOptions.SvgImage")));
            this.chiTietNhanVien.Name = "chiTietNhanVien";
            this.chiTietNhanVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.chiTietNhanVien_ItemClick);
            // 
            // btnDanhSachNV
            // 
            this.btnDanhSachNV.Caption = "Danh sách nhân viên";
            this.btnDanhSachNV.Id = 12;
            this.btnDanhSachNV.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDanhSachNV.ImageOptions.SvgImage")));
            this.btnDanhSachNV.Name = "btnDanhSachNV";
            this.btnDanhSachNV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDanhSachNV_ItemClick);
            // 
            // btnDanhSachVatTu
            // 
            this.btnDanhSachVatTu.Caption = "Danh sách vật tư";
            this.btnDanhSachVatTu.Id = 13;
            this.btnDanhSachVatTu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDanhSachVatTu.ImageOptions.SvgImage")));
            this.btnDanhSachVatTu.Name = "btnDanhSachVatTu";
            this.btnDanhSachVatTu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDanhSachVatTu_ItemClick);
            // 
            // btnDonHangKoPhieuNhap
            // 
            this.btnDonHangKoPhieuNhap.Caption = "Đơn hàng không phiếu nhập";
            this.btnDonHangKoPhieuNhap.Id = 14;
            this.btnDonHangKoPhieuNhap.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDonHangKoPhieuNhap.ImageOptions.SvgImage")));
            this.btnDonHangKoPhieuNhap.Name = "btnDonHangKoPhieuNhap";
            this.btnDonHangKoPhieuNhap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDonHangKoPhieuNhap_ItemClick);
            // 
            // btnTHNX
            // 
            this.btnTHNX.Caption = "Tổng hợp nhập xuất";
            this.btnTHNX.Id = 17;
            this.btnTHNX.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTHNX.ImageOptions.SvgImage")));
            this.btnTHNX.Name = "btnTHNX";
            this.btnTHNX.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTHNX_ItemClick);
            // 
            // ribbonMiniToolbar1
            // 
            this.ribbonMiniToolbar1.ParentControl = this;
            // 
            // systemPage
            // 
            this.systemPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.groupAction,
            this.ribbonPageGroup11,
            this.ribbonPageGroup12});
            this.systemPage.Name = "systemPage";
            this.systemPage.Text = "Hệ thống";
            // 
            // groupAction
            // 
            this.groupAction.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("groupAction.ImageOptions.SvgImage")));
            this.groupAction.ItemLinks.Add(this.btnDangNhap);
            this.groupAction.Name = "groupAction";
            // 
            // ribbonPageGroup11
            // 
            this.ribbonPageGroup11.ItemLinks.Add(this.btnDangXuat);
            this.ribbonPageGroup11.Name = "ribbonPageGroup11";
            // 
            // ribbonPageGroup12
            // 
            this.ribbonPageGroup12.ItemLinks.Add(this.btnTaoTk);
            this.ribbonPageGroup12.Name = "ribbonPageGroup12";
            // 
            // categoryPage
            // 
            this.categoryPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup4,
            this.ribbonPageGroup1,
            this.ribbonPageGroup10,
            this.ribbonPageGroup13,
            this.ribbonPageGroup14});
            this.categoryPage.Name = "categoryPage";
            this.categoryPage.Text = "Danh mục";
            this.categoryPage.Visible = false;
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.vatTuBtn);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.khoBtn);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.nhanVienBtn);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup10
            // 
            this.ribbonPageGroup10.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup10.Name = "ribbonPageGroup10";
            // 
            // reportPage
            // 
            this.reportPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3,
            this.ribbonPageGroup5,
            this.ribbonPageGroup6,
            this.ribbonPageGroup7,
            this.ribbonPageGroup8,
            this.ribbonPageGroup9});
            this.reportPage.Name = "reportPage";
            this.reportPage.Text = "Báo cáo";
            this.reportPage.Visible = false;
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnDanhSachNV);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ItemLinks.Add(this.btnDonHangKoPhieuNhap);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.ItemLinks.Add(this.chiTietNhanVien);
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            // 
            // ribbonPageGroup9
            // 
            this.ribbonPageGroup9.ItemLinks.Add(this.btnTHNX);
            this.ribbonPageGroup9.Name = "ribbonPageGroup9";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manv,
            this.hoten,
            this.nhom});
            this.statusStrip1.Location = new System.Drawing.Point(0, 761);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 25, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1384, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // manv
            // 
            this.manv.Name = "manv";
            this.manv.Size = new System.Drawing.Size(52, 20);
            this.manv.Text = "MANV";
            // 
            // hoten
            // 
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(57, 20);
            this.hoten.Text = "HOTEN";
            // 
            // nhom
            // 
            this.nhom.Name = "nhom";
            this.nhom.Size = new System.Drawing.Size(55, 20);
            this.nhom.Text = "NHOM";
            // 
            // xtraTabControl
            // 
            this.xtraTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
            this.xtraTabControl.Location = new System.Drawing.Point(0, 193);
            this.xtraTabControl.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.xtraTabControl.Name = "xtraTabControl";
            this.xtraTabControl.Size = new System.Drawing.Size(1384, 568);
            this.xtraTabControl.TabIndex = 0;
            this.xtraTabControl.Click += new System.EventHandler(this.xtraTabControl_Click);
            // 
            // btnTongHopNhapXuat
            // 
            this.btnTongHopNhapXuat.Caption = "Tổng hợp nhập xuất";
            this.btnTongHopNhapXuat.Id = 10;
            this.btnTongHopNhapXuat.Name = "btnTongHopNhapXuat";
            this.btnTongHopNhapXuat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTongHopNhapXuat_ItemClick);
            // 
            // ribbonPageCategory1
            // 
            this.ribbonPageCategory1.Name = "ribbonPageCategory1";
            this.ribbonPageCategory1.Text = "ribbonPageCategory1";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.btnDanhSachVatTu);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            // 
            // ribbonPageGroup13
            // 
            this.ribbonPageGroup13.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup13.Name = "ribbonPageGroup13";
            // 
            // ribbonPageGroup14
            // 
            this.ribbonPageGroup14.ItemLinks.Add(this.barButtonItem4);
            this.ribbonPageGroup14.Name = "ribbonPageGroup14";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Phiếu nhập";
            this.barButtonItem3.Id = 20;
            this.barButtonItem3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem3.ImageOptions.SvgImage")));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick_1);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Phiếu xuất";
            this.barButtonItem4.Id = 21;
            this.barButtonItem4.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem4.ImageOptions.SvgImage")));
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.Name = "sqlDataSource1";
            // 
            // Form1
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 787);
            this.Controls.Add(this.xtraTabControl);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.S);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Ribbon = this.S;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.S)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl S;
        private DevExpress.XtraBars.Ribbon.RibbonPage systemPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupAction;
        private DevExpress.XtraBars.BarButtonItem btnDangNhap;
        private DevExpress.XtraBars.BarButtonItem btnTaoTk;
        private DevExpress.XtraBars.BarButtonItem btnDangXuat;
        private DevExpress.XtraBars.Ribbon.RibbonPage categoryPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPage reportPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel manv;
        private System.Windows.Forms.ToolStripStatusLabel hoten;
        private System.Windows.Forms.ToolStripStatusLabel nhom;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl;
        private DevExpress.XtraBars.BarButtonItem nhanVienBtn;
        private DevExpress.XtraBars.BarButtonItem khoBtn;
        private DevExpress.XtraBars.BarButtonItem vatTuBtn;
        private DevExpress.XtraBars.BarButtonItem btnPhieuNhanVienLapTheoNam;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem chiTietNhanVien;
        private DevExpress.XtraBars.BarButtonItem btnDanhSachNV;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.BarButtonItem btnDanhSachVatTu;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup9;
        private DevExpress.XtraBars.BarButtonItem btnDonHangKoPhieuNhap;
        private DevExpress.XtraBars.BarButtonItem btnTongHopNhapXuat;
        private DevExpress.XtraBars.BarButtonItem btnTHNX;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageCategory ribbonPageCategory1;
        private DevExpress.XtraBars.Ribbon.RibbonMiniToolbar ribbonMiniToolbar1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup10;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup11;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup12;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup13;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup14;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    }
}

