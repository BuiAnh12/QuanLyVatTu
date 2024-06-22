using DevExpress.Utils.Helpers;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using QuanLyVatTu.SubForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.CodeParser;
using System.Diagnostics;
using DevExpress.Xpo.DB.Helpers;
using DevExpress.Utils.Automation;

namespace QuanLyVatTu
{
    //Define template CTDDH table
    public partial class frmDondathang : Form
    {
        String macn = "";
        DataTable tempDataTable = new DataTable();
        String MaDDH = "";
        String MaDDHMoi = "";
        int vitri = 0;
        int loaithaotac =-1;
        int indexDonHang = -1;
        int indexCTDDH = -1;

        //Define tempalte CTDDH table 

        private Form checkExist(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }
        public void setButtonCTDDH()
        {
            themCTDDHbtn.Enabled = ghiCTDDHbtn.Enabled = suaCTDDHbtn.Enabled = false;
            xoaCTDDHbtn.Enabled = phuchoiCTDDHbtn.Enabled = false;
        }
        public frmDondathang()
        {   

            InitializeComponent();
            datHangDS.EnforceConstraints = false;
            //Combobox Action
            CbChiNhanh.DataSource = Program.bds_dspm;
            CbChiNhanh.DisplayMember = "TENCN";
            CbChiNhanh.ValueMember = "TENSERVER";
            CbChiNhanh.SelectedIndex = Program.mChinhanh;

            cTDDHGridControl.Enabled = true;

            setButtonCTDDH();

            groupBox2.Enabled = groupBox3.Enabled = false;

            if (Program.mGroup == "CONGTY")
            {
                ThemBtn.Enabled = SuaBtn.Enabled = GhiBtn.Enabled = XoaBtn.Enabled = false;
                PhuchoiBtn.Enabled = reloadBtn.Enabled = false;
                ThoatBtn.Enabled =CbChiNhanh.Enabled= true;
                hoantatBtn.Enabled = false;

                CbChiNhanh.DataSource = Program.bds_dspm;
                CbChiNhanh.DisplayMember = "TENCN";
                CbChiNhanh.ValueMember = "TENSERVER";

            }
            else if (Program.mGroup == "USER")
            {
                ThemBtn.Enabled = SuaBtn.Enabled = GhiBtn.Enabled = XoaBtn.Enabled = false;
                PhuchoiBtn.Enabled = false;
                CbChiNhanh.Enabled = false;
                ThoatBtn.Enabled  = true;
                reloadBtn.Enabled = true;
                hoantatBtn.Enabled = false;

            }
            else if (Program.mGroup == "CHINHANH")
            {
                GhiBtn.Enabled = XoaBtn.Enabled = false;
                XoaBtn.Enabled = true;
                PhuchoiBtn.Enabled  =CbChiNhanh.Enabled= false;
                ThoatBtn.Enabled =ThemBtn.Enabled=reloadBtn.Enabled=true;
                SuaBtn.Enabled = true;
                hoantatBtn.Enabled = false;
            }

        }

        

        private void datHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsDathang.EndEdit();
            this.tableAdapterManager.UpdateAll(this.datHangDS);

        }

