using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qualyt.Domain.Models;
using Qualyt.Domain.Models.HealthInsurances;

namespace Qualyt.Data.Mappings
{
    class HealthInsurancesMapping : IEntityTypeConfiguration<HealthInsurance>
    {
        public void Configure(EntityTypeBuilder<HealthInsurance> entity)
        {
            entity.ToTable("healthinsurances").HasKey(x => x.Id);
            entity.HasIndex(x => x.Name).IsUnique();
            entity.HasOne(x => x.Country).WithMany().HasForeignKey(x => x.CountryId);
            
        }
    }
}
