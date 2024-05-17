using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qualyt.Domain.Models;
using Qualyt.Domain.Models.AssociativeClasses;
using Qualyt.Domain.Models.HealthInsurances;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;

namespace Qualyt.Data.Mappings
{
    class PatientPathologiesMapping : IEntityTypeConfiguration<PatientPathology>
    {
        public void Configure(EntityTypeBuilder<PatientPathology> entity)
        {
            entity.ToTable("patientpathologies").HasKey(x => new { x.PathologyId, x.PatientId });
            entity.HasOne(x => x.Pathology).WithMany().HasForeignKey(x => x.PathologyId);
            entity.HasOne<Patient>().WithMany(x=>x.PatientPathologies).HasForeignKey(x => x.PatientId);
        }
    }
}
