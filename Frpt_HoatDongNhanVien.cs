using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
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
    public partial class Frpt_HoatDongNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public Frpt_HoatDongNhanVien()
        {
            InitializeComponent();
            cmbChiNhanhMain.DataSource = Program.bds_dspm;
            cmbChiNhanhMain.DisplayMember = "TENCN";
            cmbChiNhanhMain.ValueMember = "TENSERVER";
            cmbChiNhanhMain.SelectedIndex = Program.mChinhanh;
            if (Program.mGroup == "CONGTY")
            {
                cmbChiNhanhMain.Enabled  = true;
            }
            else
            {
                cmbChiNhanhMain.Enabled = false;
            }
        }

        private void Frpt_HoatDongNhanVien_Load(object sender, EventArgs e)
        {
            nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            nhanVienTableAdapter.Fill(nhanVienDS.NhanVien);

        }

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.nhanVienBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.nhanVienDS);

        }

        private void label1_Click(object sender, EventArgs e)
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
                nhanVienTableAdapter.Fill(nhanVienDS.NhanVien);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (deStart.Text == "")
            {
                MessageBox.Show("Không được để trống ngày bắt đầu"
                   , "", MessageBoxButtons.OK);
                return;
            }
            if(deEnd.Text == "")
            {
                MessageBox.Show("Không được để trống ngày kết thúc"
                   , "", MessageBoxButtons.OK);
                return;
            }
            if (deStart.DateTime >= deEnd.DateTime)
            {
                MessageBox.Show("Phải nhập ngày bắt đầu nhỏ hơn ngày kết thúc", "", MessageBoxButtons.OK);
                deStart.Focus();
                return;
            }
            String manv = txtMaNV.Text;
            String hoTen = txtHo.Text + " " + txtTen.Text;
            DateTime start = deStart.DateTime;
            DateTime end = deEnd.DateTime;

            Xrpt_HoatDongNhanVien xrpt = new Xrpt_HoatDongNhanVien(manv, hoTen, start, end);
            ReportPrintTool print = new ReportPrintTool(xrpt);
            print.ShowPreviewDialog();
        }

        private void nhanVienGridControl_Click(object sender, EventArgs e)
        {

        }
    }
}