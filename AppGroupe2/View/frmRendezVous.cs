using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services.Description;
using System.Windows.Forms;
using AppGroupe2.Model;
using BdRvMedicalContexe = AppGroupe2.Model.BdRvMedicalContexe;

namespace AppGroupe2.View
{/// <summary>
/// Formulaire  pour la gestion des rendez-vous.
/// Ce formulaire permet de visualiser, ajouter, modifier ou supprimer des rendez-vous planifiés.
/// Il permet aussi de lier un patient à un médecin et de définir un créneau horaire pour chaque rendez-vous.
/// </summary>
    public partial class frmRendezVous : Form
    {
        public int idPatient;

        BdRvMedicalContexe db = new BdRvMedicalContexe();

        public frmRendezVous()
        {
            InitializeComponent();
            InitialiserModePaiement();
            InitialiserCout();
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
            dgRendezvous.DataSource = db.RendezVous.Where(a => a.DateRv >= DateTime.Now && a.IdPatient == idPatient ).ToList();

            txtNumeroRecu.Text = string.Empty;
            txtReferencePaiement.Text = string.Empty;
            txtCreneauSelectionne.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;
            cbbSoin.SelectedValue = string.Empty;
            cbbSoin.DataSource = LoadCbbSoin();
            cbbSoin.ValueMember = "Value";
            cbbSoin.DisplayMember = "Text";
            cbbMedecin.SelectedValue = string.Empty;
            cbbMedecin.DataSource = LoadCbbMedecin();
            cbbMedecin.ValueMember = "Value";
            cbbMedecin.DisplayMember = "Text";

            txtNumeroRecu.Focus();
        }
        //private void ChargerSoins()
        //{
        //    try
        //    {
        //        var soins = db.Soins.Select(s => new { s.IdSoin, s.Libelle }).ToList();
        //        if (soins.Count == 0)
        //        {
        //            MessageBox.Show("Aucun soin trouvé.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        else
        //        {
        //            cbbSoin.DataSource = soins;
        //            cbbSoin.DisplayMember = "Libelle";
        //            cbbSoin.ValueMember = "IdSoin";

        //            if (cbbSoin.Items.Count > 0)
        //            {
        //                cbbSoin.SelectedIndex = 0;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Erreur lors du chargement des soins : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


        //private void ChargerMedecins()
        //{
        //    try
        //    {
        //        var medecins = db.Medecins.Select(m => new { m.IdMedecin, m.NomPrenom }).ToList();
        //        if (medecins.Count == 0)
        //        {
        //            MessageBox.Show("Aucun medecin trouvé.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        else
        //        {
        //            cbbMedecin.DataSource = medecins;
        //            cbbMedecin.DisplayMember = "NomPrenom";
        //            cbbMedecin.ValueMember = "IdMedecin";

        //            if (cbbMedecin.Items.Count > 0)
        //            {
        //                cbbMedecin.SelectedIndex = 0; 
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Erreur lors du chargement des soins : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


