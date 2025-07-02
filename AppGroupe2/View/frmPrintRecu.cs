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
using AppGroupe2.ServiceMetier;
using CrystalDecisions.Windows.Forms;

namespace AppGroupe2.View
{
    public partial class frmPrintRecu : Form
    {
        private AppGroupe2.ServiceMetier.Service1Client service;
        private int idRendezVous;

        public frmPrintRecu(int rendezVousId = 0)
        {
            InitializeComponent();
            idRendezVous = rendezVousId;
            
            try
            {
                service = new AppGroupe2.ServiceMetier.Service1Client();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion au service: " + ex.Message, "Erreur de Connexion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmPrintRecu_Load(object sender, EventArgs e)
        {
            try
            {
                if (service == null)
                {
                    MessageBox.Show("Service non disponible", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                RecuRvMedical objRpt = new RecuRvMedical();
                objRpt.SetDataSource(GetTableRecu(idRendezVous));
                crystalReportViewer1.ReportSource = objRpt;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement du rapport: " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable GetTableRecu(int? idRv = 0)
        {
            DataTable table = new DataTable();
            table.Columns.Add("NomPrenom", typeof(string));
            table.Columns.Add("DateNaissance", typeof(DateTime));
            table.Columns.Add("Tel", typeof(string));
            table.Columns.Add("DateRv", typeof(DateTime));
            table.Columns.Add("Medecin", typeof(string));
            table.Columns.Add("HeureRv", typeof(string));
            table.Columns.Add("NumeroRecu", typeof(string));
            table.Columns.Add("ReferencePaiement", typeof(string));
            table.Columns.Add("ModePaiement", typeof(string));
            table.Columns.Add("Cout", typeof(decimal));
            table.Columns.Add("Soin", typeof(string));
            table.Columns.Add("DateImpression", typeof(DateTime));

            try
            {
                if (service == null)
                {
                    table.Rows.Add("Service non disponible", DateTime.Now, "", DateTime.Now, "Erreur", "", "", "", "", 0, "", DateTime.Now);
                    return table;
                }

                var leRv = service.GetRendezvousById((int)idRv);

                if (leRv != null)
                {
                    // Récupérer les informations du patient et du médecin
                    var patient = service.GetPatientById(leRv.IdPatient);
                    var medecin = service.GetMedecinById(leRv.IdMedecin);
                    var soin = service.GetSoinById(leRv.IdSoin);

                    string nomPatient = patient?.NomPrenom ?? "Inconnu";
                    DateTime dateNaissance = patient?.DateNaissance ?? DateTime.Now;
                    string telephone = patient?.Tel ?? "";
                    string nomMedecin = medecin?.NomPrenom ?? "Inconnu";
                    string nomSoin = soin?.Libelle ?? "Inconnu";

                    table.Rows.Add(
                        nomPatient,
                        dateNaissance,
                        telephone,
                        leRv.DateRv,
                        nomMedecin,
                        leRv.Horaire,
                        leRv.NumeroRecu,
                        leRv.ReferencePaiement,
                        leRv.ModePaiement,
                        leRv.Cout,
                        nomSoin,
                        DateTime.Now
                    );
                }
                else
                {
                    table.Rows.Add("Rendez-vous non trouvé", DateTime.Now, "", DateTime.Now, "Inconnu", "", "", "", "", 0, "", DateTime.Now);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la récupération du reçu : " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                table.Rows.Add("Erreur", DateTime.Now, "", DateTime.Now, "Erreur", "", "", "", "", 0, "", DateTime.Now);
            }

            return table;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            // Événement de chargement du CrystalReportView
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (service != null)
            {
                service.Dispose();
            }
        }
    }
} 