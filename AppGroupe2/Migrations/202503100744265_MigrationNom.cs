namespace AppGroupe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationNom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Soins", "Libelle", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Soins", "Libelle");
        }
    }
}
