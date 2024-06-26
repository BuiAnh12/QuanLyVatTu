﻿using DevExpress.DXTemplateGallery.Extensions;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Model;
using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyVatTu
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        private SqlConnection conn_publisher = new SqlConnection();

        private void layDSPM(String cmd)
        {
            DataTable dt = new DataTable();
            try
            {
                if (conn_publisher.State == ConnectionState.Closed)
                {
                    conn_publisher.Open();
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd, conn_publisher);
                da.Fill(dt);

                Program.bds_dspm.DataSource = dt;
                cmbChiNhanh.DataSource = dt;
                cmbChiNhanh.DisplayMember = "TENCN";
                cmbChiNhanh.ValueMember = "TENSERVER";
                cmbChiNhanh.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn_publisher.Close();
            }
        }

        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }
        public frmDangNhap()
        {
            InitializeComponent();
            frmDangNhap_Load(this, EventArgs.Empty);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.Text.Trim() == "" || txtMatKhau.Text.Trim() == "")
            {
                MessageBox.Show("Tài khoản và mật khẩu không được để trống");
                return;
            }
            else
            {
                try
                {
                    /*
                        Login bằng cách cập nhập mLogin và password -> nhận bởi Program.KetNoi() -> kết nối với db -> cred sai thì báo ko kết nối được
                    */
                    Program.mlogin = txtTaiKhoang.Text;
                    Program.password = txtMatKhau.Text;
                    if (Program.KetNoi() == 0)
                    {
                        return;
                    }
                    Program.mChinhanh = cmbChiNhanh.SelectedIndex;
                    Program.mloginDN = Program.mlogin;
                    Program.passwordDN = Program.password;
                    /*
                        Login được -> truy xuất thông tin cơ bản của nv đăng nhập bằng SP_LayThongTinNhanVien với login đã cho
                    */
                    string strLenh = "EXECUTE SP_LayThongTinNhanVien '" + Program.mlogin + "'";

                    Program.myReader = Program.ExecSqlDataReader(strLenh);
                    if (Program.myReader == null)
                    {
                        return;
                    }
                    Program.myReader.Read();


                    Program.username = Program.myReader.GetString(0);
                    if (Convert.IsDBNull(Program.username))
                    {
                        MessageBox.Show("Bạn không có quyền truy cập dữ liệu");
                        return;
                    }
                    Program.mHoten = Program.myReader.GetString(1);
                    Program.mGroup = Program.myReader.GetString(2);
                    Program.myReader.Close();
                    Program.conn.Close();

                    Program.frmChinh.HienThiMenu();
                    MessageBox.Show("Bạn đã đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK);
                    if (Program.mGroup == "USER")
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi!" + ex, "Thông báo", MessageBoxButtons.OK);
                    throw;
                }
                
            }
        }

        private int KetNoiCSDL_GOC()
        {
            try
            {
                conn_publisher.ConnectionString = Program.connstr_publisher;
                conn_publisher.Open();
                return 1;
            }
            catch (Exception e)
            {

                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nBạn xem lại user name và password.\n " + e.Message, "", MessageBoxButtons.OK);
                return 0;
            }
        }


        private void frmDangNhap_Load(object sender, EventArgs e) {

            if (KetNoiCSDL_GOC() == 0)
            {
                return;
            }
            layDSPM("USE [QLVT_DATHANG] SELECT * FROM V_DS_PHANMANH");
            cmbChiNhanh.SelectedIndex = 1;
            cmbChiNhanh.SelectedIndex = 0;
            
        }

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Program.servername = cmbChiNhanh.SelectedValue.ToString();
            }
            catch (Exception)
            {

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Ask the user for confirmation before exiting
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi tab này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
    }
}