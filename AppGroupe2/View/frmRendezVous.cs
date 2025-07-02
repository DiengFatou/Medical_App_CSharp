using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services.Description;
using System.Windows.Forms;
using AppGroupe2.App_Code;
using AppGroupe2.Model;
using MaterielRvMedical.Model;
using AppGroupe2.View;

namespace AppGroupe2.View
{/// <summary>
/// Formulaire  pour la gestion des rendez-vous.
/// Ce formulaire permet de visualiser, ajouter, modifier ou supprimer des rendez-vous planifiés.
/// Il permet aussi de lier un patient à un médecin et de définir un créneau horaire pour chaque rendez-vous.
/// </summary>
    public partial class frmRendezVous : Form
    {
        public int idPatient;

        AppGroupe2.ServiceMetier.Service1Client service;
        Utils utils = new Utils();

        public frmRendezVous()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            
            try
            {
                service = new AppGroupe2.ServiceMetier.Service1Client();
                InitialiserModePaiement();
                InitialiserCout();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion au service: " + ex.Message, "Erreur de Connexion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                utils.WriteDataError("frmRendezVous-Constructor", ex.ToString());
            }
        }

        private void InitialiserModePaiement()
        {
            cbbModePay.Items.Clear();
            cbbModePay.Items.Add("Espèces");
            cbbModePay.Items.Add("Carte");
            cbbModePay.Items.Add("Mobile Money");
            cbbModePay.SelectedIndex = 0;
        }

        private void InitialiserCout()
        {
            cbbCout.Items.Clear();
            cbbCout.Items.Add("3000");
            cbbCout.Items.Add("4000");
            cbbCout.Items.Add("6000");
            cbbCout.Items.Add("8000");
            cbbCout.Items.Add("15000");
            cbbCout.SelectedIndex = 0;
        }
        
