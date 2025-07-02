//using AppGroupe2.Migrations;
using AppGroupe2.App_Code;
using AppGroupe2.Helper;
using AppGroupe2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BdRvMedicalContexe = AppGroupe2.Model.BdRvMedicalContexe;
using MaterielRvMedical.Model;

namespace AppGroupe2.View
{
    /// <summary>
    /// Formulaire  pour la gestion des m�decins.
    /// Ce formulaire permet d'afficher, d'ajouter, de modifier et de supprimer des m�decins.
    /// Il affiche �galement les informations d�taill�es sur les m�decins.
    /// </summary>
    public partial class frmMedecin : Form
       
    {
        //BdRvMedicalContexe db=new BdRvMedicalContexe();
        AppGroupe2.ServiceMetier.Service1Client service = new AppGroupe2.ServiceMetier.Service1Client();
        Utils utils = new Utils();


        public frmMedecin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

      
        private void ResetForm()
        {
            try
            {
                txtAdresse.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtIdentifiant.Text = string.Empty;
                txtNomPrenom.Text = string.Empty;
                txtNumeroOrdreMedecin.Text = string.Empty;
                cbbSpecialite.SelectedValue = string.Empty;
                txtTelephone.Text = string.Empty;
                cbbSpecialite.DataSource = LoadCbbSpecialite();
                cbbSpecialite.ValueMember = "Value";
                cbbSpecialite.DisplayMember = "Text";
                txtNomPrenom.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la r�initialisation: " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                utils.WriteDataError("frmMedecin-ResetForm", ex.ToString());
            }
        }

        private void btnChoisir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgMedecin.CurrentRow == null) return;

                int id = int.Parse(dgMedecin.CurrentRow.Cells[0].Value.ToString());
                var m = service.GetMedecinById(id);

                if (m != null)
                {
                    txtAdresse.Text = m.Adresse;
                    txtEmail.Text = m.Email;
                    txtIdentifiant.Text = m.Identifiant;
                    txtNomPrenom.Text = m.NomPrenom;
                    txtNumeroOrdreMedecin.Text = m.NumeroOrdre;
                    cbbSpecialite.SelectedValue = m.IdSpecialite;
                    txtTelephone.Text = m.Tel;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la s�lection: " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                utils.WriteDataError("frmMedecin-btnChoisir_Click", ex.ToString());
            }
        }

        

       

        private void frmMedecin_Load(object sender, EventArgs e)
        {
            try
            {
                ResetForm();
                LoadMedecins();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur au chargement: " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                utils.WriteDataError("frmMedecin-frmMedecin_Load", ex.ToString());
            }
        }

        private List<SelectListViewModel> LoadCbbSpecialite()
        {
            try
            {
                var specialites = service.GetAllSpecialites(); // � impl�menter dans le service si n�cessaire
                List<SelectListViewModel> liste = new List<SelectListViewModel>();

                liste.Add(new SelectListViewModel { Text = "Selection....", Value = "" });

                foreach (var c in specialites)
                {
                    liste.Add(new SelectListViewModel { Text = c.NomSpecialite, Value = c.IdSpecialite.ToString() });
                }

                return liste;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement sp�cialit�s: " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                utils.WriteDataError("frmMedecin-LoadCbbSpecialite", ex.ToString());
                return new List<SelectListViewModel>();
            }
        }
        private void LoadMedecins()
        {
            try
            {
                dgMedecin.DataSource = service.GetListMedecin();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement m�decins: " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                utils.WriteDataError("frmMedecin-LoadMedecins", ex.ToString());
            }
        }
        private void btnAgenda_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgMedecin.CurrentRow == null) return;

                int idMedcin = int.Parse(dgMedecin.CurrentRow.Cells[0].Value.ToString());
                frmAgenda a = new frmAgenda();
                a.idMedcin = idMedcin;
                a.Show();
                this.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur ouverture agenda: " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                utils.WriteDataError("frmMedecin-btnAgenda_Click", ex.ToString());
            }
        }

        private void dgMedecin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgMedecin.CurrentRow == null) return;

                int id = int.Parse(dgMedecin.CurrentRow.Cells[0].Value.ToString());
                var m = service.GetMedecinById(id);

                if (m != null)
                {
                    m.Adresse = txtAdresse.Text;
                    m.NumeroOrdre = txtNumeroOrdreMedecin.Text;
                    m.Email = txtEmail.Text;
                    m.NomPrenom = txtNomPrenom.Text;
                    m.Tel = txtTelephone.Text;
                    m.IdSpecialite = int.Parse(cbbSpecialite.SelectedValue.ToString());
                    m.Identifiant = txtIdentifiant.Text;

                    if (service.UpdateMedecin(m))
                    {
                        MessageBox.Show("M�decin modifi� avec succ�s", "Succ�s", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetForm();
                    }
                    else
                    {
                        MessageBox.Show("�chec de la modification", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur modification: " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                utils.WriteDataError("frmMedecin-btnModifier_Click", ex.ToString());
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgMedecin.CurrentRow == null) return;

                int id = int.Parse(dgMedecin.CurrentRow.Cells[0].Value.ToString());

                if (MessageBox.Show("Confirmez-vous la suppression ?", "Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (service.DeleteMedecin(id))
                    {
                        MessageBox.Show("M�decin supprim� avec succ�s", "Succ�s", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetForm();
                    }
                    else
                    {
                        MessageBox.Show("�chec de la suppression", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur suppression: " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                utils.WriteDataError("frmMedecin-btnSupprimer_Click", ex.ToString());
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(txtNomPrenom.Text))
                {
                    MessageBox.Show("Le nom est obligatoire", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var m = new MaterielRvMedical.Model.Medecin
                {
                    Adresse = txtAdresse.Text,
                    NumeroOrdre = txtNumeroOrdreMedecin.Text,
                    Email = txtEmail.Text,
                    NomPrenom = txtNomPrenom.Text,
                    Tel = txtTelephone.Text,
                    IdSpecialite = cbbSpecialite.SelectedValue != null ? int.Parse(cbbSpecialite.SelectedValue.ToString()) : 0,
                    Identifiant = txtIdentifiant.Text,
                    Status = true,
                    MotDePasse = CryptString.GetMd5Hash("Passer@123")
                };

                if (service.AddMedecin(m))
                {
                    MessageBox.Show("M�decin ajout� avec succ�s", "Succ�s", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMedecins();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("�chec de l'ajout", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur ajout: " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                utils.WriteDataError("frmMedecin-btnAjouter_Click", ex.ToString());
            }
        }

    }
}
