using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QuanLyVatTu
{
    public partial class Xrpt_HoatDongNhanVien : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_HoatDongNhanVien(String manv, String hoTen, DateTime start, DateTime end)
        {
            InitializeComponent();
            this.sqlDataSource1.Queries[0].Parameters[1].Value = manv;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = start.Date;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = end.Date;
            txtStart.Text = start.Date.ToString("dd-MM-yyyy");
            txtEnd.Text = end.Date.ToString("dd-MM-yyyy");
            txtHoTen.Text = hoTen.ToString();
            txtMaNV.Text = manv.ToString();
        }

    }
}
