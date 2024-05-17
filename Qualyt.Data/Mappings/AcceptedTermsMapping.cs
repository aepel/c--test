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
    class AcceptedTermsMapping : IEntityTypeConfiguration<AttachedFile>
    {
        public void Configure(EntityTypeBuilder<AttachedFile> entity)
        {
            entity.ToTable("attachedfiles").HasKey(x => x.Id);
            entity.HasOne(x => x.TermsAndConditions).WithMany().HasForeignKey(x => x.TermsAndConditionsId).IsRequired(false);
        }
    }
}
