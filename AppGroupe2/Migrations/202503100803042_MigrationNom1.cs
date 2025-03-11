namespace AppGroupe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationNom1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personnes", "IdPatient", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Personnes", "IdPatient");
        }
    }
}
