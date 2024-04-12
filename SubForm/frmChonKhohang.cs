using DevExpress.Sparkline.Core;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyVatTu.SubForm
{
    public partial class frmChonKhohang : DevExpress.XtraEditors.XtraForm
    {
        int index = 0;
        public frmChonKhohang()
        {
            InitializeComponent();
            CbChiNhanh.DataSource = Program.bds_dspm;
            CbChiNhanh.DisplayMember = "TENCN";
            CbChiNhanh.ValueMember = "TENSERVER";
            CbChiNhanh.SelectedIndex = Program.mChinhanh;
            this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khoTableAdapter.Fill(this.khoDS.Kho);
            CbChiNhanh.Enabled = false;
        }

        private void khoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKho.EndEdit();
            this.tableAdapterManager.UpdateAll(this.khoDS);

        }

        private void frmChoKhohang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'khoDS.Kho' table. You can move, or remove it, as needed.
            this.khoTableAdapter.Fill(this.khoDS.Kho);

        }

       
  
        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
           index= bdsKho.Position;
           DataRowView currentDataRowView = (DataRowView)bdsKho.Current;
            if (currentDataRowView != null)
            {
               Program.maKhodcChon= currentDataRowView["MAKHO"].ToString();
            }
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Program.maKhodcChon = "";
            this.Close();
        }
    }
}