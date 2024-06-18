using DevExpress.XtraTab;
using QuanLyVatTu.DSTableAdapters;
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
    public partial class frmKho : Form
    {

        String macn = "";
        int vitri = 0;
        Stack<String> undo = null;
        Boolean isEditing = false;

        public frmKho()
        {
            InitializeComponent();


            try
            {
                macn = ((DataRowView)bdsKho[0])["MACN"].ToString();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Lỗi loadMACN : " + ex.Message, "", MessageBoxButtons.OK);
            }

            cmbChiNhanhMain.DataSource = Program.bds_dspm;
            cmbChiNhanhMain.DisplayMember = "TENCN";
            cmbChiNhanhMain.ValueMember = "TENSERVER";
            cmbChiNhanhMain.SelectedIndex = Program.mChinhanh;

            txtMACN.Enabled = false;

          


            if (Program.mGroup == "CONGTY")
            {
                cmbChiNhanhMain.Enabled = btnThoat.Enabled = true;
                btnGhi.Enabled = btnPhucHoi.Enabled
                    = btnReload.Enabled = btnSua.Enabled = btnThem.Enabled
                    = btnXoa.Enabled = false;
            }
            else
            {
                cmbChiNhanhMain.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = false;
                btnThoat.Enabled = btnSua.Enabled = btnThem.Enabled 
                    = btnReload.Enabled = btnXoa.Enabled = true;
            }

            // Tạo stack để lưu thông tin undo
            undo = new Stack<String>();
        }

        private void frmKho_Load(object sender, EventArgs e)
        {
            //KhoDS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'khoDS.DatHang' table. You can move, or remove it, as needed.
            this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.datHangTableAdapter.Fill(this.khoDS.DatHang);
            // TODO: This line of code loads data into the 'khoDS.Kho' table. You can move, or remove it, as needed.
            this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khoTableAdapter.Fill(this.khoDS.Kho);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsKho.CancelEdit();
            if (btnThem.Enabled == false)
            {
                bdsKho.Position = vitri;
            }
            gcKho.Enabled = true;
            groupBox1.Enabled = false;
            btnReload.Enabled = btnSua.Enabled
                = btnThem.Enabled = btnThoat.Enabled = btnXoa.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            isEditing = false; // cài lại giá trị mặc định
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsKho.Position;
            groupBox1.Enabled = true;
            btnReload.Enabled = btnSua.Enabled
                = btnThem.Enabled = btnThoat.Enabled = btnXoa.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            isEditing = true; // đang chỉnh sửa 
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.khoTableAdapter.Fill(this.khoDS.Kho);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi Reload : " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsKho.Position;
            groupBox1.Enabled = true;
            bdsKho.AddNew();

            txtMACN.Text = ((DataRowView)bdsKho[0])["MACN"].ToString();
            btnReload.Enabled =
                btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = false;
            btnThoat.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = true;
            gcKho.Enabled = false;
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
                khoTableAdapter.Connection.ConnectionString = Program.connstr;
                khoTableAdapter.Fill(this.khoDS.Kho);

                try
                {
                    macn = ((DataRowView)bdsKho[0])["MACN"].ToString();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lỗi loadMACN : " + ex.Message, "", MessageBoxButtons.OK);
                }
            }
        }

        private void gcKho_Click(object sender, EventArgs e)
        {

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

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMaKho.Text.Trim() == "")
            {
                MessageBox.Show("Mã kho không được để trống"
                    , "", MessageBoxButtons.OK);
                txtMaKho.Focus();
                return;
            }
            if (txtTenKho.Text.Trim() == "")
            {
                MessageBox.Show("Tên kho không được để trống"
                    , "", MessageBoxButtons.OK);
                txtMaKho.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ không được để trống"
                    , "", MessageBoxButtons.OK);
                txtMaKho.Focus();
                return;
            }
            if (txtMaKho.Text.Trim().Length != 4)
            {
                MessageBox.Show("Sai cú pháp mã kho. Mã kho phải có 4 ký tự."
                    , "", MessageBoxButtons.OK);
                txtMaKho.Focus();
                return;
            }
            int viTriConTro = bdsKho.Position;
            int viTriMaKho = bdsKho.Find("MAKHO", txtMaKho.Text);
            if (viTriConTro != viTriMaKho && viTriMaKho != -1)
            {
                MessageBox.Show("Mã kho này đã được sử dụng !", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (this.isEditing)
            {
                String maKhoCu = ((DataRowView)bdsKho[viTriConTro])["MAKHO"].ToString();
                String tenKhoCu = ((DataRowView)bdsKho[viTriConTro])["TENKHO"].ToString();
                String diaChiCu = ((DataRowView)bdsKho[viTriConTro])["DIACHI"].ToString();
                String maCNCu   = ((DataRowView)bdsKho[viTriConTro])["MACN"].ToString();
                String maKhoMoi = txtMaKho.Text;
                String undoQueryUpdate = "UPDATE Kho SET " +
                         "MAKHO = '" + maKhoCu + "', " +
                         "TENKHO = '" + tenKhoCu + "', " +
                         "DIACHI = '" + diaChiCu + "', " +
                         "MACN = '" + maCNCu + "' " +
                         "WHERE MAKHO = '" + maKhoMoi + "'";
                this.undo.Push(undoQueryUpdate);
            }
            else
            {
                String maKhoMoi = txtMaKho.Text;
                String undoQueryDelete = "DELETE FROM Kho WHERE MAKHO = '" + maKhoMoi + "'";
                this.undo.Push(undoQueryDelete);
            }
           
            try
            {
                foreach (DataRowView rowView in bdsKho)
                {
                    DataRow row = rowView.Row;
                    if (row.RowState == DataRowState.Added) 
                    {
                        row["MACN"] = cmbChiNhanhMain.SelectedValue.ToString(); 
                        Console.WriteLine("MACN:", cmbChiNhanhMain.SelectedValue.ToString());
                    }
                }
                
                bdsKho.EndEdit();
                bdsKho.ResetCurrentItem();
                khoTableAdapter.Connection.ConnectionString = Program.connstr;
                khoTableAdapter.Update(this.khoDS.Kho);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi kho mới. \n" + ex.Message + ""
                    , "", MessageBoxButtons.OK);
                this.undo.Pop();
                return;
            }
            gcKho.Enabled = true;
            btnReload.Enabled = btnSua.Enabled
                = btnThem.Enabled = btnThoat.Enabled = btnXoa.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            groupBox1.Enabled = false;
            isEditing = false; // Set lại giá trị mặc định 
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string selectedMAKHO = ((DataRowView)bdsKho[bdsKho.Position])["MAKHO"].ToString();
            if (bdsDatHang.Count > 0)
            {
                MessageBox.Show("Không thể xóa kho này vì đã lập đơn đặt hàng"
                    , "", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show("Bạn thật sự muốn xóa Kho này ?"
                    , "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String maKhoCu = txtMaKho.Text;
                String tenKhoCu = txtTenKho.Text;
                String diaChiCu = txtDiaChi.Text;
                String maCN = txtMACN.Text;
                String undoQueryInsert = "INSERT INTO Kho (MAKHO, TENKHO, DIACHI, MACN) " +
                    "VALUES ('" 
                    + maKhoCu + "','" 
                    + tenKhoCu + "','" 
                    + diaChiCu + "','" 
                    + maCN + "')";
                this.undo.Push(undoQueryInsert);
                try
                {
                    bdsKho.RemoveCurrent();
                    khoTableAdapter.Connection.ConnectionString = Program.connstr;
                    khoTableAdapter.Update(khoDS.Kho);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa Kho. Bạn hãy xóa lại\n" + ex.Message + ""
                    , "", MessageBoxButtons.OK);
                    this.khoTableAdapter.Fill(khoDS.Kho);
                    bdsKho.Position = bdsKho.Find("MAKHO", selectedMAKHO);
                    this.undo.Pop();
                    return;
                }
            }

            if (bdsKho.Count == 0)
            {
                btnXoa.Enabled = false;
            }
        }

        private void mAKHOTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                this.khoTableAdapter.Fill(this.khoDS.Kho);
            }
        }
    }
}
