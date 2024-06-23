using DevExpress.CodeParser;
using DevExpress.Diagram.Core.Shapes;
using DevExpress.XtraReports.UI;
using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyVatTu
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            btnTaoTk.Enabled = false;
            btnDangXuat.Enabled = false;
            btnDangNhap.PerformClick();

        }

        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (ftype == f.GetType())
                {
                    return f;
                }
            }
            return null;
        }

        private XtraTabPage CheckExistsXtra(Type ftype)
        {
            foreach (XtraTabPage page in xtraTabControl.TabPages)
            {
                if (page.Controls.Count > 0 && page.Controls[0] is Form form && form.GetType() == ftype)
                {
                    return page;
                }
            }
            return null;
        }
        private void btnDangNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mlogin != "")
            {
                btnDangNhap.Enabled = false;
                MessageBox.Show("Bạn đã đăng nhập thành công rồi!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            XtraTabPage frm = this.CheckExistsXtra(typeof(frmDangNhap));
            if (frm != null)
            {
                xtraTabControl.SelectedTabPage = frm;
            }
            else
            {

                frmDangNhap f = new frmDangNhap();
                f.MdiParent = this;

                f.TopLevel = false; // Set TopLevel to false
                f.FormBorderStyle = FormBorderStyle.None; // bỏ khung border

                XtraTabPage tabPage = new XtraTabPage();
                tabPage.Text = "Đăng nhập"; // Tiêu đề


                tabPage.Controls.Add(f); // thêm tab đó vào 
                f.Show(); // Hiển thị form
                xtraTabControl.TabPages.Add(tabPage); // Thêm nó vào tab control
                xtraTabControl.SelectedTabPage = tabPage;



                
            }

        }

        public void HienThiMenu()
        {
            manv.Text = "Mã NV: " + Program.username;
            nhom.Text = "Nhóm: " + Program.mGroup;
            hoten.Text = "Họ tên nhân viên: " + Program.mHoten;
            categoryPage.Visible = true;
            reportPage.Visible = true;
            btnTaoTk.Enabled = true;
            btnDangXuat.Enabled = true;
        }

        private void btnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                manv.Text = "MANV";
                nhom.Text = "NHOM";
                hoten.Text = "HOTEN";
                Program.mlogin = "";
                Program.password = "";
                Program.mGroup = "";
                Program.mHoten = "";
                Program.username = "";
                categoryPage.Visible = false;
                reportPage.Visible = false;
                btnTaoTk.Enabled = false;
                XtraTabControl tabControl = FindTabControl(this);
                btnDangXuat.Enabled = false;
                btnDangNhap.Enabled = true;

                if (tabControl != null)
                {
                    // Clear all tab pages
                    tabControl.TabPages.Clear();
                }
                btnDangNhap.PerformClick();
                btnDangXuat.Enabled = false;
            }
        }

        private XtraTabControl FindTabControl(Control control)
        {
            foreach (Control ctrl in control.Controls)
            {
                if (ctrl is XtraTabControl)
                {
                    return (XtraTabControl)ctrl;
                }
                else
                {
                    XtraTabControl tabControl = FindTabControl(ctrl);
                    if (tabControl != null)
                    {
                        return tabControl;
                    }
                }
            }
            return null;
        }

        private void xtraTabControl_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage frm = this.CheckExistsXtra(typeof(frmNhanVien));
            if (frm != null) xtraTabControl.SelectedTabPage = frm;
            else
            {

                frmNhanVien f = new frmNhanVien();
                f.MdiParent = this;

                f.TopLevel = false; // Set TopLevel to false
                f.FormBorderStyle = FormBorderStyle.None; // bỏ khung border

                XtraTabPage tabPage = new XtraTabPage();
                tabPage.Text = "Nhân viên"; // Tiêu đề


                tabPage.Controls.Add(f); // thêm tab đó vào 
                f.Show(); // Hiển thị form
                xtraTabControl.TabPages.Add(tabPage); // Thêm nó vào tab control
                xtraTabControl.SelectedTabPage = tabPage;
            }
        }

        private void khoBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage frm = this.CheckExistsXtra(typeof(frmKho));
            if (frm != null) xtraTabControl.SelectedTabPage = frm;
            else
            {

                frmKho f = new frmKho();
                f.MdiParent = this;

                f.TopLevel = false; // Set TopLevel to false
                f.FormBorderStyle = FormBorderStyle.None; // bỏ khung border

                XtraTabPage tabPage = new XtraTabPage();
                tabPage.Text = "Kho"; // Tiêu đề


                tabPage.Controls.Add(f); // thêm tab đó vào 
                f.Show(); // Hiển thị form
                xtraTabControl.TabPages.Add(tabPage); // Thêm nó vào tab control
                xtraTabControl.SelectedTabPage = tabPage;

            }
        }

        private void vatTuBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage frm = this.CheckExistsXtra(typeof(frmVatTu));
            if (frm != null) xtraTabControl.SelectedTabPage = frm;
            else
            {

                frmVatTu f = new frmVatTu();
                f.MdiParent = this;

                f.TopLevel = false; // Set TopLevel to false
                f.FormBorderStyle = FormBorderStyle.None; // bỏ khung border

                XtraTabPage tabPage = new XtraTabPage();
                tabPage.Text = "Vật tư"; // Tiêu đề


                tabPage.Controls.Add(f); // thêm tab đó vào 
                f.Show(); // Hiển thị form
                xtraTabControl.TabPages.Add(tabPage); // Thêm nó vào tab control
                xtraTabControl.SelectedTabPage = tabPage;
            }
        }

        private void btnPhieuNhanVienLapTheoNam_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(Frpt_PhieuNvLapTrongNamTheoLoai));
            if (frm != null) frm.Activate();
            else
            {

                Frpt_PhieuNvLapTrongNamTheoLoai f = new Frpt_PhieuNvLapTrongNamTheoLoai();
                f.TopLevel = false; // Set TopLevel to false
                f.FormBorderStyle = FormBorderStyle.None; // Optionally remove border

                XtraTabPage tabPage = new XtraTabPage();
                tabPage.Text = "In nhân viên"; // Set the tab page text

                // Create a panel to host the form
                Panel panel = new Panel();
                panel.Dock = DockStyle.Fill; // Dock the panel to fill the tab page
                tabPage.Controls.Add(panel); // Add the panel to the tab page
                f.Parent = panel; // Set the panel as the parent of the form

                // Show the form
                f.Show();

                xtraTabControl.TabPages.Add(tabPage); // Add the tab page to the tab control
                xtraTabControl.SelectedTabPage = tabPage;
            }
        }

        private void btnTaoTk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mGroup == "USER")
            {
                MessageBox.Show("User không có quyền truy cập chức năng này! ", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            XtraTabPage frm = this.CheckExistsXtra(typeof(frmTaoTaiKhoan));
            if (frm != null) xtraTabControl.SelectedTabPage = frm;
            else
            {

                frmTaoTaiKhoan f = new frmTaoTaiKhoan();
                f.MdiParent = this;

                f.TopLevel = false; // Set TopLevel to false
                f.FormBorderStyle = FormBorderStyle.None; // bỏ khung border

                XtraTabPage tabPage = new XtraTabPage();
                tabPage.Text = "Tạo tài khoảng"; // Tiêu đề


                tabPage.Controls.Add(f); // thêm tab đó vào 
                f.Show(); // Hiển thị form
                xtraTabControl.TabPages.Add(tabPage); // Thêm nó vào tab control
                xtraTabControl.SelectedTabPage = tabPage;

            }
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmDondathang));
            if (frm != null) frm.Activate();
            else
            {

                frmDondathang f = new frmDondathang();
                f.TopLevel = false; // Set TopLevel to false
                f.FormBorderStyle = FormBorderStyle.None; // Optionally remove border

                XtraTabPage tabPage = new XtraTabPage();
                tabPage.Text = "Đặt hàng"; // Set the tab page text

                // Create a panel to host the form
                Panel panel = new Panel();
                panel.Dock = DockStyle.Fill; // Dock the panel to fill the tab page
                tabPage.Controls.Add(panel); // Add the panel to the tab page
                f.Parent = panel; // Set the panel as the parent of the form

                // Show the form
                f.Show();



                xtraTabControl.TabPages.Add(tabPage); // Add the tab page to the tab control
                xtraTabControl.SelectedTabPage = tabPage;
            }
        }

        // <<<<<<< HEAD
        //         private void phieuNhapBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //         {
        //             Form frm = this.CheckExists(typeof(frmPhieuNhap));
        //             if (frm != null) frm.Activate();
        //             else
        //             {

        //                 frmPhieuNhap f = new frmPhieuNhap();
        //                 f.TopLevel = false; // Set TopLevel to false
        //                 f.FormBorderStyle = FormBorderStyle.None; // Optionally remove border

        //                 XtraTabPage tabPage = new XtraTabPage();
        //                 tabPage.Text = "Đặt hàng"; // Set the tab page text

        //                 // Create a panel to host the form
        //                 Panel panel = new Panel();
        //                 panel.Dock = DockStyle.Fill; // Dock the panel to fill the tab page
        //                 tabPage.Controls.Add(panel); // Add the panel to the tab page
        //                 f.Parent = panel; // Set the panel as the parent of the form

        //                 // Show the form
        //                 f.Show();



        //                 xtraTabControl.TabPages.Add(tabPage); // Add the tab page to the tab control
        //                 xtraTabControl.SelectedTabPage = tabPage;

        //             }
        // =======
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmChiTietSoLuongTriGiaHangHoaNhapXuat frpt = new frmChiTietSoLuongTriGiaHangHoaNhapXuat();

            frpt.ShowDialog();

        }

        private void btnTongHopNhapXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            

        }

        private void chiTietNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frpt_HoatDongNhanVien frpt = new Frpt_HoatDongNhanVien();
            frpt.ShowDialog();
            // >>>>>>> 792ccfc0b905ab191e4fc4452c9545d4a228bdc1
        }

        private void phieuNhapBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmPhieuNhap));
            if (frm != null) frm.Activate();
            else
            {

                frmPhieuNhap f = new frmPhieuNhap();
                f.TopLevel = false; // Set TopLevel to false
                f.FormBorderStyle = FormBorderStyle.None; // Optionally remove border

                XtraTabPage tabPage = new XtraTabPage();
                tabPage.Text = "Phiếu Nhập"; // Set the tab page text

                // Create a panel to host the form
                Panel panel = new Panel();
                panel.Dock = DockStyle.Fill; // Dock the panel to fill the tab page
                tabPage.Controls.Add(panel); // Add the panel to the tab page
                f.Parent = panel; // Set the panel as the parent of the form

                // Show the form
                f.Show();



                xtraTabControl.TabPages.Add(tabPage); // Add the tab page to the tab control
                xtraTabControl.SelectedTabPage = tabPage;
            }
        }

        private void btnDanhSachNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frpt_DanhSachNhanVien frpt = new Frpt_DanhSachNhanVien();
            frpt.ShowDialog();

        }

        private void btnDanhSachVatTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DanhSachVT xrpt = new DanhSachVT();
            ReportPrintTool print = new ReportPrintTool(xrpt);
            print.ShowPreviewDialog();
        }

        private void btnDonHangKoPhieuNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frpt_DDHChuaCoPhieuNhap frpt = new Frpt_DDHChuaCoPhieuNhap();
            frpt.ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Khong đụng vào nha
        }

        private void btnTHNX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frpt_TongHopNhapXuat frpt = new Frpt_TongHopNhapXuat();
            frpt.ShowDialog();
        }

        private void barButtonItem3_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Phieu nhap
            XtraTabPage frm = this.CheckExistsXtra(typeof(frmPhieuNhap));
            if (frm != null) xtraTabControl.SelectedTabPage = frm;
            else
            {

                frmPhieuNhap f = new frmPhieuNhap();
                f.MdiParent = this;

                f.TopLevel = false; // Set TopLevel to false
                f.FormBorderStyle = FormBorderStyle.None; // bỏ khung border

                XtraTabPage tabPage = new XtraTabPage();
                tabPage.Text = "Phiếu nhập"; // Tiêu đề


                tabPage.Controls.Add(f); // thêm tab đó vào 
                f.Show(); // Hiển thị form
                xtraTabControl.TabPages.Add(tabPage); // Thêm nó vào tab control
                xtraTabControl.SelectedTabPage = tabPage;

            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Phieu xuat
            XtraTabPage frm = this.CheckExistsXtra(typeof(frmPhieuXuat));
            if (frm != null) xtraTabControl.SelectedTabPage = frm;
            else
            {

                frmPhieuXuat f = new frmPhieuXuat();
                f.MdiParent = this;

                f.TopLevel = false; // Set TopLevel to false
                f.FormBorderStyle = FormBorderStyle.None; // bỏ khung border

                XtraTabPage tabPage = new XtraTabPage();
                tabPage.Text = "Phiếu xuất"; // Tiêu đề


                tabPage.Controls.Add(f); // thêm tab đó vào 
                f.Show(); // Hiển thị form
                xtraTabControl.TabPages.Add(tabPage); // Thêm nó vào tab control
                xtraTabControl.SelectedTabPage = tabPage;

            }
        }

        private void S_Click(object sender, EventArgs e)
        {

        }
    }
}
