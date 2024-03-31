using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using QuanLyVatTu.DSTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyVatTu
{
    
    public partial class frmTaoTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        String macn = "";
        int MaNV;
        public frmTaoTaiKhoan()
        {
            InitializeComponent();
            try
            {
                macn = ((DataRowView)bdsNhanVien[0])["MACN"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi loadMACN : " + ex.Message, "", MessageBoxButtons.OK);
            }

            // Set up cmbChiNhanhMain
            cmbChiNhanhMain.DataSource = Program.bds_dspm;
            cmbChiNhanhMain.DisplayMember = "TENCN";
            cmbChiNhanhMain.ValueMember = "TENSERVER";
            cmbChiNhanhMain.SelectedIndex = Program.mChinhanh;
            cmbChiNhanhMain.SelectedIndexChanged += new EventHandler(cmbChiNhanhMain_SelectedIndexChanged);

            // Set up cmbPhanQuyen
            cmbPhanQuyen.Items.AddRange(new string[] { "CONGTY", "CHINHANH", "USER" });
            if (Program.mGroup == "CONGTY")
            {
                cmbChiNhanhMain.Enabled = true;
                cmbPhanQuyen.SelectedIndex = 0;
                cmbPhanQuyen.Enabled = false;
            }
            else
            {
                cmbPhanQuyen.Enabled = true;
            }
            
        }



        private void frmTaoTaiKhoan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nhanVienDS.DatHang' table. You can move, or remove it, as needed.
            this.datHangTableAdapter.Fill(this.nhanVienDS.DatHang);
            nhanVienDS.EnforceConstraints = false;
            nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.nhanVienDS.NhanVien);

            hoTenNVTableAdapter.Connection.ConnectionString = Program.connstr;
            this.hoTenNVTableAdapter.Fill(this.nhanVienDS.HoTenNV);
            updateContain();
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void hOTENLabel_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cmbChiNhanhMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChiNhanhMain.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                return;
            }
            Program.servername = cmbChiNhanhMain.SelectedValue.ToString();
            if (cmbChiNhanhMain.SelectedIndex != Program.mChinhanh)
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }
            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Lỗi kết nối về chi nhánh mới"
                    , "", MessageBoxButtons.OK);
                return;
            }
            else
            {
                nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.nhanVienTableAdapter.Fill(this.nhanVienDS.NhanVien);

                hoTenNVTableAdapter.Connection.ConnectionString = Program.connstr;
                this.hoTenNVTableAdapter.Fill(this.nhanVienDS.HoTenNV);

                try
                {
                    macn = ((DataRowView)bdsNhanVien[0])["MACN"].ToString();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lỗi loadMACN : " + ex.Message, "", MessageBoxButtons.OK);
                }
            }
            cmbHoTenNV_SelectedIndexChanged(sender, e);
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void updateContain()
        {
            try
            {
                if (cmbHoTenNV != null && cmbHoTenNV.SelectedValue != null)
                {
                    MaNV = Convert.ToInt32(cmbHoTenNV.SelectedValue);
                    string strLenh = "EXECUTE SP_LayLogin '" + cmbHoTenNV.SelectedValue + "'";
                    Program.myReader = Program.ExecSqlDataReader(strLenh);
                    if (Program.myReader == null)
                    {
                        return;
                    }
                    bool rowFound = Program.myReader.Read(); // Check if there is at least one row

                    if (rowFound)
                    {
                        string TENLOGIN = Program.myReader["TENLOGIN"].ToString();
                        string TENNHOM = Program.myReader["TENNHOM"].ToString();

                        txtMatKhau.Enabled = txtTaiKhoan.Enabled = false;

                        this.txtTaiKhoan.Text = TENLOGIN;
                        this.txtMatKhau.Text = "*******";
                        cmbPhanQuyen.SelectedItem = TENNHOM;
                        cmbPhanQuyen.Enabled = false;

                        btnTaoTK.Enabled = false;
                        btnXoaTK.Enabled = true;
                    }
                    else
                    {

                        txtMatKhau.Enabled = txtTaiKhoan.Enabled = true;
                        this.txtTaiKhoan.Text = "";
                        this.txtMatKhau.Text = "";
                        cmbPhanQuyen.Text = "";
                        cmbPhanQuyen.SelectedItem = Program.mGroup;
                        if (Program.mGroup == "CONGTY")
                        {
                            cmbPhanQuyen.Enabled = false;
                        }
                        else
                        {
                            cmbPhanQuyen.Enabled = true;
                        }
                        btnTaoTK.Enabled = true;
                        btnXoaTK.Enabled = false;
                    }
                    Program.myReader.Close();
                }
                else
                {
                    // Handle the case when cmbHoTen or SelectedValue is null
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi loadMACN : " + ex.Message, "", MessageBoxButtons.OK);
            }
        }


        private void cmbHoTenNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateContain();
        }

        private void btnTaoTK_Click(object sender, EventArgs e)
        {

            int index = cmbHoTenNV.SelectedIndex;
            try
            {
                if (txtMatKhau.Text.Trim() == "")
                {
                    MessageBox.Show("Mật khẩu không được để trống", "", MessageBoxButtons.OK);
                    txtMatKhau.Focus();
                    return;
                }
                if (txtTaiKhoan.Text.Trim() == "")
                {
                    MessageBox.Show("Tên tài khoản được để trống", "", MessageBoxButtons.OK);
                    txtTaiKhoan.Focus();
                    return;
                }

                // Call the stored procedure to add login and roles
                string strLenh = "EXEC SP_ThemLogin '" + txtTaiKhoan.Text + "', '" + txtMatKhau.Text + "', '" + Program.database + "', '" + txtMaNV.Text + "', '" + this.cmbPhanQuyen.Text + "'";
                Program.ExecSqlNonQuery(strLenh);

                MessageBox.Show("Tạo tài khoản thành công", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo tài khoản: " + ex.Message, "", MessageBoxButtons.OK);
            }
            cmbHoTenNV_SelectedIndexChanged(sender, e);
            cmbHoTenNV.SelectedIndex = index;
        }



        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            int index = cmbHoTenNV.SelectedIndex;
            try
            {
                // Call the stored procedure to delete the login and associated user
                string strLenh = "EXEC SP_XoaLogin @login = '" + txtTaiKhoan.Text + "', @user = '" + this.txtMaNV.Text + "'";
                Program.ExecSqlNonQuery(strLenh);

                MessageBox.Show("Xóa tài khoản thành công", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa tài khoản: " + ex.Message, "", MessageBoxButtons.OK);
            }
            cmbHoTenNV_SelectedIndexChanged(sender, e);
            cmbHoTenNV.SelectedIndex = index;
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

        private void btnThoat_Click(object sender, EventArgs e)
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
    }
}