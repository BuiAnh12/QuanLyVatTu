using DevExpress.Xpo.DB.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyVatTu.SubForm
{
    public partial class frmChonDDH : DevExpress.XtraEditors.XtraForm
    {
        public frmChonDDH()
        {
            InitializeComponent();
            CbChiNhanh.DataSource = Program.bds_dspm;
            CbChiNhanh.DisplayMember = "TENCN";
            CbChiNhanh.ValueMember = "TENSERVER";
            CbChiNhanh.SelectedIndex = Program.mChinhanh;
            fillData();

        }
        private void fillData()
        {
            DataTable temp = new DataTable();
            temp.Columns.Add("MasoDDH", typeof(string));
            temp.Columns.Add("NGAY", typeof(DateTime));
            temp.Columns.Add("NhaCC", typeof(string));
            temp.Columns.Add("MAKHO", typeof(string));
            try
            {
                if (Program.KetNoi() == 1)
                {
                    string query = "SP_SelectDatHangNotInPhieuNhap";
                    SqlCommand cmd = new SqlCommand(query, Program.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DataRow row = temp.NewRow();
                        row["MasoDDH"] = reader["MasoDDH"];
                        row["NGAY"] = reader["NGAY"];
                        row["NhaCC"] = reader["NhaCC"];
                        row["MAKHO"] = reader["MAKHO"];
                        temp.Rows.Add(row);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Lấy đơn đặt hàng. \n" + ex.Message, "", MessageBoxButtons.OK);

            }
            gridControl1.DataSource = temp;
            gridControl1.MainView.PopulateColumns();  // Refresh columns based on data source
            gridControl1.RefreshDataSource();

        }

        private void datHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.datHangBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.phieuNhapDS);

        }

        private void frmChonDDH_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'phieuNhapDS.DatHang' table. You can move, or remove it, as needed.
            this.datHangTableAdapter.Fill(this.phieuNhapDS.DatHang);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GridView gridView = gridControl1.MainView as GridView;
            if (gridView != null)
            {
                DataRow selectedRow = gridView.GetFocusedDataRow();
                Program.maDDHdcChonTrongPhieuNhap = selectedRow["MasoDDH"].ToString();
                Program.maKhodcChonTrongPhieuNhap= selectedRow["MAKHO"].ToString();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đơn hàng");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}