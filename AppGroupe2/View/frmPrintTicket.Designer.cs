namespace AppGroupe2.View
{
    partial class frmPrintTicket
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
            this.CrystalReportView1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CrystalReportView1
            // 
            this.CrystalReportView1.ActiveViewIndex = -1;
            this.CrystalReportView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrystalReportView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrystalReportView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrystalReportView1.Location = new System.Drawing.Point(0, 0);
            this.CrystalReportView1.Name = "CrystalReportView1";
            this.CrystalReportView1.Size = new System.Drawing.Size(1464, 813);
            this.CrystalReportView1.TabIndex = 0;
            this.CrystalReportView1.Load += new System.EventHandler(this.CrystalReportView1_Load);
            // 
            // frmPrintTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 813);
            this.ControlBox = false;
            this.Controls.Add(this.CrystalReportView1);
            this.Name = "frmPrintTicket";
            this.Text = "Impression";
            this.Load += new System.EventHandler(this.frmPrintTicket_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrystalReportView1;
        private System.Windows.Forms.Button btnFermer;
    }
}