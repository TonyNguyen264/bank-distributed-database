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
    public partial class frmTaiKhoanNganHang : DevExpress.XtraEditors.XtraForm
    {
        int vitriTK = 0;

        Boolean isEditingTK = false;
        String maCN;
        DateTime now = DateTime.Now;
        public frmTaiKhoanNganHang()
        {
            InitializeComponent();
            if (Program.Role.Trim() == "NGANHANG")
            {
                BtnThem.Enabled = false;
                BtnLamMoi.Enabled = false;
                BtnGhi.Enabled = false;
                BtnHoanTac.Enabled = false;
                BtnXoa.Enabled = false;
                txtCMND.ReadOnly = true;
                txtMaCN.ReadOnly = true;
                txtSoTk.ReadOnly = true;
                dateNgayMoTK.ReadOnly = true;
                SpinEditSoDu.ReadOnly = true;
            }
        }

        private bool kiemTraDuLieuDauVao()
        {
            /*            kiem tra txtMANV
            */
            if (SpinEditSoDu.Text.Trim() == "")
            {
                MessageBox.Show("Số dư không được bỏ trống !", "Thông báo !", MessageBoxButtons.OK);
                SpinEditSoDu.Focus();
                return false;
            }
            else if (txtSoTk.Text.Trim() == "")
            {
                MessageBox.Show("Số tài khoản không được bỏ trống !", "Thông báo !", MessageBoxButtons.OK);
                txtSoTk.Focus();
            }
            /*else if (!Program.isValidInputCMNDSTK.IsMatch(txtSTK.Text.Trim()))
            {
                MessageBox.Show("Chứng minh nhân dân không đúng định dạng !", "Thông báo !", MessageBoxButtons.OK);
                txtSTK.Focus();
            }*/
            else if (dateNgayMoTK.DateTime.CompareTo(now) == 1)
            {
                MessageBox.Show("Không được chọn quá ngày hiện tại!", "Thông báo!", MessageBoxButtons.OK);
            }
            else if (dateNgayMoTK.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn ngày mở TK!", "Thông báo!", MessageBoxButtons.OK);
            }
            return true;
        }

            private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void taiKhoanBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsTK.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmTaiKhoanNganHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.GD_GOIRUT' table. You can move, or remove it, as needed.
            this.gD_GOIRUTTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gD_GOIRUTTableAdapter.Fill(this.dS.GD_GOIRUT);
            // TODO: This line of code loads data into the 'dS.GD_CHUYENTIEN' table. You can move, or remove it, as needed.
           
            this.gD_CHUYENTIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gD_CHUYENTIENTableAdapter.Fill(this.dS.GD_CHUYENTIEN);
            // TODO: This line of code loads data into the 'dS.sp_HienThiKhachHang' table. You can move, or remove it, as needed.
            this.sp_HienThiKhachHangTableAdapter.Fill(this.dS.sp_HienThiKhachHang);
            // TODO: This line of code loads data into the 'dS.ChiNhanh' table. You can move, or remove it, as needed.
            this.chiNhanhTableAdapter.Connection.ConnectionString = Program.connstr;
            this.chiNhanhTableAdapter.Fill(this.dS.ChiNhanh);

            string CMND_KH = ((DataRowView)bdsCN[0])["MACN"].ToString().Trim();
            txtMaCN.Text = maCN;
            // TODO: This line of code loads data into the 'dS.TaiKhoan' table. You can move, or remove it, as needed.
            this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
            this.taiKhoanTableAdapter.Fill(this.dS.TaiKhoan);


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

        }

        private void BtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRowView currentKH = (DataRowView)bdsKH.Current;
            txtSoTk.Focus();
            vitriTK = bdsTK.Position;
            isEditingTK = true;
            bdsTK.AddNew();
            taiKhoanGridControl.Enabled = false;
            txtMaCN.Text = maCN;
            txtCMND.Text = "";
            txtCMND.ReadOnly = false;
            txtCMND.Focus();
            gcDSKH.Enabled = true;
            txtCMND.ReadOnly = true;
