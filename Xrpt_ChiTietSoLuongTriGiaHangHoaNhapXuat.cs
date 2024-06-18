using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QuanLyVatTu
{
    public partial class Xrpt_ChiTietSoLuongTriGiaHangHoaNhapXuat : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_ChiTietSoLuongTriGiaHangHoaNhapXuat()
        {
            InitializeComponent();
        }
        public Xrpt_ChiTietSoLuongTriGiaHangHoaNhapXuat(String vaiTro, String loai, DateTime start, DateTime end)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = vaiTro;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = loai;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = start.Date;
            this.sqlDataSource1.Queries[0].Parameters[3].Value = end.Date;
            this.txtLoaiPhieu.Text = loai;
            this.txtNgayBatDau.Text = start.Date.ToString("dd-MM-yyyy");
            this.txtNgayKetThuc.Text = end.Date.ToString("dd-MM-yyyy");
        }



    }
}
