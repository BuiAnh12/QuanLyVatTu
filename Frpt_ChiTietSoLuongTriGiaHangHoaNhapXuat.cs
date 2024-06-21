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
    public partial class frmChiTietSoLuongTriGiaHangHoaNhapXuat : DevExpress.XtraEditors.XtraForm
    {
        public frmChiTietSoLuongTriGiaHangHoaNhapXuat()
        {
            InitializeComponent();
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (deStart.Text == "")
            {
                MessageBox.Show("Phải nhập ngày bắt đầu", "", MessageBoxButtons.OK);
                deStart.Focus();
                return;
            }
            if (deEnd.Text == "")
            {
                MessageBox.Show("Phải nhập ngày kết thúc", "", MessageBoxButtons.OK);
                deEnd.Focus();
                return;
            }
            if (cmbLoai.Text.Trim() == "")
            {
                MessageBox.Show("Phải nhập loại báo cáo ( XUAT - NHAP )"
                    , "", MessageBoxButtons.OK);
                cmbLoai.Focus();
                return;
            }
            if (deStart.DateTime >= deEnd.DateTime)
            {
                MessageBox.Show("Phải nhập ngày bắt đầu nhỏ hơn ngày kết thúc", "", MessageBoxButtons.OK);
                deStart.Focus();
                return;
            }


            String loai = cmbLoai.Text;
            String vaiTro = Program.mGroup;
            DateTime start = deStart.DateTime;
            DateTime end = deEnd.DateTime;

            Xrpt_ChiTietSoLuongTriGiaHangHoaNhapXuat xrpt = new Xrpt_ChiTietSoLuongTriGiaHangHoaNhapXuat(vaiTro, loai, start, end);
            ReportPrintTool print = new ReportPrintTool(xrpt);
            print.ShowPreviewDialog();

        }
    }
}