using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;
using AppGroupe2.Model;
namespace AppGroupe2.View
{
    /// <summary>
    /// Formulaire pour la gestion des patients.
    /// Ce formulaire permet d'afficher, d'ajouter, de modifier et de supprimer des informations sur les patients.
    /// </summary>
    public partial class frmPatient : Form
    {
        BdRvMedicalContexe db = new BdRvMedicalContexe();
        public frmPatient()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

        }


        public object CurrentRow { get; private set; }


        private void ResetForm()
        {
            txtNomPrenom.Text = string.Empty;
            txtAdresse.Text = string.Empty;
            txtEmail.Text = string.Empty;

            // Charger les groupes sanguins correctement
            cbbGroupeSanguin.DataSource = LoadCbbGroupesanguin();
            cbbGroupeSanguin.ValueMember = "Value";
            cbbGroupeSanguin.DisplayMember = "Text";

            txtPoid.Text = string.Empty;
            txtTaille.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;

            dgPatient.DataSource = db.Patients
     .Select(a => new
     {
         a.IDU,
         a.NomPrenom,
         a.Adresse,
         a.Tel,
         a.Email,
         a.Poids,
         a.Taille,
         GroupeSanguin = a.GroupeSanguin.CodeGroupeSanguin,
         DateNaissance = a.DateNaissance 
     })
     .AsEnumerable()
     .Select(a => new
     {
         a.IDU,
         a.NomPrenom,
         a.Adresse,
         a.Tel,
         a.Email,
         a.Poids,
         a.Taille,
         a.GroupeSanguin,
         DateNaissance = a.DateNaissance.HasValue ? a.DateNaissance.Value.ToString("dd/MM/yyyy") : ""
     })
     .ToList();


            txtNomPrenom.Focus();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Patient p = new Patient();
            p.NomPrenom = txtNomPrenom.Text;
            p.Adresse = txtAdresse.Text;
            p.Tel=txtTelephone.Text;
            p.Email=txtEmail.Text;
            p.Poids = float.Parse(txtTaille.Text, CultureInfo.InvariantCulture);
            p.Taille = float.Parse(txtTaille.Text, CultureInfo.InvariantCulture);
            p.IdGroupeSanguin = int.Parse(cbbGroupeSanguin.SelectedValue.ToString());
            p.DateNaissance = dateTimePicker1.Value;
            db.Patients.Add(p);
            db.SaveChanges();
            ResetForm();


        }

        private void frmPatient_Load(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnChoisir_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgPatient.CurrentRow.Cells[0].Value.ToString()); 
            var p = db.Patients.Find(id);
            if (p != null)
            {
                txtNomPrenom.Text = p.NomPrenom;
                txtAdresse.Text = p.Adresse;
                txtEmail.Text = p.Email;
                txtTelephone.Text = p.Tel;
                txtPoid.Text = p.Poids.ToString();
                txtTaille.Text = p.Taille.ToString();
                cbbGroupeSanguin.SelectedValue = p.IdGroupeSanguin;
            }
        }


        private void btnModifier_Click(object sender, EventArgs e)
        {
                int? id = int.Parse(dgPatient.CurrentRow.Cells[0].Value.ToString());
                var p = db.Patients.Find(id);
                p.NomPrenom = txtNomPrenom.Text;
                p.Adresse = txtAdresse.Text;
                p.Tel = txtTelephone.Text;
                p.Email = txtEmail.Text;
                p.Poids = float.Parse(txtTaille.Text);
                p.IdGroupeSanguin = int.Parse(cbbGroupeSanguin.SelectedValue.ToString());
                p.DateNaissance = dateTimePicker1.Value;
            db.SaveChanges();
                ResetForm();

            }
        

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgPatient.CurrentRow.Cells[3].Value.ToString());
            if (id.HasValue)
            {
                var p = db.Patients.Find(id);
                db.Patients.Remove(p);
                db.SaveChanges();
                ResetForm();

            }
        }
        private List<SelectListViewModel> LoadCbbGroupesanguin()
        {
            var groupes = db.GroupeSanguins.ToList();
            List<SelectListViewModel> liste = new List<SelectListViewModel>();

            // Ajout de l'option par défaut
            liste.Add(new SelectListViewModel { Text = "Sélectionnez...", Value = "" });

            // Ajout des groupes sanguins à la liste
            foreach (var groupe in groupes)
            {
                liste.Add(new SelectListViewModel
                {
                    Text = groupe.CodeGroupeSanguin,
                    Value = groupe.IdGroupeSanguin.ToString()
                });
            }

            return liste;
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            var liste = db.Patients.ToList();

            if (!string.IsNullOrEmpty(txtREmail.Text))
            {
                liste = liste.Where(a => a.Email.ToUpper() == txtREmail.Text.ToUpper()).ToList();
            }

            if (!string.IsNullOrEmpty(txtRTel.Text))
            {
                liste = liste.Where(a => a.Tel.ToUpper() == txtRTel.Text.ToUpper()).ToList();
            }

            dgPatient.DataSource = liste;
        }

        private void btnRv_Click(object sender, EventArgs e)
        {
            frmRendezVous f = new frmRendezVous();
            f.idPatient = int.Parse(dgPatient.CurrentRow.Cells[0].Value.ToString());

            f.Show();
            this.Enabled = false;
        }
    }
}
