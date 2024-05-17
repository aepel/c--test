using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qualyt.Domain.Models;
using Qualyt.Domain.Models.HealthInsurances;
using Qualyt.Domain.Models.Laboratories;

namespace Qualyt.Data.Mappings
{
    class ProductsMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.ToTable("products").HasKey(x => x.Id);
            entity.HasIndex(x => x.Name).IsUnique();
        }
    }
}
