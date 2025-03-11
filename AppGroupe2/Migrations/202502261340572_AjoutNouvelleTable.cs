namespace AppGroupe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutNouvelleTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personnes", "DateNaissance", c => c.DateTime(precision: 0));
            AddColumn("dbo.RendezVous", "DateRv", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.RendezVous", "Statut", c => c.String(maxLength: 10, storeType: "nvarchar"));
            AddColumn("dbo.RendezVous", "IdSoin", c => c.Int());
            AddColumn("dbo.RendezVous", "IdPatient", c => c.Int());
            AddColumn("dbo.RendezVous", "IdMedecin", c => c.Int());
            CreateIndex("dbo.RendezVous", "IdSoin");
            CreateIndex("dbo.RendezVous", "IdPatient");
            CreateIndex("dbo.RendezVous", "IdMedecin");
            AddForeignKey("dbo.RendezVous", "IdMedecin", "dbo.Personnes", "IDU");
            AddForeignKey("dbo.RendezVous", "IdPatient", "dbo.Personnes", "IDU");
            AddForeignKey("dbo.RendezVous", "IdSoin", "dbo.Soins", "IdSoin");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RendezVous", "IdSoin", "dbo.Soins");
            DropForeignKey("dbo.RendezVous", "IdPatient", "dbo.Personnes");
            DropForeignKey("dbo.RendezVous", "IdMedecin", "dbo.Personnes");
            DropIndex("dbo.RendezVous", new[] { "IdMedecin" });
            DropIndex("dbo.RendezVous", new[] { "IdPatient" });
            DropIndex("dbo.RendezVous", new[] { "IdSoin" });
            DropColumn("dbo.RendezVous", "IdMedecin");
            DropColumn("dbo.RendezVous", "IdPatient");
            DropColumn("dbo.RendezVous", "IdSoin");
            DropColumn("dbo.RendezVous", "Statut");
            DropColumn("dbo.RendezVous", "DateRv");
            DropColumn("dbo.Personnes", "DateNaissance");
        }
    }
}
