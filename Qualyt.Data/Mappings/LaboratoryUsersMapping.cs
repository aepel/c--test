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
    class LaboratoryUsersMapping : IEntityTypeConfiguration<LaboratoryUser>
    {
        public void Configure(EntityTypeBuilder<LaboratoryUser> entity)
        {
            entity.HasOne(x => x.Laboratory).WithMany().HasForeignKey(x => x.LaboratoryId);
            //entity.OwnsOne(x => x.Location);
        }
    }
}
