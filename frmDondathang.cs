using DevExpress.XtraTab;
using QuanLyVatTu.SubForm;
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
        String macn = "";
        private Form checkExist(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }
        public void setButtonCTDDH()
        {
            themCTDDHbtn.Enabled = ghiCTDDHbtn.Enabled = suaCTDDHbtn.Enabled = false;
            xoaCTDDHbtn.Enabled = phuchoiCTDDHbtn.Enabled = false;
        }
        public frmDondathang()
        {   

            InitializeComponent();
            datHangDS.EnforceConstraints = false;

            CbChiNhanh.DataSource = Program.bds_dspm;
            CbChiNhanh.DisplayMember = "TENCN";
            CbChiNhanh.ValueMember = "TENSERVER";
            CbChiNhanh.SelectedIndex = Program.mChinhanh;

            cTDDHGridControl.Enabled = true;

            setButtonCTDDH();

            groupBox2.Enabled = groupBox3.Enabled = false;

            if (Program.mGroup == "CONGTY")
            {
                ThemBtn.Enabled = SuaBtn.Enabled = GhiBtn.Enabled = XoaBtn.Enabled = false;
                PhuchoiBtn.Enabled = reloadBtn.Enabled = false;
                ThoatBtn.Enabled =CbChiNhanh.Enabled= true;
                //groupBox1.Enabled = groupBox2.Enabled = false;

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
               


            }
            else if (Program.mGroup == "CHINHANH")
            {
                SuaBtn.Enabled = GhiBtn.Enabled = XoaBtn.Enabled = false;
                PhuchoiBtn.Enabled  =CbChiNhanh.Enabled= false;
                ThoatBtn.Enabled =ThemBtn.Enabled=reloadBtn.Enabled=true;
            }

        }

      

        private void datHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsDathang.EndEdit();
            this.tableAdapterManager.UpdateAll(this.datHangDS);

        }

        private void Dondathang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'datHangDS.Vattu' table. You can move, or remove it, as needed.
            this.vattuTableAdapter.Fill(this.datHangDS.Vattu);
            // TODO: This line of code loads data into the 'datHangDS.CTDDH' table. You can move, or remove it, as needed.
            this.cTDDHTableAdapter.Fill(this.datHangDS.CTDDH);
            // TODO: This line of code loads data into the 'datHangDS.DatHang' table. You can move, or remove it, as needed.
            this.datHangTableAdapter.Fill(this.datHangDS.DatHang);
            // TODO: This line of code loads data into the 'datHangDS.DatHang' table. You can move, or remove it, as needed.
            this.datHangTableAdapter.Fill(this.datHangDS.DatHang);
            // TODO: This line of code loads data into the 'datHangDS.CTDDH' table. You can move, or remove it, as needed.
            this.cTDDHTableAdapter.Fill(this.datHangDS.CTDDH);
            // TODO: This line of code loads data into the 'datHangDS.Vattu' table. You can move, or remove it, as needed.
            this.vattuTableAdapter.Fill(this.datHangDS.Vattu);
            // TODO: This line of code loads data into the 'datHangDS.CTDDH' table. You can move, or remove it, as needed.
            this.cTDDHTableAdapter.Fill(this.datHangDS.CTDDH);
            // TODO: This line of code loads data into the 'datHangDS.DatHang' table. You can move, or remove it, as needed.
            this.datHangTableAdapter.Fill(this.datHangDS.DatHang);
            // TODO: This line of code loads data into the 'datHangDS.CTDDH' table. You can move, or remove it, as needed.
           
            this.datHangTableAdapter.Fill(this.datHangDS.DatHang);
       
  
            // TODO: This line of code loads data into the 'dS.DatHang' table. You can move, or remove it, as needed.
            datHangDS.EnforceConstraints = false;
            this.datHangTableAdapter.Fill(this.datHangDS.DatHang);

        }

   

     
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView")
                    return;
            Program.servername=CbChiNhanh.SelectedValue.ToString();
            if (CbChiNhanh.SelectedIndex == Program.mChinhanh)
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.password;
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
                datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                datHangTableAdapter.Fill(datHangDS.DatHang);
                //try
                //{
                //    macn = ((DataRowView)bdsNhanVien[0])["MACN"].ToString();
                //}
                //catch (Exception ex)
                //{

                //    MessageBox.Show("Lỗi loadMACN : " + ex.Message, "", MessageBoxButtons.OK);
                //}

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


        private void datHangBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsDathang.EndEdit();
            this.tableAdapterManager.UpdateAll(this.datHangDS);

        }

        private void datHangBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsDathang.EndEdit();
            this.tableAdapterManager.UpdateAll(this.datHangDS);

        }

        private void datHangBindingNavigatorSaveItem_Click_3(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsDathang.EndEdit();
            this.tableAdapterManager.UpdateAll(this.datHangDS);

        }

        private void reloadBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.datHangTableAdapter.Fill(datHangDS.DatHang);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi Reload : " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            frmChonVatTu frm = new frmChonVatTu();
            frm.ShowDialog();
            this.maVatTutxt.Text = Program.maVatTudcChon;
            this.tenVatTutxt.Text = Program.tenVattudcChon;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmChonKhohang frm = new frmChonKhohang();
            frm.ShowDialog();
            this.maKhotxt.Text = Program.maKhodcChon;

            //Hien Thi Cac Truong Lien Quan
            ngayTxt.Text = DateTime.Now.ToString("M/d/yyyy");
            maNVtxt.Text = Program.username;
            // Hien thi Form CTDDH 
            themCTDDHbtn.Enabled = phuchoiCTDDHbtn.Enabled = true;
            cTDDHGridControl.Enabled = true;
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            groupBox3.Enabled = true;
            suaCTDDHbtn.Enabled = xoaCTDDHbtn.Enabled = false;
        }

        private void ThemBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            datHangGridControl.Enabled = false;
            groupBox2.Enabled = true;
            groupBox3.Enabled = false;
            cTDDHGridControl.DataSource = null;
            MaDontxt.Text = nhaCCtxt.Text = maKhotxt.Text = ngayTxt.Text = maNVtxt.Text = "";
            maVatTutxt.Text = tenVatTutxt.Text = soLuongtxt.Text = donGiatxt.Text = "";
        }
    }
}
