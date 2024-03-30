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

namespace NGANHANG
{
    public partial class frmChuyenChiNhanh : DevExpress.XtraEditors.XtraForm
    {
        public frmChuyenChiNhanh()
        {
            InitializeComponent();
        }

        private void cmbCHINHANH_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCHINHANH.DataSource = Program.bindingSource.DataSource;
            /*sao chep bingding source tu form dang nhap*/
            cmbCHINHANH.DisplayMember = "tencn";
            cmbCHINHANH.ValueMember = "tenserver";
            cmbCHINHANH.SelectedIndex = Program.mCN;
        }
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }
        public delegate void Mini_Func(string chiNhanh);
        public Mini_Func Mini_chuyenCN;
        private void btnTHOAT_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnXACNHAN_Click(object sender, EventArgs e)
        {
            if (cmbCHINHANH.Text.Trim().Equals(""))
            {
                MessageBox.Show("Vui lòng chọn chi nhánh", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            /*Step 2*/
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn chuyển nhân viên này đi ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.OK)
            {
                Mini_chuyenCN(cmbCHINHANH.SelectedValue.ToString());
            }

            this.Dispose();
        }
    }
}