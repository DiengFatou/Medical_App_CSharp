namespace AppGroupe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NomDeTaMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Td_Erreur", "DescriptionErreur", c => c.String(maxLength: 2000, storeType: "nvarchar"));
            AlterColumn("dbo.Td_Erreur", "TitreErreur", c => c.String(maxLength: 200, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Td_Erreur", "TitreErreur", c => c.String(unicode: false));
            AlterColumn("dbo.Td_Erreur", "DescriptionErreur", c => c.String(unicode: false));
        }
    }
}
