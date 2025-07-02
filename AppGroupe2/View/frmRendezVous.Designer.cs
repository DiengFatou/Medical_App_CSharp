namespace AppGroupe2.View
{
    partial class frmRendezVous
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgCreneau = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPatient = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbSoin = new System.Windows.Forms.ComboBox();
            this.cbbMedecin = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtReferencePaiement = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbModePay = new System.Windows.Forms.ComboBox();
            this.cbbCout = new System.Windows.Forms.ComboBox();
            this.btnGenerer = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnValider = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtNumeroRecu = new System.Windows.Forms.TextBox();
            this.txtCreneauSelectionne = new System.Windows.Forms.TextBox();
            this.btnAgenda = new System.Windows.Forms.Button();
            this.lblPatient = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblIdPatient = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgRendezvous = new System.Windows.Forms.DataGridView();
            this.btnFermer = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCreneau)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRendezvous)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dgCreneau);
            this.groupBox1.Location = new System.Drawing.Point(11, 63);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(353, 426);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selectionner l\'heure";
            // 
            // dgCreneau
            // 
            this.dgCreneau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCreneau.Location = new System.Drawing.Point(5, 29);
            this.dgCreneau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgCreneau.Name = "dgCreneau";
            this.dgCreneau.RowHeadersWidth = 62;
            this.dgCreneau.RowTemplate.Height = 28;
            this.dgCreneau.Size = new System.Drawing.Size(340, 368);
            this.dgCreneau.TabIndex = 0;
            this.dgCreneau.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCreneau_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnPatient);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbbSoin);
            this.groupBox2.Controls.Add(this.cbbMedecin);
            this.groupBox2.Location = new System.Drawing.Point(630, 63);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(244, 242);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selectionner:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Medecin";
            // 
            // btnPatient
            // 
            this.btnPatient.BackColor = System.Drawing.Color.SteelBlue;
            this.btnPatient.Location = new System.Drawing.Point(68, 166);
            this.btnPatient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPatient.Name = "btnPatient";
            this.btnPatient.Size = new System.Drawing.Size(97, 41);
            this.btnPatient.TabIndex = 15;
            this.btnPatient.Text = "Patient";
            this.btnPatient.UseVisualStyleBackColor = false;
            this.btnPatient.Click += new System.EventHandler(this.btnPatient_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Soin";
            // 
            // cbbSoin
            // 
            this.cbbSoin.FormattingEnabled = true;
            this.cbbSoin.Location = new System.Drawing.Point(35, 121);
            this.cbbSoin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbSoin.Name = "cbbSoin";
            this.cbbSoin.Size = new System.Drawing.Size(152, 24);
            this.cbbSoin.TabIndex = 2;
            // 
            // cbbMedecin
            // 
            this.cbbMedecin.FormattingEnabled = true;
            this.cbbMedecin.Location = new System.Drawing.Point(35, 55);
            this.cbbMedecin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbMedecin.Name = "cbbMedecin";
            this.cbbMedecin.Size = new System.Drawing.Size(152, 24);
            this.cbbMedecin.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.txtReferencePaiement);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.cbbModePay);
            this.groupBox3.Controls.Add(this.cbbCout);
            this.groupBox3.Location = new System.Drawing.Point(907, 63);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(244, 242);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Paiement";
            // 
            // txtReferencePaiement
            // 
            this.txtReferencePaiement.Location = new System.Drawing.Point(16, 196);
            this.txtReferencePaiement.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtReferencePaiement.Name = "txtReferencePaiement";
            this.txtReferencePaiement.Size = new System.Drawing.Size(154, 22);
            this.txtReferencePaiement.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mode de Paiement";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Reference de Paiement";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Cout";
            // 
            // cbbModePay
            // 
            this.cbbModePay.FormattingEnabled = true;
            this.cbbModePay.Location = new System.Drawing.Point(16, 130);
            this.cbbModePay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbModePay.Name = "cbbModePay";
            this.cbbModePay.Size = new System.Drawing.Size(152, 24);
            this.cbbModePay.TabIndex = 1;
            // 
            // cbbCout
            // 
            this.cbbCout.FormattingEnabled = true;
            this.cbbCout.Location = new System.Drawing.Point(16, 58);
            this.cbbCout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbCout.Name = "cbbCout";
            this.cbbCout.Size = new System.Drawing.Size(152, 24);
            this.cbbCout.TabIndex = 0;
            // 
            // btnGenerer
            // 
            this.btnGenerer.BackColor = System.Drawing.Color.LimeGreen;
            this.btnGenerer.Location = new System.Drawing.Point(1080, 15);
            this.btnGenerer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenerer.Name = "btnGenerer";
            this.btnGenerer.Size = new System.Drawing.Size(71, 22);
            this.btnGenerer.TabIndex = 7;
            this.btnGenerer.Text = "Generer";
            this.btnGenerer.UseVisualStyleBackColor = false;
            this.btnGenerer.Click += new System.EventHandler(this.btnGenerer_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(786, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Numéro de reçu:";
            // 
            // btnValider
            // 
            this.btnValider.BackColor = System.Drawing.Color.LimeGreen;
            this.btnValider.Location = new System.Drawing.Point(628, 326);
            this.btnValider.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(100, 27);
            this.btnValider.TabIndex = 10;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = false;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.Red;
            this.btnAnnuler.Location = new System.Drawing.Point(1012, 326);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(100, 27);
            this.btnAnnuler.TabIndex = 11;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(390, 194);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(221, 22);
            this.dateTimePicker1.TabIndex = 12;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(611, 418);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 16);
            this.lblMessage.TabIndex = 13;
            // 
            // txtNumeroRecu
            // 
            this.txtNumeroRecu.Location = new System.Drawing.Point(915, 14);
            this.txtNumeroRecu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNumeroRecu.Name = "txtNumeroRecu";
            this.txtNumeroRecu.Size = new System.Drawing.Size(147, 22);
            this.txtNumeroRecu.TabIndex = 9;
            // 
            // txtCreneauSelectionne
            // 
            this.txtCreneauSelectionne.Location = new System.Drawing.Point(390, 161);
            this.txtCreneauSelectionne.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCreneauSelectionne.Name = "txtCreneauSelectionne";
            this.txtCreneauSelectionne.Size = new System.Drawing.Size(221, 22);
            this.txtCreneauSelectionne.TabIndex = 14;
            // 
            // btnAgenda
            // 
            this.btnAgenda.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAgenda.Location = new System.Drawing.Point(647, 6);
            this.btnAgenda.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgenda.Name = "btnAgenda";
            this.btnAgenda.Size = new System.Drawing.Size(91, 46);
            this.btnAgenda.TabIndex = 16;
            this.btnAgenda.Text = "Agenda";
            this.btnAgenda.UseVisualStyleBackColor = false;
            this.btnAgenda.Click += new System.EventHandler(this.btnAgenda_Click);
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblPatient.Location = new System.Drawing.Point(18, 49);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(0, 16);
            this.lblPatient.TabIndex = 17;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblIdPatient);
            this.groupBox4.Controls.Add(this.lblPatient);
            this.groupBox4.Location = new System.Drawing.Point(11, 504);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(353, 76);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Message";
            // 
            // lblIdPatient
            // 
            this.lblIdPatient.AutoSize = true;
            this.lblIdPatient.BackColor = System.Drawing.Color.White;
            this.lblIdPatient.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblIdPatient.Location = new System.Drawing.Point(18, 18);
            this.lblIdPatient.Name = "lblIdPatient";
            this.lblIdPatient.Size = new System.Drawing.Size(0, 16);
            this.lblIdPatient.TabIndex = 19;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dgRendezvous);
            this.groupBox5.Location = new System.Drawing.Point(630, 358);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(626, 330);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Liste Rendezvous";
            // 
            // dgRendezvous
            // 
            this.dgRendezvous.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRendezvous.Location = new System.Drawing.Point(17, 29);
            this.dgRendezvous.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgRendezvous.Name = "dgRendezvous";
            this.dgRendezvous.RowHeadersWidth = 62;
            this.dgRendezvous.RowTemplate.Height = 28;
            this.dgRendezvous.Size = new System.Drawing.Size(592, 290);
            this.dgRendezvous.TabIndex = 0;
            // 
            // btnFermer
            // 
            this.btnFermer.BackColor = System.Drawing.Color.Red;
            this.btnFermer.Location = new System.Drawing.Point(1172, 14);
            this.btnFermer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(67, 23);
            this.btnFermer.TabIndex = 20;
            this.btnFermer.Text = "Fermer";
            this.btnFermer.UseVisualStyleBackColor = false;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Location = new System.Drawing.Point(884, 326);
            this.btnSupprimer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(101, 27);
            this.btnSupprimer.TabIndex = 21;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(750, 326);
            this.btnModifier.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(99, 27);
            this.btnModifier.TabIndex = 22;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            // 
            // frmRendezVous
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1301, 697);
            this.ControlBox = false;
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnFermer);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnAgenda);
            this.Controls.Add(this.txtCreneauSelectionne);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.txtNumeroRecu);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnGenerer);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmRendezVous";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rendez-Vous";
            this.Load += new System.EventHandler(this.frmRendezVous_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCreneau)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRendezvous)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgCreneau;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbSoin;
        private System.Windows.Forms.ComboBox cbbMedecin;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbbModePay;
        private System.Windows.Forms.TextBox txtReferencePaiement;
        private System.Windows.Forms.ComboBox cbbCout;
        private System.Windows.Forms.Button btnGenerer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtNumeroRecu;
        private System.Windows.Forms.TextBox txtCreneauSelectionne;
        private System.Windows.Forms.Button btnPatient;
        private System.Windows.Forms.Button btnAgenda;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblIdPatient;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgRendezvous;
        private System.Windows.Forms.Button btnFermer;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnModifier;
    }
}