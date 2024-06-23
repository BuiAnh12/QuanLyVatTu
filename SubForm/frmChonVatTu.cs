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
    public partial class frmChonVatTu : DevExpress.XtraEditors.XtraForm
    {
        public frmChonVatTu()
        {
            InitializeComponent();
        }

        private void vattuBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsVatTu.EndEdit();
            this.tableAdapterManager.UpdateAll(this.vatTuDS);

        }

        private void ChonVatTu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'vatTuDS.Vattu' table. You can move, or remove it, as needed.
            this.vattuTableAdapter.Fill(this.vatTuDS.Vattu);

        }

        private void vattuBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsVatTu.EndEdit();
            this.tableAdapterManager.UpdateAll(this.vatTuDS);

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataRowView currentDataRowView = (DataRowView)bdsVatTu.Current;
            if(currentDataRowView != null)
            {
                Program.maVatTudcChon = currentDataRowView["MAVT"].ToString();
                Program.tenVattudcChon = currentDataRowView["TENVT"].ToString();
                Program.soluongtonvattu = Convert.ToInt32(currentDataRowView["SOLUONGTON"]);

            }
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Program.maVatTudcChon = "";
            Program.tenVattudcChon = "";
            this.Close();
        }
    }
}