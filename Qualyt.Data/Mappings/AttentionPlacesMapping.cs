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
    class AttentionPlacesMapping : IEntityTypeConfiguration<AttentionPlace>
    {
        public void Configure(EntityTypeBuilder<AttentionPlace> entity)
        {
            entity.ToTable("attentionplaces").HasKey(x => x.Id);
            entity.HasIndex(x => x.Name).IsUnique();
            
        }
    }
}
