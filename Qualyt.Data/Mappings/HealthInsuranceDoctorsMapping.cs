using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qualyt.Domain.Models;
using Qualyt.Domain.Models.AssociativeClasses;
using Qualyt.Domain.Models.HealthInsurances;
using Qualyt.Domain.Models.Users;

namespace Qualyt.Data.Mappings
{
    class HealthInsuranceDoctorsMapping : IEntityTypeConfiguration<HealthInsuranceDoctor>
    {
        public void Configure(EntityTypeBuilder<HealthInsuranceDoctor> entity)
        {
            entity.ToTable("healthinsurancedoctors").HasKey(x => new { x.DoctorId, x.HealthInsuranceId });
            entity.HasOne(x => x.HealthInsurance).WithMany().HasForeignKey(x => x.HealthInsuranceId);
            entity.HasOne<Doctor>().WithMany(x=>x.HealthInsuranceDoctors).HasForeignKey(x => x.DoctorId);
        }
    }
}
