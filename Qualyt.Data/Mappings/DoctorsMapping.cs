using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qualyt.Domain.Models;
using Qualyt.Domain.Models.HealthInsurances;
using Qualyt.Domain.Models.Laboratories;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;

namespace Qualyt.Data.Mappings
{
    class DoctorsMapping : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> entity)
        {
            entity.HasOne(x => x.Specialty).WithMany().HasForeignKey(x => x.SpecialtyId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.SalesContact).WithMany().HasForeignKey(x => x.SalesContactId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.AttentionPlace).WithMany().HasForeignKey(x => x.AttentionPlaceId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.Country).WithMany().HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Restrict);
            entity.OwnsOne(x => x.Location, l => {
                l.Property(x => x.Address).HasColumnName("Address");
                l.Property(x => x.Latitude).HasColumnName("Latitude");
                l.Property(x => x.Longitude).HasColumnName("Longitude");
            });

        }
    }
}