/*            txtCMND.Text = (string)currentKH["CMND"];*/
/*            txtCMND.Text = ((DataRowView)bdsKH[bdsKH.Position])["CMND"].ToString().Trim();
*/            dateNgayMoTK.EditValue = now;
            BtnThem.Enabled = BtnXoa.Enabled = BtnThoat.Enabled = false;
        }

        private void BtnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool ketQua = kiemTraDuLieuDauVao();
            if (ketQua == false) return;
            String SOTK = txtSoTk.Text.Trim();// Trim() de loai bo khoang trang thua
            String cauTruyVan =
                   "DECLARE	@result int " +
                   "EXEC @result = [dbo].[sp_TraCuu_KiemTraSTK] '" +
                   SOTK + "' " +
                   "SELECT 'Value' = @result"; ;
            SqlCommand sqlCommand = new SqlCommand(cauTruyVan, Program.conn);
            Program.myReader = Program.ExecSqlDataReader(cauTruyVan);

            Program.myReader.Read();
            int result = int.Parse(Program.myReader.GetValue(0).ToString());
            Program.myReader.Close();

            string maCN = ((DataRowView)bdsCN[0])["MACN"].ToString().Trim();
            if (result == 1 && isEditingTK == true)
            {
                MessageBox.Show("Số tài khoản đã tồn tại. Vui lòng kiểm tra lại !", "Thông báo !", MessageBoxButtons.OK);
                return;
            }
            else if(result ==0 && isEditingTK==true)
            {
                DateTime NGAYMOTK  = (DateTime)((DataRowView)bdsTK[bdsTK.Position])["NGAYMOTK"];
                string themnhanvien =
               string.Format("INSERT INTO DBO.TAIKHOAN( SOTK,CMND,SODU,MACN,NGAYMOTK)" +
           "VALUES({0},'{1}','{2}','{3}','{4}',CAST({5} AS DATETIME))", 
           txtSoTk.Text, txtCMND.Text, SpinEditSoDu.Text, txtMaCN.Text, NGAYMOTK.ToString("yyyy-MM-dd"));
                if (Program.KetNoi() == 0)
                {
                    return;
                }

                int n = Program.ExecSqlNonQuery(themnhanvien);
                isEditingTK = false;
                taiKhoanGridControl.Enabled = true;
                BtnThem.Enabled = BtnXoa.Enabled = BtnThoat.Enabled = true;
                gcDSKH.Enabled = false;
                MessageBox.Show("Lưu thành công!", "Thông báo !", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    bdsTK.EndEdit();            // kết thúc quá trình hiệu chỉnh, gửi dl về dataset
                    bdsTK.ResetCurrentItem();           // lấy dl của textbox control bên dưới đẩy lên gridcontrol đòng bộ 2 khu vực(ko còn ở dạng tạm nữa mà chính thức ghi vào dataset)
                    this.taiKhoanTableAdapter.Update(this.dS.TaiKhoan);         // cập nhật dl từ dataset về database thông qua tableadapter
                    isEditingTK = false;
                    taiKhoanGridControl.Enabled = true;
                    BtnThem.Enabled = BtnXoa.Enabled = BtnThoat.Enabled = true;
                    gcDSKH.Enabled = false;
                    MessageBox.Show("Lưu thành công!", "Thông báo !", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi tài khoản. " + ex.Message, "Thông báo !", MessageBoxButtons.OK);
                }
            }
        }

        private void BtnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
            this.taiKhoanTableAdapter.Fill(this.dS.TaiKhoan);
            this.sp_HienThiKhachHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sp_HienThiKhachHangTableAdapter.Fill(this.dS.sp_HienThiKhachHang);
            if (isEditingTK == true)
            {
                bdsTK.CancelEdit();
                bdsTK.Position = vitriTK;
                taiKhoanGridControl.Enabled = true;
                txtCMND.ReadOnly = true;
                BtnThem.Enabled = BtnXoa.Enabled = BtnThoat.Enabled = true;
                isEditingTK = false;
                gcDSKH.Enabled = false;
            }
        }

        private void gcDSKH_Click(object sender, EventArgs e)
        {
            DataRowView current = (DataRowView)bdsKH.Current;
            if (isEditingTK == true)
            { 
                txtCMND.Text = (string)current["CMND"];
                
            }
        }

        private void BtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsTK.Count == 0)
            {
                return;
            }
            if (bdsGDGR.Count > 0)
            {
                MessageBox.Show("Tài khoản đã có giao dịch gửi hoặc rút tiền, không thể xóa !", "Thông báo !", MessageBoxButtons.OK);
                return;
            }
            if (bdsGDCT.Count > 0)
            {
                MessageBox.Show("Tài khoản đã có giao dịch chuyển tiền, không thể xóa !", "Thông báo !", MessageBoxButtons.OK);
                return;
            }
            DialogResult ds = MessageBox.Show("Bạn chắc chắn muốn xóa tài khoản ?", "Thông báo !", MessageBoxButtons.YesNo);
            if (ds == DialogResult.Yes)
            {
                try
                {
                    bdsTK.RemoveCurrent();         //xóa row đang chọn ra khỏi dataset
                    this.taiKhoanTableAdapter.Update(this.dS.TaiKhoan);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa tài khoản. " + ex.Message, "Thông báo !", MessageBoxButtons.OK);
                }
            }
            
        }

    }
}