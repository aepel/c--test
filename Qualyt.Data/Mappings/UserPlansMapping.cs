using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qualyt.Domain.Models;
using Qualyt.Domain.Models.AssociativeClasses;
using Qualyt.Domain.Models.HealthInsurances;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;

namespace Qualyt.Data.Mappings
{
    class UserPlansMapping : IEntityTypeConfiguration<UserPlan>
    {
        public void Configure(EntityTypeBuilder<UserPlan> entity)
        {
            entity.ToTable("userplans").HasKey(x => new { x.UserId, x.PlanId });
            entity.HasOne(x => x.Plan).WithMany().HasForeignKey(x => x.PlanId);
            entity.HasOne<ApplicationUser>().WithMany(x=>x.Plans).HasForeignKey(x => x.UserId);
        }
    }
}
