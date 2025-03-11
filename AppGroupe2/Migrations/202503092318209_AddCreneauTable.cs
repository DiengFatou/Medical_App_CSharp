namespace AppGroupe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreneauTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Creneaux",
                c => new
                    {
                        IdCreneau = c.Int(nullable: false, identity: true),
                    HeureDebut = c.Time(nullable: false, precision: 0), 
                    HeureFin = c.Time(nullable: false, precision: 0),  
                    IdAgenda = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCreneau)
                .ForeignKey("dbo.Agenda", t => t.IdAgenda, cascadeDelete: true)
                .Index(t => t.IdAgenda);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Creneaux", "IdAgenda", "dbo.Agenda");
            DropIndex("dbo.Creneaux", new[] { "IdAgenda" });
            DropTable("dbo.Creneaux");
        }
    }
}
