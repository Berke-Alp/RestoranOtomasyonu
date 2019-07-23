using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace RestoranOtomasyonu
{
    public partial class frmMoneyReport : Form
    {
        public DataSet ds = new DataSet();

        public frmMoneyReport()
        {
            InitializeComponent();
        }

        private void frmMoneyReport_Load(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource("HesapRaporu", ds.Tables["Hesap Hareketleri"]);
            reportViewer1.LocalReport.ReportPath = "../../HesapReport.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            frmMoney mn = new frmMoney();
            mn.Show();
            this.Hide();
        }
    }
}