        private void Dondathang_Load(object sender, EventArgs e)
        {
            datHangDS.EnforceConstraints = false;
            this.vattuTableAdapter.Fill(this.datHangDS.Vattu);
            this.datHangTableAdapter.Fill(this.datHangDS.DatHang);
            this.cTDDHTableAdapter.Fill(this.datHangDS.CTDDH);
            // TODO: This line of code loads data into the 'datHangDS.Vattu' table. You can move, or remove it, as needed.
            this.vattuTableAdapter.Fill(this.datHangDS.Vattu);
            // TODO: This line of code loads data into the 'datHangDS.CTDDH' table. You can move, or remove it, as needed.
            this.cTDDHTableAdapter.Fill(this.datHangDS.CTDDH);
            // TODO: This line of code loads data into the 'datHangDS.DatHang' table. You can move, or remove it, as needed.
            this.datHangTableAdapter.Fill(this.datHangDS.DatHang);
            // TODO: This line of code loads data into the 'datHangDS.CTDDH' table. You can move, or remove it, as needed.
           
            this.datHangTableAdapter.Fill(this.datHangDS.DatHang);
       
            // TODO: This line of code loads data into the 'dS.DatHang' table. You can move, or remove it, as needed.
            this.datHangTableAdapter.Fill(this.datHangDS.DatHang);

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView")
                    return;
            Program.servername=CbChiNhanh.SelectedValue.ToString();
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
                datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                datHangTableAdapter.Fill(datHangDS.DatHang);
              
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
        private void ThoatBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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


        private void datHangBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsDathang.EndEdit();
            this.tableAdapterManager.UpdateAll(this.datHangDS);

        }

