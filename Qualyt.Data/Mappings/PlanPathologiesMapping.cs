using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qualyt.Domain.Models;
using Qualyt.Domain.Models.AssociativeClasses;
using Qualyt.Domain.Models.HealthInsurances;
using Qualyt.Domain.Models.Laboratories;
using Qualyt.Domain.Models.MedicalTreatments;

namespace Qualyt.Data.Mappings
{
    class PlanPathologiesMapping : IEntityTypeConfiguration<PlanPathology>
    {
        public void Configure(EntityTypeBuilder<PlanPathology> entity)
        {
            entity.ToTable("planpathologies").HasKey(x => new {x.PathologyId,x.PlanId });
            entity.HasOne(x=>x.Pathology).WithMany().HasForeignKey(x=>x.PathologyId);
            entity.HasOne<Plan>().WithMany(x=>x.PlanPathologies).HasForeignKey(x=>x.PlanId);
        }
    }
}
