using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using MaterielRvMedical.Model;
using Microsoft.VisualBasic.Devices;

namespace AppGroupe2.View
{
    public partial class frmMenu : Form
    {
        private string roleUtilisateur;

        public string RoleUtilisateur
        {
            get { return roleUtilisateur; }
            set { roleUtilisateur = value; }
        }

        public frmMenu()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

       
       
        //methode commune de remise à zero des couleurs
        private void ReinitialiserCouleurBoutons(Control parent = null)
        {
            Color couleurParDefaut = Color.FromArgb(77, 168, 218); 

            if (parent == null)
                parent = this;

            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is Button bouton)
                {
                    bouton.BackColor = couleurParDefaut;
                }
                else if (ctrl.HasChildren)
                {
                    ReinitialiserCouleurBoutons(ctrl);
                }
            }
        }



        private void Menu_Load(object sender, EventArgs e)
        {
            if (roleUtilisateur == "Admin")
            {
                btnAccueil.Visible = true;
                btnMedecin.Visible = false;
            }
            else if (roleUtilisateur == "Medecin")
            {
                btnPatient.Visible = true;
                btnRendezvous.Visible = true;
                btnAccueil.Visible = true;
            }
            
            btnQuitter.Visible = true;
            btnDeconnecter.Visible = true;
        }
        

        private void btnAccueil_Click(object sender, EventArgs e)
        {
            ReinitialiserCouleurBoutons();

            Button boutonClique = sender as Button;
            if (boutonClique != null)
            {
                boutonClique.UseVisualStyleBackColor = false;
                boutonClique.BackColor = Color.FromArgb(27, 73, 101); 
            }
            fermer();
            frmAccueil f = new frmAccueil();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void btnMedecin_Click(object sender, EventArgs e)
        {
            ReinitialiserCouleurBoutons();

            Button boutonClique = sender as Button;
            if (boutonClique != null)
            {
                boutonClique.UseVisualStyleBackColor = false;
                boutonClique.BackColor = Color.FromArgb(27, 73, 101);
            }

            fermer();
            frmMedecin f = new frmMedecin();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            ReinitialiserCouleurBoutons();

            Button boutonClique = sender as Button;
            if (boutonClique != null)
            {
                boutonClique.UseVisualStyleBackColor = false;
                boutonClique.BackColor = Color.FromArgb(27, 73, 101 );
            }
            fermer();
            frmPatient f = new frmPatient();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void btnRendezvous_Click(object sender, EventArgs e)
        {
            ReinitialiserCouleurBoutons();

            Button boutonClique = sender as Button;
            if (boutonClique != null)
            {
                boutonClique.UseVisualStyleBackColor = false;
                boutonClique.BackColor = Color.FromArgb(27, 73, 101);
            }
            fermer();
            frmRendezVous f = new frmRendezVous();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            ReinitialiserCouleurBoutons();

            Button boutonClique = sender as Button;
            if (boutonClique != null)
            {
                boutonClique.UseVisualStyleBackColor = false;
                boutonClique.BackColor = Color.FromArgb(27, 73, 101); 
            }
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
           

             this.Close();
        }

        private void btnDeconnecter_Click(object sender, EventArgs e)
        {
            frmConnexion f = new frmConnexion();
            f.Show();
            this.Close();

        }
        private void fermer()
        {
            Form[] charr = this.MdiChildren;

            //For each child form set the window state to Maximized 
            foreach (Form chform in charr)
            {
                //chform.WindowState = FormWindowState.Maximized;
                chform.Close();
            }
        }
    }
}
