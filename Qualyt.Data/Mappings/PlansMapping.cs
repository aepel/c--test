using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qualyt.Domain.Models;
using Qualyt.Domain.Models.HealthInsurances;
using Qualyt.Domain.Models.Laboratories;
using Qualyt.Domain.Models.MedicalTreatments;

namespace Qualyt.Data.Mappings
{
    class PlansMapping : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> entity)
        {
            entity.ToTable("plans").HasKey(x => x.Id);
            entity.HasOne(x=>x.Laboratory).WithMany().HasForeignKey(x=>x.LaboratoryId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x=>x.Country).WithMany().HasForeignKey(x=>x.CountryId).OnDelete(DeleteBehavior.Restrict);
            entity.HasIndex(x => x.Name).IsUnique();
        }
    }
}
