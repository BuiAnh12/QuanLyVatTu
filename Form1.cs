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
            Form frm = this.CheckExists(typeof(frmDangNhap));
            if (frm != null) frm.Activate();
            else
            {
                frmDangNhap f = new frmDangNhap();
                f.MdiParent = this;
                f.Show();
            }
        }

        public void HienThiMenu()
        {
            manv.Text = "Mã NV: " + Program.username;
            nhom.Text = "Nhóm: " + Program.mGroup;
            hoten.Text = "Họ tên nhân viên: " + Program.mHoten;

        }

        private void btnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            manv.Text = "MANV";
            nhom.Text = "NHOM";
            hoten.Text = "HOTEN";
            Program.mlogin = "";
            Program.password = "";
            Program.mGroup = "";
            Program.mHoten = "";
            Program.username = "";
        }
    }
}
