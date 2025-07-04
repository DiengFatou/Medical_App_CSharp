namespace AppGroupe2.View
{
    partial class frmMenu
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.btnMedecin = new System.Windows.Forms.Button();
            this.btnDeconnecter = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.btnRendezvous = new System.Windows.Forms.Button();
            this.btnPatient = new System.Windows.Forms.Button();
            this.btnAccueil = new System.Windows.Forms.Button();
            this.btnAgenda = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // btnMedecin
            // 
            this.btnMedecin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(168)))), ((int)(((byte)(218)))));
            this.btnMedecin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMedecin.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnMedecin.Location = new System.Drawing.Point(8, 127);
            this.btnMedecin.Name = "btnMedecin";
            this.btnMedecin.Size = new System.Drawing.Size(306, 56);
            this.btnMedecin.TabIndex = 6;
            this.btnMedecin.Text = "Medecins";
            this.btnMedecin.UseVisualStyleBackColor = false;
            this.btnMedecin.Click += new System.EventHandler(this.btnMedecin_Click);
            // 
            // btnDeconnecter
            // 
            this.btnDeconnecter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnDeconnecter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeconnecter.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDeconnecter.Location = new System.Drawing.Point(8, 581);
            this.btnDeconnecter.Name = "btnDeconnecter";
            this.btnDeconnecter.Size = new System.Drawing.Size(310, 56);
            this.btnDeconnecter.TabIndex = 5;
            this.btnDeconnecter.Text = "S Deconnecter";
            this.btnDeconnecter.UseVisualStyleBackColor = false;
            this.btnDeconnecter.Click += new System.EventHandler(this.btnDeconnecter_Click);
            // 
            // btnQuitter
            // 
            this.btnQuitter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnQuitter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQuitter.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnQuitter.Location = new System.Drawing.Point(8, 511);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(310, 56);
            this.btnQuitter.TabIndex = 3;
            this.btnQuitter.Text = "Quitter";
            this.btnQuitter.UseVisualStyleBackColor = false;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // btnRendezvous
            // 
            this.btnRendezvous.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(168)))), ((int)(((byte)(218)))));
            this.btnRendezvous.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRendezvous.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnRendezvous.Location = new System.Drawing.Point(8, 306);
            this.btnRendezvous.Name = "btnRendezvous";
            this.btnRendezvous.Size = new System.Drawing.Size(306, 56);
            this.btnRendezvous.TabIndex = 2;
            this.btnRendezvous.Text = "Rendez-Vous";
            this.btnRendezvous.UseVisualStyleBackColor = false;
            this.btnRendezvous.Click += new System.EventHandler(this.btnRendezvous_Click);
            // 
            // btnPatient
            // 
            this.btnPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(168)))), ((int)(((byte)(218)))));
            this.btnPatient.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPatient.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPatient.Location = new System.Drawing.Point(8, 217);
            this.btnPatient.Name = "btnPatient";
            this.btnPatient.Size = new System.Drawing.Size(306, 56);
            this.btnPatient.TabIndex = 1;
            this.btnPatient.Text = "Patients";
            this.btnPatient.UseVisualStyleBackColor = false;
            this.btnPatient.Click += new System.EventHandler(this.btnPatient_Click);
            // 
            // btnAccueil
            // 
            this.btnAccueil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(168)))), ((int)(((byte)(218)))));
            this.btnAccueil.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAccueil.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAccueil.Location = new System.Drawing.Point(8, 42);
            this.btnAccueil.Name = "btnAccueil";
            this.btnAccueil.Size = new System.Drawing.Size(310, 56);
            this.btnAccueil.TabIndex = 0;
            this.btnAccueil.Text = "Accueil";
            this.btnAccueil.UseVisualStyleBackColor = false;
            this.btnAccueil.Click += new System.EventHandler(this.btnAccueil_Click);
            // 
            // btnAgenda
            // 
            this.btnAgenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(168)))), ((int)(((byte)(218)))));
            this.btnAgenda.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgenda.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAgenda.Location = new System.Drawing.Point(8, 389);
            this.btnAgenda.Name = "btnAgenda";
            this.btnAgenda.Size = new System.Drawing.Size(306, 56);
            this.btnAgenda.TabIndex = 7;
            this.btnAgenda.Text = "Agenda";
            this.btnAgenda.UseVisualStyleBackColor = false;
            this.btnAgenda.Click += new System.EventHandler(this.btnAgenda_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(168)))), ((int)(((byte)(218)))));
            this.panel1.Controls.Add(this.btnMedecin);
            this.panel1.Controls.Add(this.btnAgenda);
            this.panel1.Controls.Add(this.btnRendezvous);
            this.panel1.Controls.Add(this.btnQuitter);
            this.panel1.Controls.Add(this.btnAccueil);
            this.panel1.Controls.Add(this.btnPatient);
            this.panel1.Controls.Add(this.btnDeconnecter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 649);
            this.panel1.TabIndex = 8;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1206, 649);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(12)))), ((int)(((byte)(56)))));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMenu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.ToolTip toolTip;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.Button btnAccueil;
        private System.Windows.Forms.Button btnMedecin;
        private System.Windows.Forms.Button btnDeconnecter;
        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.Button btnRendezvous;
        private System.Windows.Forms.Button btnPatient;
        private System.Windows.Forms.Button btnAgenda;
        private System.Windows.Forms.Panel panel1;
    }
}



