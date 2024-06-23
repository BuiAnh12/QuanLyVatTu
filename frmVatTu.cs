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

    public partial class frmVatTu : Form
    {

        String VT = "";
        int vitri = 0;
        Stack<String> undo = null;
        Boolean isEditing = false;
        public frmVatTu()
        {
            InitializeComponent();
            if (Program.mGroup == "CONGTY")
            {
                btnThoat.Enabled = true;
                btnGhi.Enabled = btnIn.Enabled = btnPhucHoi.Enabled = btnHoanTac.Enabled
                    = btnReload.Enabled = btnSua.Enabled = btnThem.Enabled
                    = btnXoa.Enabled = false;
            }
            else
            {
                btnGhi.Enabled = btnPhucHoi.Enabled = false;
                btnThoat.Enabled = btnSua.Enabled = btnThem.Enabled = btnIn.Enabled
                 = btnHoanTac.Enabled = btnReload.Enabled = btnXoa.Enabled = true;
            }
            groupBox1.Enabled = false;
            // Tạo stack để lưu thông tin undo
            undo = new Stack<String>();
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
            bdsVatTu.AllowNew = true;
            bdsVatTu.AddNew();
            txtMaVT.Text = txtTenVT.Text = txtDVT.Text = "";
            txtSoLuongTon.Text = "1";
            btnReload.Enabled = btnHoanTac.Enabled =
                btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = false;
            btnThoat.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = true;
            gcVatTu.Enabled = false;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsVatTu.Position;
            groupBox1.Enabled = true;
            gcVatTu.Enabled = false;
            btnReload.Enabled = btnSua.Enabled = btnHoanTac.Enabled
                = btnThem.Enabled = btnThoat.Enabled = btnXoa.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            isEditing = true; // Set trang thai dang edit
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMaVT.Text.Trim().Length != 4)
            {
                MessageBox.Show("Sai định dạng mã vật tư. Mã phải có độ dài bằng 4!"
                    , "", MessageBoxButtons.OK);
                txtMaVT.Focus();
                return;
            }

            if (txtMaVT.Text.Trim() == "")
            {
                MessageBox.Show("Mã vật tư không được để trống"
                    , "", MessageBoxButtons.OK);
                txtMaVT.Focus();
                return;
            }
            if (txtTenVT.Text.Trim() == "")
            {
                MessageBox.Show("Tên vật tư không được để trống và không quá 30 ký tự"
                    , "", MessageBoxButtons.OK);
                txtTenVT.Focus();
                return;
            }
            if (txtDVT.Text.Trim() == "")
            {
                MessageBox.Show("Đơn vị tính không được để trống và không quá 15 ký tự"
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
            if (int.Parse(txtSoLuongTon.Text) >= int.MaxValue)
            {
                MessageBox.Show("Số lượng tồn quá lớn xin vui lòng nhập lại"
                    , "", MessageBoxButtons.OK);
                txtDVT.Focus();
                return;
            }
            if ( int.Parse(txtSoLuongTon.Text) < 0)
            {
                MessageBox.Show("Sô lượng tồn phải ít nhất bằng 0", "Thông báo", MessageBoxButtons.OK);
                txtSoLuongTon.Focus();
                return;
            }
            int viTriConTro = bdsVatTu.Position;
            int viTriMaVatTu = bdsVatTu.Find("MAVT", txtMaVT.Text);

            String query =
                    "DECLARE	@result int " +
                    "EXEC @result = [dbo].[sp_KiemTraMaVatTu] '" +
                    txtMaVT.Text + "' " +
                    "SELECT 'Value' = @result";
            int res = 1;
            try
            {
                Program.myReader = Program.ExecSqlDataReader(query);
                /*khong co ket qua tra ve thi ket thuc luon*/
                if (Program.myReader == null)
                {
                    return;
                }
                Program.myReader.Read();
                res = int.Parse(Program.myReader.GetValue(0).ToString());
                Program.myReader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Thực thi database thất bại!\n\n" + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
                return;
            }



            if (viTriConTro != viTriMaVatTu && res == 1)
            {
                MessageBox.Show("Mã vật tư này đã được sử dụng !", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            DialogResult dr = DialogResult.Cancel;
            if (this.isEditing)
            {
                String thongBao = "Vật tư này đã có trong: \n";
                if (bdsCTPN.Count > 0)
                {
                    thongBao += "    - Phiếu nhập\n";
                }
                if (bdsCTPX.Count > 0)
                {
                    thongBao += "    - Phiếu xuất\n";
                }
                if (bdsCTDDH.Count > 0)
                {
                    thongBao += "   - Đơn đặt hàng\n";
                }
                if (bdsCTPN.Count <= 0 && bdsCTPX.Count <= 0 && bdsCTDDH.Count <= 0 )
                {
                    thongBao = "";
                }
                thongBao += "Bạn có chắc chắn muốn thay đổi vật tư này ?";
                dr = MessageBox.Show(thongBao, "Thông báo",
                       MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else
            {
                dr = MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào cơ sở dữ liệu ?", "Thông báo",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            if (dr == DialogResult.OK)
            {
                if (this.isEditing)
                {
                    
                    // Chức năng Undo
                    String mavtCu = ((DataRowView)bdsVatTu[viTriConTro])["MAVT"].ToString();
                    String tenvtCu = ((DataRowView)bdsVatTu[viTriConTro])["TENVT"].ToString();
                    String dvtCu = ((DataRowView)bdsVatTu[viTriConTro])["DVT"].ToString();
                    String soluongtonCu = ((DataRowView)bdsVatTu[viTriConTro])["SOLUONGTON"].ToString();
                    String mavtMoi = txtMaVT.Text;
                    String undoQueryUpdate = "UPDATE VatTu SET " +
                             "TENVT = N'" + tenvtCu + "', " +
                             "DVT = N'" + dvtCu + "', " +
                             "SOLUONGTON = N'" + soluongtonCu + "', " +
                             "MAVT = N'" + mavtCu + "' " +
                             "WHERE MAVT = N'" + mavtMoi + "'";
                    this.undo.Push(undoQueryUpdate);
                }
                else
                {
                    String mavtMoi = txtMaVT.Text;
                    String undoQueryDelete = "DELETE FROM VatTu WHERE MAVT = N'" + mavtMoi + "'";
                    this.undo.Push(undoQueryDelete);
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
                    MessageBox.Show("Lỗi ghi vật tư mới. \n" + ex.Message + ""
                        , "", MessageBoxButtons.OK);
                    return;
                }
                gcVatTu.Enabled = true;
                btnReload.Enabled = btnSua.Enabled = btnHoanTac.Enabled
                    = btnThem.Enabled = btnThoat.Enabled = btnXoa.Enabled = true;
                btnGhi.Enabled = btnPhucHoi.Enabled = false;
                groupBox1.Enabled = false;
            }  
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string selectedMAVT = ((DataRowView)bdsVatTu[bdsVatTu.Position])["MAVT"].ToString();



            if (bdsCTPN.Count > 0)
            {
                MessageBox.Show("Không thể xóa vật tư này vì đã lập phiếu nhập"
                    , "", MessageBoxButtons.OK);
                return;
            }
            if (bdsCTPX.Count > 0)
            {
                MessageBox.Show("Không thể xóa vật tư này vì đã lập phiếu xuất"
                    , "", MessageBoxButtons.OK);
                return;
            }
            if (bdsCTDDH.Count > 0)
            {
                MessageBox.Show("Không thể xóa vật tư này vì đã lập đơn đặt hàng"
                    , "", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show("Bạn thật sự muốn xóa vật tư này ?"
                    , "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String mavt = txtMaVT.Text;
                String tenvt = txtTenVT.Text;
                String dvt = txtDVT.Text;
                String soluongton = txtSoLuongTon.Text;
                String undoQueryInsert = "INSERT INTO VatTu (MAVT, TENVT, DVT, SOLUONGTON) " +
                    "VALUES (N'"
                    + mavt + "',N'"
                    + tenvt + "',N'"
                    + dvt + "',N'"
                    + soluongton + "')";
                this.undo.Push(undoQueryInsert);
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
            this.vattuTableAdapter.Fill(this.VatTuDS.Vattu);
            if (btnThem.Enabled == false)
            {
                bdsVatTu.Position = vitri;
            }
            gcVatTu.Enabled = true;
            groupBox1.Enabled = false;
            btnReload.Enabled = btnSua.Enabled = btnHoanTac.Enabled
                = btnThem.Enabled = btnThoat.Enabled = btnXoa.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            isEditing = false;
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

        private void label4_Click(object sender, EventArgs e)
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
                this.vattuTableAdapter.Fill(this.VatTuDS.Vattu);
            }
        }
    }
}
