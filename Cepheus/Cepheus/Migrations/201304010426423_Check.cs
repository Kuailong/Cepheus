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
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.GameId)
                .ForeignKey("dbo.Developers", t => t.DeveloperId, cascadeDelete: true)
                .Index(t => t.DeveloperId);
            
            CreateTable(
                "dbo.GameTypes",
                c => new
                    {
                        GameTypeId = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameTypeId)
                .ForeignKey("dbo.Types", t => t.TypeId, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .Index(t => t.TypeId)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        TypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TypeId);
            
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
            DropIndex("dbo.GameTypes", new[] { "GameId" });
            DropIndex("dbo.GameTypes", new[] { "TypeId" });
            DropIndex("dbo.Games", new[] { "DeveloperId" });
            DropForeignKey("dbo.GameTypes", "GameId", "dbo.Games");
            DropForeignKey("dbo.GameTypes", "TypeId", "dbo.Types");
            DropForeignKey("dbo.Games", "DeveloperId", "dbo.Developers");
            DropTable("dbo.Developers");
            DropTable("dbo.Types");
            DropTable("dbo.GameTypes");
            DropTable("dbo.Games");
        }
    }
}
