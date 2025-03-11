namespace AppGroupe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class log : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Td_Erreur",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateErreur = c.DateTime(nullable: false, precision: 0),
                        DescriptionErreur = c.String(unicode: false),
                        TitreErreur = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Td_Erreur");
        }
    }
}
