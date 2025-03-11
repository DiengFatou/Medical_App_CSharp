namespace AppGroupe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SelectListViewModels",
                c => new
                    {
                        IdSelectlistViewModel = c.Int(nullable: false, identity: true),
                        Value = c.String(unicode: false),
                        Text = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.IdSelectlistViewModel);
            
            AddColumn("dbo.Personnes", "IdSecretaire", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Personnes", "IdSecretaire");
            DropTable("dbo.SelectListViewModels");
        }
    }
}
