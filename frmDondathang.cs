using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyVatTu
{
    public partial class frmDondathang : Form
    {

        private Form checkExist(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }
        public frmDondathang()
        {   

            InitializeComponent();
            datHangDS.EnforceConstraints = false;

            if (Program.mGroup == "CONGTY")
            {
                ThemBtn.Enabled = SuaBtn.Enabled = GhiBtn.Enabled = XoaBtn.Enabled = false;
                PhuchoiBtn.Enabled = reloadBtn.Enabled = false;
                ThoatBtn.Enabled =CbChiNhanh.Enabled= true;
                //groupBox1.Enabled = groupBox2.Enabled = false;
                panelControl3.Enabled = false;

                CbChiNhanh.DataSource = Program.bds_dspm;
                CbChiNhanh.DisplayMember = "TENCN";
                CbChiNhanh.ValueMember = "TENSERVER";

            }
            else if (Program.mGroup == "USER")
            {
                ThemBtn.Enabled = SuaBtn.Enabled = GhiBtn.Enabled = XoaBtn.Enabled = false;
                PhuchoiBtn.Enabled = false;
                CbChiNhanh.Enabled = false;
                ThoatBtn.Enabled  = true;
                reloadBtn.Enabled = true;
                //groupBox1.Enabled = groupBox2.Enabled = false;
                panelControl3.Enabled = false;



            }
            else if (Program.mGroup == "CHINHANH")
            {
                SuaBtn.Enabled = GhiBtn.Enabled = XoaBtn.Enabled = false;
                PhuchoiBtn.Enabled  =CbChiNhanh.Enabled= false;
                ThoatBtn.Enabled =ThemBtn.Enabled=reloadBtn.Enabled=true;
                //groupBox1.Enabled = groupBox2.Enabled = false;
                panelControl3.Enabled = false;
            }

        }

      

        private void datHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsDathang.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void Dondathang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'datHangDS.CTDDH' table. You can move, or remove it, as needed.
            this.cTDDHTableAdapter1.Fill(this.datHangDS.CTDDH);
            // TODO: This line of code loads data into the 'datHangDS.DatHang' table. You can move, or remove it, as needed.
            this.datHangTableAdapter1.Fill(this.datHangDS.DatHang);
            // TODO: This line of code loads data into the 'dS.CTDDH' table. You can move, or remove it, as needed.
            this.CTDDHTableAdapter.Fill(this.dS.CTDDH);
            // TODO: This line of code loads data into the 'dS.DatHang' table. You can move, or remove it, as needed.
            dS.EnforceConstraints = false;
            this.datHangTableAdapter.Fill(this.dS.DatHang);

        }

   

     
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView")
                    return;
            Program.servername=CbChiNhanh.SelectedValue.ToString();
            if (CbChiNhanh.SelectedIndex == Program.mChinhanh)
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.mloginDN;
            }
            else
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
            }
            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Xảy ra kết nối với chi nhánh hiện tại ", "Thông báo ", MessageBoxButtons.OK);
            }
            else
            {
                this.CTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
                //this.CTDDHTableAdapter.Fill(this.)
            }
            //        if (CbChiNhanh.SelectedIndex != Program.mChinhanh)
            //        {
            //            Program.mlogin = Program.remotelogin;
            //            Program.passwordDN = Program.remotepassword;
            //        }
            //        /*Neu chon trung voi chi nhanh dang dang nhap o formDangNhap*/
            //        else
            //        {
            //            Program.mlogin = Program.currentLogin;
            //            Program.passwordDN = Program.currentPassword;
            //        }

            //        if (Program.KetNoi() == 0)
            //        {
            //            MessageBox.Show("Xảy ra lỗi kết nối với chi nhánh hiện tại", "Thông báo", MessageBoxButtons.OK);
            //        }
            //        else
            //        {
            //            this.CTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            //            this.CTDDHTableAdapter.Fill(this.dS.CTDDH);

            //            this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            //            this.datHangTableAdapter.Fill(this.dS.DatHang);

            //        }

            //    }
        }


        private XtraTabControl FindTabControl(Control control)
        {
            while (control != null)
            {
                if (control is XtraTabControl tabControl)
                {
                    return tabControl;
                }
                control = control.Parent;
            }
            return null;
        }
        private void ThoatBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi tab này không", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                XtraTabControl tabControl = FindTabControl(this);

                if (tabControl != null)
                {
                    // Get the parent tab page
                    XtraTabPage tabPage = tabControl.SelectedTabPage;

                    if (tabPage != null)
                    {
                        // Remove the current tab page
                        tabControl.TabPages.Remove(tabPage);
                    }
                }
            }
        }

        private void panelControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void panelControl3_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
