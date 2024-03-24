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
    public partial class frmVatTu : Form
    {

        String VT = "";
        int vitri = 0;
        public frmVatTu()
        {
            InitializeComponent();
            if (Program.mGroup == "CONGTY")
            {
                btnThoat.Enabled = true;
                btnGhi.Enabled = btnIn.Enabled = btnPhucHoi.Enabled
                    = btnReload.Enabled = btnSua.Enabled = btnThem.Enabled
                    = btnXoa.Enabled = false;
            }
            else
            {
                btnGhi.Enabled = btnPhucHoi.Enabled = false;
                btnThoat.Enabled = btnSua.Enabled = btnThem.Enabled = btnIn.Enabled
                    = btnReload.Enabled = btnXoa.Enabled = true;
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void frmVatTu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'vatTuDS.CTDDH' table. You can move, or remove it, as needed.
            this.CTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.CTDDHTableAdapter.Fill(this.VatTuDS.CTDDH);
            // TODO: This line of code loads data into the 'vatTuDS.CTPN' table. You can move, or remove it, as needed.
            this.CTPNTableAdapter.Connection.ConnectionString = Program.connstr;
            this.CTPNTableAdapter.Fill(this.VatTuDS.CTPN);
            // TODO: This line of code loads data into the 'vatTuDS.CTPX' table. You can move, or remove it, as needed.
            this.CTPXTableAdapter.Connection.ConnectionString = Program.connstr;
            this.CTPXTableAdapter.Fill(this.VatTuDS.CTPX);
            // TODO: This line of code loads data into the 'vatTuDS.Vattu' table. You can move, or remove it, as needed.
            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vattuTableAdapter.Fill(this.VatTuDS.Vattu);


        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsVatTu.Position;
            groupBox1.Enabled = true;
            bdsVatTu.AddNew();

            btnReload.Enabled =
                btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = false;
            btnThoat.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = true;
            gcVatTu.Enabled = false;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsVatTu.Position;
            groupBox1.Enabled = true;
            btnReload.Enabled = btnSua.Enabled
                = btnThem.Enabled = btnThoat.Enabled = btnXoa.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMaVT.Text.Trim() == "")
            {
                MessageBox.Show("Mã vật tư không được để trống"
                    , "", MessageBoxButtons.OK);
                txtMaVT.Focus();
                return;
            }
            if (txtTenVT.Text.Trim() == "")
            {
                MessageBox.Show("Tên vật tư không được để trống"
                    , "", MessageBoxButtons.OK);
                txtTenVT.Focus();
                return;
            }
            if (txtDVT.Text.Trim() == "")
            {
                MessageBox.Show("Đơn vị tính không được để trống"
                    , "", MessageBoxButtons.OK);
                txtDVT.Focus();
                return;
            }
            if (txtSoLuongTon.Text.Trim() == "")
            {
                MessageBox.Show("Số lượng tồn không được để trống"
                    , "", MessageBoxButtons.OK);
                txtDVT.Focus();
                return;
            }
            try
            {
                bdsVatTu.EndEdit();
                bdsVatTu.ResetCurrentItem();
                vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                vattuTableAdapter.Update(this.VatTuDS.Vattu);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi kho mới. \n" + ex.Message + ""
                    , "", MessageBoxButtons.OK);
                return;
            }
            gcVatTu.Enabled = true;
            btnReload.Enabled = btnSua.Enabled
                = btnThem.Enabled = btnThoat.Enabled = btnXoa.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            groupBox1.Enabled = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string selectedMAVT = ((DataRowView)bdsVatTu[bdsVatTu.Position])["MAVT"].ToString();

            foreach (DataRowView datHangRowView in bdsCTDDH)
            {
                DataRow datHangRow = datHangRowView.Row;
                string MAVT = datHangRow["MAVT"].ToString();

                if (MAVT == selectedMAVT)
                {
                    MessageBox.Show("Không thể xóa vật tư này vì đã lập đơn đặt hàng", "", MessageBoxButtons.OK);
                    return;
                }
            }
            foreach (DataRowView datHangRowView in bdsCTPN)
            {
                DataRow phieuNhapRow = datHangRowView.Row;
                string MAVT = phieuNhapRow["MAVT"].ToString();

                if (MAVT == selectedMAVT)
                {
                    MessageBox.Show("Không thể xóa vật tư này vì đã lập phiếu nhập", "", MessageBoxButtons.OK);
                    return;
                }
            }
            foreach (DataRowView datHangRowView in bdsCTPX)
            {
                DataRow phieuXuatRow = datHangRowView.Row;
                string MAVT = phieuXuatRow["MAVT"].ToString();

                if (MAVT == selectedMAVT)
                {
                    MessageBox.Show("Không thể xóa vật tư này vì đã lập phiếu xuất", "", MessageBoxButtons.OK);
                    return;
                }
            }

            if (MessageBox.Show("Bạn thật sự muốn xóa vật tư này ??"
                    , "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    bdsVatTu.RemoveCurrent();
                    vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                    vattuTableAdapter.Update(VatTuDS.Vattu);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa Kho. Bạn hãy xóa lại\n" + ex.Message + ""
                    , "", MessageBoxButtons.OK);
                    vattuTableAdapter.Fill(VatTuDS.Vattu);
                    bdsVatTu.Position = bdsVatTu.Find("MAKHO", selectedMAVT);
                    return;
                }
            }

            if (bdsVatTu.Count == 0)
            {
                btnXoa.Enabled = false;
            }
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsVatTu.CancelEdit();
            if (btnThem.Enabled == false)
            {
                bdsVatTu.Position = vitri;
            }
            gcVatTu.Enabled = true;
            groupBox1.Enabled = false;
            btnReload.Enabled = btnSua.Enabled
                = btnThem.Enabled = btnThoat.Enabled = btnXoa.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.vattuTableAdapter.Fill(this.VatTuDS.Vattu);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi Reload : " + ex.Message, "", MessageBoxButtons.OK);
                return;
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
    }
}
