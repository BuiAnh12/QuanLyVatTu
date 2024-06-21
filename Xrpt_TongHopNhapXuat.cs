using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QuanLyVatTu
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport1(DateTime start, DateTime end)
        {
            InitializeComponent();
            this.sqlDataSource1.Queries[0].Parameters[0].Value = start.Date;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = end.Date;
            txtStart.Text = start.Date.ToString("dd-MM-yyyy");
            txtEnd.Text = end.Date.ToString("dd-MM-yyyy");
        }

    }
}
