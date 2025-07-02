using AppGroupe2.View;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppGroupe2
{
    public partial class frmMDI : Form
    {
        public string role;

        public frmMDI()
        {
            InitializeComponent();
        }

        private void seDeconnecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConnexion f = new frmConnexion();
            f.Show();
            this.Close();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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


        //private void frmMdi_Load(object sender, EventArgs e)
        //{
        //    Computer myComputer = new Computer();
        //    this.Width = myComputer.Screen.Bounds.Width;
        //    this.Height = myComputer.Screen.Bounds.Height;
        //    this.Location = new Point(0, 0);
        //}



        private void frmMDI_Load(object sender, EventArgs e)
        {
            Computer myComputer = new Computer();
            this.Width = myComputer.Screen.Bounds.Width;
            this.Height = myComputer.Screen.Bounds.Height;
            this.Location = new Point(0, 0);
            switch (role)
            {
                case "admin":
                    couleurToolStripMenuItem.Visible = true;
                    planifierToolStripMenuItem.Visible = false;
                    break;
                case "med":
                case "sec":
                    couleurToolStripMenuItem.Visible = false;
                    planifierToolStripMenuItem.Visible = true;
                    break;
            }
        }
        private void patientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmPatient f = new frmPatient();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void rendezVousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmRendezVous f = new frmRendezVous();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void utilisateurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmMedecin f = new frmMedecin();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        
    }
    }

