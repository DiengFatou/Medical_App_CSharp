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
        BdRvMedicalContexe db = new BdRvMedicalContexe();
        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            var m =db.Medecins.Find(idMedcin);
            lblMedecin.Text = string.Format("N Ordre: {0}, Nom Prenom:{1}", m.NumeroOrdre, m.NomPrenom);
            lblIdMedecin.Text = m.IDU.ToString();
            lblIdMedecin.Visible = false;
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
                Agenda a = new Agenda
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

                // Ajouter a la base de données
                db.Agenda.Add(a);
                db.SaveChanges();

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
            dgAgenda.DataSource=db.Agenda.Where(a=>a.DatePlanifier>=DateTime.Now ).ToList();

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

                var a = db.Agenda.Find(id);
                if (a == null)
                {
                    MessageBox.Show("Rendez-vous introuvable.", "Erreur", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                a.Creneau = int.Parse(txtCreneau.Text);
                a.HeureFin = txtHeureFin.Text;
                a.HeureDebut = txtHeureDebut.Text;
                a.IdMedecin = idMedcin;
                a.DatePlanifier = txtDateAgenda.Value;
                a.Statut = "Brouillon";
                a.Titre = txtTitre.Text;
                a.Lieu = txtLieu.Text;

                db.SaveChanges();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite : " + ex.Message, "Erreur", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                var a = db.Agenda.Find(id);
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
                txtDateAgenda.Text = a.DatePlanifier.HasValue ? a.DatePlanifier.Value.ToString("yyyy-MM-dd") : "";
                txtTitre.Text = a.Titre;
                txtLieu.Text = a.Lieu;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite : " + ex.Message, "Erreur", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                var a = db.Agenda.Find(id);
                if (a == null)
                {
                    MessageBox.Show("Rendez-vous introuvable.", "Erreur", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                db.Agenda.Remove(a);
                db.SaveChanges();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite : " + ex.Message, "Erreur", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
