using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qualyt.Domain.Models;
using Qualyt.Domain.Models.HealthInsurances;
using Qualyt.Domain.Models.Laboratories;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;

namespace Qualyt.Data.Mappings
{
    class TermsAndConditionsMapping : IEntityTypeConfiguration<TermsAndConditions>
    {
        public void Configure(EntityTypeBuilder<TermsAndConditions> entity)
        {
            entity.ToTable("termsandconditions").HasKey(x => x.Id);
        }
    }
}
