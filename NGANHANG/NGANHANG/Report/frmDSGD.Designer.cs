
namespace NGANHANG.Report
{
    partial class frmDSGD
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
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.sP_SaoKeTaiKhoanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ds = new NGANHANG.DS();
            this.txtSoTK = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ngayKetThuc = new DevExpress.XtraEditors.DateEdit();
            this.ngayBatDau = new DevExpress.XtraEditors.DateEdit();
            this.tableAdapterManager = new NGANHANG.DSTableAdapters.TableAdapterManager();
            this.sP_SaoKeTaiKhoanTableAdapter = new NGANHANG.DSTableAdapters.SP_SaoKeTaiKhoanTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sP_SaoKeTaiKhoanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngayKetThuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngayKetThuc.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngayBatDau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngayBatDau.Properties.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.txtSoTK);
            this.groupControl2.Controls.Add(this.label1);
            this.groupControl2.Controls.Add(this.cmbBrand);
            this.groupControl2.Controls.Add(this.label4);
            this.groupControl2.Controls.Add(this.btnThoat);
            this.groupControl2.Controls.Add(this.btnXem);
            this.groupControl2.Controls.Add(this.label3);
            this.groupControl2.Controls.Add(this.label2);
            this.groupControl2.Controls.Add(this.ngayKetThuc);
            this.groupControl2.Controls.Add(this.ngayBatDau);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(5);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(1683, 1044);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "groupControl2";
            // 
            // sP_SaoKeTaiKhoanBindingSource
            // 
            this.sP_SaoKeTaiKhoanBindingSource.DataMember = "SP_SaoKeTaiKhoan";
            this.sP_SaoKeTaiKhoanBindingSource.DataSource = this.ds;
            // 
            // ds
            // 
            this.ds.DataSetName = "DS";
            this.ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtSoTK
            // 
            this.txtSoTK.Location = new System.Drawing.Point(240, 394);
            this.txtSoTK.Name = "txtSoTK";
            this.txtSoTK.Size = new System.Drawing.Size(483, 33);
            this.txtSoTK.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 25);
            this.label1.TabIndex = 21;
            this.label1.Text = "Chi Nhánh:";
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(240, 110);
            this.cmbBrand.Margin = new System.Windows.Forms.Padding(5);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(481, 33);
            this.cmbBrand.TabIndex = 20;
            this.cmbBrand.SelectedIndexChanged += new System.EventHandler(this.cmbChiNhanh_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 402);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 25);
            this.label4.TabIndex = 19;
            this.label4.Text = "Số Tài Khoản:";
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(581, 513);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(5);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(176, 76);
            this.btnThoat.TabIndex = 17;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(195, 513);
            this.btnXem.Margin = new System.Windows.Forms.Padding(5);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(176, 76);
            this.btnXem.TabIndex = 15;
            this.btnXem.Text = "Xuất File";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 256);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "Đến Ngày:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 154);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "Từ Ngày:";
            // 
            // ngayKetThuc
            // 
            this.ngayKetThuc.EditValue = new System.DateTime(2023, 8, 17, 0, 0, 0, 0);
            this.ngayKetThuc.Location = new System.Drawing.Point(240, 292);
            this.ngayKetThuc.Margin = new System.Windows.Forms.Padding(5);
            this.ngayKetThuc.Name = "ngayKetThuc";
            this.ngayKetThuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ngayKetThuc.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ngayKetThuc.Size = new System.Drawing.Size(483, 40);
            this.ngayKetThuc.TabIndex = 11;
            this.ngayKetThuc.EditValueChanged += new System.EventHandler(this.ngayKetThuc_EditValueChanged);
            // 
            // ngayBatDau
            // 
            this.ngayBatDau.EditValue = new System.DateTime(2023, 8, 17, 0, 0, 0, 0);
            this.ngayBatDau.Location = new System.Drawing.Point(240, 189);
            this.ngayBatDau.Margin = new System.Windows.Forms.Padding(5);
            this.ngayBatDau.Name = "ngayBatDau";
            this.ngayBatDau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ngayBatDau.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ngayBatDau.Size = new System.Drawing.Size(483, 40);
            this.ngayBatDau.TabIndex = 10;
            this.ngayBatDau.EditValueChanged += new System.EventHandler(this.ngayBatDau_EditValueChanged);
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ChiNhanhTableAdapter = null;
            this.tableAdapterManager.GD_CHUYENTIENTableAdapter = null;
            this.tableAdapterManager.GD_GOIRUTTableAdapter = null;
            this.tableAdapterManager.KhachHangTableAdapter = null;
            this.tableAdapterManager.NhanVienTableAdapter = null;
            this.tableAdapterManager.SP_DanhSachKhachHangTableAdapter = null;
            this.tableAdapterManager.SP_GiaoDichChuyenTienTableAdapter = null;
            this.tableAdapterManager.SP_GiaoDichGuiRutTableAdapter = null;
            this.tableAdapterManager.SP_KiemTraTonTaiSTKTableAdapter = null;
            this.tableAdapterManager.SP_SaoKeTaiKhoanTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = NGANHANG.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // sP_SaoKeTaiKhoanTableAdapter
            // 
            this.sP_SaoKeTaiKhoanTableAdapter.ClearBeforeFill = true;
            // 
            // frmDSGD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1758, 1044);
            this.Controls.Add(this.groupControl2);
            this.Name = "frmDSGD";
            this.Load += new System.EventHandler(this.frmSaoKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sP_SaoKeTaiKhoanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngayKetThuc.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngayKetThuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngayBatDau.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngayBatDau.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.DateEdit ngayKetThuc;
        private DevExpress.XtraEditors.DateEdit ngayBatDau;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBrand;
        private DS ds;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private DSTableAdapters.SP_SaoKeTaiKhoanTableAdapter sP_SaoKeTaiKhoanTableAdapter;
        private System.Windows.Forms.TextBox txtSoTK;
        private System.Windows.Forms.BindingSource sP_SaoKeTaiKhoanBindingSource;
    }
}