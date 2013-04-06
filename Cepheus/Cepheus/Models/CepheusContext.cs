using Cepheus.Entities;
using Cepheus.Entities.Configurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cepheus.Models
{
    public class CepheusContext : DbContext
    {
        #region Properties

        public DbSet<Game> Games { get; set; }
        public DbSet<GameAndType> GameAndType { get; set; }
        public DbSet<GameType> GameTypes { get; set; }
        public DbSet<Developer> Developers { get; set; }

        #endregion

        #region Constructor

        public CepheusContext()
            : base("CepheusDB")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public CepheusContext(bool lazyLoadingEnabled)
            : base("CepheusDB")
        {
            this.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
        }

        #endregion

        #region Override Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new GameConfig());
            modelBuilder.Configurations.Add(new GameAndTypeConfig());
            modelBuilder.Configurations.Add(new GameTypeConfig());
            modelBuilder.Configurations.Add(new DeveloperConfig());
        }

        #endregion
    }
}