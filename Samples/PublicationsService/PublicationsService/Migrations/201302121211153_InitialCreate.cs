namespace PublicationsService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Components",
                c => new
                    {
                        ComponentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ComponentTypeId = c.Int(nullable: false),
                        ProductId = c.Int(),
                        Type = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ComponentId)
                .ForeignKey("dbo.ComponentTypes", t => t.ComponentTypeId, cascadeDelete: true)
                .Index(t => t.ComponentTypeId);
            
            CreateTable(
                "dbo.ComponentTypes",
                c => new
                    {
                        ComponentTypeId = c.Int(nullable: false, identity: true),
                        MaxPublications = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        RequiresCompatibility = c.Boolean(nullable: false),
                        VisibleOnUI = c.Boolean(),
                    })
                .PrimaryKey(t => t.ComponentTypeId);
            
            CreateTable(
                "dbo.Publications",
                c => new
                    {
                        PublicationId = c.Int(nullable: false, identity: true),
                        Active = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        StorageUri = c.String(nullable: false, maxLength: 200),
                        StorageRelativeFilesPath = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false, maxLength: 200),
                        ComponentId = c.Int(nullable: false),
                        Version = c.String(nullable: false, maxLength: 50),
                        Lenght = c.String(maxLength: 50),
                        PublicationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PublicationId)
                .ForeignKey("dbo.Components", t => t.ComponentId, cascadeDelete: true)
                .Index(t => t.ComponentId);
            
            CreateTable(
                "dbo.PublicationLibraries",
                c => new
                    {
                        PublicationLibraryId = c.Int(nullable: false, identity: true),
                        PublicationId = c.Int(nullable: false),
                        Name = c.String(),
                        Version = c.String(),
                        Revision = c.String(),
                    })
                .PrimaryKey(t => t.PublicationLibraryId)
                .ForeignKey("dbo.Publications", t => t.PublicationId, cascadeDelete: true)
                .Index(t => t.PublicationId);
            
            CreateTable(
                "dbo.ComponentCriterias",
                c => new
                    {
                        ComponentCriteriaId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        SubGroupId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                        HighRelevant = c.Boolean(nullable: false),
                        PublicationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ComponentCriteriaId)
                .ForeignKey("dbo.Publications", t => t.PublicationId, cascadeDelete: true)
                .Index(t => t.PublicationId);
            
            CreateTable(
                "dbo.PublicationsComponentsCompatibilities",
                c => new
                    {
                        CompatibilityId = c.Int(nullable: false, identity: true),
                        PublicationId = c.Int(nullable: false),
                        CompatibleComponentId = c.Int(nullable: false),
                        CompatibilityVersion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CompatibilityId)
                .ForeignKey("dbo.Publications", t => t.PublicationId, cascadeDelete: true)
                .ForeignKey("dbo.Components", t => t.CompatibleComponentId)
                .Index(t => t.PublicationId)
                .Index(t => t.CompatibleComponentId);
            
            CreateTable(
                "dbo.Updates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SerialNumber = c.String(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        ComponentId = c.Int(nullable: false),
                        PublicationVersion = c.String(nullable: false),
                        AccountId = c.Int(nullable: false),
                        LibraryId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        MD5 = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.MD5);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.PublicationsComponentsCompatibilities", new[] { "CompatibleComponentId" });
            DropIndex("dbo.PublicationsComponentsCompatibilities", new[] { "PublicationId" });
            DropIndex("dbo.ComponentCriterias", new[] { "PublicationId" });
            DropIndex("dbo.PublicationLibraries", new[] { "PublicationId" });
            DropIndex("dbo.Publications", new[] { "ComponentId" });
            DropIndex("dbo.Components", new[] { "ComponentTypeId" });
            DropForeignKey("dbo.PublicationsComponentsCompatibilities", "CompatibleComponentId", "dbo.Components");
            DropForeignKey("dbo.PublicationsComponentsCompatibilities", "PublicationId", "dbo.Publications");
            DropForeignKey("dbo.ComponentCriterias", "PublicationId", "dbo.Publications");
            DropForeignKey("dbo.PublicationLibraries", "PublicationId", "dbo.Publications");
            DropForeignKey("dbo.Publications", "ComponentId", "dbo.Components");
            DropForeignKey("dbo.Components", "ComponentTypeId", "dbo.ComponentTypes");
            DropTable("dbo.Files");
            DropTable("dbo.Updates");
            DropTable("dbo.PublicationsComponentsCompatibilities");
            DropTable("dbo.ComponentCriterias");
            DropTable("dbo.PublicationLibraries");
            DropTable("dbo.Publications");
            DropTable("dbo.ComponentTypes");
            DropTable("dbo.Components");
        }
    }
}
