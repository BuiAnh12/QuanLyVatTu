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

        private void btnDangNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mlogin != "")
            {
                btnDangNhap.Enabled = false;
                MessageBox.Show("Bạn đã đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            Form frm = this.CheckExists(typeof(frmDangNhap));
            if (frm != null) frm.Activate();
            else
            {

                frmDangNhap f = new frmDangNhap();
                f.TopLevel = false; // Set TopLevel to false
                f.FormBorderStyle = FormBorderStyle.None; // Optionally remove border

                XtraTabPage tabPage = new XtraTabPage();
                tabPage.Text = "DangNhap"; // Set the tab page text

                // Create a panel to host the form
                Panel panel = new Panel();
                panel.Dock = DockStyle.Fill; // Dock the panel to fill the tab page
                tabPage.Controls.Add(panel); // Add the panel to the tab page
                f.Parent = panel; // Set the panel as the parent of the form

                // Show the form
                f.Show();



                xtraTabControl.TabPages.Add(tabPage); // Add the tab page to the tab control
                xtraTabControl.SelectedTabPage = tabPage;
                btnDangXuat.Enabled = true;
            }
            
        }

        public void HienThiMenu()
        {
            manv.Text = "Mã NV: " + Program.username;
            nhom.Text = "Nhóm: " + Program.mGroup;
            hoten.Text = "Họ tên nhân viên: " + Program.mHoten;
            categoryPage.Visible = true;
            businessPage.Visible = true;
            reportPage.Visible = true;
            btnTaoTk.Enabled = true;
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
                businessPage.Visible = false;
                reportPage.Visible = false;
                btnTaoTk.Enabled = false;
                XtraTabControl tabControl = FindTabControl(this);

                if (tabControl != null)
                {
                    // Clear all tab pages
                    tabControl.TabPages.Clear();
                }
            }
            btnDangXuat.Enabled = false;
            btnDangNhap.Enabled = true;
            btnDangNhap.PerformClick();
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
            Form frm = this.CheckExists(typeof(frmNhanVien));
            if (frm != null) frm.Activate();
            else
            {

                frmNhanVien f = new frmNhanVien();
                f.TopLevel = false; // Set TopLevel to false
                f.FormBorderStyle = FormBorderStyle.None; // Optionally remove border

                XtraTabPage tabPage = new XtraTabPage();
                tabPage.Text = "NhanVien"; // Set the tab page text

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

        private void khoBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmKho));
            if (frm != null) frm.Activate();
            else
            {

                frmKho f = new frmKho();
                f.TopLevel = false; // Set TopLevel to false
                f.FormBorderStyle = FormBorderStyle.None; // Optionally remove border

                XtraTabPage tabPage = new XtraTabPage();
                tabPage.Text = "Kho"; // Set the tab page text

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

        private void vatTuBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmVatTu));
            if (frm != null) frm.Activate();
            else
            {

                frmVatTu f = new frmVatTu();
                f.TopLevel = false; // Set TopLevel to false
                f.FormBorderStyle = FormBorderStyle.None; // Optionally remove border

                XtraTabPage tabPage = new XtraTabPage();
                tabPage.Text = "Vật tư"; // Set the tab page text

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
            Form frm = this.CheckExists(typeof(frmTaoTaiKhoan));
            if (frm != null) frm.Activate();
            else
            {

                frmTaoTaiKhoan f = new frmTaoTaiKhoan();
                f.TopLevel = false; // Set TopLevel to false
                f.FormBorderStyle = FormBorderStyle.None; // Optionally remove border

                XtraTabPage tabPage = new XtraTabPage();
                tabPage.Text = "Tạo tài khoản"; // Set the tab page text

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

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmChiTietSoLuongTriGiaHangHoaNhapXuat frpt = new frmChiTietSoLuongTriGiaHangHoaNhapXuat();

            frpt.ShowDialog();

        }

        private void btnTongHopNhapXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frpt_TongHopNhapXuat frpt = new Frpt_TongHopNhapXuat();
            frpt.ShowDialog();

        }
    }
}
