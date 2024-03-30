using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.ComponentModel;

namespace NGANHANG
{
    public partial class frmGuiRutTien : DevExpress.XtraEditors.XtraForm
    {
        String loaiGD;
        private class Data
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }
        public frmGuiRutTien()
        {
            InitializeComponent();
            panelGuiRutTien.Enabled = false;
        }

        
        private void showTien()
        {
            String cmd = $"SELECT SODU FROM [DBO].[TAIKHOAN] WHERE SOTK = {txtSoTKGD.Text}";
            SqlDataReader dataReader = Program.ExecSqlDataReader(cmd);
            dataReader.Read();

            String tien = dataReader.GetValue(0).ToString().Substring(0, dataReader.GetValue(0).ToString().IndexOf("."));
            txtSoDu.Text = tien;
            dataReader.Close();

        }
        /*private int CheckSoTaiKhoan(string soTaiKhoan)
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


        }*/

        
        private void frmGuiRutTien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.GD_GOIRUT' table. You can move, or remove it, as needed.
            this.gD_GOIRUTTableAdapter.Fill(this.ds.GD_GOIRUT);

            BindingList<Data> _comboItems = new BindingList<Data>();
            _comboItems.Add(new Data { Name = "Gửi Tiền", Value = "GT" });
            _comboItems.Add(new Data { Name = "Rút Tiền", Value = "RT" });
            cmbLoaiGD.DataSource = _comboItems;
            cmbLoaiGD.DisplayMember = "Name";
            cmbLoaiGD.ValueMember = "Value";
            txtHoTen.Text = Program.Hoten;
            txtMaNV.Text = Program.userName;
            cmbLoaiGD.SelectedIndex = -1;
            cmbLoaiGD.SelectedIndex = 0;
        }

        private void cmbLoaiGD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLoaiGD.SelectedValue != null)
            {
                loaiGD = cmbLoaiGD.SelectedValue.ToString().Trim();
            }
        }
      
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void gD_GOIRUTBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.gD_GOIRUTBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.ds);

        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (txtSoTien.Text.Trim() == "")
            {
                MessageBox.Show("Số tiền không được bỏ trống !", "Thông báo !", MessageBoxButtons.OK);
                txtSoTien.Focus();
            }
            else if (int.Parse(txtSoTien.Text.Trim()) < 100000)
            {
                MessageBox.Show("Số tiền phải lớn hơn 100.000 !", "Thông báo !", MessageBoxButtons.OK);
                txtSoTien.Focus();
            }
            else
            {

                String cauTruyVan =
                   "DECLARE	@result int " +
                   "EXEC @result = [dbo].[SP_GiaoDichGuiRut] '" +
                   loaiGD + "', " +
                   "'" + txtSoTien.Text.Trim() + "', " +
                   "'" + txtSoTKGD.Text.Trim() + "', " +
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
                    MessageBox.Show("Giao dịch thất bại");
                }
                Program.myReader.Close();
            }

        }

        private void panelGuiRutTien_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnKiemTra_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoTKGD.Text))
            {
                MessageBox.Show("Vui lòng nhập số tài khoản chuyển", "Thông báo !", MessageBoxButtons.OK);
                txtSoTKGD.Focus();
                return;
            }

            if (Regex.IsMatch(txtSoTKGD.Text, @"^[0-9]+$") == false)
            {
                MessageBox.Show("Số tài khoản chỉ nhận số");
                txtSoTKGD.Text = "";
                txtSoTKGD.Focus();
                return;
            }
           
            frmChuyenTien chuyenTien = new frmChuyenTien();
           
            if (chuyenTien.CheckSoTaiKhoan(txtSoTKGD.Text.Trim()) == 0)
            {
                MessageBox.Show("Số tài khoản không tồn tại", "Thông báo", MessageBoxButtons.OK);
                txtSoTKGD.Text = "";
                txtSoTKGD.Focus();
                return;
            }
            else
            {
                showTien();
                panelGuiRutTien.Enabled = true;
            }
        }
    }
}