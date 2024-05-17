using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qualyt.Domain.Models;
using Qualyt.Domain.Models.AssociativeClasses;
using Qualyt.Domain.Models.HealthInsurances;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;

namespace Qualyt.Data.Mappings
{
    class UserCountriesMapping : IEntityTypeConfiguration<UserCountry>
    {
        public void Configure(EntityTypeBuilder<UserCountry> entity)
        {
            entity.ToTable("usercountries").HasKey(x => new { x.UserId, x.CountryId });
            entity.HasOne(x => x.Country).WithMany().HasForeignKey(x => x.CountryId);
            entity.HasOne<ApplicationUser>().WithMany(x=>x.Countries).HasForeignKey(x => x.UserId);
        }
    }
}
