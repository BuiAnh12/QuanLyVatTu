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
    public partial class Frpt_TongHopNhapXuat : DevExpress.XtraEditors.XtraForm
    {
        public Frpt_TongHopNhapXuat()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
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
            DateTime start = deStart.DateTime;
            DateTime end = deEnd.DateTime;

            XtraReport1 xrpt = new XtraReport1(start, end);
            ReportPrintTool print = new ReportPrintTool(xrpt);
            print.ShowPreviewDialog();

        }
    }
}