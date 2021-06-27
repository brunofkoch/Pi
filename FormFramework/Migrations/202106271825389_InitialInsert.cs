namespace FormFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialInsert : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Leituras", "ModProvas_ModProvaID", "dbo.ModProvas");
            DropIndex("dbo.Leituras", new[] { "ModProvas_ModProvaID" });
            AddColumn("dbo.Leituras", "NumProva", c => c.Int(nullable: false));
            AddColumn("dbo.ModProvas", "NumProva", c => c.Int(nullable: false));
            DropColumn("dbo.Leituras", "ModProvas_ModProvaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Leituras", "ModProvas_ModProvaID", c => c.Int());
            DropColumn("dbo.ModProvas", "NumProva");
            DropColumn("dbo.Leituras", "NumProva");
            CreateIndex("dbo.Leituras", "ModProvas_ModProvaID");
            AddForeignKey("dbo.Leituras", "ModProvas_ModProvaID", "dbo.ModProvas", "ModProvaID");
        }
    }
}
