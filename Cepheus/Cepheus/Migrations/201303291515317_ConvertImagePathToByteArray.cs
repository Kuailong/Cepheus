namespace Cepheus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConvertImagePathToByteArray : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Image", c => c.Binary());
            DropColumn("dbo.Games", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "ImagePath", c => c.String());
            DropColumn("dbo.Games", "Image");
        }
    }
}
