// <auto-generated />
namespace Cepheus.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    public sealed partial class First : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(First));
        
        string IMigrationMetadata.Id
        {
            get { return "201305110358184_First"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}