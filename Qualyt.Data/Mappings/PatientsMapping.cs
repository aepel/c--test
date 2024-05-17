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
    class PatientsMapping : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> entity)
        {
            entity.ToTable("patients").HasKey(x => x.Id);
            entity.HasOne(x => x.HealthInsurance).WithMany().HasForeignKey(x => x.HealthInsuranceId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.Doctor).WithMany().HasForeignKey(x => x.DoctorId);
            entity.HasOne(x => x.Plan).WithMany().HasForeignKey(x => x.PlanId);
            entity.OwnsOne(x => x.Location, l => {
                l.Property(x => x.Address).HasColumnName("Address");
                l.Property(x => x.Latitude).HasColumnName("Latitude");
                l.Property(x => x.Longitude).HasColumnName("Longitude");
            });
            entity.HasMany(x => x.AcceptedTerms).WithOne().HasForeignKey(x => x.PatientId);
            entity.HasOne(x => x.Country).WithMany().HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Restrict);
            entity.HasIndex(x => new { x.IdNumber,x.PlanId}).IsUnique();
            entity.HasOne(x => x.Nurse).WithMany().HasForeignKey(x => x.NurseId).IsRequired(false).OnDelete(DeleteBehavior.Restrict);
            entity.OwnsOne(x => x.ClinicalHistory, ch => ch.ToTable("clinicalhistories"));
            entity.Property(x => x.EmailSended).HasDefaultValue(false);
        }
    }
}
