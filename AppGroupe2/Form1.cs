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
using AppGroupe2.App_Start;

namespace AppGroupe2
{
    public partial class frmConnexion : Form
    {
        public frmConnexion()
        {
            InitializeComponent();

        }

       

        private void frmConnexion_Load(object sender, EventArgs e)
        {

        }

     

       

       

        private void Connecter_Click_1(object sender, EventArgs e)
        {

            if (txtNom.Text == "login")
            {
                if (txtMdp.Text == "Passer")
                {
                    frmMDI f = new frmMDI();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    lblMessage.Visible = true;

                }
            }
            Utils.WriteLogSystem("connexion", "Connexion reussie");
            GMailer.SendMail("dchifai8@gmail.com", "Connexion", "une connexion");
            

        }

        private void Quitter_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void CheckBox1_CheckedChanged_1(object sender, EventArgs e)
        {

            if (CheckBox1.Checked)
            {
                txtMdp.UseSystemPasswordChar = false;
            }
            else
            {
                txtMdp.UseSystemPasswordChar = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}
