using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qualyt.Domain.Models;
using Qualyt.Domain.Models.HealthInsurances;
using Qualyt.Domain.Models.Laboratories;

namespace Qualyt.Data.Mappings
{
    class LaboratoriesMapping : IEntityTypeConfiguration<Laboratory>
    {
        public void Configure(EntityTypeBuilder<Laboratory> entity)
        {
            entity.ToTable("laboratories").HasKey(x => x.Id);
            entity.HasIndex(x => x.Name).IsUnique();
            entity.HasMany<Product>().WithOne(x => x.Laboratory).HasForeignKey(x => x.LaboratoryId);
        }
    }
}
