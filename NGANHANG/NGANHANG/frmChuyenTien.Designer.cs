
namespace NGANHANG
{
    partial class frmChuyenTien
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSoTKChuyen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSoTKNhan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelChuyenTien = new DevExpress.XtraEditors.PanelControl();
            this.txtSoDu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnKiemTra = new System.Windows.Forms.Button();
            this.gD_CHUYENTIENTableAdapter1 = new NGANHANG.DSTableAdapters.GD_CHUYENTIENTableAdapter();
            this.ds = new NGANHANG.DS();
            this.gD_CHUYENTIENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableAdapterManager = new NGANHANG.DSTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelChuyenTien)).BeginInit();
            this.panelChuyenTien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD_CHUYENTIENBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(561, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 55);
            this.label1.TabIndex = 5;
            this.label1.Text = "Chuyển Tiền";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(323, 121);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 25);
            this.label2.TabIndex = 18;
            this.label2.Text = "Số Tài Khoản Chuyển:";
            // 
            // txtSoTKChuyen
            // 
            this.txtSoTKChuyen.Location = new System.Drawing.Point(641, 113);
            this.txtSoTKChuyen.Margin = new System.Windows.Forms.Padding(5);
            this.txtSoTKChuyen.Name = "txtSoTKChuyen";
            this.txtSoTKChuyen.Size = new System.Drawing.Size(514, 33);
            this.txtSoTKChuyen.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(392, 380);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 25);
            this.label3.TabIndex = 20;
            this.label3.Text = "Số Tài Khoản Nhận:";
            // 
            // txtSoTKNhan
            // 
            this.txtSoTKNhan.Location = new System.Drawing.Point(762, 380);
            this.txtSoTKNhan.Margin = new System.Windows.Forms.Padding(5);
            this.txtSoTKNhan.Name = "txtSoTKNhan";
            this.txtSoTKNhan.Size = new System.Drawing.Size(514, 33);
            this.txtSoTKNhan.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(392, 456);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 25);
            this.label4.TabIndex = 22;
            this.label4.Text = "Số Tiền:";
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(762, 456);
            this.txtSoTien.Margin = new System.Windows.Forms.Padding(5);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(514, 33);
            this.txtSoTien.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(392, 547);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(218, 25);
            this.label7.TabIndex = 24;
            this.label7.Text = "Họ và Tên Nhân Viên:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(762, 539);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(5);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(514, 33);
            this.txtHoTen.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(392, 637);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 25);
            this.label5.TabIndex = 26;
            this.label5.Text = "Mã Nhân Viên:";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(762, 629);
            this.txtMaNV.Margin = new System.Windows.Forms.Padding(5);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.ReadOnly = true;
            this.txtMaNV.Size = new System.Drawing.Size(514, 33);
            this.txtMaNV.TabIndex = 27;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(437, 443);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(5);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(190, 66);
            this.btnXacNhan.TabIndex = 28;
            this.btnXacNhan.Text = "Xác Nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.Location = new System.Drawing.Point(918, 443);
            this.btnHuyBo.Margin = new System.Windows.Forms.Padding(5);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(190, 66);
            this.btnHuyBo.TabIndex = 29;
            this.btnHuyBo.Text = "Hủy Bỏ";
            this.btnHuyBo.UseVisualStyleBackColor = true;
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThoat});
            this.barManager1.MaxItemId = 1;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnThoat)});
            this.bar1.Text = "Tools";
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 0;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1793, 38);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 1062);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1793, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 38);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 1024);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1793, 38);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 1024);
            // 
            // panelChuyenTien
            // 
            this.panelChuyenTien.Controls.Add(this.btnXacNhan);
            this.panelChuyenTien.Controls.Add(this.btnHuyBo);
            this.panelChuyenTien.Controls.Add(this.label1);
            this.panelChuyenTien.Location = new System.Drawing.Point(204, 283);
            this.panelChuyenTien.Name = "panelChuyenTien";
            this.panelChuyenTien.Size = new System.Drawing.Size(1389, 579);
            this.panelChuyenTien.TabIndex = 39;
            // 
            // txtSoDu
            // 
            this.txtSoDu.Location = new System.Drawing.Point(641, 185);
            this.txtSoDu.Margin = new System.Windows.Forms.Padding(5);
            this.txtSoDu.Name = "txtSoDu";
            this.txtSoDu.ReadOnly = true;
            this.txtSoDu.Size = new System.Drawing.Size(514, 33);
            this.txtSoDu.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(323, 193);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 25);
            this.label6.TabIndex = 41;
            this.label6.Text = "Số dư:";
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.Location = new System.Drawing.Point(1244, 95);
            this.btnKiemTra.Margin = new System.Windows.Forms.Padding(5);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(190, 66);
            this.btnKiemTra.TabIndex = 30;
            this.btnKiemTra.Text = "Kiểm tra";
            this.btnKiemTra.UseVisualStyleBackColor = true;
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
            // 
            // gD_CHUYENTIENTableAdapter1
            // 
            this.gD_CHUYENTIENTableAdapter1.ClearBeforeFill = true;
            // 
            // ds
            // 
            this.ds.DataSetName = "DS";
            this.ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gD_CHUYENTIENBindingSource
            // 
            this.gD_CHUYENTIENBindingSource.DataMember = "GD_CHUYENTIEN";
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ChiNhanhTableAdapter = null;
            this.tableAdapterManager.GD_CHUYENTIENTableAdapter = this.gD_CHUYENTIENTableAdapter1;
            this.tableAdapterManager.GD_GOIRUTTableAdapter = null;
            this.tableAdapterManager.KhachHangTableAdapter = null;
            this.tableAdapterManager.NhanVienTableAdapter = null;
            this.tableAdapterManager.SP_DanhSachKhachHangTableAdapter = null;
            this.tableAdapterManager.SP_GiaoDichChuyenTienTableAdapter = null;
            this.tableAdapterManager.SP_GiaoDichGuiRutTableAdapter = null;
            this.tableAdapterManager.SP_KiemTraTonTaiSTKTableAdapter = null;
            this.tableAdapterManager.SP_SaoKeTaiKhoanTableAdapter = null;
            this.tableAdapterManager.TaiKhoanTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = NGANHANG.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // frmChuyenTien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1793, 1062);
            this.Controls.Add(this.btnKiemTra);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSoDu);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSoTien);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSoTKNhan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSoTKChuyen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelChuyenTien);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmChuyenTien";
            this.Text = "frmChuyenTien";
            this.Load += new System.EventHandler(this.frmChuyenTien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelChuyenTien)).EndInit();
            this.panelChuyenTien.ResumeLayout(false);
            this.panelChuyenTien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD_CHUYENTIENBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSoTKChuyen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSoTKNhan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuyBo;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.Button btnKiemTra;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSoDu;
        private DevExpress.XtraEditors.PanelControl panelChuyenTien;
        private DSTableAdapters.GD_CHUYENTIENTableAdapter gD_CHUYENTIENTableAdapter1;
        private DS ds;
        private System.Windows.Forms.BindingSource gD_CHUYENTIENBindingSource;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
    }
}