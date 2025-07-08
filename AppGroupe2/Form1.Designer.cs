namespace AppGroupe2
{
    partial class frmConnexion
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnConnecter = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.txtMdp = new System.Windows.Forms.TextBox();
            this.txtIdentifiant = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(73)))), ((int)(((byte)(101)))));
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(498, -3);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(537, 606);
            this.panel1.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CheckBox1);
            this.groupBox1.Controls.Add(this.lblMessage);
            this.groupBox1.Controls.Add(this.btnConnecter);
            this.groupBox1.Controls.Add(this.btnQuitter);
            this.groupBox1.Controls.Add(this.txtMdp);
            this.groupBox1.Controls.Add(this.txtIdentifiant);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(22, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(503, 469);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Authentification";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // CheckBox1
            // 
            this.CheckBox1.AutoSize = true;
            this.CheckBox1.Location = new System.Drawing.Point(423, 248);
            this.CheckBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(18, 17);
            this.CheckBox1.TabIndex = 14;
            this.CheckBox1.UseVisualStyleBackColor = true;
            this.CheckBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Crimson;
            this.lblMessage.Location = new System.Drawing.Point(182, 306);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(259, 22);
            this.lblMessage.TabIndex = 13;
            this.lblMessage.Text = "Mot de passe ou login incorrect";
            this.lblMessage.Visible = false;
            // 
            // btnConnecter
            // 
            this.btnConnecter.BackColor = System.Drawing.Color.SteelBlue;
            this.btnConnecter.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnConnecter.Location = new System.Drawing.Point(326, 349);
            this.btnConnecter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConnecter.Name = "btnConnecter";
            this.btnConnecter.Size = new System.Drawing.Size(129, 51);
            this.btnConnecter.TabIndex = 12;
            this.btnConnecter.Text = "Connecter";
            this.btnConnecter.UseVisualStyleBackColor = false;
            this.btnConnecter.Click += new System.EventHandler(this.btnConnecter_Click);
            // 
            // btnQuitter
            // 
            this.btnQuitter.BackColor = System.Drawing.Color.Red;
            this.btnQuitter.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnQuitter.Location = new System.Drawing.Point(91, 349);
            this.btnQuitter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(129, 51);
            this.btnQuitter.TabIndex = 11;
            this.btnQuitter.Text = "Quitter";
            this.btnQuitter.UseVisualStyleBackColor = false;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // txtMdp
            // 
            this.txtMdp.Location = new System.Drawing.Point(91, 228);
            this.txtMdp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMdp.Multiline = true;
            this.txtMdp.Name = "txtMdp";
            this.txtMdp.Size = new System.Drawing.Size(316, 47);
            this.txtMdp.TabIndex = 10;
            this.txtMdp.UseSystemPasswordChar = true;
            // 
            // txtIdentifiant
            // 
            this.txtIdentifiant.Location = new System.Drawing.Point(91, 119);
            this.txtIdentifiant.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIdentifiant.Multiline = true;
            this.txtIdentifiant.Name = "txtIdentifiant";
            this.txtIdentifiant.Size = new System.Drawing.Size(316, 46);
            this.txtIdentifiant.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(88, 190);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 10, 10, 10);
            this.label5.Size = new System.Drawing.Size(127, 42);
            this.label5.TabIndex = 9;
            this.label5.Text = "Mot de passe";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(89, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 22);
            this.label6.TabIndex = 7;
            this.label6.Text = "Identifiant";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AppGroupe2.Properties.Resources.Telemedicine_2_;
            this.pictureBox1.Location = new System.Drawing.Point(1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 475);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // frmConnexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1035, 477);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmConnexion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connexion";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox CheckBox1;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnConnecter;
        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.TextBox txtMdp;
        private System.Windows.Forms.TextBox txtIdentifiant;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

