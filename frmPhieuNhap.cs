using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using QuanLyVatTu.SubForm;
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
    public partial class frmPhieuNhap : DevExpress.XtraEditors.XtraForm
    {
        String maPN = "";
        public frmPhieuNhap()
        {
            InitializeComponent();
            phieuNhapDS.EnforceConstraints = false;
        }

        private void phieuNhapBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
         

        }

        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'phieuNhapDS.CTDDH' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'phieuNhapDS.CTPN' table. You can move, or remove it, as needed.
            this.cTPNTableAdapter.Fill(this.phieuNhapDS.CTPN);
            // TODO: This line of code loads data into the 'phieuNhapDS.PhieuNhap' table. You can move, or remove it, as needed.
            this.phieuNhapTableAdapter.Fill(this.phieuNhapDS.PhieuNhap);


        }

        private void cTPNGridControl_Click(object sender, EventArgs e)
        {

        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void phieuNhapBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.phieuNhapBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.phieuNhapDS);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            frmChonDDH frm = new frmChonDDH();
            frm.ShowDialog();
            this.maDDHTxt.Text = Program.maDDHdcChonTrongPhieuNhap;
            this.maKhoTxt.Text = Program.maKhodcChonTrongPhieuNhap;
            Program.maDDHdcChonTrongPhieuNhap = "";
            Program.maKhodcChonTrongPhieuNhap = "";


        }
        private void generateMPN()
        {
            try
            {
                
                this.maPNTxt.Text = Program.ExecuteStoredProcedureFromMainSide("SP_generatePhieuNhap");
            }
            catch(Exception ex)
            {
               MessageBox.Show("Tạo mã phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Them moi phieu nhap
            generateMPN();
            maNVTxt.Text = Program.username;
            ngayPNTxt.Text = DateTime.Today.ToShortDateString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable tmp = new DataTable();
            tmp = cTDDH1TableAdapter.GetDataCTTDHbyMasoDDH(maPNTxt.Text.ToString(),maDDHTxt.Text.ToString());
            cTPNGridControl.DataSource = tmp;
            GridView view = (GridView)cTPNGridControl.MainView;


            //view.GridControl.BeginUpdate(); // Bắt đầu cập nhật trước khi thay đổi dữ liệu

            //view.BeginUpdate();

            //view.BeginUpdate();

            //try
            //{
            //    // Iterate through each row in the DataTable and add it to the GridView
            //    foreach (DataRow row in tmp.Rows)
            //    {
            //        view.AddNewRow();
            //        int newRowHandle = view.FocusedRowHandle;

            //        String maphieunhap = Program.ExecuteStoredProcedureFromMainSide("SP_generatePhieuNhap");

            //        view.SetRowCellValue(newRowHandle, view.Columns["MAPN"], row["MAPN"]);
            //        view.SetRowCellValue(newRowHandle, view.Columns["MAVT"], row["MAVT"]);
            //        view.SetRowCellValue(newRowHandle, view.Columns["SOLUONG"], row["SOLUONG"]);
            //        view.SetRowCellValue(newRowHandle, view.Columns["DONGIA"], row["DONGIA"]);

            //        // Move the focus to the next row (if you don't want to focus on the new row)
            //        view.UpdateCurrentRow();
            //        // Optional: Move the focus to the next row (if you don't want to focus on the new row)
            //    }
            //}
            //finally
            //{
            //    // End updating the GridView and refresh the data
            //    //view.EndUpdate();
            //    view.UpdateCurrentRow();
            //    //view.UpdateCurrentRow();

            //}
            //try
            //{
            // Duyệt qua từng hàng trong DataTable tmp
            //for (int rowIndex = 0; rowIndex < tmp.Rows.Count; rowIndex++)
            //{
            //    DataRow row = tmp.Rows[rowIndex];

            //    // Tạo một hàng mới trong grid control
            //    view.AddNewRow();
            //    view.SetRowCellValue(view.FocusedRowHandle, view.Columns[0], maPNTxt.Text.ToString());


            //    // Đặt giá trị cho các cột tương ứng trong hàng hiện tại của grid control
            //    for (int colIndex = 1; colIndex < tmp.Columns.Count; colIndex++)  // Bắt đầu từ 1 để bỏ qua cột đầu tiên trong tmp
            //    {
            //        // Sử dụng tên cột thực tế từ tmp
            //        string columnName = tmp.Columns[colIndex].ColumnName;
            //        view.SetRowCellValue(view.FocusedRowHandle, view.Columns[colIndex], row[columnName]);
            //    }

            //    // Cập nhật hàng hiện tại trong grid control
            //    view.UpdateCurrentRow();
            //}
            //}
            //finally
            //{
            //    // Kết thúc quá trình cập nhật cho grid control
            //    view.GridControl.EndUpdate();
            //}

            if (tmp.Rows.Count == 0)
            {
                MessageBox.Show("Rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            

        }

        private void fillToolStripButton_Click_1(object sender, EventArgs e)
        {
            //try
            //{
            //    this.cTDDH1TableAdapter.Fill(this.phieuNhapDS.CTDDH1,,masoDDHToolStripTextBox.Text);
            //}
            //catch (System.Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message);
            //}

        }

        private void fillToolStripButton_Click_2(object sender, EventArgs e)
        {
            try
            {
                this.cTDDH1TableAdapter.Fill(this.phieuNhapDS.CTDDH1, maPNToolStripTextBox.Text, masoDDHToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}