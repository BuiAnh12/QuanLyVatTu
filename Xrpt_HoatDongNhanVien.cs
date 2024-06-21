using DevExpress.CodeParser;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyVatTu
{
    public partial class Xrpt_HoatDongNhanVien : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_HoatDongNhanVien(String manv, String hoTen, DateTime start, DateTime end)
        {
            InitializeComponent();
            this.sqlDataSource1.Queries[0].Parameters[0].Value = manv;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = start.Date;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = end.Date;
            txtStart.Text = start.Date.ToString("dd-MM-yyyy");
            txtEnd.Text = end.Date.ToString("dd-MM-yyyy");
            txtHoTen.Text = hoTen.ToString();
            txtMaNV.Text = manv.ToString();
        }

        ConvertMoney cm = new ConvertMoney();

        private void xrLabel7_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string formattedNumber = txtSumTriGia.Text; // Assuming this contains "3,000,000VNĐ"
                if (formattedNumber == "")
                {
                    txtTienChu.Text = "";
                    return;
                }
                // Step 1: Remove the "VNĐ" suffix
                string numberWithoutSuffix = formattedNumber.Substring(0, formattedNumber.Length - 3);

                // Step 2: Remove commas
                string numberWithoutCommas = numberWithoutSuffix.Replace(",", "");

                // Step 3: Parse to integer
                int number;
                if (int.TryParse(numberWithoutCommas, out number))
                {
                    // Successfully parsed the number
                    Console.WriteLine(number);
                }
                else
                {
                    // Handle parsing error
                    Console.WriteLine("Invalid number format");
                }
                txtTienChu.Text = ConvertMoney.ConvertToText(number).ToUpper();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(),"", MessageBoxButtons.OK);
            }
            
        }
    }
}
