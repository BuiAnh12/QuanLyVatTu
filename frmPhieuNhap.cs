using DevExpress.CodeParser;
using DevExpress.DataAccess.Native.Excel;
using DevExpress.Utils;
using DevExpress.XtraCharts.Native;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList.Painter;
using QuanLyVatTu.DSTableAdapters;
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
using System.Web.UI.Design.WebControls;
using System.Windows.Forms;

namespace QuanLyVatTu
{

    public partial class frmPhieuNhap : DevExpress.XtraEditors.XtraForm
    {
        String maPN = "";
        private int loaithaotac = -1;
        private DataTable ctpnTableGetFromDB = new DataTable();
        private DataTable tmpTable = new DataTable();

        public frmPhieuNhap()
        {
            InitializeComponent();
            phieuNhapDS.EnforceConstraints = false;
            //ADD DATA TO COMBOBOX 
            CbChiNhanh.DataSource = Program.bds_dspm;
            CbChiNhanh.DisplayMember = "TENCN";
            CbChiNhanh.ValueMember = "TENSERVER";
            CbChiNhanh.SelectedIndex = Program.mChinhanh;

            //DEFINE ctpnTableGetFromDB TABLE
            ctpnTableGetFromDB.Columns.Add("MAPN", typeof(string));
            ctpnTableGetFromDB.Columns.Add("MAVT", typeof(string));
            ctpnTableGetFromDB.Columns.Add("SOLUONG", typeof(int));
            ctpnTableGetFromDB.Columns.Add("DONGIA", typeof(float));
            //DEFINE TmpTable
            AddNewtmpDataTable();

            //Set Button 


            if (Program.mGroup == "CONGTY")
            {
              

                CbChiNhanh.DataSource = Program.bds_dspm;
                CbChiNhanh.DisplayMember = "TENCN";
                CbChiNhanh.ValueMember = "TENSERVER";

                //Setbutton
                themBtn.Enabled = false;
                suaBtn.Enabled = false;
                ghiBtn.Enabled = false;
                xoaBtn.Enabled = false;
                reloadBtn.Enabled = true;
                thoatBtn.Enabled = true;
                xoactpnBtn.Enabled = false;
                //GridContorl
                phieuNhapGridControl.Enabled = true;
                cTPNGridControl.Enabled = false;
                chondonhangBtn.Enabled = false;
                hienthiCTDDHBtn.Enabled = false;
                xoactpnBtn.Enabled = false;

                CbChiNhanh.Enabled = true;

            }
            else if (Program.mGroup == "USER")
            {

                //Setbutton
                themBtn.Enabled = false;
                suaBtn.Enabled = true;
                ghiBtn.Enabled = false;
                xoaBtn.Enabled = false;
                reloadBtn.Enabled = true;
                thoatBtn.Enabled = true;
                xoactpnBtn.Enabled = false;
                //GridContorl
                phieuNhapGridControl.Enabled = true;
                cTPNGridControl.Enabled = false;
                chondonhangBtn.Enabled = false;
                hienthiCTDDHBtn.Enabled = false;
                xoactpnBtn.Enabled = false;
                //
                CbChiNhanh.Enabled = true;

            }
            else if (Program.mGroup == "CHINHANH")
            {
                //Setbutton
                themBtn.Enabled = true;
                suaBtn.Enabled = true;
                ghiBtn.Enabled = false;
                xoaBtn.Enabled = true;
                reloadBtn.Enabled = true;
                thoatBtn.Enabled = true;
                xoactpnBtn.Enabled = false;
                //GridContorl
                phieuNhapGridControl.Enabled = true;
                cTPNGridControl.Enabled = false;
                chondonhangBtn.Enabled = false;
                hienthiCTDDHBtn.Enabled = false;
                xoactpnBtn.Enabled = false;
                //Cb
                CbChiNhanh.Enabled = false;
            }


           



        }

        private void phieuNhapBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {


        }

        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
         
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
               
                phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                phieuNhapTableAdapter.Fill(phieuNhapDS.PhieuNhap);

            }
        }

        private void phieuNhapBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsPhieuNhap.EndEdit();
            this.tableAdapterManager.UpdateAll(this.phieuNhapDS);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            frmChonDDH frm = new frmChonDDH();
            frm.ShowDialog();
            this.maDDHTxt.Text = Program.maDDHdcChonTrongPhieuNhap;
            this.maKhoTxt.Text = Program.maKhodcChonTrongPhieuNhap;

            //Kiểm tra chi tiết đơn hàng đã được đặt thêm vào phiếu nhập hay chưa 
            string query = "SELECT COUNT(*) FROM PhieuNhap WHERE MasoDDH = @MasoDDH";
            bool exist = false;
            if (Program.KetNoi() == 1)
            {
                using (SqlCommand command = new SqlCommand(query, Program.conn))
                {
                    // Add the MasoDDH parameter to the command
                    command.Parameters.AddWithValue("@MasoDDH", Program.maDDHdcChonTrongPhieuNhap);

                    // Execute the query and get the result
                    int count = (int)command.ExecuteScalar();

                    // If count is greater than 0, MasoDDH exists
                    exist = (count > 0);
                }
            }
            if (exist)
            {
                MessageBox.Show("Đơn đặt hàng đã tồn tại trong phiếu nhập , vui lòng chọn đơn khác!");
                return;
            }

            Program.maDDHdcChonTrongPhieuNhap = "";
            Program.maKhodcChonTrongPhieuNhap = "";


            themBtn.Enabled = false;
            suaBtn.Enabled = false;
            ghiBtn.Enabled = false;
            xoaBtn.Enabled = false;
            reloadBtn.Enabled = true;
            thoatBtn.Enabled = true;
            xoactpnBtn.Enabled = false;
            //GridContorl
            phieuNhapGridControl.Enabled = false;
            cTPNGridControl.Enabled = false;
            chondonhangBtn.Enabled = false;
            hienthiCTDDHBtn.Enabled = true;
            xoactpnBtn.Enabled = false;


        }
        private void generateMPN()
        {
            try
            {
                String maPn = "";
                maPn= Program.ExecuteStoredProcedureFromMainSide("SP_generatePhieuNhap");
                this.maPNTxt.Text = maPn;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tạo mã phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Them moi phieu nhap
            this.loaithaotac = 1;
            generateMPN();
            maNVTxt.Text = Program.username;
            ngayPNTxt.Text = DateTime.Today.ToShortDateString();

            //Setbutton
            themBtn.Enabled = false;
            suaBtn.Enabled = false;
            ghiBtn.Enabled = false;
            xoaBtn.Enabled = false;
            reloadBtn.Enabled = true;
            thoatBtn.Enabled = true;
            xoactpnBtn.Enabled = false;
            //GridContorl
            phieuNhapGridControl.Enabled = false;
            cTPNGridControl.Enabled = false;
            chondonhangBtn.Enabled = true;
            hienthiCTDDHBtn.Enabled=false;
            xoactpnBtn.Enabled=false ;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.ctpnTableGetFromDB.Rows.Count != 0)
            {
                this.ctpnTableGetFromDB.Clear();
            }
            this.ctpnTableGetFromDB = cTDDH1TableAdapter.GetDataCTTDHbyMasoDDH(maPNTxt.Text.ToString(),maDDHTxt.Text.ToString());
            cTPNGridControl.DataSource = null;
            cTPNGridControl.DataSource = ctpnTableGetFromDB;
                     
            cTPNGridControl.RefreshDataSource();
            GridView gridView2 = (GridView)cTPNGridControl.MainView;

           /* gridView2.CellValueChanged -= gridView_CellValueChanged1; // Ensure to unsubscribe first
            gridView2.CellValueChanged += gridView_CellValueChanged1;*/


            //setbutton 
            ghiBtn.Enabled = true;

            themBtn.Enabled = false;
            suaBtn.Enabled = false;
            ghiBtn.Enabled = true;
            xoaBtn.Enabled = false;
            reloadBtn.Enabled = true;
            thoatBtn.Enabled = true;
            xoactpnBtn.Enabled = false;
            //GridContorl
            phieuNhapGridControl.Enabled = false;
            cTPNGridControl.Enabled = true;
            chondonhangBtn.Enabled = false;
            hienthiCTDDHBtn.Enabled = true;
            xoactpnBtn.Enabled = true;
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
            //try
            //{
            //    this.cTDDH1TableAdapter.Fill(this.phieuNhapDS.CTDDH1, maPNToolStripTextBox.Text, masoDDHToolStripTextBox.Text);
            //}
            //catch (System.Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message);
            //}

        }

        private void phieuNhapGridControl_Click(object sender, EventArgs e)
        {

        }
        private void checkEmpty()
        {
            if (maPNTxt.Text.Equals("") ||
                ngayPNTxt.Text.Equals("") ||
                maNVTxt.Text.Equals("") ||
                maKhoTxt.Text.Equals("") ||
                maDDHTxt.Text.Equals(""))
            {
                // If any of the text boxes are empty, show an error message
                MessageBox.Show("Các trường không được để trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private string[] GetMAVTArray(string mapn)
        {
            List<string> mavtList = new List<string>();
            string query = "SELECT MAVT CTPN WHERE MAPN = @MAPN";

            try
            {
                if (Program.KetNoi() == 1)
                {
                    using (SqlCommand cmd = new SqlCommand(query, Program.conn))
                    {
                        cmd.Parameters.AddWithValue("@MAPN", mapn);                      
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                mavtList.Add(reader["MAVT"].ToString());
                            }
                        }
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi lấy danh sách mảng vật tư", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
            return mavtList.ToArray();
        }
        private bool checksoluong(DataTable temp)
        {
            String querycheck = "SELECT SOLUONG FROM CTDDH WHERE MasoDDH=@MasoDDH AND  MAVT=@MAVT";
            bool ketqua=false;
            if (Program.KetNoi() == 1)
            {
                foreach (DataRow row in temp.Rows)
                {
                    int soluongcu = 0;
                    int soluongmoi = Convert.ToInt32(row["SOLUONG"]);
                    using (SqlCommand cmd = new SqlCommand(querycheck, Program.conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@MasoDDH", maDDHTxt.Text.ToString());
                        cmd.Parameters.AddWithValue("@MAVT", row["MAVT"]);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            soluongcu = Convert.ToInt32(result);
                        }
                    }
                    if (soluongmoi > soluongcu)
                    {
                        MessageBox.Show("Vui lòng nhập số lượng vật tư nhỏ hơn đơn đặt hàng!");
                        break;
                        ketqua = false;
                        return ketqua;
                    }
                    else
                    {
                        ketqua = true;
                    }

                }
            }
            return ketqua;
         
        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            checkEmpty();

            //INSERT PHIEU NHAP
            if (this.loaithaotac == 1)
            {              
                String maPN= Program.ExecuteStoredProcedureFromMainSide("SP_generatePhieuNhap");


                SqlTransaction transaction = null;

                try
                {
                    if (Program.KetNoi() == 1)
                    {

                        if (checksoluong(ctpnTableGetFromDB) == true)
                        {
                            transaction = Program.conn.BeginTransaction();
                            string query = "INSERT INTO PhieuNhap (MAPN, NGAY, MasoDDH, MANV, MAKHO) VALUES (@mapn, @ngay, @masoddh, @manv, @makho)";

                            using (SqlCommand command = new SqlCommand(query, Program.conn, transaction))
                            {
                                // Add parameters to the command
                                command.Parameters.AddWithValue("@mapn", maPN);
                                command.Parameters.AddWithValue("@ngay", DateTime.Today);
                                command.Parameters.AddWithValue("@masoddh", maDDHTxt.Text.ToString());
                                command.Parameters.AddWithValue("@manv", Program.username);
                                command.Parameters.AddWithValue("@makho", maKhoTxt.Text.ToString());

                                // Execute the command to insert the new row
                                command.ExecuteNonQuery();
                            }

                            this.ctpnTableGetFromDB.AcceptChanges();

                            foreach (DataRow row in ctpnTableGetFromDB.Rows)
                            {

                                using (SqlCommand cmd = new SqlCommand("SP_Insert_CTPN_VS_VATTU", Program.conn, transaction))
                                {
                                    // Add parameters to the command
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@MAPN", maPNTxt.Text.ToString());
                                    cmd.Parameters.AddWithValue("@MAVT", row["MAVT"]);
                                    cmd.Parameters.AddWithValue("@SOLUONG ", row["SOLUONG"]);
                                    cmd.Parameters.AddWithValue("@DONGIA ", row["DONGIA"]);
                                    cmd.ExecuteNonQuery();
                                }

                            }
                            transaction.Commit();

                            MessageBox.Show("Ghi phiếu nhập thành công!");
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Lỗi ghi phiếu nhập" + ex.Message);
                    if(transaction != null){
                        transaction.Rollback();
                    }
                }

                //Setbutton
                themBtn.Enabled = true;
                suaBtn.Enabled = true;
                ghiBtn.Enabled = false;
                xoaBtn.Enabled = true;
                reloadBtn.Enabled = true;
                thoatBtn.Enabled = true;
                xoactpnBtn.Enabled = false;
                //GridContorl
                phieuNhapGridControl.Enabled = true;
                cTPNGridControl.Enabled = false;
                chondonhangBtn.Enabled = false;
                hienthiCTDDHBtn.Enabled = false;
                xoactpnBtn.Enabled = false;


                maPNTxt.Text = "";
                ngayPNTxt.Text = "";
                maNVTxt.Text = "";
                maKhoTxt.Text = "";
                maDDHTxt.Text = "";
            }
            else if (this.loaithaotac == 0)
            {
                SqlTransaction transaction = null;
                if (Program.KetNoi() == 1)
                {
                    if (checksoluong(tmpTable))
                    {
                        transaction = Program.conn.BeginTransaction();
                        try
                        {
                            //Delete and increasing Vattu
                            using (SqlCommand cmd = new SqlCommand("SP_UpdateAndDeleteCTPNincreaseVattu", Program.conn, transaction))
                            {
                                // Add parameters to the command
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@MAPN", maPNTxt.Text.ToString());
                                cmd.ExecuteNonQuery();
                            }
                            foreach (DataRow row in tmpTable.Rows)
                            {
                                using (SqlCommand cmd = new SqlCommand("SP_AddCTPNAndUpdateSOLUONGTON", Program.conn, transaction))
                                {
                                    // Add parameters to the command
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@MAPN", maPNTxt.Text.ToString());
                                    cmd.Parameters.AddWithValue("@MAVT", row["MAVT"]);
                                    cmd.Parameters.AddWithValue("@SOLUONG ", row["SOLUONG"]);
                                    cmd.Parameters.AddWithValue("@DONGIA ", row["DONGIA"]);
                                    cmd.ExecuteNonQuery();
                                }

                            }
                            transaction.Commit();
                            MessageBox.Show("Cập nhật phiếu nhập thành công!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi cập nhật phiếu nhập" + ex.Message);
                            if (transaction != null)
                            {
                                transaction.Rollback();
                            }
                        }
                    }                  
                }
                themBtn.Enabled = true;
                suaBtn.Enabled = true;
                ghiBtn.Enabled = false;
                xoaBtn.Enabled = true;
                reloadBtn.Enabled = true;
                thoatBtn.Enabled = true;
                xoactpnBtn.Enabled = false;
                //GridContorl
                phieuNhapGridControl.Enabled = true;
                cTPNGridControl.Enabled = false;
                chondonhangBtn.Enabled = false;
                hienthiCTDDHBtn.Enabled = false;
                xoactpnBtn.Enabled = false;

                maPNTxt.Text = "";
                ngayPNTxt.Text = "";
                maNVTxt.Text = "";
                maKhoTxt.Text = "";
                maDDHTxt.Text = "";

            }

            cTPNGridControl.DataSource = bdsCTPN;

            phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            cTPNTableAdapter.Connection.ConnectionString = Program.connstr;

            phieuNhapTableAdapter.Fill(this.phieuNhapDS.PhieuNhap);
            cTPNTableAdapter.Fill(this.phieuNhapDS.CTPN);

            
        }

        private void reloadBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.phieuNhapTableAdapter.Fill(phieuNhapDS.PhieuNhap);
                this.cTPNTableAdapter.Fill(phieuNhapDS.CTPN);
                //Clear cTDDH
                phieuNhapGridControl.RefreshDataSource();

                cTPNGridControl.DataSource = bdsCTPN;
                cTPNGridControl.RefreshDataSource();


                themBtn.Enabled = true;
                suaBtn.Enabled = true;
                ghiBtn.Enabled = false;
                xoaBtn.Enabled = true;
                reloadBtn.Enabled = true;
                thoatBtn.Enabled = true;
                xoactpnBtn.Enabled = false;
                //GridContorl
                phieuNhapGridControl.Enabled = true;
                cTPNGridControl.Enabled = false;
                chondonhangBtn.Enabled = false;
                hienthiCTDDHBtn.Enabled = false;
                xoactpnBtn.Enabled = false;


                maPNTxt.Text = "";
                ngayPNTxt.Text = "";
                maNVTxt.Text = "";
                maKhoTxt.Text = "";
                maDDHTxt.Text = "";

            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi Reload : " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
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

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
        public void AddNewtmpDataTable()
        {
            this.tmpTable = new DataTable();
            tmpTable.Columns.Add("MAPN", typeof(string));
            tmpTable.Columns.Add("MAVT", typeof(string));
            tmpTable.Columns.Add("SOLUONG", typeof(int));
            tmpTable.Columns.Add("DONGIA", typeof(float));
        }
        private void addDatatoNewTmpDataTabletoUpdate()
        {

            if (this.tmpTable.Rows.Count != 0)
            {
                this.tmpTable.Clear();
            }
            // Get data from gridView2 and fill tempDataTable
            GridView gridView2 = (GridView)cTPNGridControl.MainView;
            if (gridView2.RowCount != 0)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    DataRow gridRow = gridView2.GetDataRow(i);
                    DataRow newRow = tmpTable.NewRow();
                    newRow["MAPN"] = gridRow["MAPN"];
                    newRow["MAVT"] = gridRow["MAVT"];
                    newRow["SOLUONG"] = gridRow["SOLUONG"];
                    newRow["DONGIA"] = gridRow["DONGIA"];
                    tmpTable.Rows.Add(newRow);
                }
            }
            cTPNGridControl.DataSource = this.tmpTable;
            cTPNGridControl.RefreshDataSource();
        }

        private void gridView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            GridView gridView = sender as GridView;

            if (e.RowHandle >= 0) // Ensure it's a valid row
            {
                DataRow gridRow = gridView.GetDataRow(e.RowHandle);

                // Update tmpTable with the changed value
                DataRow tmpRow = tmpTable.Rows[e.RowHandle];
                tmpRow["MAPN"] = gridRow["MAPN"];
                tmpRow["MAVT"] = gridRow["MAVT"];
                tmpRow["SOLUONG"] = gridRow["SOLUONG"];
                tmpRow["DONGIA"] = gridRow["DONGIA"];
            }
        }

        private void gridView_CellValueChanged1(object sender, CellValueChangedEventArgs e)
        {
            GridView gridView = sender as GridView;

            if (e.RowHandle >= 0) // Ensure it's a valid row
            {
                DataRow gridRow = gridView.GetDataRow(e.RowHandle);

                // Update tmpTable with the changed value
                DataRow tmpRow = this.ctpnTableGetFromDB.Rows[e.RowHandle];
                tmpRow["MAPN"] = gridRow["MAPN"];
                tmpRow["MAVT"] = gridRow["MAVT"];
                tmpRow["SOLUONG"] = gridRow["SOLUONG"];
                tmpRow["DONGIA"] = gridRow["DONGIA"];
            }
        }

        private void updatectpnBtn_Click(object sender, EventArgs e)
        {

            //addDatatoNewTmpDataTabletoUpdate();
        }
        private void getOldDataAssigntoTmpTable()
        {
            GridView gridView2 = (GridView)cTPNGridControl.MainView;
            if (gridView2.RowCount != 0)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    DataRow gridRow = gridView2.GetDataRow(i);

                    DataRow newRow = this.tmpTable.NewRow();
                    newRow["MAPN"] = gridRow["MAPN"];
                    newRow["MAVT"] = gridRow["MAVT"];
                    newRow["SOLUONG"] = gridRow["SOLUONG"];
                    newRow["DONGIA"] = gridRow["DONGIA"];

                    this.tmpTable.Rows.Add(newRow);
                }
            }
            cTPNGridControl.DataSource = this.tmpTable;
            cTPNGridControl.RefreshDataSource();

            gridView2.CellValueChanged -= gridView_CellValueChanged; // Ensure to unsubscribe first
            gridView2.CellValueChanged += gridView_CellValueChanged;
        }
        private bool CheckMANVandUserName()
        {
            GridView gridView2 = (GridView)phieuNhapGridControl.MainView;
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
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.loaithaotac = 0;
            if (CheckMANVandUserName() == false)
            {
                themBtn.Enabled = false;
                suaBtn.Enabled = false;
                ghiBtn.Enabled = true;
                xoaBtn.Enabled = false;
                reloadBtn.Enabled = true;
                thoatBtn.Enabled = true;
                xoactpnBtn.Enabled = false;
                //GridContorl
                phieuNhapGridControl.Enabled = false;
                cTPNGridControl.Enabled = true;
                chondonhangBtn.Enabled = false;
                hienthiCTDDHBtn.Enabled = false;
                xoactpnBtn.Enabled = false;
                getOldDataAssigntoTmpTable();
            }
            else
            {
                themBtn.Enabled = true;
                suaBtn.Enabled = true;
                ghiBtn.Enabled = false;
                xoaBtn.Enabled = true;
                reloadBtn.Enabled = true;
                thoatBtn.Enabled = true;
                xoactpnBtn.Enabled = false;
                //GridContorl
                phieuNhapGridControl.Enabled = true;
                cTPNGridControl.Enabled = false;
                chondonhangBtn.Enabled = false;
                hienthiCTDDHBtn.Enabled = false;
                xoactpnBtn.Enabled = false;
            }
        }

        

        private void xoactpnBtn_Click(object sender, EventArgs e)
        {
            // Cast the MainView of the grid to GridView
            int a = this.ctpnTableGetFromDB.Rows.Count;
            GridView gridView = cTPNGridControl.MainView as GridView;

            // Get the index of the focused row
            int selectedRowIndex = gridView.FocusedRowHandle;

            // Get the DataRowView associated with the focused row
            DataRowView selectedRowView = gridView.GetRow(selectedRowIndex) as DataRowView;

            // Ensure there is a selected row
            if (selectedRowView != null)
            {
                // Get the actual DataRow from the DataRowView
                DataRow selectedRow = selectedRowView.Row;

                // Delete the row from the DataTable (assuming it's the DataTable's Rows collection)
                selectedRow.Delete();

                // Optionally, you might want to save changes to the data source here if needed
                // For example, if your data source is a DataTable:
                if (ctpnTableGetFromDB is DataTable dataTable)
                {
                    dataTable.AcceptChanges();
                }
                this.cTPNGridControl.RefreshDataSource();
            }
            
            int num = this.ctpnTableGetFromDB.Rows.Count;
        }

        private void xoaBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridView gridView = phieuNhapGridControl.MainView as GridView;

            // Get the index of the focused row
            int selectedRowIndex = gridView.FocusedRowHandle;
            

            // Get the DataRowView associated with the focused row
            DataRowView selectedRowView = gridView.GetRow(selectedRowIndex) as DataRowView;

            if (selectedRowView != null)
            {
                SqlTransaction transaction = null;
                if (Program.KetNoi() == 1)
                {
                    String maPN = selectedRowView.Row["MAPN"].ToString();
                    transaction=Program.conn.BeginTransaction();
                    try
                    {
                        //Delete and increasing Vattu

                        using (SqlCommand cmd = new SqlCommand("SP_DeletePhieuNhap", Program.conn, transaction))
                        {
                            // Add parameters to the command
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@MAPN", maPNTxt.Text.ToString());
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        MessageBox.Show("Xóa phiếu nhập thành công!");

                    }
                    catch (Exception ex)
                    {
                        if (transaction != null)
                        {
                            transaction.Rollback();
                        }
                        MessageBox.Show("Lỗi xóa Phiếu Nhập : " + ex.Message, "", MessageBoxButtons.OK);
                        return;
                    }

                    themBtn.Enabled = true;
                    suaBtn.Enabled = true;
                    ghiBtn.Enabled = false;
                    xoaBtn.Enabled = true;
                    reloadBtn.Enabled = true;
                    thoatBtn.Enabled = true;
                    xoactpnBtn.Enabled = false;
                    //GridContorl
                    phieuNhapGridControl.Enabled = true;
                    cTPNGridControl.Enabled = false;
                    chondonhangBtn.Enabled = false;
                    hienthiCTDDHBtn.Enabled = false;
                    xoactpnBtn.Enabled = false;


                    maPNTxt.Text = "";
                    ngayPNTxt.Text = "";
                    maNVTxt.Text = "";
                    maKhoTxt.Text = "";
                    maDDHTxt.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Phiếu Nhập cần xóa !" );
            }
          
        }
    }
}