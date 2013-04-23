namespace Cepheus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        DeveloperId = c.Int(nullable: false),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.GameId)
                .ForeignKey("dbo.Developers", t => t.DeveloperId, cascadeDelete: true)
                .Index(t => t.DeveloperId);
            
            CreateTable(
                "dbo.GameAndTypes",
                c => new
                    {
                        GameAndTypeId = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        GameTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameAndTypeId)
                .ForeignKey("dbo.GameTypes", t => t.GameTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameTypeId)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.GameTypes",
                c => new
                    {
                        GameTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GameTypeId);
            
            CreateTable(
                "dbo.Developers",
                c => new
                    {
                        DeveloperId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DeveloperId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.GameAndTypes", new[] { "GameId" });
            DropIndex("dbo.GameAndTypes", new[] { "GameTypeId" });
            DropIndex("dbo.Games", new[] { "DeveloperId" });
            DropForeignKey("dbo.GameAndTypes", "GameId", "dbo.Games");
            DropForeignKey("dbo.GameAndTypes", "GameTypeId", "dbo.GameTypes");
            DropForeignKey("dbo.Games", "DeveloperId", "dbo.Developers");
            DropTable("dbo.Developers");
            DropTable("dbo.GameTypes");
            DropTable("dbo.GameAndTypes");
            DropTable("dbo.Games");
        }
    }
}
