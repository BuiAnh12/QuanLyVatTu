namespace QuanLyVatTu.SubForm
{
    partial class frmChonKhohang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.khoGridControl = new DevExpress.XtraGrid.GridControl();
            this.bdsKho = new System.Windows.Forms.BindingSource(this.components);
            this.khoDS = new QuanLyVatTu.KhoDS();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAKHO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENKHO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIACHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMACN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.khoTableAdapter = new QuanLyVatTu.KhoDSTableAdapters.KhoTableAdapter();
            this.tableAdapterManager = new QuanLyVatTu.KhoDSTableAdapters.TableAdapterManager();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.CbChiNhanh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.khoGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khoDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.khoGridControl);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(589, 306);
            this.panelControl1.TabIndex = 0;
            // 
            // khoGridControl
            // 
            this.khoGridControl.DataSource = this.bdsKho;
            this.khoGridControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.khoGridControl.Location = new System.Drawing.Point(2, 2);
            this.khoGridControl.MainView = this.gridView1;
            this.khoGridControl.Name = "khoGridControl";
            this.khoGridControl.Size = new System.Drawing.Size(585, 227);
            this.khoGridControl.TabIndex = 0;
            this.khoGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // bdsKho
            // 
            this.bdsKho.DataMember = "Kho";
            this.bdsKho.DataSource = this.khoDS;
            // 
            // khoDS
            // 
            this.khoDS.DataSetName = "KhoDS";
            this.khoDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAKHO,
            this.colTENKHO,
            this.colDIACHI,
            this.colMACN});
            this.gridView1.GridControl = this.khoGridControl;
            this.gridView1.Name = "gridView1";
            // 
            // colMAKHO
            // 
            this.colMAKHO.FieldName = "MAKHO";
            this.colMAKHO.Name = "colMAKHO";
            this.colMAKHO.Visible = true;
            this.colMAKHO.VisibleIndex = 0;
            // 
            // colTENKHO
            // 
            this.colTENKHO.FieldName = "TENKHO";
            this.colTENKHO.Name = "colTENKHO";
            this.colTENKHO.Visible = true;
            this.colTENKHO.VisibleIndex = 1;
            // 
            // colDIACHI
            // 
            this.colDIACHI.FieldName = "DIACHI";
            this.colDIACHI.Name = "colDIACHI";
            this.colDIACHI.Visible = true;
            this.colDIACHI.VisibleIndex = 2;
            // 
            // colMACN
            // 
            this.colMACN.FieldName = "MACN";
            this.colMACN.Name = "colMACN";
            this.colMACN.Visible = true;
            this.colMACN.VisibleIndex = 3;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(164, 292);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(93, 35);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "OK";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click_1);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new System.Drawing.Point(340, 292);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(88, 35);
            this.simpleButton2.TabIndex = 3;
            this.simpleButton2.Text = "CANCEL";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // khoTableAdapter
            // 
            this.khoTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.DatHangTableAdapter = null;
            this.tableAdapterManager.KhoTableAdapter = this.khoTableAdapter;
            this.tableAdapterManager.UpdateOrder = QuanLyVatTu.KhoDSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.CbChiNhanh);
            this.panelControl2.Controls.Add(this.label1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(589, 50);
            this.panelControl2.TabIndex = 5;
            // 
            // CbChiNhanh
            // 
            this.CbChiNhanh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbChiNhanh.FormattingEnabled = true;
            this.CbChiNhanh.Location = new System.Drawing.Point(131, 9);
            this.CbChiNhanh.Name = "CbChiNhanh";
            this.CbChiNhanh.Size = new System.Drawing.Size(246, 27);
            this.CbChiNhanh.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chi Nhánh";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmChonKhohang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 351);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmChonKhohang";
            this.Text = "frmChoKhohang";
            this.Load += new System.EventHandler(this.frmChoKhohang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.khoGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.khoDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private KhoDS khoDS;
        private System.Windows.Forms.BindingSource bdsKho;
        private KhoDSTableAdapters.KhoTableAdapter khoTableAdapter;
        private KhoDSTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl khoGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMAKHO;
        private DevExpress.XtraGrid.Columns.GridColumn colTENKHO;
        private DevExpress.XtraGrid.Columns.GridColumn colDIACHI;
        private DevExpress.XtraGrid.Columns.GridColumn colMACN;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.ComboBox CbChiNhanh;
        private System.Windows.Forms.Label label1;
    }
}