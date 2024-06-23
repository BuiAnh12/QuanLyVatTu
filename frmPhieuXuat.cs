using DevExpress.CodeParser;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraTab;
using QuanLyVatTu.SubForm;
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

namespace QuanLyVatTu
{
    public partial class frmPhieuXuat : DevExpress.XtraEditors.XtraForm
    {
        private DataTable ctpxTable = new DataTable();
        private int lastInvalidRowIndex = -1;
        private int loaithaotac=-1;
        private List<string> mavtCu = new List<string>();
        private List<string> mavtDaXoa = new List<string>();
        public frmPhieuXuat()
        {
            InitializeComponent();
            phieuXuatDS.EnforceConstraints = false;
            setcolumn();

            //ADD DATA TO COMBOBOX 
            CbChiNhanh.DataSource = Program.bds_dspm;
            CbChiNhanh.DisplayMember = "TENCN";
            CbChiNhanh.ValueMember = "TENSERVER";
            CbChiNhanh.SelectedIndex = Program.mChinhanh;



            if (Program.mGroup == "CONGTY")
            {


                CbChiNhanh.DataSource = Program.bds_dspm;
                CbChiNhanh.DisplayMember = "TENCN";
                CbChiNhanh.ValueMember = "TENSERVER";

                //SET BUTTON
                themBtn.Enabled = false;
                suaBtn.Enabled = false;
                ghiBtn.Enabled = false;
                xoaBtn.Enabled = false;
                reloadBtn.Enabled = true;
                thoatBtn.Enabled = true;
                chonKhoBtn.Enabled = false;
                themCTPXBtn.Enabled = false;
                xoaCTPXBtn.Enabled = false;

                tenKHTxt.Enabled = false;
                //SET GRIControl
                cTPXGridControl.Enabled = false;
                phieuXuatGridControl.Enabled = true;

                CbChiNhanh.Enabled = true;

            }
            else if (Program.mGroup == "USER")
            {

                //SET BUTTON
                themBtn.Enabled = true;
                suaBtn.Enabled = true;
                ghiBtn.Enabled = false;
                xoaBtn.Enabled = true;
                reloadBtn.Enabled = true;
                thoatBtn.Enabled = true;
                chonKhoBtn.Enabled = false;
                themCTPXBtn.Enabled = false;
                xoaCTPXBtn.Enabled = false;


                tenKHTxt.Enabled = false;
                //SET GRIControl

                cTPXGridControl.Enabled = false;
                phieuXuatGridControl.Enabled = true;
                //Cb
                CbChiNhanh.Enabled = false;

            }
            else if (Program.mGroup == "CHINHANH")
            {
                //SET BUTTON
                themBtn.Enabled = true;
                suaBtn.Enabled = true;
                ghiBtn.Enabled = false;
                xoaBtn.Enabled = true;
                reloadBtn.Enabled = true;
                thoatBtn.Enabled = true;
                chonKhoBtn.Enabled = false;
                themCTPXBtn.Enabled = false;
                xoaCTPXBtn.Enabled = false;

                tenKHTxt.Enabled = false;
                //SET GRIControl
                cTPXGridControl.Enabled = false;
                phieuXuatGridControl.Enabled = true;
                //Cb
                CbChiNhanh.Enabled = false;
            }

        }
        private void CbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView")
                return;
            Program.servername = CbChiNhanh.SelectedValue.ToString();
            if (CbChiNhanh.SelectedIndex == Program.mChinhanh)
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.password;
            }
            else
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
            }
            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Xảy ra kết nối với chi nhánh hiện tại ", "Thông báo ", MessageBoxButtons.OK);
            }
            else
            {

                phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                phieuXuatTableAdapter.Fill(phieuXuatDS.PhieuXuat);

            }
        }

        private void phieuXuatBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsPhieuXuat.EndEdit();
            this.tableAdapterManager.UpdateAll(this.phieuXuatDS);

        }

        private void frmPhieuXuat_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'phieuXuatDS.CTPX' table. You can move, or remove it, as needed.
            this.cTPXTableAdapter.Fill(this.phieuXuatDS.CTPX);
            // TODO: This line of code loads data into the 'phieuXuatDS.PhieuXuat' table. You can move, or remove it, as needed.
            this.phieuXuatTableAdapter.Fill(this.phieuXuatDS.PhieuXuat);

        }

        private void phieuXuatBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
        private void setcolumn()
        {
            this.ctpxTable.Columns.Add("MAPX", typeof(string));
            this.ctpxTable.Columns.Add("MAVT", typeof(string));
            this.ctpxTable.Columns.Add("SOLUONG", typeof(int));
            this.ctpxTable.Columns.Add("DONGIA", typeof(float));
            this.ctpxTable.Columns.Add("SOLUONGTON", typeof(int));
        }
        private bool checkExistVattu(String mavt)
        {
            bool result = false;
            foreach (DataRow row in this.ctpxTable.Rows)
            {
                if (row["MAVT"].Equals(mavt))
                {
                    MessageBox.Show("Mã vật tư đã tồn tại trong bảng , vui lòng chỉnh sửa số lượng cần cập nhật");
                    result = true;
                    return result;
                }
               
            }
            return false;
        }
        private bool CheckStockQuantities(out int invalidRowIndex)
        {
            bool flag = true;
            invalidRowIndex = -1; // Khởi tạo vị trí không hợp lệ

            // Bắt đầu vòng lặp từ vị trí không hợp lệ lần trước nếu có
            int startIndex = lastInvalidRowIndex >= 0 ? lastInvalidRowIndex : 0;

            for (int i = startIndex; i < ctpxTable.Rows.Count; i++)
            {
                DataRow row = ctpxTable.Rows[i];
                int soluongton = Convert.ToInt32(row["SOLUONGTON"]);
                int soluong = Convert.ToInt32(row["SOLUONG"]);

                if (soluongton < soluong)
                {
                    invalidRowIndex = i; // Gán vị trí của hàng không hợp lệ
                    flag = false;
                    lastInvalidRowIndex = i; // Lưu vị trí không hợp lệ lần này
                    break;
                }
            }

            return flag;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            frmChonVatTu frm = new frmChonVatTu();       
            frm.ShowDialog();

            
            String mavt = Program.maVatTudcChon;
            String mapx = Program.ExecuteStoredProcedureFromMainSide("SP_generatePhieuXuat");
            int soluongton = Program.soluongtonvattu;

            if (mavt != "")
            {
                if (checkExistVattu(mavt) == false)
                {
                    DataRow newRow = ctpxTable.NewRow();
                    newRow["MAPX"] = mapx;
                    newRow["MAVT"] = mavt;
                    newRow["SOLUONG"] = 0;
                    newRow["DONGIA"] = 0.0;
                    newRow["SOLUONGTON"] = soluongton;
                    ctpxTable.Rows.Add(newRow);
                }
            }


            cTPXGridControl.DataSource = ctpxTable;
            cTPXGridControl.RefreshDataSource();

            //SET BUTTON
            themBtn.Enabled = false;
            suaBtn.Enabled = false;
            ghiBtn.Enabled = true;
            xoaBtn.Enabled = false;
            reloadBtn.Enabled = true;
            thoatBtn.Enabled = true;
            chonKhoBtn.Enabled = false;
            themCTPXBtn.Enabled = true;
            xoaCTPXBtn.Enabled = true;
           

            //SET GRIDCONTROL
            phieuXuatGridControl.Enabled = false;
            cTPXGridControl.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void cTPXGridControl_Click(object sender, EventArgs e)
        {

        }
        private XtraTabControl FindTabControl(Control control)
        {
            while (control != null)
            {
                if (control is XtraTabControl tabControl)
                {
                    return tabControl;
                }
                control = control.Parent;
            }
            return null;
        }
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi tab này không", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                XtraTabControl tabControl = FindTabControl(this);

                if (tabControl != null)
                {
                    // Get the parent tab page
                    XtraTabPage tabPage = tabControl.SelectedTabPage;

                    if (tabPage != null)
                    {
                        // Remove the current tab page
                        tabControl.TabPages.Remove(tabPage);
                    }
                }
            }
        }
        
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int invalidRowIndex;
            bool result = CheckStockQuantities( out invalidRowIndex);

            if (!result)
            {
                MessageBox.Show($"Số lượng tồn tại hàng: {invalidRowIndex + 1} nhỏ hơn số lượng yêu cầu.");
            }
            else
            {
                // Đặt lại vị trí không hợp lệ nếu tất cả các hàng đều hợp lệ
                lastInvalidRowIndex = -1;
                //THEM PHIEU XUAT
                if (loaithaotac == 1)
                {
                    SqlTransaction transaction = null;
                    try {

                        if (Program.KetNoi() == 1)
                        {
                            
                            String query = "INSERT INTO PhieuXuat(MAPX,NGAY,HOTENKH,MANV,MAKHO) VALUES(@MAPX,@NGAY,@HOTENKH,@MANV,@MAKHO) ";
                            transaction = Program.conn.BeginTransaction();
                            //ADD NEW PHIEU XUAT
                            using (SqlCommand command = new SqlCommand(query, Program.conn, transaction))
                            {
                                // Add parameters to the command
                                command.Parameters.AddWithValue("@MAPX", maPxTxt.Text.ToString());
                                command.Parameters.AddWithValue("@NGAY", DateTime.Today);
                                command.Parameters.AddWithValue("@HOTENKH", tenKHTxt.Text.ToString());
                                command.Parameters.AddWithValue("@MANV", Program.username);
                                command.Parameters.AddWithValue("@MAKHO", maKhoTxt.Text.ToString());

                                // Execute the command to insert the new row
                                command.ExecuteNonQuery();
                            }
                            //ADD NEW CTPX
                            foreach (DataRow row in ctpxTable.Rows)
                            {

                                using (SqlCommand cmd = new SqlCommand("SP_Insert_CTPX_VS_VATTU", Program.conn, transaction))
                                {
                                    // Add parameters to the command
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@MAPX",maPxTxt.Text.ToString());
                                    cmd.Parameters.AddWithValue("@MAVT", row["MAVT"]);
                                    cmd.Parameters.AddWithValue("@SOLUONG ", row["SOLUONG"]);
                                    cmd.Parameters.AddWithValue("@DONGIA ", row["DONGIA"]);
                                    cmd.ExecuteNonQuery();
                                }

                            }
                            transaction.Commit();

                            MessageBox.Show("Ghi phiếu xuất thành công!");
                            this.loaithaotac = -1;
                        }
                    }
                     catch(Exception ex)
                    {
                        MessageBox.Show("Lỗi ghi phiếu xuất" + ex.Message);
                        if (transaction != null)
                        {
                            transaction.Rollback();
                        }
                    }
                }

                //UPDATE PHIEU XUAT
                else if (loaithaotac == 0)
                {
                    SqlTransaction transaction = null;
                    try
                    {

                        if (Program.KetNoi() == 1)
                        {
                            string query = "UPDATE LINK0.QLVT_DATHANG.dbo.PhieuXuat SET HOTENKH = @HOTENKH, MAKHO = @MAKHO WHERE MAPX = @MAPX";
                            transaction = Program.conn.BeginTransaction();
                            //UPDATE PHIEU XUAT
                            using (SqlCommand command = new SqlCommand(query, Program.conn, transaction))
                            {
                                // Add parameters to the command
                                command.CommandType = CommandType.Text;
                                command.Parameters.AddWithValue("@MAPX", maPxTxt.Text.ToString());
                                command.Parameters.AddWithValue("@HOTENKH", tenKHTxt.Text.ToString());
                                command.Parameters.AddWithValue("@MAKHO", maKhoTxt.Text.ToString());

                                // Execute the command to insert the new row
                                command.ExecuteNonQuery();
                            }
                            //ADD UPDATE CTPX
                            

                            foreach (DataRow row in ctpxTable.Rows)
                            {
                                String mavt = row["MAVT"].ToString();
                            

                                using (SqlCommand cmd = new SqlCommand("SP_UpdateCTPXandVATTU", Program.conn, transaction))
                                {
                                    // Add parameters to the command
                                    cmd.CommandType = CommandType.StoredProcedure;
                                   
                                    int soluongton = Convert.ToInt32(row["SOLUONGTON"]);
                                    int soluong = Convert.ToInt32(row["SOLUONG"]);
                                    int soluongcanupdate = soluongton - soluong;

                                    cmd.Parameters.AddWithValue("@MAPX", row["MAPX"]);
                                    cmd.Parameters.AddWithValue("@MAVT", row["MAVT"]);
                                    cmd.Parameters.AddWithValue("@SOLUONG", row["SOLUONG"]);
                                    cmd.Parameters.AddWithValue("@SOLUONGTON",soluongcanupdate);
                                    cmd.Parameters.AddWithValue("@DONGIA", row["DONGIA"]);
                                    
                                    cmd.ExecuteNonQuery();
                                }

                            }
                            transaction.Commit();

                            MessageBox.Show("Cập nhật phiếu xuất thành công!");
                            this.loaithaotac = -1;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi cập nhật phiếu xuất" + ex.Message);
                        if (transaction != null)
                        {
                            transaction.Rollback();
                        }
                    }
                }
       
            }
            this.cTPXGridControl.DataSource = bdsCTPX;
            //SET BUTTON
            themBtn.Enabled = true;
            suaBtn.Enabled = true;
            ghiBtn.Enabled = false;
            xoaBtn.Enabled = true;
            reloadBtn.Enabled = true;
            thoatBtn.Enabled = true;
            chonKhoBtn.Enabled = false;
            themCTPXBtn.Enabled = false;
            xoaCTPXBtn.Enabled = false;

            tenKHTxt.Enabled = false;
            //SET GRIControl
            cTPXGridControl.Enabled = false;
            phieuXuatGridControl.Enabled = true;


        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.loaithaotac = 1;

            String maPX = Program.ExecuteStoredProcedureFromMainSide("SP_generatePhieuXuat");

            this.maPxTxt.Text = maPX;
            this.maNVTxt.Text = Program.username;
            this.ngayTxt.Text = DateTime.Today.ToShortDateString();

            this.tenKHTxt.Text = "";
            this.maKhoTxt.Text = "";

            this.cTPXGridControl.DataSource = ctpxTable;
            this.cTPXGridControl.RefreshDataSource();

            //SET BUTTON
            themBtn.Enabled = false;
            suaBtn.Enabled = false;
            ghiBtn.Enabled = true;
            xoaBtn.Enabled = false;
            reloadBtn.Enabled = true;
            thoatBtn.Enabled = true;
            chonKhoBtn.Enabled = true;
            themCTPXBtn.Enabled = true;
            xoaCTPXBtn.Enabled = true;

            tenKHTxt.Enabled = true;

            

            //SET GRIDCONTROL
            phieuXuatGridControl.Enabled = false;

        }

        private void chonKhoBtn_Click(object sender, EventArgs e)
        {
            frmChonKhohang frm = new frmChonKhohang();
            frm.ShowDialog();
            String makho = Program.maKhodcChon;
            this.maKhoTxt.Text =makho;

            //SET BUTTON
            themBtn.Enabled = false;
            suaBtn.Enabled = false;
            ghiBtn.Enabled = true;
            xoaBtn.Enabled = false;
            reloadBtn.Enabled = true;
            thoatBtn.Enabled = true;
            chonKhoBtn.Enabled = false;
            themCTPXBtn.Enabled = true;
            xoaCTPXBtn.Enabled = false;
            if (this.loaithaotac == 0)
            {
                themCTPXBtn.Enabled = false;
                xoaCTPXBtn.Enabled = false;
            }

            //SET GRIDCONTROL
            phieuXuatGridControl.Enabled = false;
            cTPXGridControl.Enabled = true;

        }
        private void getTableForUpdate()
        {
            if (this.ctpxTable.Rows.Count != 0)
            {
                this.ctpxTable.Clear();
            }

            if (this.mavtCu.Count != 0)
            {
                this.mavtCu.Clear();
            }

            String query = "SELECT SOLUONGTON FROM VATTU WHERE MAVT=@MAVT";

            GridView gridView2 = (GridView)cTPXGridControl.MainView;
            if (gridView2.RowCount != 0)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    DataRow gridRow = gridView2.GetDataRow(i);


                    DataRow newRow = this.ctpxTable.NewRow();
                    newRow["MAPX"] = gridRow["MAPX"];
                    newRow["MAVT"] = gridRow["MAVT"];
                    newRow["SOLUONG"] = gridRow["SOLUONG"];
                    newRow["DONGIA"] = gridRow["DONGIA"];

                    //Lưu giữ lại mã vật tư 
                    this.mavtCu.Add(gridRow["MAVT"].ToString());

                    String mavt= gridRow["MAVT"].ToString();
                    int soluongton = 0;

                    if (Program.KetNoi() == 1)
                    {
                        using (SqlCommand cmd = new SqlCommand(query, Program.conn))
                        {
                            cmd.Parameters.AddWithValue("@MAVT", mavt);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    soluongton = reader.GetInt32(0);
                                }
                            }
                        }
                    }
                    int soluong = Convert.ToInt32(gridRow["SOLUONG"]);                  
                    newRow["SOLUONGTON"] = soluongton+soluong;
                    this.ctpxTable.Rows.Add(newRow);
                }
            }
            cTPXGridControl.DataSource = this.ctpxTable;
            cTPXGridControl.RefreshDataSource();
        }

        private bool CheckMANVandUserName()
        {
            GridView gridView2 = (GridView)phieuXuatGridControl.MainView;
            bool ketqua = false;
            // Check if gridView2 is not null
            if (gridView2 == null)
            {
                MessageBox.Show("GridView is not available.");
                return true;
            }

            // Get the index of the focused row
            int selectedRowIndex = gridView2.FocusedRowHandle;

            // Check if a row is selected
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("No row is selected.");
                return true;
            }

            // Get the value of the "MANV" column in the selected row
            object manvValue = gridView2.GetRowCellValue(selectedRowIndex, "MANV");

            // Check if manvValue is null
            if (manvValue == null)
            {
                MessageBox.Show("MANV value is null.");
                return true;
            }

            // Convert manvValue to string and compare with Program.username
            string manv = manvValue.ToString();
            if (manv != Program.username)
            {
                MessageBox.Show("Phiếu nhập này không phải của bạn! Không có quyền chỉnh sửa.");
                ketqua = true;
            }
            else
            {
                ketqua = false;
            }
            return ketqua;

            // If the MANV matches Program.username, continue with your logic here
            // ...
        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.loaithaotac = 0;
            //Backup old data
            if (CheckMANVandUserName()==false)
            {
                getTableForUpdate();
                foreach (DataRow row in this.ctpxTable.Rows)
                {
                    String mapx = row["MAPX"].ToString();
                    String mavt = row["MAVT"].ToString();
                    int soluong = Convert.ToInt32(row["SOLUONG"]);
                    float dongia = Convert.ToSingle(row["DONGIA"]);

                }
                //SET BUTTON
                themBtn.Enabled = false;
                suaBtn.Enabled = false;
                ghiBtn.Enabled = true;
                xoaBtn.Enabled = false;
                reloadBtn.Enabled = true;
                thoatBtn.Enabled = true;
                chonKhoBtn.Enabled = true;
                themCTPXBtn.Enabled = false;
                xoaCTPXBtn.Enabled = false;
                if (this.loaithaotac == 0)
                {
                    themCTPXBtn.Enabled = false;
                    xoaCTPXBtn.Enabled = false;
                }

                tenKHTxt.Enabled = true;

                //SET GRIDCONTROL
                phieuXuatGridControl.Enabled = false;
                cTPXGridControl.Enabled = true;
            }
            else
            {
              
                //SET BUTTON
                themBtn.Enabled = false;
                suaBtn.Enabled = false;
                ghiBtn.Enabled = true;
                xoaBtn.Enabled = false;
                reloadBtn.Enabled = true;
                thoatBtn.Enabled = true;
                chonKhoBtn.Enabled = true;
                themCTPXBtn.Enabled = false;
                xoaCTPXBtn.Enabled = false;
                if (this.loaithaotac == 0)
                {
                    themCTPXBtn.Enabled = false;
                    xoaCTPXBtn.Enabled = false;
                }

                //SET GRIDCONTROL
                phieuXuatGridControl.Enabled = false;
                cTPXGridControl.Enabled = true;
            }

           
        }

        private void xoaBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridView gridView = phieuXuatGridControl.MainView as GridView;

            // Get the index of the focused row
            int selectedRowIndex = gridView.FocusedRowHandle;


            // Get the DataRowView associated with the focused row
            DataRowView selectedRowView = gridView.GetRow(selectedRowIndex) as DataRowView;

            if (selectedRowView != null)
            {
                SqlTransaction transaction = null;
                if (Program.KetNoi() == 1)
                {
                    String maPX = selectedRowView.Row["MAPX"].ToString();
                    transaction = Program.conn.BeginTransaction();
                    try
                    {
                        //Delete and increasing Vattu

                        using (SqlCommand cmd = new SqlCommand("SP_XoaPhieuXuat", Program.conn, transaction))
                        {
                            // Add parameters to the command
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@MAPX", maPxTxt.Text.ToString());
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        MessageBox.Show("Xóa phiếu xuất thành công!");

                        //SET BUTTON
                        themBtn.Enabled = true;
                        suaBtn.Enabled = true;
                        ghiBtn.Enabled = false;
                        xoaBtn.Enabled = true;
                        reloadBtn.Enabled = true;
                        thoatBtn.Enabled = true;
                        chonKhoBtn.Enabled = false;
                        themCTPXBtn.Enabled = false;
                        xoaCTPXBtn.Enabled = false;

                        //SET GRIControl
                        cTPXGridControl.Enabled = false;
                        phieuXuatGridControl.Enabled = true;

                    }
                    catch (Exception ex)
                    {
                        if (transaction != null)
                        {
                            transaction.Rollback();
                        }
                        MessageBox.Show("Lỗi xóa Phiếu xuất : " + ex.Message, "", MessageBoxButtons.OK);
                        return;
                    }

                    //SET BUTTON 
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Phiếu Xuất cần xóa !");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // Cast the MainView of the grid to GridView
            int a = this.ctpxTable.Rows.Count;
            GridView gridView = cTPXGridControl.MainView as GridView;

            // Get the index of the focused row
            int selectedRowIndex = gridView.FocusedRowHandle;

            // Get the DataRowView associated with the focused row
            DataRowView selectedRowView = gridView.GetRow(selectedRowIndex) as DataRowView;

            // Ensure there is a selected row
            if (selectedRowView != null)
            {
                // Get the actual DataRow from the DataRowView
                DataRow selectedRow = selectedRowView.Row;
                this.mavtDaXoa.Add(selectedRow["MAVT"].ToString());

                // Delete the row from the DataTable (assuming it's the DataTable's Rows collection)
                selectedRow.Delete();

                // Optionally, you might want to save changes to the data source here if needed
                // For example, if your data source is a DataTable:
                if (this.ctpxTable is DataTable dataTable)
                {
                    dataTable.AcceptChanges();
                }
                this.cTPXGridControl.RefreshDataSource();
            }
            int b = this.ctpxTable.Rows.Count;

            foreach (DataRow row in this.ctpxTable.Rows)
            {
                String mapx = row["MAPX"].ToString();
                String mavt = row["MAVT"].ToString();
                int soluong = Convert.ToInt32(row["SOLUONG"]);

                // Cast to float
                float dongia = Convert.ToSingle(row["DONGIA"]);
            }


            //SET BUTTON
            themBtn.Enabled = false;
            suaBtn.Enabled = false;
            ghiBtn.Enabled = true;
            xoaBtn.Enabled = false;
            reloadBtn.Enabled = true;
            thoatBtn.Enabled = true;
            chonKhoBtn.Enabled = false;
            themCTPXBtn.Enabled = true;
            xoaCTPXBtn.Enabled = true;


            //SET GRIDCONTROL
            phieuXuatGridControl.Enabled = false;
            cTPXGridControl.Enabled = true;

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.phieuXuatTableAdapter.Fill(this.phieuXuatDS.PhieuXuat);
            this.cTPXTableAdapter.Fill(this.phieuXuatDS.CTPX);
            //SET BUTTON
            themBtn.Enabled = true;
            suaBtn.Enabled = true;
            ghiBtn.Enabled = false;
            xoaBtn.Enabled = true;
            reloadBtn.Enabled = true;
            thoatBtn.Enabled = true;
            chonKhoBtn.Enabled = false;
            themCTPXBtn.Enabled = false;
            xoaCTPXBtn.Enabled = false;

            tenKHTxt.Enabled = false;
            //SET GRIControl
            cTPXGridControl.Enabled = false;
            phieuXuatGridControl.Enabled = true;

        }
    }
}