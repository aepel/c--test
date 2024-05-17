using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qualyt.Domain.Models;
using Qualyt.Domain.Models.HealthInsurances;
using Qualyt.Domain.Models.Laboratories;
using Qualyt.Domain.Models.MedicalTreatments;

namespace Qualyt.Data.Mappings
{
    class TreatmentsMapping : IEntityTypeConfiguration<Treatment>
    {
        public void Configure(EntityTypeBuilder<Treatment> entity)
        {
            entity.ToTable("treatments").HasKey(x => x.Id);
            entity.HasMany(x => x.ControlTrackings).WithOne().HasForeignKey(x => x.TreatmentId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.Doctor).WithMany().HasForeignKey(x => x.DoctorId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.Pathology).WithMany().HasForeignKey(x => x.PathologyId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.Patient).WithMany().HasForeignKey(x => x.PatientId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
