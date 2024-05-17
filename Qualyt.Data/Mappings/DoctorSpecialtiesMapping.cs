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
    class DoctorSpecialtiesMapping : IEntityTypeConfiguration<DoctorSpecialty>
    {
        public void Configure(EntityTypeBuilder<DoctorSpecialty> entity)
        {
            entity.ToTable("doctorspecialties").HasKey(x => x.Id);
            entity.HasIndex(x => x.Name).IsUnique();
        }
    }
}
