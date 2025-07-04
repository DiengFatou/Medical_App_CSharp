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
using AppGroupe2.Model;
using AppGroupe2.Helper;
using AppGroupe2.ServiceMetier;
using AppGroupe2.View;

namespace AppGroupe2
{
    public partial class frmConnexion : Form
    {
        Service1Client service = new Service1Client();

        public frmConnexion()
        {
            InitializeComponent();

        }

       

       

        private void btnConnecter_Click(object sender, EventArgs e)
        {
            Utils utils = new Utils();

            try
            {
                var leUser = service.GetUtilisateurByIdentifiant(txtIdentifiant.Text);

                if (leUser != null && CryptString.VerifyMd5Hash(txtMdp.Text, leUser.MotDePasse))
                {
                    frmMenu f = new frmMenu();
                    f.RoleUtilisateur = leUser.Role.Code;
                    f.Show();
                    this.Hide();

                    Utils.WriteLogSystem("connexion", "Connexion reussie"); 
                    GMailer.SendMail("dchifai8@gmail.com", "Connexion", "une connexion");
                }
                else
                {
                    lblMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion: " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                utils.WriteDataError("frmConnexion-btnConnecter", ex.ToString());
            }
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
           
            this.Close();

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
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

       
    }
}
