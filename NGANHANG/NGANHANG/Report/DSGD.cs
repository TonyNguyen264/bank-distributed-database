
using System;


namespace NGANHANG.Report
{
    public partial class DSGD : DevExpress.XtraReports.UI.XtraReport
    {
        public DSGD(string txtSTK, DateTime dateFrom, DateTime dateTo)
        {
            InitializeComponent();
            var query = this.sqlDataSource1.Queries[0];
            query.Parameters[0].Value = txtSTK;
            query.Parameters[1].Value = dateFrom.Date.ToString("yyyy-MM-dd");
            query.Parameters[2].Value = dateTo.Date.ToString("yyyy-MM-dd");
            //query.Parameters[3].Value = type;
            this.sqlDataSource1.Fill();

            //lbBrandName.Text = brandName;
            //lbTransType.Text = typeName;
            lbSTK.Text = txtSTK;
            lbDate.Text = dateFrom.Date.ToString("d") + " - " + dateTo.Date.ToString("d");
        }

    }
}

     