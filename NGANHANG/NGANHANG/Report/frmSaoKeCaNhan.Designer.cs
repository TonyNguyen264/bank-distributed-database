
namespace NGANHANG.Report
{
    partial class frmSaoKeCaNhan
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
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ngayKetThuc = new DevExpress.XtraEditors.DateEdit();
            this.ngayBatDau = new DevExpress.XtraEditors.DateEdit();
            this.cmbSTK = new DevExpress.XtraEditors.DateEdit();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ngayKetThuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngayKetThuc.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngayBatDau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngayBatDau.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSTK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSTK.Properties.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(441, 147);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 25);
            this.label1.TabIndex = 31;
            this.label1.Text = "Chi Nhánh:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(441, 433);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 25);
            this.label4.TabIndex = 29;
            this.label4.Text = "Số Tài Khoản:";
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(993, 552);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(5);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(176, 76);
            this.btnThoat.TabIndex = 28;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(607, 552);
            this.btnXem.Margin = new System.Windows.Forms.Padding(5);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(176, 76);
            this.btnXem.TabIndex = 27;
            this.btnXem.Text = "Xuất File";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(441, 337);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 25);
            this.label3.TabIndex = 26;
            this.label3.Text = "Đến Ngày:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(441, 234);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 25);
            this.label2.TabIndex = 25;
            this.label2.Text = "Từ Ngày:";
            // 
            // ngayKetThuc
            // 
            this.ngayKetThuc.EditValue = null;
            this.ngayKetThuc.Location = new System.Drawing.Point(652, 331);
            this.ngayKetThuc.Margin = new System.Windows.Forms.Padding(5);
            this.ngayKetThuc.Name = "ngayKetThuc";
            this.ngayKetThuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ngayKetThuc.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ngayKetThuc.Size = new System.Drawing.Size(483, 40);
            this.ngayKetThuc.TabIndex = 24;
            this.ngayKetThuc.EditValueChanged += new System.EventHandler(this.ngayKetThuc_EditValueChanged);
            // 
            // ngayBatDau
            // 
            this.ngayBatDau.EditValue = null;
            this.ngayBatDau.Location = new System.Drawing.Point(652, 228);
            this.ngayBatDau.Margin = new System.Windows.Forms.Padding(5);
            this.ngayBatDau.Name = "ngayBatDau";
            this.ngayBatDau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ngayBatDau.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ngayBatDau.Size = new System.Drawing.Size(483, 40);
            this.ngayBatDau.TabIndex = 23;
            this.ngayBatDau.EditValueChanged += new System.EventHandler(this.ngayBatDau_EditValueChanged);
            // 
            // cmbSTK
            // 
            this.cmbSTK.EditValue = null;
            this.cmbSTK.Location = new System.Drawing.Point(652, 427);
            this.cmbSTK.Margin = new System.Windows.Forms.Padding(5);
            this.cmbSTK.Name = "cmbSTK";
            this.cmbSTK.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSTK.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSTK.Size = new System.Drawing.Size(483, 40);
            this.cmbSTK.TabIndex = 32;
         
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(652, 144);
            this.cmbBrand.Margin = new System.Windows.Forms.Padding(5);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(481, 33);
            this.cmbBrand.TabIndex = 33;
            this.cmbBrand.SelectedIndexChanged += new System.EventHandler(this.cmbBrand_SelectedIndexChanged);
            // 
            // frmSaoKeCaNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1701, 776);
            this.Controls.Add(this.cmbBrand);
            this.Controls.Add(this.cmbSTK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ngayKetThuc);
            this.Controls.Add(this.ngayBatDau);
            this.Name = "frmSaoKeCaNhan";
            this.Text = "frmSaoKeCaNhan";
            this.Load += new System.EventHandler(this.frmSaoKeCaNhan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ngayKetThuc.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngayKetThuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngayBatDau.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngayBatDau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSTK.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSTK.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.DateEdit ngayKetThuc;
        private DevExpress.XtraEditors.DateEdit ngayBatDau;
        private DevExpress.XtraEditors.DateEdit cmbSTK;
        private System.Windows.Forms.ComboBox cmbBrand;
    }
}