namespace AppGroupe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixModelChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Personnes", "IdMedecin", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Personnes", "IdMedecin", c => c.String(unicode: false));
        }
    }
}
