using DevExpress.DXTemplateGallery.Extensions;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
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
                Program.mlogin = txtTaiKhoang.Text;
                Program.password = txtMatKhau.Text;
                if (Program.KetNoi() == 0)
                {
                    return;
                }
                Program.mChinhanh = cmbChiNhanh.SelectedIndex;
                Program.mloginDN = Program.mlogin;
                Program.passwordDN = Program.password;
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
            cmbChiNhanh.SelectedIndex = 1; cmbChiNhanh.SelectedIndex = 0;
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
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Close the application
                this.Close();
            }
        }
    }
}