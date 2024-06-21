using DevExpress.Xpo.Exceptions;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraRichEdit.Model;
using QuanLyVatTu.DatHangDSTableAdapters;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QuanLyVatTu
{
    public partial class frmDatHang : DevExpress.XtraEditors.XtraForm
    {
        
        private int vitri;
        public frmDatHang()
        {
            
            InitializeComponent();
            cmbChiNhanhMain.DataSource = Program.bds_dspm;
            cmbChiNhanhMain.DisplayMember = "TENCN";
            cmbChiNhanhMain.ValueMember = "TENSERVER";
            cmbChiNhanhMain.SelectedIndex = Program.mChinhanh;

            /*
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
            
            try
            {
                makho = ((DataRowView)bdsDatHang.Current)["MAKHO"].ToString();
                manv = ((DataRowView)bdsDatHang.Current)["MANV"].ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi loadMANV - MAKHO : " + ex.Message, "", MessageBoxButtons.OK);
            }
            */

        }

        private void reload()
        {
            
        }


        private void datHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsDatHang.EndEdit();
            this.tableAdapterManager.UpdateAll(this.datHangDS);

        }

        private void frmDatHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'datHangDS.PhieuNhap' table. You can move, or remove it, as needed.
            this.phieuNhapTableAdapter.Fill(this.datHangDS.PhieuNhap);
            // TODO: This line of code loads data into the 'datHangDS.PhieuNhap' table. You can move, or remove it, as needed.
            this.phieuNhapTableAdapter.Fill(this.datHangDS.PhieuNhap);
            // TODO: This line of code loads data into the 'datHangDS.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.Fill(this.datHangDS.NhanVien);

            // TODO: This line of code loads data into the 'datHangDS.Vattu' table. You can move, or remove it, as needed.
            this.vattuTableAdapter.Fill(this.datHangDS.Vattu);
            
            datHangDS.EnforceConstraints = false;
            CTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.CTDDHTableAdapter.Fill(this.datHangDS.CTDDH);
            

            khoTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khoTableAdapter.Fill(this.datHangDS.Kho);
            

            hoTenNVTableAdapter.Connection.ConnectionString = Program.connstr;
            this.hoTenNVTableAdapter.Fill(this.nhanVienDS.HoTenNV);

            datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.datHangTableAdapter.Fill(this.datHangDS.DatHang);

            reload();
        }

        private void masoDDHLabel_Click(object sender, EventArgs e)
        {

        }


        private void cmbHoTenNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHoTenNV.SelectedValue != null)
            {
                txtMaNV.Text = cmbHoTenNV.SelectedValue.ToString();
            }
            else
            {
                // Optionally, handle the case where SelectedValue is null
            }
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

                hoTenNVTableAdapter.Connection.ConnectionString = Program.connstr;
                this.hoTenNVTableAdapter.Fill(this.nhanVienDS.HoTenNV);

                datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.datHangTableAdapter.Fill(this.datHangDS.DatHang);
            }
            
        }

        private void datHangGridControl_Click(object sender, EventArgs e)
        {
            
        }

        private void txtMaNVValueChanged(object sender, EventArgs e)
        {

            
        }

        private void txtMaNVValueChanged(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

        }

        private void cTDDHDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTenVT_sub.SelectedValue != null)
            {
                txtMaVT_sub.Text = cmbTenVT_sub.SelectedValue.ToString();
            }
            else
            {
                // Optionally, handle the case where SelectedValue is null
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsDatHang.Position;
            gcDDH.Enabled = true;
            gcCTDDH.Enabled = true;
            gcTTCTDDH.Enabled = true;   
            bdsDatHang.AddNew();

            txtMSDDH.Text = "";
            txtMSDDH.Enabled = true;

            deNgay.EditValue = "";
            txtNhaCC.Text = "";

            cmbHoTenNV.SelectedIndex = 0; 
            cmbTenKho.SelectedIndex = 0;

            txtMaNV.Text = cmbHoTenNV.SelectedValue.ToString();
            txtMaKho.Text = cmbTenKho.SelectedValue.ToString();

            

            btnIn.Enabled = btnReload.Enabled = gcDatHang.Enabled =
                btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = false;
            btnThoat.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = true;
             
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        /*
         Loi khau xoa:
            Xóa đơn hàng chỉ xóa 1 chi tiết đơn hàng -> phải cho vòng loop tìm và xóa 
            Thêm chi tiết đơn hàng sẽ cần đơn hàng thêm vào trước, không thêm vô bảng tạm được
            
         */

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string maddh = "";

            /*
            string selectedMSDDH = ((DataRowView)bdsDatHang.Current)["MasoDDH"].ToString();
            foreach (DataRowView phieuNhapRowView in bdsPhieuNhap)
            {
                DataRow phieuNhapRow = phieuNhapRowView.Row;
                string MSDDH = phieuNhapRow["MasoDDH"].ToString();

                if (MSDDH == selectedMSDDH)
                {
                    MessageBox.Show("Không thể xóa Kho này vì đã lập đơn đặt hàng", "", MessageBoxButtons.OK);
                    return;
                }
            }
            */

            if (MessageBox.Show("Bạn thật sự muốn xóa đơn đặt hàng này ??"
                    , "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    
                    maddh = ((DataRowView)bdsDatHang[bdsDatHang.Position])["MasoDDH"].ToString();
                    bdsCTDDH.RemoveCurrent();
                    bdsDatHang.RemoveCurrent();
                    datHangDS.EnforceConstraints = false;
                    // Check logic chỗ này 
                    CTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
                    CTDDHTableAdapter.Update(datHangDS.CTDDH);

                    datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                    datHangTableAdapter.Update(datHangDS.DatHang);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa nhân viên. Bạn hãy xóa lại\n" + ex.Message + ""
                    , "", MessageBoxButtons.OK);

                    CTDDHTableAdapter.Fill(datHangDS.CTDDH);
                    datHangTableAdapter.Fill(datHangDS.DatHang);
                    bdsDatHang.Position = bdsDatHang.Find("MasoDDH", maddh);
                    return;
                }
            }

            if (bdsNhanVien.Count == 0)
            {
                btnXoa.Enabled = false;
            }
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMSDDH.Text.Trim() == "")
            {
                MessageBox.Show("Mã số đơn đặt hàng không được để trống"
                    , "", MessageBoxButtons.OK);
                txtMSDDH.Focus();
                return;
            }
            if (txtNhaCC.Text.Trim() == "")
            {
                MessageBox.Show("Nhà cung cấp không được để trống"
                    , "", MessageBoxButtons.OK);
                txtNhaCC.Focus();
                return;
            }
            if (deNgay.Text.Trim() == "")
            {
                MessageBox.Show("Ngày không được để trống"
                    , "", MessageBoxButtons.OK);
                deNgay.Focus();
                return;
            }
            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Mã nhân viên không được để trống"
                    , "", MessageBoxButtons.OK);
                txtMaNV.Focus();
                return;
            }
            if (txtMaKho.Text.Trim() == "")
            {
                MessageBox.Show("Mã kho không được để trống"
                    , "", MessageBoxButtons.OK);
                txtMaKho.Focus();
                return;
            }
            
            try
            {
                /*
                int row = gvChiTietDonDatHang.RowCount;
                if (row <= 0)
                {
                    MessageBox.Show("Bạn chưa thêm chi tiết đơn đặt hàng"
                    , "", MessageBoxButtons.OK);
                    return;
                }
                */
                bdsDatHang.EndEdit();
                bdsDatHang.ResetCurrentItem();
                datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                datHangTableAdapter.Update(this.datHangDS.DatHang);

                bdsCTDDH.EndEdit();
                CTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
                CTDDHTableAdapter.Update(this.datHangDS.CTDDH);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi đơn đặt hàng mới. \n" + ex.Message + ""
                    , "", MessageBoxButtons.OK);
                return;
            }
            gcDatHang.Enabled = true;
            btnIn.Enabled = btnReload.Enabled = gcDatHang.Enabled =
                btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = true;
            btnThoat.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = false;
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsDatHang.CancelEdit();
            bdsCTDDH.CancelEdit();
            if (btnThem.Enabled == false)
            {
                bdsDatHang.Position = vitri;
            }
            gcDatHang.Enabled = true;
            gcDDH.Enabled = false;
            gcCTDDH.Enabled = false;    
            btnIn.Enabled = btnReload.Enabled = btnSua.Enabled
                = btnThem.Enabled = btnThoat.Enabled = btnXoa.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            { 
                this.datHangTableAdapter.Fill(this.datHangDS.DatHang);
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi Reload : " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }


        private void btnThemCTDH_Click(object sender, EventArgs e)
        {
            if (txtMSDDH.Text.Trim() == "")
            {
                MessageBox.Show("Mã số đơn đặt hàng không được để trống trước khi thêm đơn hàng"
                    , "", MessageBoxButtons.OK);
                txtMSDDH.Focus();
                return;
            }
            bdsCTDDH.AddNew();
            int position = bdsCTDDH.Position;
            DataRowView newRowView = (DataRowView)bdsCTDDH.Current;
            newRowView["masoDDH"] = txtMSDDH.Text;

        }

        private void btnXoaCTDH_Click(object sender, EventArgs e)
        {

        }

        private void btnGhiCTDH_Click(object sender, EventArgs e)
        {
            int row = gvChiTietDonDatHang.RowCount;
            if (row <= 0)
            {
                MessageBox.Show("Bạn chưa thêm chi tiết đơn đặt hàng"
                , "", MessageBoxButtons.OK);
                return;
            }
            bdsCTDDH.EndEdit();
            
            CTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            CTDDHTableAdapter.Update(this.datHangDS.CTDDH);
        }
    }
}