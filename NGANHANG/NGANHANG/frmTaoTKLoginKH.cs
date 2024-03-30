using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NGANHANG
{
    public partial class frmTaoTKLoginKH : DevExpress.XtraEditors.XtraForm
    {

        String nLogin = "";
        String nPass = "";
        // String nUserName = "";
        String nRole = "";
        public frmTaoTKLoginKH()
        {
            InitializeComponent();
        }

      
        private bool kiemTraDuLieuDauVao()
        {
    
            if (txtTK.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tài khoản", "Thông báo !", MessageBoxButtons.OK);
                txtTK.Focus();
                return false;
            }
            else if (txtMK.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo !", MessageBoxButtons.OK);
                txtMK.Focus();
                return false;
            }
            else if (txtNhapLai.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng xác nhận lại mật khẩu", "Thông báo !", MessageBoxButtons.OK);
                txtMK.Focus();
                return false;
            }
            else if (txtMK.Text.Trim() != txtNhapLai.Text.Trim())
            {
                MessageBox.Show("Mật khẩu và nhập lại mật khẩu chưa trùng khớp", "Thông báo !", MessageBoxButtons.OK);
                txtMK.Focus();
                return false;
            }
            else if (txtCMND.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn nhân viên", "Thông báo !", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void frmTaoTKLoginKH_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'dS.KhachHang' table. You can move, or remove it, as needed.
            this.khachHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khachHangTableAdapter.Fill(this.dS.KhachHang);

            cmbRole.Items.Add("KHACHHANG");
            txtCMND.ReadOnly = true;
            cmbRole.SelectedIndex = 0;
            cmbRole.Enabled = true;
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void khachHangGridControl_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = ((DataRowView)bdsKH[bdsKH.Position])["HO"].ToString().Trim() + " " + ((DataRowView)bdsKH[bdsKH.Position])["TEN"].ToString().Trim();
            txtCMND.Text = ((DataRowView)bdsKH[bdsKH.Position])["CMND"].ToString().Trim();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn thật sự muốn hủy thao tác đăng ký tài khoản?",
                    "Xác thực", MessageBoxButtons.YesNo);

            if (dr == DialogResult.No)
            {
                return;
            }
            else if (dr == DialogResult.Yes)
            {
                this.Close();

            }
        }

        private void checkedShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtMK.Properties.UseSystemPasswordChar = (checkedShowPass.Checked) ? false : true;
            txtNhapLai.Properties.UseSystemPasswordChar = (checkedShowPass.Checked) ? false : true;
        }

        private void khachHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKH.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            bool ketQua = kiemTraDuLieuDauVao();
            if (ketQua == false) return;

            nLogin = txtTK.Text.Trim();
            nPass = txtMK.Text.Trim();
            nRole = cmbRole.Text.Trim();
            String MaNV = txtCMND.Text.Trim();
            String cauTruyVan =
                   "EXEC sp_TaoLogKH '" + nLogin + "' , '" + nPass + "', '"
                   + MaNV + "', '" + nRole + "'";

            SqlCommand sqlCommand = new SqlCommand(cauTruyVan, Program.conn);
            try
            {


                Program.myReader = Program.ExecSqlDataReader(cauTruyVan);
                /*khong co ket qua tra ve thi ket thuc luon*/
                if (Program.myReader == null)
                {
                    return;
                }

                MessageBox.Show("Đăng kí tài khoản thành công\n\nTài khoản: " + nLogin + "\nMật khẩu: " + nPass + "\n Mã Nhân Viên: " + MaNV + "\n Vai Trò: " + nRole, "Thông Báo", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thực thi database thất bại!\n\n" + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}