using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using AppGroupe2.App_Code;
using MaterielRvMedical.Model;

namespace AppGroupe2.View
{
    public partial class frmPatient : Form
    {
        public int idPatient;
        Utils utils = new Utils();
        AppGroupe2.ServiceMetier.Service1Client service = new AppGroupe2.ServiceMetier.Service1Client();

        public frmPatient()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void ResetForm()
        {
            txtNomPrenom.Text = string.Empty;
            txtAdresse.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPoid.Text = string.Empty;
            txtTaille.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;
            cbbGroupeSanguin.SelectedIndex = 0;
            LoadPatients();
            txtNomPrenom.Focus();
        }

        private bool ValidatePatientData()
        {
            if (string.IsNullOrWhiteSpace(txtNomPrenom.Text) ||
                string.IsNullOrWhiteSpace(txtAdresse.Text) ||
                string.IsNullOrWhiteSpace(txtTelephone.Text))
            {
                MessageBox.Show("Les champs Nom/Prénom, Adresse et Téléphone sont obligatoires.", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!float.TryParse(txtPoid.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out float poids) ||
                !float.TryParse(txtTaille.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out float taille))
            {
                MessageBox.Show("Poids et Taille doivent être des nombres valides.", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidatePatientData())
                    return;

                var p = new Patient()
                {
                    NomPrenom = txtNomPrenom.Text,
                    Adresse = txtAdresse.Text,
                    Tel = txtTelephone.Text,
                    Email = txtEmail.Text,
                    Poids = float.Parse(txtPoid.Text, CultureInfo.InvariantCulture),
                    Taille = float.Parse(txtTaille.Text, CultureInfo.InvariantCulture),
                    IdGroupeSanguin = int.TryParse(cbbGroupeSanguin.SelectedValue?.ToString(), out int id) ? id : (int?)null,
                    DateNaissance = dateTimePicker1.Value
                };

                if (service.AddPatient(p))
                {
                    MessageBox.Show("Patient ajouté avec succès.", "Succès",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Échec de l'ajout du patient.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                utils.WriteDataError("frmPatient-btnAjouter_Click", ex.ToString());
            }
        }

        private void frmPatient_Load(object sender, EventArgs e)
        {
            try
            {
                cbbGroupeSanguin.DataSource = LoadCbbGroupesanguin();
                cbbGroupeSanguin.ValueMember = "Value";
                cbbGroupeSanguin.DisplayMember = "Text";
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                utils.WriteDataError("frmPatient-Load", ex.ToString());
            }
        }

        private void LoadPatients()
        {
            try
            {
                var patients = service.GetListPatient()
                    .OrderBy(p => p.NomPrenom)
                    .ToList();

                dgPatient.DataSource = patients.Select(p => new
                {
                    p.IDU,
                    p.NomPrenom,
                    p.Adresse,
                    p.Tel,
                    p.Email,
                    p.Poids,
                    p.Taille,
                    GroupeSanguin = p.GroupeSanguin?.CodeGroupeSanguin ?? "",
                    DateNaissance = p.DateNaissance?.ToString("dd/MM/yyyy") ?? ""
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des patients: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChoisir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgPatient.CurrentRow == null)
                {
                    MessageBox.Show("Sélectionnez un patient.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(dgPatient.CurrentRow.Cells[0].Value.ToString(), out int id))
                {
                    MessageBox.Show("ID invalide.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var p = service.GetPatientById(id);
                if (p == null)
                {
                    MessageBox.Show("Patient introuvable.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                txtNomPrenom.Text = p.NomPrenom;
                txtAdresse.Text = p.Adresse;
                txtTelephone.Text = p.Tel;
                txtEmail.Text = p.Email;
                txtPoid.Text = p.Poids?.ToString(CultureInfo.InvariantCulture) ?? "";
                txtTaille.Text = p.Taille?.ToString(CultureInfo.InvariantCulture) ?? "";
                dateTimePicker1.Value = p.DateNaissance ?? DateTime.Now;
                cbbGroupeSanguin.SelectedValue = p.IdGroupeSanguin?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la récupération: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                utils.WriteDataError("frmPatient-btnChoisir_Click", ex.ToString());
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgPatient.CurrentRow == null)
                {
                    MessageBox.Show("Sélectionnez un patient avant de modifier.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidatePatientData())
                    return;

                if (!int.TryParse(dgPatient.CurrentRow.Cells[0].Value.ToString(), out int id))
                {
                    MessageBox.Show("ID invalide.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var p = service.GetPatientById(id);
                if (p == null)
                {
                    MessageBox.Show("Patient introuvable.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                p.NomPrenom = txtNomPrenom.Text;
                p.Adresse = txtAdresse.Text;
                p.Tel = txtTelephone.Text;
                p.Email = txtEmail.Text;
                p.Poids = float.Parse(txtPoid.Text, CultureInfo.InvariantCulture);
                p.Taille = float.Parse(txtTaille.Text, CultureInfo.InvariantCulture);
                p.IdGroupeSanguin = int.TryParse(cbbGroupeSanguin.SelectedValue?.ToString(), out int idGroupe) ? idGroupe : (int?)null;
                p.DateNaissance = dateTimePicker1.Value;

                if (service.UpdatePatient(p))
                {
                    MessageBox.Show("Patient modifié avec succès.", "Succès",
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
                utils.WriteDataError("frmPatient-btnModifier_Click", ex.ToString());
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgPatient.CurrentRow == null)
                {
                    MessageBox.Show("Sélectionnez un patient avant de supprimer.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(dgPatient.CurrentRow.Cells[0].Value.ToString(), out int id))
                {
                    MessageBox.Show("ID invalide.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Voulez-vous vraiment supprimer ce patient?", "Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (service.DeletePatient(id))
                    {
                        MessageBox.Show("Patient supprimé avec succès.", "Succès",
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
                utils.WriteDataError("frmPatient-btnSupprimer_Click", ex.ToString());
            }
        }

        private List<SelectListViewModel> LoadCbbGroupesanguin()
        {
            try
            {
                var groupes = service.GetAllGroupesSanguins();
                var liste = new List<SelectListViewModel>
                {
                    new SelectListViewModel { Text = "Sélectionnez...", Value = "" }
                };

                liste.AddRange(groupes.Select(g => new SelectListViewModel
                {
                    Text = g.CodeGroupeSanguin,
                    Value = g.IdGroupeSanguin.ToString()
                }));

                return liste;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement groupes sanguins: " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                utils.WriteDataError("frmPatient-LoadCbbGroupesanguin", ex.ToString());
                return new List<SelectListViewModel>();
            }
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            try
            {
                var patients = service.GetListPatient().AsQueryable();

                if (!string.IsNullOrEmpty(txtREmail.Text))
                {
                    patients = patients.Where(p => p.Email != null &&
                        p.Email.ToUpper().Contains(txtREmail.Text.ToUpper()));
                }

                if (!string.IsNullOrEmpty(txtRTel.Text))
                {
                    patients = patients.Where(p => p.Tel != null && p.Tel.Contains(txtRTel.Text));
                }

                dgPatient.DataSource = patients.Select(p => new
                {
                    p.IDU,
                    p.NomPrenom,
                    p.Adresse,
                    p.Tel,
                    p.Email,
                    p.Poids,
                    p.Taille,
                    GroupeSanguin = p.GroupeSanguin != null ? p.GroupeSanguin.CodeGroupeSanguin : "",
                    DateNaissance = p.DateNaissance.HasValue ? p.DateNaissance.Value.ToString("dd/MM/yyyy") : ""
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la recherche: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                utils.WriteDataError("frmPatient-btnRechercher_Click", ex.ToString());
            }
        }


        private void btnRv_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgPatient.CurrentRow == null)
                {
                    MessageBox.Show("Sélectionnez un patient avant de créer un rendez-vous.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(dgPatient.CurrentRow.Cells[0].Value.ToString(), out int id))
                {
                    MessageBox.Show("ID invalide.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                frmRendezVous f = new frmRendezVous();
                f.idPatient = id;
                f.Show();
                this.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ouverture du formulaire de rendez-vous: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                utils.WriteDataError("frmPatient-btnRv_Click", ex.ToString());
            }
        }
    }

    public class SelectListViewModel
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}