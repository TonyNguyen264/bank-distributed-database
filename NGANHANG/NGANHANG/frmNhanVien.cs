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
    public partial class frmNhanVien : DevExpress.XtraEditors.XtraForm
    {
        /* vị trí của con trỏ trên grid view*/
        int viTri = 0;
        /********************************************
         * đang thêm mới -> true -> đang dùng btnTHEM
         *              -> false -> có thể là btnGHI( chỉnh sửa) hoặc btnXOA
         *              
         * Mục đích: dùng biến này để phân biệt giữa btnTHEM - thêm mới hoàn toàn
         * và việc chỉnh sửa nhân viên( do mình ko dùng thêm btnXOA )
         * Trạng thái true or false sẽ được sử dụng 
         * trong btnGHI - việc này để phục vụ cho btnHOANTAC
         ********************************************/
        bool dangThemMoi = false;

        String maCN = "";
        /**********************************************************
         * undoList - phục vụ cho btnHOANTAC -  chứa các thông tin của đối tượng bị tác động 
         * 
         * nó là nơi lưu trữ các đối tượng cần thiết để hoàn tác các thao tác
         * 
         * nếu btnGHI sẽ ứng với INSERT
         * nếu btnXOA sẽ ứng với DELETE
         * nếu btnCHUYENCHINHANH sẽ ứng với CHANGEBRAND
         **********************************************************/
        Stack undoList = new Stack();

        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        private void ShowMdiChildren(Type fType)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == fType)
                {
                    f.Activate();
                    return;
                }
            }
            Form form = (Form)Activator.CreateInstance(fType);
            form.MdiParent = this;
            form.Show();
        }



        private void BtnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                // do du lieu moi tu dataSet vao gridControl NHANVIEN
                this.nhanVienTableAdapter.Fill(this.DS.NhanVien);
                this.nhanVienGridControl.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Làm mới" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                return;
            }
        }

        private bool kiemTraDuLieuDauVao()
        {
            /*            kiem tra txtMANV
            */
            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Mã nhân viên không được bỏ trống !", "Thông báo !", MessageBoxButtons.OK);
                txtMaNV.Focus();
                return false;
            }
            else if (txtHo.Text.Trim() == "")
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

        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.ChiNhanh' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'dS.NhanVien' table. You can move, or remove it, as needed.

            cmbCN.DataSource = Program.bdsDSPM;
            cmbCN.DisplayMember = "TENCN";
            cmbCN.ValueMember = "TENSERVER";
            cmbCN.SelectedIndex = Program.mCN;

            viTri = bdsNV.Position;
            /*            this.panelNhap.Enabled = true;
            */
            dangThemMoi = true;


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
            maCN = ((DataRowView)bdsCN[0])["MACN"].ToString().Trim();

            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.DS.NhanVien);
            /*            maNVXoa = ((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString().Trim();
            */            /*    if (maNVXoa == Program.userName)
                            {
                                btnXoaNV.Enabled = false;
                                btnChuyen.Enabled = false;
                            }*/

        }

        private void BtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            viTri = bdsNV.Position;
            /*            this.panelNhap.Enabled = true;
            */
            dangThemMoi = true;

            bdsNV.AddNew();
            txtMaCN.Text = maCN;
            txtMaCN.ReadOnly = true;
            this.txtMaNV.ReadOnly = false;

            cmbPhai.SelectedIndex = 1;
            cmbPhai.SelectedIndex = 0;
            /*            this.cmbPhai.ReadOnly = true;
            */
            this.BtnThem.Enabled = false;
            this.BtnXoa.Enabled = false;
            this.BtnGhi.Enabled = true;

            this.BtnHoanTac.Enabled = true;
            this.BtnLamMoi.Enabled = false;
            this.BtnChuyenCN.Enabled = false;
            this.BtnThoat.Enabled = false;
            this.chbTTX.Enabled = false;
            this.chbTTX.Checked = false;

            this.nhanVienGridControl.Enabled = false;
        }

        private void BtnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool ketQua = kiemTraDuLieuDauVao();
            if (ketQua == false) return;

            String maNhanVien = txtMaNV.Text.Trim();// Trim() de loai bo khoang trang thua
            DataRowView drv = ((DataRowView)bdsNV[bdsNV.Position]);
            String ho = drv["HO"].ToString();
            String ten = drv["TEN"].ToString();

            String diaChi = drv["DIACHI"].ToString();
            String CMND = drv["CMND"].ToString();
            String SoDT = drv["SODT"].ToString();
            String Phai = drv["Phai"].ToString();
            String maChiNhanh = drv["MACN"].ToString();
            int trangThai = 0;


            String cauTruyVanMaNV =
                   "DECLARE	@result int " +
                   "EXEC @result = [dbo].[sp_TraCuu_KiemTraMaNhanVien] '" +
                   maNhanVien + "' " +
                   "SELECT 'Value' = @result"; ;

            /*       String cauTruyVanCMND =
                           "DECLARE	@result int " +
                           "EXEC @result = [dbo].[sp_TraCuu_KiemTraCMND] '" +
                           CMND + "' " +
                           "SELECT 'Value' = @result"; ;*/
            SqlCommand sqlCommand = new SqlCommand(cauTruyVanMaNV, Program.conn);
            Program.myReader = Program.ExecSqlDataReader(cauTruyVanMaNV);

            Program.myReader.Read();
            int result_MaNV = int.Parse(Program.myReader.GetValue(0).ToString());
            Program.myReader.Close();

            int viTriConTro = bdsNV.Position;
            int viTriMaNhanVien = bdsNV.Find("MANV", txtMaNV.Text);

            String cauTruyVanCMND =
                    "DECLARE	@result int " +
                    "EXEC @result = [dbo].[sp_TraCuu_KiemTraCMND] '" +
                    CMND + "' " +
                    "SELECT 'Value' = @result"; ;
            Program.myReader = Program.ExecSqlDataReader(cauTruyVanCMND);

            Program.myReader.Read();
            int result_CMND = int.Parse(Program.myReader.GetValue(0).ToString());
            Program.myReader.Close();

            if (result_MaNV == 1 && viTriConTro != viTriMaNhanVien)
            {
                MessageBox.Show("Mã nhân viên này đã được sử dụng !", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            else if (result_CMND == 1)
            {
                MessageBox.Show("CMND này đã được sử dụng !", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            else/*them moi | sua nhan vien*/
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào cơ sở dữ liệu ?", "Thông báo",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        /*bật các nút về ban đầu*/
                        BtnThem.Enabled = true;
                        BtnXoa.Enabled = true;
                        BtnGhi.Enabled = true;
                        BtnHoanTac.Enabled = true;

                        BtnLamMoi.Enabled = true;
                        BtnChuyenCN.Enabled = true;
                        BtnThoat.Enabled = true;

                        this.txtMaNV.Enabled = false;
                        this.bdsNV.EndEdit();
                        this.nhanVienTableAdapter.Update(this.DS.NhanVien);
                        this.nhanVienGridControl.Enabled = true;

                        /*lưu 1 câu truy vấn để hoàn tác yêu cầu*/
                        String cauTruyVanHoanTac = "";
                        /*trước khi ấn btnGHI là btnTHEM*/
                        if (dangThemMoi == true)
                        {
                            cauTruyVanHoanTac = "" +
                                "DELETE DBO.NHANVIEN " +
                                "WHERE MANV = " + txtMaNV.Text.Trim();
                        }
                        /*trước khi ấn btnGHI là sửa thông tin nhân viên*/
                        else
                        {


                            cauTruyVanHoanTac =
                                    "UPDATE DBO.NhanVien " +
                                    "SET " +
                                    "HO = '" + ho + "'," +
                                    "TEN = '" + ten + "'," +
                                    "CMND= '" + CMND + "'," +
                                    "DIACHI = '" + diaChi + "'," +
                                    "Phai= '" + Phai + "'," +
                                    "TrangThaiXoa = " + trangThai + " " +
                                    "WHERE MANV = '" + maNhanVien + "'";
                        }
                        Console.WriteLine(cauTruyVanHoanTac);

                        /*Đưa câu truy vấn hoàn tác vào undoList 
                            * để nếu chẳng may người dùng ấn hoàn tác thì quất luôn*/
                        undoList.Push(cauTruyVanHoanTac);
                        /*cập nhật lại trạng thái thêm mới cho chắc*/
                        dangThemMoi = false;
                        MessageBox.Show("Ghi thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {

                        bdsNV.RemoveCurrent();
                        MessageBox.Show("Thất bại. Vui lòng kiểm tra lại!\n" + ex.Message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void BtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String MaNV = ((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString();
            /*Step 1*/

            // khong cho xoa nguoi dang dang nhap ke ca nguoi do khong co don hang - phieu nhap - phieu xuat
            if (MaNV == Program.userName)
            {
                MessageBox.Show("Không thể xóa chính tài khoản đang đăng nhập", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (bdsNV.Count == 0)
            {
                BtnXoa.Enabled = false;
            }
            string cauTruyVanHoanTac =
               string.Format("INSERT INTO DBO.NHANVIEN( MANV,HO,TEN,DIACHI,CMND,PHAI,SODT,MACN)" +
           "VALUES({0},'{1}','{2}','{3}',{4}, {5},'{6}','{7},'{8}')", txtMaNV.Text, txtHo.Text, txtTen.Text, txtDiaChi.Text, txtCMND.Text, cmbPhai.Text, txtMaCN.Text.Trim());

            Console.WriteLine(cauTruyVanHoanTac);
            undoList.Push(cauTruyVanHoanTac);

            DialogResult ds = MessageBox.Show("Bạn chắc chắn muốn xóa hoàn toàn nhân viên này?", "Thông báo !", MessageBoxButtons.YesNo);
            if (ds == DialogResult.Yes)
            {
                String cauTruyVan =
                "DECLARE	@result int " +
                "EXEC @result = [dbo].[sp_TraCuu_KiemTraCMND] '" +
                MaNV + "' " +
                "SELECT 'Value' = @result"; ;
                SqlCommand sqlCommand = new SqlCommand("", Program.conn);
                Program.myReader = Program.ExecSqlDataReader(cauTruyVan);

                Program.myReader.Read();
                int result = int.Parse(Program.myReader.GetValue(0).ToString());
                Program.myReader.Close();
                if (result == 0)
                {
                    MessageBox.Show("Nhân viên đã có giao dịch không thể xóa");
                    return;
                }
                else if (result == 1)
                {
                    DialogResult ds1 = MessageBox.Show("Nhân viên này đã có tài khoản, bạn có chắc muốn xóa?\nThao tác này không thể hoàn tác!!", "Thông báo !", MessageBoxButtons.YesNo);
                    if (ds1 == DialogResult.Yes)
                    {
                        try
                        {

                            String cauTruyVanXoaLogin =
                                "DECLARE	@result int " +
                                "EXEC @result = [dbo].[SP_Xoa_Login] '" +
                                txtMaNV + "' " + Program.Role + "' " +
                                "SELECT 'Value' = @result"; ;
                            Program.myReader = Program.ExecSqlDataReader(cauTruyVanXoaLogin);

                            Program.myReader.Read();
                            int ret = int.Parse(Program.myReader.GetValue(0).ToString());
                            Program.myReader.Close();
                            if (ret == 0)
                            {
                                MessageBox.Show("Bạn không có quyền này!!", "Thông báo !", MessageBoxButtons.OK);
                                return;
                            }
                            else
                            {

                                bdsNV.EndEdit();            // kết thúc quá trình hiệu chỉnh, gửi dl về dataset
                                bdsNV.ResetCurrentItem();           // lấy dl của textbox control bên dưới đẩy lên gridcontrol đòng bộ 2 khu vực(ko còn ở dạng tạm nữa mà chính thức ghi vào dataset)
                                this.nhanVienTableAdapter.Update(this.DS.NhanVien);
                                MessageBox.Show("Xóa thành công!", "Thông báo !", MessageBoxButtons.OK);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi xóa login. Xóa thất bại" + ex.Message, "Thông báo !", MessageBoxButtons.OK);
                        }
                    }
                }


            }
            else
            {
                undoList.Pop();
            }
        }
                /**********************************************************************
                * moi lan nhan btnHOANTAC thi nen nhan them btnLAMMOI de 
                * tranh bi loi khi an btnTHEM lan nua
                * 
                * statement: chua cau y nghia chuc nang ngay truoc khi an btnHOANTAC.
                * Vi du: statement = INSERT | DELETE | CHANGEBRAND
                * 
                * bdsNhanVien.CancelEdit() - phuc hoi lai du lieu neu chua an btnGHI
                * Step 0: trường hợp đã ấn btnTHEM nhưng chưa ấn btnGHI
                * Step 1: kiểm tra undoList có trông hay không ?
                * Step 2: Neu undoList khong trống thì lấy ra khôi phục
                *********************************************************************/
        private void BtnHoanTac_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /* Step 0 - */
            if (dangThemMoi == true && this.BtnThem.Enabled == false)
            {
                dangThemMoi = false;

                this.txtMaNV.Enabled = false;
                this.BtnThem.Enabled = true;
                this.BtnXoa.Enabled = true;
                this.BtnGhi.Enabled = true;

                this.BtnHoanTac.Enabled = false;
                this.BtnLamMoi.Enabled = true;
                this.BtnChuyenCN.Enabled = true;
                this.BtnThoat.Enabled = true;
                this.chbTTX.Checked = false;

                this.nhanVienGridControl.Enabled = true;


                bdsNV.CancelEdit();
                /*xoa dong hien tai*/
                bdsNV.RemoveCurrent();
                /* trở về lúc đầu con trỏ đang đứng*/
                bdsNV.Position = viTri;
                return;
            }


            /*Step 1*/
            if (undoList.Count == 0)
            {
                MessageBox.Show("Không còn thao tác nào để khôi phục", "Thông báo", MessageBoxButtons.OK);
                BtnHoanTac.Enabled = false;
                return;
            }

            /*Step 2*/
            bdsNV.CancelEdit();
            String cauTruyVanHoanTac = undoList.Pop().ToString();
            //Console.WriteLine(cauTruyVanHoanTac);

            /*Step 2.1*/
            if (cauTruyVanHoanTac.Contains("sp_ChuyenChiNhanh"))
            {
                try
                {
                    String chiNhanhHienTai = Program.serverName;
                    String chiNhanhChuyenToi = Program.serverNameLeft;

                    Program.serverName = chiNhanhChuyenToi;
                    Program.loginName = Program.remoteLogin;
                    Program.loginPassword = Program.remotePassword;

                    if (Program.KetNoi() == 0)
                    {
                        return;
                    }


                    int n = Program.ExecSqlNonQuery(cauTruyVanHoanTac);

                    MessageBox.Show("Chuyển nhân viên trở lại thành công", "Thông báo", MessageBoxButtons.OK);
                    Program.serverName = chiNhanhHienTai;
                    Program.loginName = Program.currentLogin;
                    Program.loginPassword = Program.currentPassword;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Chuyển nhân viên thất bại \n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                    return;
                }

            }
            /*Step 2.2*/
            else
            {
                if (Program.KetNoi() == 0)
                {
                    return;
                }
                int n = Program.ExecSqlNonQuery(cauTruyVanHoanTac);

            }
            this.nhanVienTableAdapter.Fill(this.DS.NhanVien);
        }

        public void chuyenChiNhanh(String chiNhanh)
        {
            //Console.WriteLine("Chi nhánh được chọn là " + chiNhanh);

            /*Step 1*/
            if (Program.serverName == chiNhanh)
            {
                MessageBox.Show("Hãy chọn chi nhánh khác chi nhánh bạn đang đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            /*Step 2*/
            String maChiNhanhHienTai = "";
            String maChiNhanhMoi = "";
            int viTriHienTai = bdsNV.Position;
            String maNhanVien = ((DataRowView)bdsNV[viTriHienTai])["MANV"].ToString();

            if (chiNhanh.Contains("1"))
            {
                maChiNhanhHienTai = "CN2";
                maChiNhanhMoi = "CN1";
            }
            else if (chiNhanh.Contains("2"))
            {
                maChiNhanhHienTai = "CN1";
                maChiNhanhMoi = "CN2";
            }
            else
            {
                MessageBox.Show("Mã chi nhánh không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Console.WriteLine("Ma chi nhanh hien tai : " + maChiNhanhHienTai);
            Console.WriteLine("Ma chi nhanh Moi : " + maChiNhanhMoi);



            /*Step 3*/
/*            String cauTruyVanHoanTac = "EXEC sp_ChuyenChiNhanh " + maNhanVien + ",'" + maChiNhanhHienTai + "'";
*/    /*        undoList.Push(cauTruyVanHoanTac);*/

/*            Program.serverNameLeft = chiNhanh; *//*Lấy tên chi nhánh tới để làm tính năng hoàn tác*/
/*            Console.WriteLine("Ten server con lai" + Program.serverNameLeft);
*/


            /*Step 4*/
            String cauTruyVan = "EXEC sp_ChuyenChiNhanh " + maNhanVien + ",'" + maChiNhanhMoi + "'";
            Console.WriteLine("Cau Truy Van: " + cauTruyVan);
/*            Console.WriteLine("Cau Truy Van Hoan Tac: " + cauTruyVanHoanTac);
*/
            SqlCommand sqlcommand = new SqlCommand(cauTruyVan, Program.conn);
            try
            {
                Program.myReader = Program.ExecSqlDataReader(cauTruyVan);
                MessageBox.Show("Chuyển chi nhánh thành công", "thông báo", MessageBoxButtons.OK);

                if (Program.myReader == null)
                {
                    return;/*khong co ket qua tra ve thi ket thuc luon*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("thực thi database thất bại!\n\n" + ex.Message, "thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
                return;
            }
            this.nhanVienTableAdapter.Update(this.DS.NhanVien);


        }

        private void BtnChuyenCN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int viTriHienTai = bdsNV.Position;
            int trangThaiXoa = int.Parse(((DataRowView)(bdsNV[viTriHienTai]))["TrangThaiXoa"].ToString());
            string maNhanVien = ((DataRowView)(bdsNV[viTriHienTai]))["MANV"].ToString();

            if (maNhanVien == Program.userName)
            {
                MessageBox.Show("Không thể chuyển chính người đang đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            /*Step 1 - Kiem tra trang thai xoa*/
            if (trangThaiXoa == 1)
            {
                MessageBox.Show("Nhân viên này không có ở chi nhánh này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (bdsNV.Count ==0)
            {
                return;
            }
            DialogResult ds = MessageBox.Show("Bạn chắc chắn muốn chuyển chi nhánh nhân viên này?\nThao tác này không thể hoàn tác!!", "Thông báo !", MessageBoxButtons.YesNo);
            if (ds == DialogResult.Yes)
            {
                /*Step 2 Kiem tra xem form da co trong bo nho chua*/
                Form f = this.CheckExists(typeof(frmChuyenChiNhanh));
                if (f != null)
                {
                    f.Activate();
                }
                frmChuyenChiNhanh form = new frmChuyenChiNhanh();
                form.Show();

                /*Step 3*/
                /*đóng gói hàm chuyenChiNhanh từ formNHANVIEN đem về formChuyenChiNhanh để làm việc*/
                form.Mini_chuyenCN = new frmChuyenChiNhanh.Mini_Func(chuyenChiNhanh);

                /*Step 4*/
                this.BtnHoanTac.Enabled = false;
            }
       
        }
    }
}

    
    