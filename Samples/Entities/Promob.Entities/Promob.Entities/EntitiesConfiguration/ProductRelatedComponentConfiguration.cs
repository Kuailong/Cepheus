using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

namespace Promob.Entities.EntitiesConfiguration
{
    public class ProductRelatedComponentConfiguration : EntityTypeConfiguration<ProductRelatedComponent>
    {
        public ProductRelatedComponentConfiguration()
        {
            this.Map(m => m.Requires("Type").HasValue("ProductRelated"))
                .ToTable("Components");
        }
    }
}
