using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qualyt.Domain.Models;
using Qualyt.Domain.Models.AssociativeClasses;
using Qualyt.Domain.Models.HealthInsurances;
using Qualyt.Domain.Models.Laboratories;
using Qualyt.Domain.Models.MedicalTreatments;

namespace Qualyt.Data.Mappings
{
    class PlanProductsMapping : IEntityTypeConfiguration<PlanProduct>
    {
        public void Configure(EntityTypeBuilder<PlanProduct> entity)
        {
            entity.ToTable("planproducts").HasKey(x => new {x.ProductId,x.PlanId });
            entity.HasOne(x=>x.Product).WithMany().HasForeignKey(x=>x.ProductId);
            entity.HasOne<Plan>().WithMany(x=>x.PlanProducts).HasForeignKey(x=>x.PlanId);
        }
    }
}
