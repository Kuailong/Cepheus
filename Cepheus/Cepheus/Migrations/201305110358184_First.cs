namespace Cepheus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        NameUser = c.String(nullable: false, maxLength: 128),
                        Key = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.NameUser);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
