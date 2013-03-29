namespace Cepheus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Check : DbMigration
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
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.GameId)
                .ForeignKey("dbo.Developers", t => t.DeveloperId, cascadeDelete: true)
                .Index(t => t.DeveloperId);
            
            CreateTable(
                "dbo.GameTypes",
                c => new
                    {
                        GameTypeId = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
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
            
            CreateTable(
                "dbo.GamesAndTypes",
                c => new
                    {
                        GameId = c.Int(nullable: false),
                        GameTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GameId, t.GameTypeId })
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.GameTypes", t => t.GameTypeId, cascadeDelete: true)
                .Index(t => t.GameId)
                .Index(t => t.GameTypeId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.GamesAndTypes", new[] { "GameTypeId" });
            DropIndex("dbo.GamesAndTypes", new[] { "GameId" });
            DropIndex("dbo.Games", new[] { "DeveloperId" });
            DropForeignKey("dbo.GamesAndTypes", "GameTypeId", "dbo.GameTypes");
            DropForeignKey("dbo.GamesAndTypes", "GameId", "dbo.Games");
            DropForeignKey("dbo.Games", "DeveloperId", "dbo.Developers");
            DropTable("dbo.GamesAndTypes");
            DropTable("dbo.Developers");
            DropTable("dbo.GameTypes");
            DropTable("dbo.Games");
        }
    }
}
