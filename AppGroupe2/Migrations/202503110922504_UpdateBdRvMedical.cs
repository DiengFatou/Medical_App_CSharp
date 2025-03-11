namespace AppGroupe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBdRvMedical : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.SelectListViewModels");
        }
        
        public override void Down()
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
            
        }
    }
}
