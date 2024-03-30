
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NGANHANG
{
    public partial class frmChuyenTien : DevExpress.XtraEditors.XtraForm
    {
        public frmChuyenTien()
        {
            InitializeComponent();
            panelChuyenTien.Enabled = false;
        }

        private void showTien()
        {
            String cmd = $"SELECT SODU FROM [DBO].[TAIKHOAN] WHERE SOTK = {txtSoTKChuyen.Text}";
            SqlDataReader dataReader = Program.ExecSqlDataReader(cmd);
            dataReader.Read();

            String tien = dataReader.GetValue(0).ToString().Substring(0, dataReader.GetValue(0).ToString().IndexOf("."));
            txtSoDu.Text = tien;
            dataReader.Close();

        }
        public int CheckSoTaiKhoan(string soTaiKhoan)
        {
            String SOTK = soTaiKhoan;// Trim() de loai bo khoang trang thua
            String cauTruyVan =
                   "DECLARE	@result int " +
                   "EXEC @result = [dbo].[SP_KiemTraTonTaiSTK] '" +
                   SOTK + "' " +
                   "SELECT 'Value' = @result";
            SqlCommand sqlCommand = new SqlCommand(cauTruyVan, Program.conn);
            Program.myReader = Program.ExecSqlDataReader(cauTruyVan);

            Program.myReader.Read();
            int result = int.Parse(Program.myReader.GetValue(0).ToString());
            Program.myReader.Close();

            return result;
           

        }



        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            

            if (string.IsNullOrEmpty(txtSoTKChuyen.Text))
            {
                MessageBox.Show("Vui lòng nhập số tài khoản chuyển", "Thông báo !", MessageBoxButtons.OK);
                txtSoTKChuyen.Focus();
                return;
            }

            if (Regex.IsMatch(txtSoTKChuyen.Text, @"^[0-9]+$") == false)
            {
                MessageBox.Show("Số tài khoản chỉ nhận số");
                txtSoTKChuyen.Text = "";
                txtSoTKChuyen.Focus();
                return;
            }
            
            
            if (CheckSoTaiKhoan(txtSoTKChuyen.Text.Trim()) == 0)
            {
                MessageBox.Show("Số tài khoản chuyển không tồn tại", "Thông báo", MessageBoxButtons.OK);
                txtSoTKChuyen.Text = "";
                txtSoTKChuyen.Focus();
                return;
            }
            else
            {
              
                showTien();

                panelChuyenTien.Enabled = true;
            }
        }
       


        private void frmChuyenTien_Load(object sender, EventArgs e)
        {
            this.gD_CHUYENTIENTableAdapter1.Fill(this.ds.GD_CHUYENTIEN);          
            txtHoTen.Text = Program.Hoten;
            txtMaNV.Text = Program.userName;
            
        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void gD_GOIRUTBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.gD_CHUYENTIENBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.ds);

        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {

            if (txtSoTKNhan.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập số tài khoản nhận", "Thông báo !", MessageBoxButtons.OK);
                txtSoTKNhan.Focus();
                return;
            }
            else if (txtSoTKChuyen.Text.Trim() == txtSoTKNhan.Text.Trim())
            {
                MessageBox.Show("Tài khoản nhận và tài khoản chuyển không được trùng nhau", "Thông báo !", MessageBoxButtons.OK);
                txtSoTKNhan.Focus();
                return;
            }
            else if (txtSoTien.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập số tiền cần chuyển", "Thông báo !", MessageBoxButtons.OK);
                txtSoTien.Focus();
                return;
            }
            else if (Int64.Parse(txtSoTien.Text) > Int64.Parse(txtSoDu.Text))
            {
                MessageBox.Show("Số tiền chuyển phải nhỏ hơn số tiền hiện tại");
                txtSoTien.Text = "";
                txtSoTien.Focus();
                return;
            }
            else if(CheckSoTaiKhoan(txtSoTKNhan.Text.Trim()) == 0)
            {
                    MessageBox.Show("Số tài khoản chuyển không tồn tại", "Thông báo", MessageBoxButtons.OK);
                    txtSoTKNhan.Text = "";
                    txtSoTKNhan.Focus();
                    return;
            }
            else
            {
                String cauTruyVan =
                   "DECLARE	@result int " +
                   "EXEC @result = [dbo].[SP_GiaoDichChuyenTien] '" +
                   txtSoTKNhan.Text.Trim() + "', " +
                   "'" + txtSoTKChuyen.Text.Trim() + "', " +
                   "'" + txtSoTien.Text.Trim() + "', " +
                   "'" + txtMaNV.Text.Trim() + "' " +
                   "SELECT 'Value' = @result";


                Program.myReader = Program.ExecSqlDataReader(cauTruyVan);

                Program.myReader.Read();

                int result = int.Parse(Program.myReader.GetValue(0).ToString());
                if (result == 0)
                {
                    MessageBox.Show("Giao dịch thành công");
                }
                else
                {
                    MessageBox.Show("Giao dịch thất bại, đã có lỗi trong quá trình chuyển tiền");
                }
                Program.myReader.Close();
                
            }    
            
            
           

        }
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn thật sự muốn hủy thao tác chuyển tiền?",
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

        
    }
}