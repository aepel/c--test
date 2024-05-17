using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qualyt.Domain.Models;
using Qualyt.Domain.Models.AssociativeClasses;
using Qualyt.Domain.Models.HealthInsurances;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;

namespace Qualyt.Data.Mappings
{
    class PatientTermsAndConditionsMapping : IEntityTypeConfiguration<PatientTermsAndConditions>
    {
        public void Configure(EntityTypeBuilder<PatientTermsAndConditions> entity)
        {
            entity.ToTable("patienttermsandconditions").HasKey(x => new { x.TermsAndConditionsId, x.PatientId });
            entity.HasOne(x => x.TermsAndConditions).WithMany().HasForeignKey(x => x.TermsAndConditionsId);
            entity.HasOne<Patient>().WithMany(x=>x.PatientTermsAndConditions).HasForeignKey(x => x.PatientId);
        }
    }
}