        private void ResetForm()
        {
            try
            {
                if (service == null)
                {
                    MessageBox.Show("Service non disponible", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Charger les rendez-vous du patient
                var rendezVous = service.GetListRendezvous()
                    .Where(a => a.DateRv >= DateTime.Now && a.IdPatient == idPatient).ToList();
                dgRendezvous.DataSource = rendezVous;

                // Réinitialiser les champs
                txtNumeroRecu.Text = string.Empty;
                txtReferencePaiement.Text = string.Empty;
                txtCreneauSelectionne.Text = string.Empty;
                dateTimePicker1.Value = DateTime.Now;
                
                // Charger les combobox
                cbbSoin.DataSource = LoadCbbSoin();
                cbbSoin.ValueMember = "Value";
                cbbSoin.DisplayMember = "Text";
                cbbSoin.SelectedIndex = 0;
                
                cbbMedecin.DataSource = LoadCbbMedecin();
                cbbMedecin.ValueMember = "Value";
                cbbMedecin.DisplayMember = "Text";
                cbbMedecin.SelectedIndex = 0;

                txtNumeroRecu.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la réinitialisation: " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                utils.WriteDataError("frmRendezVous-ResetForm", ex.ToString());
            }
        }

        private void ChargerCreneaux()
        {
            try
            {
                if (service == null) return;
                
                var creneaux = service.GetListCreneau()
                    .Select(c => new { c.HeureDebut, c.HeureFin })
                    .ToList();
                dgCreneau.DataSource = creneaux;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement créneaux: " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                utils.WriteDataError("frmRendezVous-ChargerCreneaux", ex.ToString());
            }
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            try
            {
                if (service == null)
                {
                    MessageBox.Show("Service non disponible", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validation des champs obligatoires
                if (string.IsNullOrWhiteSpace(txtReferencePaiement.Text) || string.IsNullOrWhiteSpace(txtNumeroRecu.Text))
                {
                    MessageBox.Show("Veuillez remplir tous les champs obligatoires.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbbMedecin.SelectedValue == null || string.IsNullOrWhiteSpace(cbbMedecin.SelectedValue.ToString()) || cbbMedecin.SelectedIndex == 0)
                {
                    MessageBox.Show("Veuillez sélectionner un médecin valide.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbbSoin.SelectedValue == null || string.IsNullOrWhiteSpace(cbbSoin.SelectedValue.ToString()) || cbbSoin.SelectedIndex == 0)
                {
                    MessageBox.Show("Veuillez sélectionner un soin valide.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCreneauSelectionne.Text))
                {
                    MessageBox.Show("Veuillez sélectionner un créneau horaire.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var rv = new MaterielRvMedical.Model.RendezVous
                {
                    DateRv = dateTimePicker1.Value,
                    ReferencePaiement = txtReferencePaiement.Text.Trim(),
                    NumeroRecu = txtNumeroRecu.Text.Trim(),
                    ModePaiement = cbbModePay.SelectedItem.ToString(),
                    Cout = decimal.Parse(cbbCout.SelectedItem.ToString()),
                    IdMedecin = int.Parse(cbbMedecin.SelectedValue.ToString()),
                    IdSoin = int.Parse(cbbSoin.SelectedValue.ToString()),
                    Horaire = txtCreneauSelectionne.Text.Trim(),
                    IdPatient = idPatient
                };

                if (service.AddRendezvous(rv))
                {
                    MessageBox.Show("Rendez-vous ajouté avec succès !", "Succès",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Demander si l'utilisateur veut imprimer le reçu
                    if (MessageBox.Show("Voulez-vous imprimer le reçu ?", "Impression du Reçu",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ImprimerRecu(rv);
                    }
                    
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Échec de l'ajout du rendez-vous", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout: " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                utils.WriteDataError("frmRendezVous-btnValider_Click", ex.ToString());
            }
        }

        private void ImprimerRecu(MaterielRvMedical.Model.RendezVous rendezVous)
        {
            try
            {
                // Récupérer l'ID du rendez-vous nouvellement créé
                var rendezVousList = service.GetListRendezvous()
                    .Where(r => r.NumeroRecu == rendezVous.NumeroRecu && r.IdPatient == rendezVous.IdPatient)
                    .OrderByDescending(r => r.DateRv)
                    .FirstOrDefault();

                if (rendezVousList != null)
                {
                    frmPrintTicket frmRecu = new frmPrintTicket(rendezVousList.IdRv);
                    frmRecu.Show();
                }
                else
                {
                    MessageBox.Show("Impossible de récupérer les informations du rendez-vous pour l'impression.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'impression du reçu: " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                utils.WriteDataError("frmRendezVous-ImprimerRecu", ex.ToString());
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgRendezvous.CurrentRow == null)
                {
                    MessageBox.Show("Veuillez sélectionner un rendez-vous", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(dgRendezvous.CurrentRow.Cells[0].Value.ToString());
                var rv = service.GetRendezvousById(id);

                if (rv != null)
                {
                    rv.DateRv = dateTimePicker1.Value;
                    rv.ReferencePaiement = txtReferencePaiement.Text;
                    rv.NumeroRecu = txtNumeroRecu.Text;
                    rv.ModePaiement = cbbModePay.SelectedItem.ToString();
                    rv.Cout = decimal.Parse(cbbCout.SelectedItem.ToString());
                    rv.IdMedecin = int.Parse(cbbMedecin.SelectedValue.ToString());
                    rv.IdSoin = int.Parse(cbbSoin.SelectedValue.ToString());
                    rv.Horaire = txtCreneauSelectionne.Text;

                    if (service.UpdateRendezvous(rv))
                    {
                        MessageBox.Show("Rendez-vous modifié avec succès", "Succès",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetForm();
                    }
                    else
                    {
                        MessageBox.Show("Échec de la modification", "Erreur",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification: " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                utils.WriteDataError("frmRendezVous-btnModifier_Click", ex.ToString());
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgRendezvous.CurrentRow == null)
                {
                    MessageBox.Show("Veuillez sélectionner un rendez-vous", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(dgRendezvous.CurrentRow.Cells[0].Value.ToString());

                if (MessageBox.Show("Confirmez-vous la suppression ?", "Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (service.DeleteRendezvous(id))
                    {
                        MessageBox.Show("Rendez-vous supprimé avec succès", "Succès",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetForm();
                    }
                    else
                    {
                        MessageBox.Show("Échec de la suppression", "Erreur",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression: " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                utils.WriteDataError("frmRendezVous-btnSupprimer_Click", ex.ToString());
            }
        }

        private void GenererNumeroRecu()
        {
            txtNumeroRecu.Text = "REC-" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        private void dgCreneau_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var heureDebut = dgCreneau.Rows[e.RowIndex].Cells["HeureDebut"].Value?.ToString();
                    var heureFin = dgCreneau.Rows[e.RowIndex].Cells["HeureFin"].Value?.ToString();

                    if (!string.IsNullOrEmpty(heureDebut) && !string.IsNullOrEmpty(heureFin))
                    {
                        txtCreneauSelectionne.Text = $"{heureDebut} - {heureFin}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur sélection créneau: " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            // Réinitialisation des champs
            txtNumeroRecu.Clear();
            cbbModePay.SelectedIndex = 0;
            cbbSoin.SelectedIndex = -1;
            cbbMedecin.SelectedIndex = -1;
            txtCreneauSelectionne.Clear();
            txtReferencePaiement.Clear();
        }

        private void frmRendezVous_Load(object sender, EventArgs e)
        {
            try
            {
                var p = service.GetPatientById(idPatient);
                if (p != null)
                {
                    lblPatient.Text = $"N° Telephone: {p.Tel}, Nom Prenom: {p.NomPrenom}";
                    lblIdPatient.Text = p.IDU.ToString();
                    lblIdPatient.Visible = false;
                }

                ResetForm();
                ChargerCreneaux();
                GenererNumeroRecu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur au chargement: " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                utils.WriteDataError("frmRendezVous-frmRendezVous_Load", ex.ToString());
            }
        }

        private void btnGenerer_Click(object sender, EventArgs e)
        {
            GenererNumeroRecu();
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            frmPatient rv = new frmPatient();
            rv.Show();
        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            frmAgenda f = new frmAgenda();
            f.Show();
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimerRecu_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgRendezvous.CurrentRow == null)
                {
                    MessageBox.Show("Veuillez sélectionner un rendez-vous", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(dgRendezvous.CurrentRow.Cells[0].Value.ToString());
                frmPrintTicket frmRecu = new frmPrintTicket(id);
                frmRecu.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'impression du reçu: " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                utils.WriteDataError("frmRendezVous-btnImprimerRecu_Click", ex.ToString());
            }
        }

        private List<SelectListViewModel> LoadCbbSoin()
        {
            try
            {
                var soins = service.GetListSoin();
                var liste = new List<SelectListViewModel>
                {
                    new SelectListViewModel { Text = "Selection....", Value = "" }
                };

                liste.AddRange(soins.Select(s => new SelectListViewModel
                {
                    Text = s.Libelle,
                    Value = s.IdSoin.ToString()
                }));

                return liste;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement soins: " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<SelectListViewModel>();
            }
        }

        private List<SelectListViewModel> LoadCbbMedecin()
        {
            try
            {
                var medecins = service.GetListMedecin();
                var liste = new List<SelectListViewModel>
                {
                    new SelectListViewModel { Text = "Selection....", Value = "" }
                };

                liste.AddRange(medecins.Select(m => new SelectListViewModel
                {
                    Text = m.NomPrenom,
                    Value = m.IDU.ToString()
                }));

                return liste;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement médecins: " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<SelectListViewModel>();
            }
        }
    }
}
