using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppGroupe2.Model;
using AppGroupe2.Report;
using CrystalDecisions.Windows.Forms;

namespace AppGroupe2.View
{
    public partial class frmPrintTicket : Form
    {
        public frmPrintTicket()
        {
            InitializeComponent();
        }

       BdRvMedicalContexe db = new BdRvMedicalContexe();

        private void frmPrintTicket_Load(object sender, EventArgs e)
        {
            rptTicketRv objRpt = new rptTicketRv();

            objRpt.SetDataSource(GetTableTicket(0));
            CrystalReportView1.ReportSource = objRpt;
            CrystalReportView1.Refresh();
        }
        public DataTable GetTableTicket(int? idRv = 0)
        {
            DataTable table  = new DataTable();
            table.Columns.Add("NomPrenom", typeof(string));
            table.Columns.Add("DateNaissance", typeof(DateTime));
            table.Columns.Add("DateRv",typeof(DateTime));
            table.Columns.Add("Medecin", typeof(string));
            table.Columns.Add("HeureRv", typeof(string));
            table.Columns.Add("DataQr", typeof(byte));
            var leRv = db.RendezVous.Where(a => a.IdRv== idRv).FirstOrDefault();
            if (leRv != null)
            {
                table.Rows.Add(leRv.Patient.NomPrenom, leRv.Patient.DateNaissance, leRv.DateRv, leRv.Medecin.NomPrenom);
            }else
            {
                table.Rows.Add("NomPrenom", DateTime.Now, DateTime.Now, "NomPrenom", new byte[0]);

            }
            return table;

        }

        private void CrystalReportView1_Load(object sender, EventArgs e)
        {

        }
    }
}
