namespace QuanLyVatTu
{
    partial class Frpt_PhieuNvLapTrongNamTheoLoai
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
            System.Windows.Forms.Label hOTENLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.cmbChiNhanhMain = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bdsHoTenNV = new System.Windows.Forms.BindingSource(this.components);
            this.nhanVienDS = new QuanLyVatTu.NhanVienDS();
            this.hoTenNVTableAdapter = new QuanLyVatTu.NhanVienDSTableAdapters.HoTenNVTableAdapter();
            this.tableAdapterManager = new QuanLyVatTu.NhanVienDSTableAdapters.TableAdapterManager();
            this.cmbLoai = new System.Windows.Forms.ComboBox();
            this.cmbNam = new System.Windows.Forms.ComboBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.cmbHoTen = new System.Windows.Forms.ComboBox();
            hOTENLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bdsHoTenNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienDS)).BeginInit();
            this.SuspendLayout();
            // 
            // hOTENLabel
            // 
            hOTENLabel.AutoSize = true;
            hOTENLabel.Location = new System.Drawing.Point(41, 178);
            hOTENLabel.Name = "hOTENLabel";
            hOTENLabel.Size = new System.Drawing.Size(62, 22);
            hOTENLabel.TabIndex = 12;
            hOTENLabel.Text = "Họ tên";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(41, 251);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(46, 22);
            label1.TabIndex = 16;
            label1.Text = "Loại";
            label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(41, 312);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(47, 22);
            label2.TabIndex = 17;
            label2.Text = "Năm";
            label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cmbChiNhanhMain
            // 
            this.cmbChiNhanhMain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChiNhanhMain.Enabled = false;
            this.cmbChiNhanhMain.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cmbChiNhanhMain.FormattingEnabled = true;
            this.cmbChiNhanhMain.Location = new System.Drawing.Point(176, 50);
            this.cmbChiNhanhMain.Margin = new System.Windows.Forms.Padding(4);
            this.cmbChiNhanhMain.Name = "cmbChiNhanhMain";
            this.cmbChiNhanhMain.Size = new System.Drawing.Size(534, 30);
            this.cmbChiNhanhMain.TabIndex = 11;
            this.cmbChiNhanhMain.SelectedIndexChanged += new System.EventHandler(this.cmbChiNhanhMain_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(41, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 22);
            this.label3.TabIndex = 10;
            this.label3.Text = "Chi nhánh";
            // 
            // bdsHoTenNV
            // 
            this.bdsHoTenNV.DataMember = "HoTenNV";
            this.bdsHoTenNV.DataSource = this.nhanVienDS;
            this.bdsHoTenNV.CurrentChanged += new System.EventHandler(this.hoTenNVBindingSource_CurrentChanged);
            // 
            // nhanVienDS
            // 
            this.nhanVienDS.DataSetName = "NhanVienDS";
            this.nhanVienDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hoTenNVTableAdapter
            // 
            this.hoTenNVTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.CTPNTableAdapter = null;
            this.tableAdapterManager.CTPXTableAdapter = null;
            this.tableAdapterManager.DatHangTableAdapter = null;
            this.tableAdapterManager.NhanVienTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = QuanLyVatTu.NhanVienDSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // cmbLoai
            // 
            this.cmbLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoai.FormattingEnabled = true;
            this.cmbLoai.Items.AddRange(new object[] {
            "Nhập",
            "Xuất"});
            this.cmbLoai.Location = new System.Drawing.Point(176, 248);
            this.cmbLoai.Name = "cmbLoai";
            this.cmbLoai.Size = new System.Drawing.Size(197, 30);
            this.cmbLoai.TabIndex = 14;
            // 
            // cmbNam
            // 
            this.cmbNam.FormattingEnabled = true;
            this.cmbNam.Items.AddRange(new object[] {
            "2015",
            "2016",
            "2017",
            "2018",
            "2019"});
            this.cmbNam.Location = new System.Drawing.Point(177, 309);
            this.cmbNam.Name = "cmbNam";
            this.cmbNam.Size = new System.Drawing.Size(196, 30);
            this.cmbNam.TabIndex = 15;
            this.cmbNam.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(176, 390);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(197, 38);
            this.btnPreview.TabIndex = 18;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // cmbHoTen
            // 
            this.cmbHoTen.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsHoTenNV, "HOTEN", true));
            this.cmbHoTen.DataSource = this.bdsHoTenNV;
            this.cmbHoTen.DisplayMember = "HOTEN";
            this.cmbHoTen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHoTen.FormattingEnabled = true;
            this.cmbHoTen.Location = new System.Drawing.Point(177, 178);
            this.cmbHoTen.Name = "cmbHoTen";
            this.cmbHoTen.Size = new System.Drawing.Size(534, 30);
            this.cmbHoTen.TabIndex = 19;
            this.cmbHoTen.ValueMember = "MANV";
            this.cmbHoTen.SelectedIndexChanged += new System.EventHandler(this.cmbHoTen_SelectedIndexChanged_1);
            // 
            // Frpt_PhieuNvLapTrongNamTheoLoai
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 538);
            this.Controls.Add(this.cmbHoTen);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(this.cmbNam);
            this.Controls.Add(this.cmbLoai);
            this.Controls.Add(hOTENLabel);
            this.Controls.Add(this.cmbChiNhanhMain);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Frpt_PhieuNvLapTrongNamTheoLoai";
            this.Text = "Frpt_PhieuNvLapTrongNamTheoLoai";
            this.Load += new System.EventHandler(this.Frpt_PhieuNvLapTrongNamTheoLoai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bdsHoTenNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbChiNhanhMain;
        private System.Windows.Forms.Label label3;
        private NhanVienDS nhanVienDS;
        private System.Windows.Forms.BindingSource bdsHoTenNV;
        private NhanVienDSTableAdapters.HoTenNVTableAdapter hoTenNVTableAdapter;
        private NhanVienDSTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ComboBox cmbLoai;
        private System.Windows.Forms.ComboBox cmbNam;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.ComboBox cmbHoTen;
    }
}