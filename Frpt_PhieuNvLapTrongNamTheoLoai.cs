using DevExpress.Xpo.Helpers;
using DevExpress.XtraCharts;
using DevExpress.XtraReports.UI;
using QuanLyVatTu.DSTableAdapters;
using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
namespace QuanLyVatTu
{
    public partial class Frpt_PhieuNvLapTrongNamTheoLoai : DevExpress.XtraEditors.XtraForm
    {
        int MaNV;
        public Frpt_PhieuNvLapTrongNamTheoLoai()
        {
            InitializeComponent();
            cmbChiNhanhMain.DataSource = Program.bds_dspm;
            cmbChiNhanhMain.DisplayMember = "TENCN";
            cmbChiNhanhMain.ValueMember = "TENSERVER";
            cmbChiNhanhMain.SelectedIndex = Program.mChinhanh;

            /*
            cmbHoTen.DataSource = this.bdsHoTenNV;
            cmbHoTen.DisplayMember = "HOTEN";
            cmbHoTen.ValueMember = "MANV";
            cmbChiNhanhMain.SelectedIndex = 0;
            */
            if (Program.mGroup == "CONGTY")
            {
                cmbChiNhanhMain.Enabled = true;
            }
            else
            {
                cmbChiNhanhMain.Enabled = false;
            }
        }

        private void Frpt_PhieuNvLapTrongNamTheoLoai_Load(object sender, EventArgs e)
        {
            this.hoTenNVTableAdapter.Connection.ConnectionString = Program.connstr;
            this.hoTenNVTableAdapter.Fill(this.nhanVienDS.HoTenNV);

        }

        private void hoTenNVBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                this.hoTenNVTableAdapter.Connection.ConnectionString = Program.connstr;
                this.hoTenNVTableAdapter.Fill(this.nhanVienDS.HoTenNV);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmbHoTen_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Xrpt_PhieuNvLapTrongNamTheoLoai rpt = new Xrpt_PhieuNvLapTrongNamTheoLoai(MaNV, cmbLoai.Text.Substring(0, 1), int.Parse(cmbNam.Text));
            rpt.lbTieuDe.Text = "DANH SÁCH PHIẾU " + cmbLoai.Text.ToUpper() + " NHÂN VIÊN TRONG NĂM " + cmbNam.Text;
            rpt.lbHoTen.Text = cmbHoTen.Text.ToString();
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void cmbHoTen_SelectedIndexChanged_1(object sender, EventArgs e)
        { 
            try
            {
                if (cmbHoTen != null && cmbHoTen.SelectedValue != null)
                {
                    MaNV = Convert.ToInt32(cmbHoTen.SelectedValue);
                }
                else
                {
                    // Handle the case when cmbHoTen or SelectedValue is null
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}