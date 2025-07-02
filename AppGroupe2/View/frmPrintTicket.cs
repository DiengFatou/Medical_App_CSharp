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
    public partial class frmPrintTicket : Form
    {
        private AppGroupe2.ServiceMetier.Service1Client service;
        private int idRendezVous;

        public frmPrintTicket(int rendezVousId = 0)
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

        private void frmPrintTicket_Load(object sender, EventArgs e)
        {
            try
            {
                if (service == null)
                {
                    MessageBox.Show("Service non disponible", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                rptTicketRv objRpt = new rptTicketRv();
                objRpt.SetDataSource(GetTableTicket(idRendezVous));
                CrystalReportView1.ReportSource = objRpt;
                CrystalReportView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement du rapport: " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable GetTableTicket(int? idRv = 0)
        {
            DataTable table = new DataTable();
            table.Columns.Add("NomPrenom", typeof(string));
            table.Columns.Add("DateNaissance", typeof(DateTime));
            table.Columns.Add("DateRv", typeof(DateTime));
            table.Columns.Add("Medecin", typeof(string));
            table.Columns.Add("HeureRv", typeof(string));
            table.Columns.Add("DataQr", typeof(byte[]));
            table.Columns.Add("NumeroRecu", typeof(string));
            table.Columns.Add("ReferencePaiement", typeof(string));
            table.Columns.Add("ModePaiement", typeof(string));
            table.Columns.Add("Cout", typeof(decimal));
            table.Columns.Add("Soin", typeof(string));

            try
            {
                if (service == null)
                {
                    table.Rows.Add("Service non disponible", DateTime.Now, DateTime.Now, "Erreur", "", new byte[0], "", "", "", 0, "");
                    return table;
                }

                var leRv = service.GetRendezvousById((int)idRv);

                if (leRv != null)
                {
                    // Récupérer les informations du patient, médecin et soin
                    var patient = leRv.IdPatient.HasValue ? service.GetPatientById(leRv.IdPatient.Value) : null;
                    var medecin = leRv.IdMedecin.HasValue ? service.GetMedecinById(leRv.IdMedecin.Value) : null;
                    var soin = leRv.IdSoin.HasValue ? service.GetSoinById(leRv.IdSoin.Value) : null;
                    string nomPatient = patient?.NomPrenom ?? "Inconnu";
                    DateTime dateNaissance = patient?.DateNaissance ?? DateTime.Now;
                    string nomMedecin = medecin?.NomPrenom ?? "Inconnu";
                    string nomSoin = soin?.Libelle ?? "Inconnu";

                    table.Rows.Add(
                        nomPatient,
                        dateNaissance,
                        leRv.DateRv,
                        nomMedecin,
                        leRv.Horaire,
                        Encoding.UTF8.GetBytes(leRv.NumeroRecu), // Convertir en byte[]
                        leRv.NumeroRecu,
                        leRv.ReferencePaiement,
                        leRv.ModePaiement,
                        leRv.Cout,
                        nomSoin
                    );
                }
                else
                {
                    table.Rows.Add("Rendez-vous non trouvé", DateTime.Now, DateTime.Now, "Inconnu", "", new byte[0], "", "", "", 0, "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la récupération du ticket : " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                table.Rows.Add("Erreur", DateTime.Now, DateTime.Now, "Erreur", "", new byte[0], "", "", "", 0, "");
            }

            return table;
        }

        private void CrystalReportView1_Load(object sender, EventArgs e)
        {
            // Événement de chargement du CrystalReportView
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (service != null)
            {
                try
                {
                    // Essayer de fermer proprement le service
                    if (service.State == System.ServiceModel.CommunicationState.Opened)
                    {
                        service.Close();
                    }
                }
                catch
                {
                    // En cas d'erreur, forcer la fermeture
                    service.Abort();
                }
            }
        }
    
    }
}
