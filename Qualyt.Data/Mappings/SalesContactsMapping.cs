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
    class SalesContactsMapping : IEntityTypeConfiguration<SalesContact>
    {
        public void Configure(EntityTypeBuilder<SalesContact> entity)
        {
            entity.ToTable("salescontact").HasKey(x => x.Id);
        }
    }
}
