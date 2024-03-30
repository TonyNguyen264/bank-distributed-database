using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using NGANHANG.Report;
using System.Windows.Forms;

namespace NGANHANG
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        public frmMain()
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

        public void EnableButton()
        {

          /*  MessageBox.Show("Đã vào");*/
            RBadmin.Visible = true;
            RBBaoCao.Visible = true;
            RBGiaoDich.Visible = true;
            BtnDangXuat.Enabled = true;
            BtnDangNhap.Enabled = false;
            BtnTaoTaiKhoan.Enabled = true;
            BtnTaoTaiKhoanKH.Enabled = true;
          
        }
        private void logout()
        {
            foreach (Form f in this.MdiChildren)
                f.Dispose();
        }
        public void status()
        {
            toolStripStatusLabel2.Text = Program.Hoten+"  "+Program.userName+"  "+Program.Role;
        }


        private void frmMain_load(object sender, EventArgs e)
        {
/*            BtnDangNhap.PerformClick();
*/          Form f = this.CheckExists(typeof(frmDangNhap));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmDangNhap form = new frmDangNhap();
                form.MdiParent = this;
                form.Show();
            }


          
        }

       
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(frmDSGD));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmDSGD form = new frmDSGD();
                form.MdiParent = this;
                form.Show();
            }

        }

        private void BtnDangNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(frmDangNhap));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmDangNhap form = new frmDangNhap();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void BtnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult ds = MessageBox.Show("Bạn chắc chắn muốn đăng xuất không ?", "Thông báo !", MessageBoxButtons.YesNo);
            if (ds == DialogResult.Yes)
            {
                logout();

                BtnDangNhap.Enabled = true;
                BtnDangXuat.Enabled = false;
                RBGiaoDich.Visible = false;
                RBadmin.Visible = false;
                RBBaoCao.Visible = false;
               
            }

        }

        private void BtnChuyenTien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(frmChuyenTien));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmChuyenTien form = new frmChuyenTien();
                form.MdiParent = this;
                form.Show();
            }
        }
        private void BtnGuiRut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(frmGuiRutTien));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmGuiRutTien form = new frmGuiRutTien();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void BtnNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(frmNhanVien));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmNhanVien form = new frmNhanVien();
                /*form.MdiParent = this;*/
                form.Show();
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void BtnTaoTaiKhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(frmTaoTKLoginNV));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmTaoTKLoginNV form = new frmTaoTKLoginNV();
                //form.MdiParent = this;
                form.Show();
            }
        }

        private void BtnKhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(frmKhachHang));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmKhachHang form = new frmKhachHang();
           /*     form.MdiParent = this;*/
                form.Show();
            }

        }

        private void BtnTaiKhoanNH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(frmTaiKhoanNganHang));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmTaiKhoanNganHang form = new frmTaiKhoanNganHang();
                /*     form.MdiParent = this;*/
                form.Show();
            }
        }

        private void BtnTaoTaiKhoanKH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(frmTaoTKLoginKH));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmTaoTKLoginKH form = new frmTaoTKLoginKH();
                /*     form.MdiParent = this;*/
                form.Show();
            }
        }

        private void BtnDanhSachKhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(Report.frmDSKH));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                Report.frmDSKH form = new Report.frmDSKH();
                form.MdiParent = this;
                form.Show();
            }
        }

        
    }
}
