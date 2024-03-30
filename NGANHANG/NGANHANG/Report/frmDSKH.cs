using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System;
namespace NGANHANG.Report
{
    public partial class frmDSKH : DevExpress.XtraEditors.XtraForm
    {
        public frmDSKH()
        {
            InitializeComponent();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            { 
                DSKH report = new DSKH();
                ReportPrintTool printTool = new ReportPrintTool(report);
                printTool.ShowPreviewDialog();
            }
            catch (System.Exception ex)
            {
              
                throw ex;
            }
        }
    }
}