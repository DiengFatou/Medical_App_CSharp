namespace AppGroupe2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationSangin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personnes", "IdGroupeSanguin", c => c.Int());
            CreateIndex("dbo.Personnes", "IdGroupeSanguin");
            AddForeignKey("dbo.Personnes", "IdGroupeSanguin", "dbo.GroupeSanguins", "IdGroupeSanguin");
            DropColumn("dbo.Personnes", "GroupSanguin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Personnes", "GroupSanguin", c => c.String(maxLength: 3, storeType: "nvarchar"));
            DropForeignKey("dbo.Personnes", "IdGroupeSanguin", "dbo.GroupeSanguins");
            DropIndex("dbo.Personnes", new[] { "IdGroupeSanguin" });
            DropColumn("dbo.Personnes", "IdGroupeSanguin");
        }
    }
}
