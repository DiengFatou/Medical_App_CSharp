using System;
using System.Collections.Generic;
using System.Linq;
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

        private void ChargerSoins()
        {
            try
            {
                var soins = db.Soins.Select(s => new { s.IdSoin, s.Libelle }).ToList();
                if (soins.Count == 0)
                {
                    MessageBox.Show("Aucun soin trouvé.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    cbbSoin.DataSource = soins;
                    cbbSoin.DisplayMember = "Libelle";
                    cbbSoin.ValueMember = "IdSoin";

                    if (cbbSoin.Items.Count > 0)
                    {
                        cbbSoin.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des soins : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ChargerMedecins()
        {
            try
            {
                var medecins = db.Medecins.Select(m => new { m.IdMedecin, m.NomPrenom }).ToList();
                if (medecins.Count == 0)
                {
                    MessageBox.Show("Aucun medecin trouvé.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    cbbMedecin.DataSource = medecins;
                    cbbMedecin.DisplayMember = "NomPrenom";
                    cbbMedecin.ValueMember = "IdMedecin";

                    if (cbbMedecin.Items.Count > 0)
                    {
                        cbbMedecin.SelectedIndex = 0; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des soins : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ChargerCreneaux()
        {
            var creneaux = db.Creneaux
                             .Select(c => new { c.HeureDebut, c.HeureFin })
                             .ToList();
            dgCreneau.DataSource = creneaux;
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (cbbSoin.SelectedValue == null ||  cbbMedecin.SelectedValue == null)
            {
                MessageBox.Show("Veuillez sélectionner un soin, et un médecin.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                //int idSoin = (int)cbbSoin.SelectedValue;
                //int idPatient = (int)cbbPatient.SelectedValue;
                //int idMedecin = (int)cbbMedecin.SelectedValue;
                //string nomSoin = cbbSoin.Text;
                //string nomPatient = cbbPatient.Text;
                //string nomMedecin = cbbMedecin.Text;

                // Gestion du coût avec une vérification
                //decimal cout = 0;
                //if (!decimal.TryParse(cbbCout.Text, out cout))
                //{
                //    MessageBox.Show("Le coût sélectionné n'est pas valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                RendezVous rv = new RendezVous();

                rv.DateRv = dateTimePicker1.Value;
                rv.Statut = "En attente";
                rv.IdSoin = int.Parse(cbbSoin.SelectedValue.ToString());
                rv.IdMedecin = int.Parse(cbbMedecin.SelectedValue.ToString());
                rv.Cout = decimal.Parse(cbbCout.SelectedItem.ToString());
                rv.ModePaiement = cbbModePay.SelectedItem.ToString();
                rv.ReferencePaiement = txtReferencePaiement.Text;
                rv.Horaire = txtCreneauSelectionne.Text;
                

                db.RendezVous.Add(rv);
                db.SaveChanges();

                MessageBox.Show($"Rendez-vous ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors de l'enregistrement du rendez-vous : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenererNumeroRecu()
        {
            txtNumeroRecu.Text = "REC-" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }


        private void dgCreneau_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCreneauSelectionne.Text = dgCreneau.Rows[e.RowIndex].Cells["HeureDebut"].Value.ToString() + " - " + dgCreneau.Rows[e.RowIndex].Cells["HeureFin"].Value.ToString();
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

            ChargerSoins();
            ChargerMedecins();
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


        //private List<SelectListViewModel> LoadCbbSoin()
        //{
        //    var rv = db.Soins.ToList();

        //    if (rv == null || !rv.Any()) 
        //    {
        //        MessageBox.Show("Erreur lors du chargement des médecins. Vérifiez la connexion à la base de données.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return new List<SelectListViewModel>(); 
        //    }

        //    List<SelectListViewModel> liste = new List<SelectListViewModel>();
        //    SelectListViewModel b = new SelectListViewModel();
        //    b.Text = "Selection....";
        //    b.Value = "";
        //    liste.Add(b);
        //    foreach (var c in rv)
        //    {
        //        SelectListViewModel a = new SelectListViewModel();
        //        a.Text = c.Libelle;
        //        a.Value = c.IdSoin.ToString();
        //        liste.Add(a);
        //    }
        //    return liste;
        //}

        //private List<SelectListViewModel> LoadCbbPatient()
        //{
        //    var rv = db.Patients.ToList();
        //    if (rv == null || !rv.Any()) 
        //    {
        //        MessageBox.Show("Erreur lors du chargement des médecins. Vérifiez la connexion à la base de données.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return new List<SelectListViewModel>(); 
        //    }

        //    List<SelectListViewModel> liste = new List<SelectListViewModel>();
        //    SelectListViewModel b = new SelectListViewModel();
        //    b.Text = "Selection....";
        //    b.Value = "";
        //    liste.Add(b);
        //    foreach (var c in rv)
        //    {
        //        SelectListViewModel a = new SelectListViewModel();
        //        a.Text = c.NomPrenom;
        //        a.Value = c.IdPatient.ToString();
        //        liste.Add(a);
        //    }
        //    return liste;
        //}

        //private List<SelectListViewModel> LoadCbbMedecin()
        //{
        //    var rv = db.Medecins.ToList();

        //    if (rv == null || !rv.Any())
        //    {
        //        MessageBox.Show("Erreur lors du chargement des médecins. Vérifiez la connexion à la base de données.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return new List<SelectListViewModel>();
        //    }

        //    List<SelectListViewModel> liste = new List<SelectListViewModel>();
        //    SelectListViewModel b = new SelectListViewModel
        //    {
        //        Text = "Selection....",
        //        Value = ""
        //    };
        //    liste.Add(b);
        //    foreach (var c in rv)
        //    {
        //        SelectListViewModel a = new SelectListViewModel
        //        {
        //            Text = c.NomPrenom,
        //            Value = c.IdMedecin.ToString()
        //        };
        //        liste.Add(a);
        //    }

        //    return liste;
        //}


    }
}
