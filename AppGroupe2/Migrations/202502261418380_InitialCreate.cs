namespace AppGroupe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RendezVous", "Cout", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.RendezVous", "ModePaiement", c => c.String(unicode: false));
            AddColumn("dbo.RendezVous", "ReferencePaiement", c => c.String(unicode: false));
            AddColumn("dbo.RendezVous", "Horaire", c => c.String(unicode: false));
            AddColumn("dbo.RendezVous", "NumeroRecu", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RendezVous", "NumeroRecu");
            DropColumn("dbo.RendezVous", "Horaire");
            DropColumn("dbo.RendezVous", "ReferencePaiement");
            DropColumn("dbo.RendezVous", "ModePaiement");
            DropColumn("dbo.RendezVous", "Cout");
        }
    }
}
