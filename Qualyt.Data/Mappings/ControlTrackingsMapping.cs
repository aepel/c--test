using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qualyt.Domain.Models;
using Qualyt.Domain.Models.HealthInsurances;
using Qualyt.Domain.Models.Laboratories;
using Qualyt.Domain.Models.MedicalTreatments;

namespace Qualyt.Data.Mappings
{
    class ControlTrackingsMapping : IEntityTypeConfiguration<ControlTracking>
    {
        public void Configure(EntityTypeBuilder<ControlTracking> entity)
        {
            entity.ToTable("controltrackings").HasKey(x => x.Id);
            entity.HasOne(x => x.CreatedByUser).WithMany().HasForeignKey(x => x.CreatedBy).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
