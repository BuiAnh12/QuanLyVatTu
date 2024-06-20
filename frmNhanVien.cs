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
using static DevExpress.Xpo.Helpers.AssociatedCollectionCriteriaHelper;

namespace QuanLyVatTu
{
    public partial class frmNhanVien : Form
    {
        String macn = "";
        int vitri = 0;
        Stack<String> undo = null;
        Boolean isEditing = false;
        public frmNhanVien()
        {
            InitializeComponent();
           

            try
            {
                macn = ((DataRowView)bdsNhanVien[0])["MACN"].ToString();
            }
            catch (Exception ex)
            {
                
                //MessageBox.Show("Lỗi loadMACN : " + ex.Message, "", MessageBoxButtons.OK);
            }

            cmbChiNhanhMain.DataSource = Program.bds_dspm;
            cmbChiNhanhMain.DisplayMember = "TENCN";
            cmbChiNhanhMain.ValueMember = "TENSERVER";
            cmbChiNhanhMain.SelectedIndex = Program.mChinhanh;

            
            cmbChiNhanh.DataSource = Program.bds_dspm;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChinhanh;
            

            if (Program.mGroup == "CONGTY")
            {
                cmbChiNhanhMain.Enabled = btnThoat.Enabled = true;
                btnGhi.Enabled = btnIn.Enabled = btnPhucHoi.Enabled 
                    = btnReload.Enabled = btnSua.Enabled = btnThem.Enabled 
                    = btnXoa.Enabled = false;
            }
            else
            {
                cmbChiNhanhMain.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = false;
                btnThoat.Enabled = btnSua.Enabled = btnThem.Enabled = btnIn.Enabled
                    = btnReload.Enabled = btnXoa.Enabled = true;
            }
            undo = new Stack<String>();
            groupBox1.Enabled = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void textEdit6_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNhanVien.EndEdit();
            this.tableAdapterManager.UpdateAll(this.nhanVienDS);

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsNhanVien.Position;
            groupBox1.Enabled = true;
            bdsNhanVien.AddNew();
            checkTrangThaiXoa.Checked = false;
            DeNgaySinh.EditValue = "";
            btnIn.Enabled = btnReload.Enabled = 
                btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = false;
            btnThoat.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = true;
            gcNhanVien.Enabled = false;
            txtMACN.Text = ((DataRowView)bdsNhanVien[0])["MACN"].ToString();
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsNhanVien.CancelEdit();
            if (btnThem.Enabled == false)
            {
                bdsNhanVien.Position = vitri;
            }
            gcNhanVien.Enabled = true;
            groupBox1.Enabled = false;
            btnIn.Enabled = btnReload.Enabled = btnSua.Enabled 
                = btnThem.Enabled = btnThoat.Enabled  = btnXoa.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            this.isEditing = false;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsNhanVien.Position;
            groupBox1.Enabled = true;
            btnIn.Enabled = btnReload.Enabled = btnSua.Enabled
                = btnThem.Enabled = btnThoat.Enabled = btnXoa.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            this.isEditing = true;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.nhanVienTableAdapter.Fill(this.nhanVienDS.NhanVien);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi Reload : " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
            
        } 

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Int32 manv = 0;
            if (txtTen.Text == Program.username)
            {
                MessageBox.Show("Không thể xóa chính tài khoản đang đăng nhập", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (bdsPhieuNhap.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã lập phiếu nhập"
                    , "", MessageBoxButtons.OK);
                return;
            }
            if (bdsPhieuXuat.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã lập phiếu xuất"
                    , "", MessageBoxButtons.OK);
                return;
            }
            if (bdsDatHang.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã lập đơn đặt hàng"
                    , "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn thật sự muốn xóa nhân viên này ??"
                    , "Xác nhận", MessageBoxButtons.OKCancel)  == DialogResult.OK)
            {
                int viTriConTro = bdsNhanVien.Position;
                String manvMoi = ((DataRowView)bdsNhanVien[viTriConTro])["MANV"].ToString();
                String ho = ((DataRowView)bdsNhanVien[viTriConTro])["HO"].ToString();
                String ten = ((DataRowView)bdsNhanVien[viTriConTro])["TEN"].ToString();
                String soCMND = ((DataRowView)bdsNhanVien[viTriConTro])["SOCMND"].ToString();
                String diachi = ((DataRowView)bdsNhanVien[viTriConTro])["DIACHI"].ToString();
                String ngaySinh = ((DataRowView)bdsNhanVien[viTriConTro])["NGAYSINH"].ToString();
                String luong = ((DataRowView)bdsNhanVien[viTriConTro])["LUONG"].ToString();
                String maCN = ((DataRowView)bdsNhanVien[viTriConTro])["MACN"].ToString();
                String trangThaiXoa = ((DataRowView)bdsNhanVien[viTriConTro])["TrangThaiXoa"].ToString() == "False" ? "0" : "1";
                
                String undoQueryInsert = "INSERT INTO NhanVien (MANV, HO, TEN, SOCMND, DIACHI, NGAYSINH, LUONG, MACN, TrangThaiXoa) " +
                   "VALUES (N'"
                   + manvMoi + "',N'"
                   + ho + "',N'"
                   + ten + "',N'"
                   + soCMND + "',N'"
                   + diachi + "',N'"
                   + ngaySinh + "',N'"
                   + luong + "',N'"
                   + maCN + "',"
                   + trangThaiXoa + ")";
                this.undo.Push(undoQueryInsert);
                try
                {
                    manv = int.Parse(((DataRowView)bdsNhanVien[bdsNhanVien.Position])["MANV"].ToString());
                    bdsNhanVien.RemoveCurrent();
                    nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                    nhanVienTableAdapter.Update(nhanVienDS.NhanVien);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa nhân viên. Bạn hãy xóa lại\n" + ex.Message + ""
                    , "", MessageBoxButtons.OK);
                    this.nhanVienTableAdapter.Fill(nhanVienDS.NhanVien);
                    bdsNhanVien.Position = bdsNhanVien.Find("MANV", manv);
                    return;
                }
            }

            if (bdsNhanVien.Count == 0)
            {
                btnXoa.Enabled = false;
            }


        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            
            // TODO: This line of code loads data into the 'nhanVienDS.DatHang' table. You can move, or remove it, as needed.
            this.datHangTableAdapter.Fill(this.nhanVienDS.DatHang);
            // TODO: This line of code loads data into the 'nhanVienDS.CTPX' table. You can move, or remove it, as needed.
            this.CTPXTableAdapter.Fill(this.nhanVienDS.CTPX);
            // TODO: This line of code loads data into the 'nhanVienDS.CTPN' table. You can move, or remove it, as needed.
            this.CTPNTableAdapter.Fill(this.nhanVienDS.CTPN);


            


            nhanVienDS.EnforceConstraints = false;

            phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuXuatTableAdapter.Fill(this.nhanVienDS.PhieuXuat);

            phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.nhanVienDS.PhieuNhap);

            nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            nhanVienTableAdapter.Fill(nhanVienDS.NhanVien);

            CTPNTableAdapter.Connection.ConnectionString = Program.connstr;
            this.CTPNTableAdapter.Fill(this.nhanVienDS.CTPN);

            CTPXTableAdapter.Connection.ConnectionString = Program.connstr;
            this.CTPXTableAdapter.Fill(this.nhanVienDS.CTPX);

            datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.datHangTableAdapter.Fill(this.nhanVienDS.DatHang);

        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            bool thongQua = kiemTraRangBuoc();
            if (thongQua)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào cơ sở dữ liệu ?", "Thông báo",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (this.isEditing)
                    {
                        int viTriConTro = bdsNhanVien.Position;
                        String maNVCu = ((DataRowView)bdsNhanVien[viTriConTro])["MANV"].ToString();
                        String ho = ((DataRowView)bdsNhanVien[viTriConTro])["HO"].ToString();
                        String ten = ((DataRowView)bdsNhanVien[viTriConTro])["TEN"].ToString();
                        String soCMND = ((DataRowView)bdsNhanVien[viTriConTro])["SOCMND"].ToString();
                        String diachi = ((DataRowView)bdsNhanVien[viTriConTro])["DIACHI"].ToString();
                        String ngaySinh = ((DataRowView)bdsNhanVien[viTriConTro])["NGAYSINH"].ToString();
                        String luong = ((DataRowView)bdsNhanVien[viTriConTro])["LUONG"].ToString();
                        String maCN = ((DataRowView)bdsNhanVien[viTriConTro])["MACN"].ToString();
                        String trangThaiXoa = ((DataRowView)bdsNhanVien[viTriConTro])["TrangThaiXoa"].ToString() == "False" ? "0" : "1";
                        String maNVMoi = txtMANV.Text;
                        String undoQueryUpdate = "UPDATE NhanVien SET " +
                                 "MANV = N'" + maNVCu + "', " +
                                 "HO = N'" + ho + "', " +
                                 "TEN = N'" + ten + "', " +
                                 "DIACHI = N'" + diachi + "', " +
                                 "SOCMND = N'" + soCMND + "', " +
                                 "NGAYSINH = N'" + ngaySinh + "', " +
                                 "LUONG = N'" + luong + "', " +
                                 "MACN = N'" + maCN + "' " +
                                 "TrangThaiXoa = " + trangThaiXoa + " " +
                                 "WHERE MANV = N'" + maNVMoi + "'";
                        this.undo.Push(undoQueryUpdate);
                    }
                    else
                    {
                        String maNVMoi = txtMANV.Text;
                        String undoQueryDelete = "DELETE FROM NhanVien WHERE MANV = N'" + maNVMoi + "'";
                        this.undo.Push(undoQueryDelete);
                    }
                    try
                    {
                        bdsNhanVien.EndEdit();
                        bdsNhanVien.ResetCurrentItem();
                        nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                        nhanVienTableAdapter.Update(this.nhanVienDS.NhanVien);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi ghi nhân viên. \n" + ex.Message + ""
                            , "", MessageBoxButtons.OK);
                        return;
                    }
                    gcNhanVien.Enabled = true;
                    btnIn.Enabled = btnReload.Enabled = btnSua.Enabled
                        = btnThem.Enabled = btnThoat.Enabled = btnXoa.Enabled = true;
                    btnGhi.Enabled = btnPhucHoi.Enabled = false;
                    groupBox1.Enabled = false;
                }
                    
            }
            
        }

        int CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }

        private bool kiemTraRangBuoc()
        {
            //Set MACN thành mặc định từ combo-box
            txtMACN.Text = ((DataRowView)bdsNhanVien[0])["MACN"].ToString();
            if (txtMANV.Text.Trim() == "")
            {
                MessageBox.Show("Mã nhân viên không được để trống"
                    , "", MessageBoxButtons.OK);
                txtMANV.Focus();
                return false;
            }
            if (txtHo.Text.Trim() == "")
            {
                MessageBox.Show("Họ không được để trống"
                    , "", MessageBoxButtons.OK);
                txtHo.Focus();
                return false;
            }
            if (txtTen.Text.Trim() == "")
            {
                MessageBox.Show("Tên không được để trống"
                    , "", MessageBoxButtons.OK);
                txtTen.Focus();
                return false;
            }
            if (txtLuong.Text.Trim() == "")
            {
                MessageBox.Show("Lương không được để trống"
                    , "", MessageBoxButtons.OK);
                txtLuong.Focus();
                return false;
            }
            if (txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ không được để trống"
                    , "", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return false;
            }
            if (DeNgaySinh.Text.Trim() == "")
            {
                MessageBox.Show("Ngày sinh không được để trống"
                    , "", MessageBoxButtons.OK);
                DeNgaySinh.Focus();
                return false;
            }
            DateTime ngaySinh;
            if (!DateTime.TryParse(DeNgaySinh.Text.Trim(), out ngaySinh))
            {
                MessageBox.Show("Ngày sinh không hợp lệ", "", MessageBoxButtons.OK);
                DeNgaySinh.Focus();
                return false;
            }
            if (CalculateAge(ngaySinh) < 18)
            {
                MessageBox.Show("Nhân sự dưới 18 tuổi không được thêm vào biên chế", "", MessageBoxButtons.OK);
                DeNgaySinh.Focus();
                return false;
            }
            decimal luong;
            if (!decimal.TryParse(txtLuong.Text, out luong))
            {
                MessageBox.Show("Lương phải là một số hợp lệ", "", MessageBoxButtons.OK);
                txtLuong.Focus();
                return false;
            }
            if (luong < 4000000)
            {
                MessageBox.Show("Lương không được nhỏ hơn 4,000,000", "", MessageBoxButtons.OK);
                txtLuong.Focus();
                return false;
            }
            int viTriConTro = bdsNhanVien.Position;
            int viTriMNV = bdsNhanVien.Find("MANV", int.Parse(txtMANV.Text));
            int viTriCMND = bdsNhanVien.Find("SOCMND", long.Parse(txtCMND.Text));
            if (viTriConTro != viTriMNV && viTriMNV != -1)
            {
                MessageBox.Show("Mã nhân viên này đã được sử dụng !", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            if (viTriConTro != viTriCMND && viTriCMND != -1)
            {
                MessageBox.Show("CMND này đã được sử dụng !", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            return true;
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
                nhanVienTableAdapter.Fill(nhanVienDS.NhanVien);

                CTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                CTPNTableAdapter.Fill(this.nhanVienDS.CTPN);

                CTPXTableAdapter.Connection.ConnectionString = Program.connstr;
                CTPXTableAdapter.Fill(this.nhanVienDS.CTPX);

                datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                datHangTableAdapter.Fill(this.nhanVienDS.DatHang);

                phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuXuatTableAdapter.Fill(this.nhanVienDS.PhieuXuat);

                phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuNhapTableAdapter.Fill(this.nhanVienDS.PhieuNhap);

                try
                {
                    macn = ((DataRowView)bdsNhanVien[0])["MACN"].ToString();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lỗi loadMACN : " + ex.Message, "", MessageBoxButtons.OK);
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
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void checkTrangThaiXoa_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.undo.Count <= 0)
            {
                MessageBox.Show("Không thể undo vì chưa có hành động nào được thực hiện"
                    , "", MessageBoxButtons.OK);
                return;
            }
            else
            {
                if (Program.KetNoi() == 0)
                {
                    MessageBox.Show("Không thể kết nối với database để thực hiện tác vụ"
                    , "", MessageBoxButtons.OK);
                    return;
                }
                String undoQuery = this.undo.Pop();
                int n = Program.ExecSqlNonQuery(undoQuery);
                this.nhanVienTableAdapter.Fill(this.nhanVienDS.NhanVien);
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String macnLuanChuyen = txtMACN.Text.Trim() == "CN1" ? "CN2" : "CN1";
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn luân chuyển nhân viên có MSNV: " + txtMANV.Text + " CN tới: " + macnLuanChuyen 
                + "\nHành động này sẽ không được hoàn tác", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                if (Program.KetNoi() == 0)
                {
                    MessageBox.Show("Không thể kết nối với database để thực hiện tác vụ"
                    , "", MessageBoxButtons.OK);
                    return;
                }
                try
                {
                    String query = "exec sp_luanChuyenNV " + txtMANV.Text + ", '" + macnLuanChuyen + "'";
                    MessageBox.Show(query, "", MessageBoxButtons.OK);
                    int n = Program.ExecSqlNonQuery(query);
                    this.nhanVienTableAdapter.Fill(this.nhanVienDS.NhanVien);
                    MessageBox.Show("Luân chuyển nhân viên thành công", "", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Luân chuyển nhân viên gặp lỗi !\n" + ex, "", MessageBoxButtons.OK);
                }
            }
                
            
        }
    }
}
