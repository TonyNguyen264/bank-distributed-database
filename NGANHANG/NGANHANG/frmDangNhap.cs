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
using System.Data.SqlClient;

namespace NGANHANG
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        private SqlConnection connPublisher = new SqlConnection();
        private void layDanhSachPhanManh(String cmd)
        {
            if (connPublisher.State == ConnectionState.Closed)
            {
                connPublisher.Open();
            }
            DataTable dt = new DataTable();
            // adapter dùng để đưa dữ liệu từ view sang database
            SqlDataAdapter da = new SqlDataAdapter(cmd, connPublisher);
            // dùng adapter thì mới đổ vào data table được
            da.Fill(dt);


            connPublisher.Close();
            Program.bdsDSPM.DataSource = dt;


            cmbCN.DataSource = Program.bdsDSPM;
            cmbCN.DisplayMember = "TENCN";
            cmbCN.ValueMember = "TENSERVER";
        }
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        /* * mở kết nối tới server
        * @return trả về 1 nếu thành công
        * trả về 0 nếu thất bại
*/
        private int KetNoiDatabaseGoc()
        {
            if (connPublisher != null && connPublisher.State == ConnectionState.Open)
                connPublisher.Close();
            try
            {
                connPublisher.ConnectionString = Program.connstrPublisher;
                connPublisher.Open();
                return 1;
            }

            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nBạn xem lại user name và password.\n " + e.Message, "", MessageBoxButtons.OK);
                return 0;
            }
        }
        
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
       
            // đặt sẵn mật khẩu để đỡ nhập lại nhiều lần
            txtUsername.Text = "tuan";// LVA - chi nhanh
            txtPass.Text = "1234";
            if (KetNoiDatabaseGoc() == 0)
                return;
            //Lấy 2 cái đầu tiên của danh sách
            layDanhSachPhanManh("SELECT TOP 2 * FROM Get_Subscribes");
            cmbCN.SelectedIndex = 0;
            cmbCN.SelectedIndex = 1;
        
        }

        /*           Kiểm tra tài khoản & mật khẩu xem có bị trống không? 
                ->gán loginName & loginPassword với tài khoản mật khẩu được nhập-> loginName và loginPassword dùng để đăng nhập vào phân mảnh này
                -> cập nhật currentLogin & currentPassword
                -> chạy stored procedure DANG NHAP de lay thong tin nguoi dung
                -> gán giá trị Mã nhân viên - họ tên - vai trò ở góc màn hình
                -> ẩn form hiện tại & hiện các nút chức năng còn lại*/


        private void BtnDangNhap_Click(object sender, EventArgs e)
        {
          
            if (txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("Tài khoản đăng nhập không được rỗng.", "Báo lỗi đăng nhập",
                    MessageBoxButtons.OK);
                txtUsername.Focus();
                return;
            }
            if (txtPass.Text.Trim() == "")
            {
                MessageBox.Show("Mật khẩu đăng nhập không được rỗng.", "Báo lỗi đăng nhập",
                    MessageBoxButtons.OK);
                txtPass.Focus();
                return;
            }

            Program.loginName = txtUsername.Text;
            Program.loginPassword = txtPass.Text;
/*            Program.serverName = ;
*/            if (Program.KetNoi() == 0)
                return;


            Program.mCN = cmbCN.SelectedIndex;
            Program.currentLogin = Program.loginName;
            Program.currentPassword = Program.loginPassword;

            String strLenh = "EXEC SP_Lay_Thong_Tin_NV_Tu_Login '" + Program.loginName + "'";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader == null) return;


            if (Program.myReader.Read())
            {
                Program.userName = Program.myReader.GetString(0);
                Program.Hoten = Program.myReader.GetString(1);
                Program.Role = Program.myReader.GetString(2);
            }
            if (Convert.IsDBNull(Program.userName))
            {
                MessageBox.Show("Login bạn nhập không có quyền truy cập dữ liệu\n Bạn vui lòng xem lại!", "", MessageBoxButtons.OK);
                return;
            }


            Program.myReader.Close();
            Program.conn.Close();
/*            Program.FrmMain = new frmMain();
*/            /*     Program.frmChinh.MANV.Text = "Mã nhân viên: " + Program.username;
                 Program.frmChinh.HOTEN.Text = "Họ và tên: " + Program.mHoten;
                 Program.frmChinh.NHOM.Text = "Nhóm: " + Program.mGroup;*/

            /*            Program.FrmMain.Close();
            */
            this.Visible = false;
        

            MessageBox.Show("Đăng Nhập Thành Công");
            Program.FrmMain.status();
            Program.FrmMain.EnableButton();
           
        }



        private void cmbCN_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Program.serverName = cmbCN.SelectedValue.ToString();
                //Console.WriteLine(cmbCHINHANH.SelectedValue.ToString());
            }
            catch (Exception)
            {
                
            }
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chbShowPass_CheckedChanged(object sender, EventArgs e)
        {
        txtPass.UseSystemPasswordChar = (chbShowPass.Checked) ? false : true;            
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}