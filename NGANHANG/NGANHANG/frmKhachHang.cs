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
    public partial class frmKhachHang : DevExpress.XtraEditors.XtraForm

    {
        int vitriKH = 0;
        Boolean isEditingKH = false;
        String maCN;
        DateTime now = DateTime.Now;
        String CMND;
        Stack undoList = new Stack();

        public frmKhachHang()
        {
            InitializeComponent();
            if (Program.Role.Trim() == "NGANHANG")
            {
                BtnGhi.Enabled = false;
                BtnLamMoi.Enabled = false;
                BtnThem.Enabled = false;
                BtnHoanTac.Enabled = false;
                BtnXoa.Enabled = false;
                txtMaCN.ReadOnly = true;
                txtDiaChi.ReadOnly = true;
                txtHo.ReadOnly = true;
                txtCMND.ReadOnly = true;
                txtSoDT.ReadOnly = true;
                txtTen.ReadOnly = true;
                dateNgayCap.ReadOnly = true;
                cmbPhai.ReadOnly = true;
            }
        }

        private bool kiemTraDuLieuDauVao()
        {
            /*            kiem tra txtMANV
            */
            if (txtHo.Text.Trim() == "")
            {
                MessageBox.Show("Họ nhân viên không được bỏ trống !", "Thông báo !", MessageBoxButtons.OK);
                txtHo.Focus();
                return false;

            }
            else if (txtTen.Text.Trim() == "")
            {
                MessageBox.Show("Tên nhân viên không được bỏ trống !", "Thông báo !", MessageBoxButtons.OK);
                txtTen.Focus();
                return false;

            }
            else if (txtSoDT.Text.Trim() == "")
            {
                MessageBox.Show("Số điện thoại không được bỏ trống !", "Thông báo !", MessageBoxButtons.OK);
                txtSoDT.Focus();
                return false;

            }
            /*      else if (!Program.isValidInputNumber.IsMatch(txtSoDT.Text.Trim()))
                  {
                      MessageBox.Show("Số điện thoại không đúng định dạng !", "Thông báo !", MessageBoxButtons.OK);
                      txtSoDT.Focus();
                      return false;

                  }*/
            else if (txtCMND.Text.Trim() == "")
            {
                MessageBox.Show("Chứng minh nhân dân không được bỏ trống !", "Thông báo !", MessageBoxButtons.OK);
                txtCMND.Focus();
                return false;

            }
            /*           else if (!Program.isValidInputNumber.IsMatch(txtSoDT.Text.Trim()))
                       {
                           MessageBox.Show("Chứng minh nhân dân không đúng định dạng !", "Thông báo !", MessageBoxButtons.OK);
                           txtCMND.Focus();
                           return false;

                       }*/
            else if (txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ không được bỏ trống !", "Thông báo !", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return false;

            }
            return true;
        }

        /*   private void khachHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
           {
               this.Validate();
               this.bdsKH.EndEdit();
               this.tableAdapterManager.UpdateAll(this.dS);



           }*/

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.ChiNhanh' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'dS.KhachHang' table. You can move, or remove it, as needed.


            cmbCN.DataSource = Program.bdsDSPM;
            cmbCN.DisplayMember = "TENCN";
            cmbCN.ValueMember = "TENSERVER";
            cmbCN.SelectedIndex = Program.mCN;

            if (Program.Role.Trim() == "NGANHANG")
            {
                Program.bdsDSPM.Filter = "TENCN <> 'Khách Hàng' ";
                cmbCN.Enabled = true;
            }
            else
            {
                cmbCN.Enabled = false;
            }
            DS.EnforceConstraints = false;
            this.chiNhanhTableAdapter.Connection.ConnectionString = Program.connstr;
            this.chiNhanhTableAdapter.Fill(this.DS.ChiNhanh);
            this.khachHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khachHangTableAdapter.Fill(this.DS.KhachHang);

            maCN = ((DataRowView)bdsCN[0])["MACN"].ToString().Trim();
            CMND = ((DataRowView)bdsKH[0])["CMND"].ToString().Trim();
            txtCMND.ReadOnly = true;
            txtMaCN.ReadOnly = true;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (bdsKH.Count == 0)
            {
                return;
            }
            String cauTruyVan =
                   "DECLARE	@result int " +
                   "EXEC @result = [dbo].[sp_TraCuu_KiemTraCMND_KH] '" +
                   txtCMND.Text.Trim() + "' " +
                   "SELECT 'Value' = @result"; ;
            SqlCommand sqlCommand = new SqlCommand(cauTruyVan, Program.conn);
            Program.myReader = Program.ExecSqlDataReader(cauTruyVan);

            Program.myReader.Read();
            int result = int.Parse(Program.myReader.GetValue(0).ToString());
            Program.myReader.Close();
            if (result == 1)
            {
                MessageBox.Show("Khách hàng này đã có tài khoản không thể xóa. Vui lòng kiểm tra lại !", "Thông báo !", MessageBoxButtons.OK);
                return;
            }
            else
            {
                DialogResult ds = MessageBox.Show("Bạn chắc chắn muốn xóa khách hàng ?", "Thông báo !", MessageBoxButtons.YesNo);
                if (ds == DialogResult.Yes)
                {
                    try
                    {
                        bdsKH.RemoveCurrent();         //xóa row đang chọn ra khỏi dataset
                        this.khachHangTableAdapter.Update(this.DS.KhachHang);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa khách hàng! " + ex.Message, "Thông báo !", MessageBoxButtons.OK);
                    }
                }
            }


        }

        private void BtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtCMND.Focus();
            vitriKH = bdsKH.Position;
            isEditingKH = true;
            bdsKH.AddNew();
            khachHangGridControl.Enabled = false;
            txtMaCN.Text = maCN;
            cmbPhai.SelectedIndex = 1;
            cmbPhai.SelectedIndex = 0;
            txtCMND.Text = "";
            txtCMND.ReadOnly = false;
            txtCMND.Focus();
            dateNgayCap.EditValue = now;
            BtnThem.Enabled = BtnXoa.Enabled = BtnThoat.Enabled = false;
        }

        private void BtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();

        }

        private void BtnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsKH.CancelEdit();
            this.khachHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khachHangTableAdapter.Fill(this.DS.KhachHang);
            if (isEditingKH == true)
            {

                bdsKH.Position = vitriKH;
                khachHangGridControl.Enabled = true;
                BtnThem.Enabled = BtnXoa.Enabled = BtnThoat.Enabled = true;
                txtCMND.ReadOnly = true;
                isEditingKH = false;
            }
        }

        private void BtnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool ketQua = kiemTraDuLieuDauVao();
            if (ketQua == false)
                return;
            String CMND = txtCMND.Text.Trim();// Trim() de loai bo khoang trang thua
            String cauTruyVan =
                   "DECLARE	@result int " +
                   "EXEC @result = [dbo].[sp_TraCuu_KiemTraMaNhanVien] '" +
                   CMND + "' " +
                   "SELECT 'Value' = @result"; ;
            SqlCommand sqlCommand = new SqlCommand(cauTruyVan, Program.conn);
            Program.myReader = Program.ExecSqlDataReader(cauTruyVan);

            Program.myReader.Read();
            int result = int.Parse(Program.myReader.GetValue(0).ToString());
            Program.myReader.Close();
            if(result==1 && isEditingKH ==true)
            {
                MessageBox.Show("Chứng minh nhân dân đã tồn tại. Vui lòng kiểm tra lại !", "Thông báo !", MessageBoxButtons.OK);
                return;
            }
            else
            {
                try
                {
                    bdsKH.EndEdit();            // kết thúc quá trình hiệu chỉnh, gửi dl về dataset
                    bdsKH.ResetCurrentItem();           // lấy dl của textbox control bên dưới đẩy lên gridcontrol đòng bộ 2 khu vực(ko còn ở dạng tạm nữa mà chính thức ghi vào dataset)
                    this.khachHangTableAdapter.Update(this.DS.KhachHang);         // cập nhật dl từ dataset về database thông qua tableadapter
                    isEditingKH = false;
                    khachHangGridControl.Enabled = true;
                    BtnThem.Enabled = BtnXoa.Enabled = BtnThoat.Enabled = true;
                    txtCMND.ReadOnly = true;
                    MessageBox.Show("Lưu thành công!", "Thông báo !", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi khách hàng. " + ex.Message, "Thông báo !", MessageBoxButtons.OK);
                }
            }
        }

        private void cmbCN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCN.SelectedValue != null)
            {
                if (cmbCN.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    Program.serverName = cmbCN.SelectedValue.ToString();
                }
                if (cmbCN.SelectedIndex != Program.mCN)
                {
                    Program.loginName = Program.remoteLogin;
                    Program.loginPassword = Program.remotePassword;
                }
                else
                {
                    Program.loginName = Program.currentLogin;
                    Program.loginPassword = Program.currentPassword;
                }
                if (Program.KetNoi() == 0)
                {
                    MessageBox.Show("Lỗi chuyển chi nhánh", "Thông báo !", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    try
                    {
                        DS.EnforceConstraints = false;
                        this.chiNhanhTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.chiNhanhTableAdapter.Fill(this.DS.ChiNhanh);
                        maCN = ((DataRowView)bdsCN[0])["MACN"].ToString().Trim();
                        this.khachHangTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.khachHangTableAdapter.Fill(this.DS.KhachHang);
                        CMND = ((DataRowView)bdsKH[bdsKH.Position])["CMND"].ToString().Trim();

                    }
                    catch (Exception) { }
                }
            }
        }

       
    }
}