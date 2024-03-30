using System;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Windows.Forms;

namespace NGANHANG.Report
{
    public partial class frmDSGD : DevExpress.XtraEditors.XtraForm
    {
        DateTime dateTo;
        DateTime dateFrom;

        DateTime now = DateTime.Now;
       
        public frmDSGD()
        {
            InitializeComponent();
        }

        private void frmSaoKe_Load(object sender, EventArgs e)
        {
            /*this.taiKhoanTableAdapter.Connection.ConnectionString = Program.ConnectionStr;
            this.taiKhoanTableAdapter.Fill(this.ds.TaiKhoan);*/

            cmbBrand.DataSource = Program.bdsDSPM;/*sao chep bingding source tu form dang nhap*/
            cmbBrand.DisplayMember = "TENCN";
            cmbBrand.ValueMember = "TENSERVER";
            cmbBrand.SelectedIndex = Program.mCN ;
            if (Program.Role.Trim() == "NGANHANG")
            {
                Program.bdsDSPM.Filter = "TENCN <> 'Khách Hàng' ";
                cmbBrand.Enabled = true;
            }
            else
            {
                cmbBrand.Enabled = false;
            }
           
            ngayBatDau.DateTime = now;
            ngayKetThuc.DateTime = now;
            btnXem.Enabled = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn thật sự muốn hủy thao tác sao kê giao dịch?",
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

        private void ngayBatDau_EditValueChanged(object sender, EventArgs e)
        {
            dateFrom = ngayBatDau.DateTime;
        }

        private void ngayKetThuc_EditValueChanged(object sender, EventArgs e)
        {
            dateTo = ngayKetThuc.DateTime;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            frmChuyenTien chuyenTien = new frmChuyenTien();

            if (dateFrom >= dateTo)
                {
                   MessageBox.Show("Chọn ngày không hợp lệ");
                    
                    return;
                }
            else if (chuyenTien.CheckSoTaiKhoan(txtSoTK.Text.Trim()) == 0)
            {
                MessageBox.Show("Số tài khoản không tồn tại", "Thông báo", MessageBoxButtons.OK);
                txtSoTK.Text = "";
                txtSoTK.Focus();
                return;
                  }    
                else {
                    btnXem.Enabled = true;
                    DSGD report = new DSGD(txtSoTK.Text.Trim(), dateFrom, dateTo);
                    ReportPrintTool printTool = new ReportPrintTool(report);
                    printTool.ShowPreviewDialog();
                    return;
                } 
                                             
             }

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnXem.Enabled = false;
            
            {
                if (cmbBrand.SelectedValue != null)
                {

                    if (cmbBrand.SelectedValue.ToString() != "System.Data.DataRowView")
                    {

                        Program.serverName = cmbBrand.SelectedValue.ToString();
                    }
                    if (cmbBrand.SelectedIndex != Program.mCN)
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

                   
                    }
                }
            }    
        }

       

       

        
        
    }
    