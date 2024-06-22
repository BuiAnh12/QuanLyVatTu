using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QuanLyVatTu
{
    public partial class Xrpt_DanhSachNhanVien : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_DanhSachNhanVien()
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
        }

    }
}
