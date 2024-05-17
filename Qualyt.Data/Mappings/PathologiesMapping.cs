﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qualyt.Domain.Models;
using Qualyt.Domain.Models.HealthInsurances;
using Qualyt.Domain.Models.Laboratories;
using Qualyt.Domain.Models.MedicalTreatments;

namespace Qualyt.Data.Mappings
{
    class PathologiesMapping : IEntityTypeConfiguration<Pathology>
    {
        public void Configure(EntityTypeBuilder<Pathology> entity)
        {
            entity.ToTable("pathologies").HasKey(x => x.Id);
            entity.HasOne(x=>x.Laboratory).WithMany().HasForeignKey(x=>x.LaboratoryId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
