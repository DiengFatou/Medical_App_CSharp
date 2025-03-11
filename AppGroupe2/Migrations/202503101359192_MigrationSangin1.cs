namespace AppGroupe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationSangin1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RendezVous", "IdCreneau", c => c.Int());
            CreateIndex("dbo.RendezVous", "IdCreneau");
            AddForeignKey("dbo.RendezVous", "IdCreneau", "dbo.Creneaux", "IdCreneau");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RendezVous", "IdCreneau", "dbo.Creneaux");
            DropIndex("dbo.RendezVous", new[] { "IdCreneau" });
            DropColumn("dbo.RendezVous", "IdCreneau");
        }
    }
}
