using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppGroupe2.App_Code;
using AppGroupe2.Model;
using MaterielRvMedical.Model;

namespace AppGroupe2.View
{
    public partial class frmAgenda : Form
    {
        public int idMedcin;
        Utils utils = new Utils();

        /// <summary>
        /// Formulaire pour la gestion des rendez-vous des médecins.
        /// Ce formulaire permet de gérer les rendez-vous planifiés dans l'agenda.
        /// </summary>
        public frmAgenda()
        {

            /// <summary>
            /// Constructeur de la classe.
            /// Initialise les composants du formulaire et définit sa position au centre de l'écran.
            /// </summary>
            /// 
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        //BdRvMedicalContexe db = new BdRvMedicalContexe();
        AppGroupe2.ServiceMetier.Service1Client service = new AppGroupe2.ServiceMetier.Service1Client();
        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            var m = service.GetMedecinById(idMedcin);
            lblMedecin.Text = string.Format("N Ordre: {0}, Nom Prenom:{1}", m.NumeroOrdre, m.NomPrenom);
            lblIdMedecin.Text = m.IDU.ToString();
            lblIdMedecin.Visible = false;

            try
            {
                var agendas = service.GetListAgenda()
                                  .Where(a => a.IdMedecin == idMedcin &&
                                            a.DatePlanifier >= DateTime.Now.Date)
                                  .OrderBy(a => a.DatePlanifier)
                                  .ThenBy(a => a.HeureDebut)
                                  .ToList();

                dgAgenda.DataSource = agendas;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                utils.WriteDataError("frmAgenda-LoadAgendas", ex.ToString());
            }
            ResetForm();

        }
        
        /// <summary>
        /// Cette méthode permet d'ajouter un nouvel agenda dans la base de données
        /// Elle vérifie que les champs sont remplis et que les données sont valides avant l'ajout.
        /// </summary>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                // Vérifier que les champs obligatoires sont remplis
                if (string.IsNullOrWhiteSpace(txtCreneau.Text) || string.IsNullOrWhiteSpace(txtHeureFin.Text) || 
                    string.IsNullOrWhiteSpace(txtHeureDebut.Text) || string.IsNullOrWhiteSpace(txtTitre.Text) || 
                    string.IsNullOrWhiteSpace(txtLieu.Text))
                {
                    MessageBox.Show("Tous les champs doivent être remplis.", "Erreur", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Vérifier que Creneau est un nombre entier valide
                int creneau;
                if (!int.TryParse(txtCreneau.Text, out creneau))
                {
                    MessageBox.Show("Le créneau doit être un nombre entier.", "Erreur", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Créer un nouvel objet Agenda
                MaterielRvMedical.Model.Agenda a = new MaterielRvMedical.Model.Agenda()
                {
                    Creneau = creneau,
                    HeureFin = txtHeureFin.Text,
                    HeureDebut = txtHeureDebut.Text,
                    IdMedecin = idMedcin,
                    DatePlanifier = txtDateAgenda.Value,
                    Statut = "Brouillon",
                    Titre = txtTitre.Text,
                    Lieu = txtLieu.Text
                };

                service.AddAgenda(a);

                // Reinitialiser le formulaire après ajout
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors de l'ajout : " + ex.Message, "Erreur", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                utils.WriteDataError("frmAgenda-btnAjouter_Click", ex.ToString());
            }finally
            {
                ResetForm();
            }
        }
        /// <summary>
        /// Réinitialise tous les champs du formulaire à leurs valeurs par défaut.
         /// </summary>
        private void ResetForm()
        {
            dgAgenda.DataSource=service.GetListAgenda().Where(a=>a.DatePlanifier>=DateTime.Now ).ToList();

            txtCreneau.Text = string.Empty;
            txtDateAgenda.Value = DateTime.Now;
            txtHeureDebut.Text= string.Empty;
            txtHeureFin.Text = string.Empty;
            txtLieu.Text = string.Empty;
            txtTitre.Text = string.Empty;
            txtTitre.Focus();
            
        }


        private void btnModifier_Click(object sender, EventArgs e)
        {
 
            try
            {
                if (dgAgenda.CurrentRow == null)
                {
                    MessageBox.Show("Sélectionnez un rendez-vous avant de modifier.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id;
                if (!int.TryParse(dgAgenda.CurrentRow.Cells[0].Value.ToString(), out id))
                {
                    MessageBox.Show("ID invalide.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Récupérer l'agenda existant
                var a = service.GetAgendaById(id);
                if (a == null)
                {
                    MessageBox.Show("Rendez-vous introuvable.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validation des heures
                if (!TimeSpan.TryParse(txtHeureDebut.Text, out _) || !TimeSpan.TryParse(txtHeureFin.Text, out _))
                {
                    MessageBox.Show("Format d'heure invalide (utilisez HH:MM).", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Mise à jour des propriétés
                a.Creneau = int.Parse(txtCreneau.Text);
                a.HeureFin = txtHeureFin.Text;
                a.HeureDebut = txtHeureDebut.Text;
                a.DatePlanifier = txtDateAgenda.Value;
                a.Titre = txtTitre.Text;
                a.Lieu = txtLieu.Text;

                if (service.UpdateAgenda(a))
                {
                    MessageBox.Show("Rendez-vous modifié avec succès.", "Succès",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Échec de la modification.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                utils.WriteDataError("frmAgenda-btnModifier_Click", ex.ToString());
            }
        
        }


        private void btnChoisir_Click(object sender, EventArgs e)
        {
          
            try
            {
                if (dgAgenda.CurrentRow == null)
                {
                    MessageBox.Show("Sélectionnez un rendez-vous.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id;
                if (!int.TryParse(dgAgenda.CurrentRow.Cells[0].Value.ToString(), out id))
                {
                    MessageBox.Show("ID invalide.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Récupérer l'agenda existant depuis le service
                var a = service.GetAgendaById(id);
                if (a == null)
                {
                    MessageBox.Show("Rendez-vous introuvable.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                txtCreneau.Text = a.Creneau.ToString();
                txtHeureFin.Text = a.HeureFin;
                txtHeureDebut.Text = a.HeureDebut;
                idMedcin = a.IdMedecin;
                txtDateAgenda.Value = a.DatePlanifier ?? DateTime.Now;
                txtTitre.Text = a.Titre;
                txtLieu.Text = a.Lieu;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la récupération: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                utils.WriteDataError("frmAgenda-btnChoisir_Click", ex.ToString());
            }
        
        }


        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgAgenda.CurrentRow == null)
                {
                    MessageBox.Show("Sélectionnez un rendez-vous avant de supprimer.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id;
                if (!int.TryParse(dgAgenda.CurrentRow.Cells[0].Value.ToString(), out id))
                {
                    MessageBox.Show("ID invalide.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Voulez-vous vraiment supprimer ce rendez-vous?", "Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (service.DeleteAgenda(id))
                    {
                        MessageBox.Show("Rendez-vous supprimé avec succès.", "Succès",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetForm();
                    }
                    else
                    {
                        MessageBox.Show("Échec de la suppression.", "Erreur",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                utils.WriteDataError("frmAgenda-btnSupprimer_Click", ex.ToString());
            }
        
    }

        private bool ValidateHeures()
        {
            if (!TimeSpan.TryParse(txtHeureDebut.Text, out TimeSpan debut) ||
                !TimeSpan.TryParse(txtHeureFin.Text, out TimeSpan fin))
            {
                MessageBox.Show("Format d'heure invalide (utilisez HH:MM).", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (debut >= fin)
            {
                MessageBox.Show("L'heure de début doit être avant l'heure de fin.", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