        private void ChargerCreneaux()
        {
            var creneaux = db.Creneaux
                             .Select(c => new { c.HeureDebut, c.HeureFin })
                             .ToList();
            dgCreneau.DataSource = creneaux;
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtReferencePaiement.Text) || string.IsNullOrWhiteSpace(txtNumeroRecu.Text))
                {
                    MessageBox.Show("Veuillez remplir tous les champs obligatoires.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Vérifiez si le medecin sélectionné a un ID valide
                if (cbbMedecin.SelectedValue == null || string.IsNullOrWhiteSpace(cbbMedecin.SelectedValue.ToString()))
                {
                    MessageBox.Show("Veuillez sélectionner un medecin valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ajout du rendez-vous avec créneau sélectionné
                RendezVous rv = new RendezVous
                {
                    DateRv = dateTimePicker1.Value,
                    ReferencePaiement = txtReferencePaiement.Text,
                    NumeroRecu = txtNumeroRecu.Text,
                    ModePaiement = cbbModePay.SelectedValue.ToString(),
                    Cout = decimal.Parse(cbbCout.SelectedValue.ToString()),
                    IdMedecin = int.Parse(cbbMedecin.SelectedValue.ToString()),
                    IdSoin = int.Parse(cbbSoin.SelectedValue.ToString()),
                    Horaire = txtCreneauSelectionne.Text,

                };

                db.RendezVous.Add(rv);
                db.SaveChanges();
                MessageBox.Show("Rendez-vous ajouté avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue lors de l'ajout : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgRendezvous.CurrentRow.Cells[0].Value.ToString());
            var p = db.RendezVous.Find(id);
            p.DateRv = dateTimePicker1.Value;
            p.ReferencePaiement = txtReferencePaiement.Text;
            p.NumeroRecu = txtNumeroRecu.Text;
            p.ModePaiement = cbbModePay.SelectedValue.ToString();
            p.Cout = decimal.Parse(cbbCout.SelectedValue.ToString());
            p.IdMedecin = int.Parse(cbbMedecin.SelectedValue.ToString());
            p.IdSoin = int.Parse(cbbSoin.SelectedValue.ToString());
            p.Horaire = txtCreneauSelectionne.Text;
            db.SaveChanges();
            ResetForm();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgRendezvous.CurrentRow.Cells[0].Value.ToString());
            var p = db.Patients.Find(id);
            db.Patients.Remove(p);
            db.SaveChanges();
            ResetForm();
        }

        private void GenererNumeroRecu()
        {
            txtNumeroRecu.Text = "REC-" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }


        private void dgCreneau_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                object heureDebut = dgCreneau.Rows[e.RowIndex].Cells["HeureDebut"].Value;
                object heureFin = dgCreneau.Rows[e.RowIndex].Cells["HeureFin"].Value;

                if (heureDebut != null && heureFin != null)
                {
                    txtCreneauSelectionne.Text = heureDebut.ToString() + " - " + heureFin.ToString();
                }
                else
                {
                    txtCreneauSelectionne.Text = "Créneau invalide";
                }
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

            var p = db.Patients.Find(idPatient);
            lblPatient.Text = string.Format("N° Telephone: {0}, Nom Prenom:{1}", p.Tel, p.NomPrenom);
            lblIdPatient.Text = p.IDU.ToString();
            lblIdPatient.Visible = false;
            ResetForm();
           
            ChargerCreneaux();
            GenererNumeroRecu();
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







        private List<SelectListViewModel> LoadCbbSoin()
        {
            var rv = db.Soins.ToList();

            if (rv == null || !rv.Any())
            {
                MessageBox.Show("Erreur lors du chargement des médecins. Vérifiez la connexion à la base de données.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<SelectListViewModel>();
            }

            List<SelectListViewModel> liste = new List<SelectListViewModel>();
            SelectListViewModel b = new SelectListViewModel();
            b.Text = "Selection....";
            b.Value = "";
            liste.Add(b);
            foreach (var c in rv)
            {
                SelectListViewModel a = new SelectListViewModel();

                a.Text = c.Libelle;
                a.Value = c.IdSoin.ToString();
                liste.Add(a);
            }
            return liste;
        }

        private List<SelectListViewModel> LoadCbbMedecin()
        {
            var rv = db.Medecins.ToList();

            if (rv == null || !rv.Any())
            {
                MessageBox.Show("Erreur lors du chargement des médecins. Vérifiez la connexion à la base de données.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<SelectListViewModel>();
            }

            List<SelectListViewModel> liste = new List<SelectListViewModel>();
            SelectListViewModel b = new SelectListViewModel
            {
                Text = "Selection....",
                Value = ""
            };
            liste.Add(b);
            foreach (var c in rv)
            {
                SelectListViewModel a = new SelectListViewModel
                {

                Text = c.NomPrenom,
                    Value = c.IdMedecin.ToString()
                };
                liste.Add(a);
            }

            return liste;
        }



    }
}