        private void datHangBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsDathang.EndEdit();
            this.tableAdapterManager.UpdateAll(this.datHangDS);

        }

        private void datHangBindingNavigatorSaveItem_Click_3(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsDathang.EndEdit();
            this.tableAdapterManager.UpdateAll(this.datHangDS);

        }
        public void DathangTableClick()
        {
        }
        private void reloadBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.datHangTableAdapter.Fill(datHangDS.DatHang);
                this.cTDDHTableAdapter.Fill(datHangDS.CTDDH);
                //Clear cTDDH
                cTDDHGridControl.RefreshDataSource();
                ThemBtn.Enabled = SuaBtn.Enabled = XoaBtn.Enabled = true;
                ghiCTDDHbtn.Enabled = xoaCTDDHbtn.Enabled = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi Reload : " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
            datHangGridControl.Enabled = true;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;

        }

        private void chonVattuBtn(object sender, EventArgs e)
        {
            frmChonVatTu frm = new frmChonVatTu();
            frm.ShowDialog();
            this.maVatTutxt.Text = Program.maVatTudcChon;
            this.tenVatTutxt.Text = Program.tenVattudcChon;
            this.ghiCTDDHbtn.Enabled = true;
           
        }

        private void chonKhoHangBtn(object sender, EventArgs e)
        {
            frmChonKhohang frm = new frmChonKhohang();
            frm.ShowDialog();
            this.maKhotxt.Text = Program.maKhodcChon;
            if (this.loaithaotac==1)
            {
                //Hien Thi Cac Truong Lien Quan
                ngayTxt.Text = DateTime.Now.ToString("yyyy/MM/dd");
                maNVtxt.Text = Program.username;
                // Hien thi Form CTDDH 
                themCTDDHbtn.Enabled = phuchoiCTDDHbtn.Enabled = true;
                cTDDHGridControl.Enabled = true;
            }
            else if(this.loaithaotac==0)
            {
                //Hien thi cac button 
                suaCTDDHbtn.Enabled = true;
            }
          
        }
        public void AddNewtmpDataTable()
        {
            tempDataTable = new DataTable();
            tempDataTable.Columns.Add("MasoDDH", typeof(string));
            tempDataTable.Columns.Add("MAVT", typeof(string));
            tempDataTable.Columns.Add("SOLUONG", typeof(int));
            tempDataTable.Columns.Add("DONGIA", typeof(float));
        }
        private void addDatatoNewTmpDataTabletoUpdate()
        {
            AddNewtmpDataTable();
            // Get data from gridView2 and fill tempDataTable
            GridView gridView2 = (GridView)cTDDHGridControl.MainView;
            if (gridView2.RowCount != 0)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    DataRow gridRow = gridView2.GetDataRow(i);
                    DataRow newRow = tempDataTable.NewRow();
                    newRow["MasoDDH"] = gridRow["MasoDDH"];
                    newRow["MAVT"] = gridRow["MAVT"];
                    newRow["SOLUONG"] = gridRow["SOLUONG"];
                    newRow["DONGIA"] = gridRow["DONGIA"];
                    tempDataTable.Rows.Add(newRow);
                }
            }
            cTDDHGridControl.DataSource = this.tempDataTable;
        }
        private void ThembtnSub(object sender, EventArgs e)
        {
            if (nhaCCtxt.Text.Equals(""))
            {
                MessageBox.Show("Không được để trống nhà CC !,Vui lòng nhập ");
                groupBox2.Enabled = true;
                return;
            }
            else
            {
                groupBox3.Enabled = true;
                groupBox2.Enabled = false;

                suaCTDDHbtn.Enabled = false;
                ghiCTDDHbtn.Enabled = false;
                themCTDDHbtn.Enabled = false;
                xoaCTDDHbtn.Enabled = true;
                if (this.loaithaotac == 1)
                {
                    // Add columns to the temporary data table (assuming the same structure as the CTDDH table)
                    AddNewtmpDataTable();
                }
            }
        }

        private void ThemBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsDathang.AddNew();
            SuaBtn.Enabled = XoaBtn.Enabled = ThemBtn.Enabled = false;
            datHangGridControl.Enabled = false;
            groupBox2.Enabled = true;
            groupBox3.Enabled = false;
            cTDDHGridControl.DataSource = null;
            MaDontxt.Text = nhaCCtxt.Text = maKhotxt.Text = ngayTxt.Text = maNVtxt.Text = "";
            maVatTutxt.Text = tenVatTutxt.Text = soLuongtxt.Text = donGiatxt.Text = "";

            //Hole Position
            vitri = bdsDathang.Position;
            this.MaDontxt.Text = Program.ExecuteStoredProcedureFromMainSide("SP_GenerateMDDH");
            //this.MaDDHMoi= Program.ExecuteStoredProcedureFromMainSide("SP_GenerateMDDH");
            //Reset  loai thao tac
            this.loaithaotac = 1;
        }
        private int CheckIfExistVTinTempTable(string maVT)
        {
            for (int i = 0; i < tempDataTable.Rows.Count; i++)
            {
                DataRow row = tempDataTable.Rows[i];
                if (row["MAVT"].ToString().Equals(maVT, StringComparison.OrdinalIgnoreCase))
                {
                    return i; // Return the index of the row where maVT is found
                }
            }
            return -1; // Return -1 if maVT is not found in any row
        }
        private int getSoluongTonVT(string maVT)
        {
            int soluongton = -1;
            //string query = "SP_GetSOLUONGTONByMAVT";
            //try
            //{
            //    if (Program.KetNoi() == 1)
            //    {
            //        SqlCommand cmd = new SqlCommand(query, Program.conn);
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@MAVT", maVT);

            //        SqlDataReader reader = cmd.ExecuteReader();
            //        if (reader.Read())
            //        {
            //            soluongton = reader.GetInt32(0);
            //        }
            //        reader.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi khi thực thi stored procedure lấy số lượng tồn. \n" + ex.Message, "", MessageBoxButtons.OK);
            //    return -1;
            //}

            return soluongton;
        }

        private void ghiCTDDHbtn_Click(object sender, EventArgs e)
        {
            if (tenVatTutxt.Text.Trim() == "" || maVatTutxt.Text.Trim() == ""|| soLuongtxt.Text.Trim() == ""|| donGiatxt.Text.Trim() == "")
            {
                MessageBox.Show("Không được để Trống các trường !"
                 , "", MessageBoxButtons.OK);
            }
            //else if (int.Parse(soLuongtxt.Text)>getSoluongTonVT(maVatTutxt.Text))
            //{
            //    MessageBox.Show("Số lượng hàng tồn vật tư không đủ ! Vui lòng nhập số lượng nhỏ hơn !"
            //    , "", MessageBoxButtons.OK);
            //}
            else
            {   
                //Add new CTDDDH
                if (this.loaithaotac == 1)
                {                  
                    DataRow newRow = tempDataTable.NewRow();
                    newRow["MasoDDH"] = MaDontxt.Text;
                    newRow["MAVT"] = maVatTutxt.Text;
                    newRow["SOLUONG"] = int.Parse(soLuongtxt.Text);
                    newRow["DONGIA"] = float.Parse(donGiatxt.Text);

                    tempDataTable.Rows.Add(newRow);
                    cTDDHGridControl.DataSource = tempDataTable;                     
                }
                //Update CTTDDH
                else if (this.loaithaotac==0)
                {
                    int tempIndex = CheckIfExistVTinTempTable(maVatTutxt.Text);
                    if (tempIndex != -1)
                    {
                        DataRow tmprow = tempDataTable.Rows[tempIndex];
                        tmprow["SOLUONG"] = int.Parse(soLuongtxt.Text);
                        tmprow["DONGIA"] = float.Parse(donGiatxt.Text);
                    }
                
                    else
                    {
                        DataRow newRow = tempDataTable.NewRow();
                        newRow["MasoDDH"] = MaDontxt.Text;
                        newRow["MAVT"] = maVatTutxt.Text;
                        newRow["SOLUONG"] = int.Parse(soLuongtxt.Text);
                        newRow["DONGIA"] = float.Parse(donGiatxt.Text);
                        tempDataTable.Rows.Add(newRow);
                    }
                    
                    cTDDHGridControl.DataSource = tempDataTable;

                }
                tenVatTutxt.Text = maVatTutxt.Text = String.Empty;
                soLuongtxt.Text = donGiatxt.Text = String.Empty;
            }
            ghiCTDDHbtn.Enabled = false;
            hoantatBtn.Enabled = true;
           
        }

        private void datHangBindingNavigatorSaveItem_Click_4(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsDathang.EndEdit();
            this.tableAdapterManager.UpdateAll(this.datHangDS);

        }
        private void updateSoluongTonVT(String maVT,int soluongton)
        {
            //try
            //{
            //    if (Program.KetNoi() == 1)
            //    {
            //        SqlCommand cmd = new SqlCommand("SP_UpdateSOLUONGTONVT", Program.conn);
            //        cmd.CommandType=CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@MAVT ", maVT);
            //        cmd.Parameters.AddWithValue("@SOLUONGTON", soluongton);
            //        cmd.ExecuteNonQuery();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi Update số lượng tồn. \n" + ex.Message + ""
            //      , "", MessageBoxButtons.OK);
            //    return;
            //}
      
        }
        private void HoantatBtn(object sender, EventArgs e)
        {
            //INSERT DATHANG
            if (this.loaithaotac == 1)
            {
                try
                {
                    //Generate maddh
                    String maddh = Program.ExecuteStoredProcedureFromMainSide("SP_GenerateMDDH");
                    
                    DataRowView newddhrow = (DataRowView)bdsDathang.AddNew();
                    newddhrow["masoddh"] = maddh;
                    newddhrow["ngay"] = DateTime.Today;
                    newddhrow["manv"] = Program.username;
                    newddhrow["nhacc"] = nhaCCtxt.Text;
                    newddhrow["makho"] = Program.maKhodcChon;
                    //bdsDathang.EndEdit();
                    datHangGridControl.RefreshDataSource();

                    datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                    datHangTableAdapter.Update(this.datHangDS.DatHang);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi Dat Hang. \n" + ex.Message + ""
                        , "", MessageBoxButtons.OK);
                    return;
                }
                //------------------------------------------------------------

                //ADD CTDDH
                if (Program.KetNoi() != 1)
                {
                    Program.conn.Open();
                }
                if (Program.KetNoi() == 1)
                {
                    try
                    {
                        foreach (DataRow row in tempDataTable.Rows)
                        {       
                            ////Update Soluongton
                            //int tmp = getSoluongTonVT(row["MAVT"].ToString());
                            //int soluongmoi=tmp - Convert.ToInt32(row["SOLUONG"]);
                            //updateSoluongTonVT(row["MAVT"].ToString(), soluongmoi);

                            //Action insert to CTDDH
                            SqlCommand cmd = new SqlCommand("SP_InsertCTDDH", Program.conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@MasoDDH ", MaDontxt.Text);
                            cmd.Parameters.AddWithValue("@MAVT", row["MAVT"]);
                            cmd.Parameters.AddWithValue("@SOLUONG ", row["SOLUONG"]);
                            cmd.Parameters.AddWithValue("@DONGIA ", row["DONGIA"]);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Ghi đơn hàng thành công.!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Program.conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi ghi CTDDH Dat Hang. \n" + ex.Message + ""
                            , "", MessageBoxButtons.OK);
                        return;
                    }
                }

            } 
            //UPDATE DATHANG
            else if (loaithaotac == 0)
            {
                //Update DonDatHang
                DataRowView currentRow = (DataRowView)bdsDathang.Current;
                //currentRow["NGAY"] = DateTime.Today;
                currentRow["NhaCC"] = nhaCCtxt.Text;
                currentRow["MAKHO"] = Program.maKhodcChon;

                // Commit the changes to the binding source
                bdsDathang.EndEdit();
                // Update the database
                datHangTableAdapter.Update(this.datHangDS.DatHang);
                //--------------------------------------------------------------       
                //Update CTDDH
            

                if (Program.KetNoi() == 1)
                {
                    try
                    {                 
                        foreach (DataRow row in tempDataTable.Rows)
                        {
                            //Update Soluongton in VATTU
                            //int tmp = getSoluongTonVT(row["MAVT"].ToString());
                            //int soluongmoi = tmp - Convert.ToInt32(row["SOLUONG"]);
                            //updateSoluongTonVT(row["MAVT"].ToString(), soluongmoi);
                            //Action to CTDDH
                            SqlCommand cmd = new SqlCommand("SP_UpdateCTDDH", Program.conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@MasoDDH ", this.MaDontxt.Text);
                            cmd.Parameters.AddWithValue("@MAVT", row["MAVT"]);
                            cmd.Parameters.AddWithValue("@SOLUONG ", row["SOLUONG"]);
                            cmd.Parameters.AddWithValue("@DONGIA ", row["DONGIA"]);
                            cmd.ExecuteNonQuery();
                        }
                        Program.conn.Close();                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi cập nhật Dat Hang ! \n" + ex.Message + ""
                            , "", MessageBoxButtons.OK);
                        return;
                    }
                    MessageBox.Show("Cập nhật đơn hàng thành công.!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.tempDataTable.Clear();
                tableAdapterManager.UpdateAll(datHangDS);
                datHangTableAdapter.Fill(this.datHangDS.DatHang);
                cTDDHTableAdapter.Fill(this.datHangDS.CTDDH);
                //Hole Connection String 
                datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
                UpdateAlltable();
            }

            // Set btn
            datHangGridControl.Enabled = true;
            groupBox3.Enabled = groupBox2.Enabled = false;
            themCTDDHbtn.Enabled = ghiCTDDHbtn.Enabled = suaCTDDHbtn.Enabled = false;
            xoaCTDDHbtn.Enabled = phuchoiCTDDHbtn.Enabled = false;
            hoantatBtn.Enabled = false;

            //Hold Connection String 
            datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            //Reset Type 
            this.loaithaotac = -1;
            //rest bdsCTDDH
            cTDDHGridControl.DataSource = bdsCTDDH;
            cTDDHTableAdapter.Fill(this.datHangDS.CTDDH);
        }
        private void UpdateAlltable()
        {
            try
            {
                var datHangTableAdapter = new DatHangDSTableAdapters.DatHangTableAdapter();
                var ctddhTableAdapter=new DatHangDSTableAdapters.CTDDHTableAdapter();

                datHangTableAdapter.Fill(datHangDS.DatHang);
                ctddhTableAdapter.Fill(datHangDS.CTDDH);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật DataSet: " + ex.Message);
            }
        }
        public void HandleRowSelection()
        {
            // Assuming gridView is your GridView instance
            gridView1.FocusedRowChanged += (sender, e) =>
            {
                // Get the selected row
                var selectedRow = ((GridView)sender).GetFocusedDataRow();

                // Perform actions based on the selected row
                if (selectedRow != null)
                {
                    // Example: Get the value of a specific column in the selected ro
                    var value = selectedRow["MasoDDH"];
                    // Example: Display the value in a message box
                    MessageBox.Show("Selected value: " + value);
                }
            };
        }

        private void SuaBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng cần chỉnh sửa.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                String tempMaNv="";
                if (bdsDathang.Current != null)
                {
                    // Get the current DataRowView from the binding source
                    DataRowView currentRowView = (DataRowView)bdsDathang.Current;

                    // Get the value of the "MANV" column
                    tempMaNv = currentRowView["MANV"].ToString();
                }
                if (!tempMaNv.Equals(Program.username))
                {
                    MessageBox.Show("Đơn hàng này không phải do bạn nhập!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    this.loaithaotac = 0;
                    datHangGridControl.Enabled = false;
                    groupBox2.Enabled = true;
                    ThemBtn.Enabled = SuaBtn.Enabled = GhiBtn.Enabled = XoaBtn.Enabled = PhuchoiBtn.Enabled = false;
                    reloadBtn.Enabled = ThoatBtn.Enabled = true;

                }
            }
        }
        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void suaCTDDHbtn_Click(object sender, EventArgs e)
        {
            ghiCTDDHbtn.Enabled = true;
            suaCTDDHbtn.Enabled = false;
            if (this.loaithaotac == 0)
            {
                groupBox2.Enabled = false;
                themCTDDHbtn.Enabled = false;
                cTDDHGridControl.Enabled = true;
                xoaCTDDHbtn.Enabled = true;

                this.tempDataTable=new DataTable();
                groupBox3.Enabled = true;
                cTDDHGridControl.Enabled = true;
                chonVatTubtn.Enabled = true;
                hoantatBtn.Enabled = true;
                //Copy data old data and ready addNew 
                addDatatoNewTmpDataTabletoUpdate();

            }
        }

        private void updateRowCTDDH_Click(object sender, EventArgs e)
        {          
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void XoaBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa đơn đặt hàng này không?", "Confirmation", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                if (checkifExistMaDDHinPhieuNhap())
                {
                    MessageBox.Show("Đơn hàng đã tồn tại trong phiếu nhập , không được xóa!");
                    return;
                }
                else
                {
                    //Action Delete
                    actionIncreateSoluongton();
                    MessageBox.Show("Đã xóa thành công!");
                }
                XoaBtn.Enabled = false;
            }

        }
        private Boolean checkifExistMaDDHinPhieuNhap()
        {
            String madon = MaDontxt.Text;
            Boolean result = false;
            if (madon.Equals(""))
            {
                MessageBox.Show("Mã đơn đặt hàng rỗng ,vui lòng chọn đơn cần xóa !");
            }
            else
            {
                try
                {
                    if (Program.KetNoi() == 1)
                    {
                        String query = "SP_CheckExistMasoDDHInPhieuNhap";
                        SqlCommand cmd = new SqlCommand(query, Program.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MasoDDH ", madon);

                        // Output parameter
                        SqlParameter existStatusParam = new SqlParameter("@ExistStatus", SqlDbType.Bit);
                        existStatusParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(existStatusParam);

                        // Open connection and execute command                      
                        cmd.ExecuteNonQuery();

                        // Retrieve output parameter value
                        bool existStatus = (bool)existStatusParam.Value;

                        return existStatus;
                    }

                }catch(Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi kiểm tra đơn hàng trong phiếu nhập: " + ex.Message);               
                }
            }
            return false;
        }
        private void actionIncreateSoluongton()
        {
            String masoDDH = MaDontxt.Text;
            ////GetChiTietDonHang
            //AddNewtmpDataTable();
            //// Get data from gridView2 and fill tempDataTable
            //GridView gridView2 = (GridView)cTDDHGridControl.MainView;
            //if (gridView2.RowCount != 0)
            //{
            //    for (int i = 0; i < gridView2.RowCount; i++)
            //    {
            //        DataRow gridRow = gridView2.GetDataRow(i);
            //        DataRow newRow = tempDataTable.NewRow();
            //        newRow["MasoDDH"] = gridRow["MasoDDH"];
            //        newRow["MAVT"] = gridRow["MAVT"];
            //        newRow["SOLUONG"] = gridRow["SOLUONG"];
            //        newRow["DONGIA"] = gridRow["DONGIA"];
            //        tempDataTable.Rows.Add(newRow);
            //    }
            //}
            ////Action With 
            //foreach(DataRow row in tempDataTable.Rows)
            //{
            //    try
            //    {
            //        //InCreateSoluongTon
            //        String maVT = row["MAVT"].ToString();
            //        int soluong = Convert.ToInt32(row["SOLUONG"]);

            //        SqlCommand cmd = new SqlCommand("SP_IncreaseSOLUONGTON", Program.conn);
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@MAVT", maVT);
            //        cmd.Parameters.AddWithValue("@IncreaseAmount  ", soluong);
            //        cmd.ExecuteNonQuery();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(" Lỗi action số lương!",ex.Message);
            //        return;
            //    }

            //}
            try
            {
                //ActionXoa CTDDH
                SqlCommand cmd1 = new SqlCommand("SP_DeleteCTDDH", Program.conn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@MasoDDH ", masoDDH);
                cmd1.ExecuteNonQuery();
                //Action Xoa Dathang
                SqlCommand cmd2 = new SqlCommand("SP_DeleteDatHangByMasoDDH", Program.conn);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@MasoDDH ", masoDDH);
                cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Lỗi action DeleteCTDDH !", ex.Message);
                return;

            }
            datHangTableAdapter.Fill(this.datHangDS.DatHang);
            cTDDHTableAdapter.Fill(this.datHangDS.CTDDH);
        }

        private void cTDDHGridControl_Click(object sender, EventArgs e)
        {

        }

        private void xoaCTDDHbtn_Click(object sender, EventArgs e)
        {
            GridView gridView = cTDDHGridControl.MainView as GridView;
            if (gridView != null)
            {
                DataRow selectedRow = gridView.GetFocusedDataRow();
                String mavt= selectedRow["MAVT"].ToString();
                foreach(DataRow row in tempDataTable.Rows)
                {
                    if (row["MAVT"].ToString().Equals(mavt))
                    {
                        
                        String Masoddh = row["MasoDDH"].ToString();
                        try
                        {
                            if (Program.KetNoi() == 1)
                            {
                                String query = "DELETE FROM LINK0.QLVT_DATHANG.dbo.CTDDH WHERE MasoDDH = @MasoDDH AND MAVT=@MAVT";
                                SqlCommand cmd = new SqlCommand(query, Program.conn);
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@MasoDDH", Masoddh);
                                cmd.Parameters.AddWithValue("@MAVT", mavt);
                                if (cmd.ExecuteNonQuery() > 0)
                                {
                                    row.Delete();
                                    tempDataTable.AcceptChanges();
                                    cTDDHGridControl.RefreshDataSource();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi xóa dòng CTDDH.\n" + ex.Message + ""
                        , "", MessageBoxButtons.OK);
                            return;
                        }
                        break; // Exit the loop once the row is found and deleted

                    }
                }
               

            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng CTDDH cần xóa!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
