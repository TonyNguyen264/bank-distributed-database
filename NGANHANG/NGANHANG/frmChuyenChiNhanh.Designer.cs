
namespace NGANHANG
{
    partial class frmChuyenChiNhanh
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
            this.btnTHOAT = new System.Windows.Forms.Button();
            this.btnXACNHAN = new System.Windows.Forms.Button();
            this.cmbCHINHANH = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTHOAT
            // 
            this.btnTHOAT.BackColor = System.Drawing.Color.Red;
            this.btnTHOAT.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnTHOAT.ForeColor = System.Drawing.Color.White;
            this.btnTHOAT.Location = new System.Drawing.Point(408, 274);
            this.btnTHOAT.Margin = new System.Windows.Forms.Padding(4);
            this.btnTHOAT.Name = "btnTHOAT";
            this.btnTHOAT.Size = new System.Drawing.Size(175, 42);
            this.btnTHOAT.TabIndex = 10;
            this.btnTHOAT.Text = "THOÁT";
            this.btnTHOAT.UseVisualStyleBackColor = false;
            this.btnTHOAT.Click += new System.EventHandler(this.btnTHOAT_Click);
            // 
            // btnXACNHAN
            // 
            this.btnXACNHAN.BackColor = System.Drawing.Color.Blue;
            this.btnXACNHAN.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnXACNHAN.ForeColor = System.Drawing.Color.White;
            this.btnXACNHAN.Location = new System.Drawing.Point(205, 274);
            this.btnXACNHAN.Margin = new System.Windows.Forms.Padding(4);
            this.btnXACNHAN.Name = "btnXACNHAN";
            this.btnXACNHAN.Size = new System.Drawing.Size(175, 42);
            this.btnXACNHAN.TabIndex = 9;
            this.btnXACNHAN.Text = "XÁC NHẬN";
            this.btnXACNHAN.UseVisualStyleBackColor = false;
            this.btnXACNHAN.Click += new System.EventHandler(this.btnXACNHAN_Click);
            // 
            // cmbCHINHANH
            // 
            this.cmbCHINHANH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCHINHANH.FormattingEnabled = true;
            this.cmbCHINHANH.Location = new System.Drawing.Point(205, 177);
            this.cmbCHINHANH.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCHINHANH.Name = "cmbCHINHANH";
            this.cmbCHINHANH.Size = new System.Drawing.Size(377, 27);
            this.cmbCHINHANH.TabIndex = 8;
            this.cmbCHINHANH.SelectedIndexChanged += new System.EventHandler(this.cmbCHINHANH_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(198, 94);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 39);
            this.label1.TabIndex = 7;
            this.label1.Text = "CHUYỂN CHI NHÁNH";
            // 
            // frmChuyenChiNhanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 411);
            this.Controls.Add(this.btnTHOAT);
            this.Controls.Add(this.btnXACNHAN);
            this.Controls.Add(this.cmbCHINHANH);
            this.Controls.Add(this.label1);
            this.Name = "frmChuyenChiNhanh";
            this.Text = "frmChuyenChiNhanh";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTHOAT;
        private System.Windows.Forms.Button btnXACNHAN;
        private System.Windows.Forms.ComboBox cmbCHINHANH;
        private System.Windows.Forms.Label label1;
    }
}