using System.Data.Entity;
using Promob.Entities;
using Promob.Entities.EntitiesConfiguration;
using Procad.DataAccess.Interfaces;

namespace PublicationsService.Models
{
    public class PromobPublicationsEntities : DbContext, IUnitOfWork
    {
        #region Constructor

        public PromobPublicationsEntities()
            : base("PromobPublications")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public PromobPublicationsEntities(bool lazyLoadingEnabled)
            : base("PromobPublications")
        {
            this.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Configurations.Add(new ProductRelatedComponentConfiguration());
            modelBuilder.Configurations.Add(new GeneralComponentConfiguration());
            modelBuilder.Configurations.Add(new ComponentConfiguration());
            modelBuilder.Configurations.Add(new PublicationConfiguration());
            modelBuilder.Configurations.Add(new ComponentCriteriaConfiguration());
            modelBuilder.Configurations.Add(new ComponentTypeConfiguration());
            modelBuilder.Configurations.Add(new PublicationsComponentsCompatibilitiesConfiguration());
            modelBuilder.Configurations.Add(new UpdatesConfiguration());
            modelBuilder.Configurations.Add(new FileConfiguration());
        }

        #endregion

        #region Properties

        public DbSet<Component> Components { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<ComponentCriteria> ComponentCriterias { get; set; }
        public DbSet<ComponentType> ComponentTypes { get; set; }
        public DbSet<PublicationsComponentsCompatibilities> Compatibilities { get; set; }
        public DbSet<Updates> Updates { get; set; }
        public DbSet<File> Files { get; set; }

        #endregion

        #region IUnitOfWork Members

        public void Save()
        {
            SaveChanges();
        }

        #endregion

    }
}