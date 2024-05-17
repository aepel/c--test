using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Qualyt.Domain.Models;
using Qualyt.Domain.Models.Interfaces;
using Qualyt.Data.Mappings;
using Qualyt.Domain.Models.Users;
using Qualyt.Domain.Models.Laboratories;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.HealthInsurances;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.AssociativeClasses;
using Qualyt.Domain.Models.Mails;
using Microsoft.EntityFrameworkCore.Infrastructure;
using EFSecondLevelCache.Core;
using EFSecondLevelCache.Core.Contracts;
using Qualyt.Domain.Models.Localization;

namespace Qualyt.Data
{
    public class MCADbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public string CurrentUserId { get; set; }

        public MCADbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<HealthInsurance> HealthInsurances{ get; set; }
        public DbSet<Pathology> Pathologies { get; internal set; }
        public DbSet<Doctor> Doctors { get; internal set; }
        public DbSet<AttentionPlace> AttentionPlaces { get; internal set; }
        public DbSet<SalesContact> SalesContacts { get; internal set; }
        public DbSet<DoctorSpecialty> DoctorSpecialties { get; internal set; }
        public DbSet<UserCountry> UserCountries { get; internal set; }
        //public DbSet<LaboratoryUser> LaboratoryUsers { get; internal set; }
        public DbSet<Laboratory> Laboratories { get; internal set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ControlTracking> ControlTrackings { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ApplicationUsersMapping());
            builder.ApplyConfiguration(new ApplicationRolesMapping());
            builder.ApplyConfiguration(new AttentionPlacesMapping());
            builder.ApplyConfiguration(new ControlTrackingsMapping());
            builder.ApplyConfiguration(new CountriesMapping());
            builder.ApplyConfiguration(new SalesContactsMapping());
            builder.ApplyConfiguration(new DevicesMapping());
            builder.ApplyConfiguration(new DoctorsMapping());
            builder.ApplyConfiguration(new DoctorSpecialtiesMapping());
            builder.ApplyConfiguration(new HealthInsuranceDoctorsMapping());
            builder.ApplyConfiguration(new HealthInsurancesMapping());
            builder.ApplyConfiguration(new LaboratoriesMapping());
            builder.ApplyConfiguration(new LaboratoryUsersMapping());
            builder.ApplyConfiguration(new MedicinesMapping());
            builder.ApplyConfiguration(new OperatorsMapping());
            builder.ApplyConfiguration(new PathologiesMapping());
            builder.ApplyConfiguration(new PatientsMapping());
            builder.ApplyConfiguration(new PatientTermsAndConditionsMapping());
            builder.ApplyConfiguration(new ProductsMapping());
            builder.ApplyConfiguration(new PatientPathologiesMapping());
            builder.ApplyConfiguration(new TermsAndConditionsMapping());
            builder.ApplyConfiguration(new TreatmentsMapping());
            builder.ApplyConfiguration(new UserCountriesMapping());
            builder.ApplyConfiguration(new UserPlansMapping());
            builder.ApplyConfiguration(new NursesMapping());
            builder.ApplyConfiguration(new PlansMapping());
            builder.ApplyConfiguration(new PlanPathologiesMapping());
            builder.ApplyConfiguration(new PlanProductsMapping());
        }




        public override int SaveChanges()
        {
            this.ChangeTracker.DetectChanges();
            var changedEntityNames = this.GetChangedEntityNames();

            UpdateAuditEntities();

            var result = base.SaveChanges();
            this.GetService<IEFCacheServiceProvider>().InvalidateCacheDependencies(changedEntityNames);

            return result;
        }


        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ChangeTracker.DetectChanges();
            var changedEntityNames = this.GetChangedEntityNames();

            UpdateAuditEntities();
            var result = base.SaveChanges(acceptAllChangesOnSuccess);
            this.GetService<IEFCacheServiceProvider>().InvalidateCacheDependencies(changedEntityNames);

            return result;
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.ChangeTracker.DetectChanges();
            var changedEntityNames = this.GetChangedEntityNames();

            UpdateAuditEntities();
            var result = base.SaveChangesAsync(cancellationToken);
            this.GetService<IEFCacheServiceProvider>().InvalidateCacheDependencies(changedEntityNames);

            return result;
        }


        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            this.ChangeTracker.DetectChanges();
            var changedEntityNames = this.GetChangedEntityNames();

            UpdateAuditEntities();
            var result = base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            this.GetService<IEFCacheServiceProvider>().InvalidateCacheDependencies(changedEntityNames);

            return result;
        }


        private void UpdateAuditEntities()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));


            foreach (var entry in modifiedEntries)
            {
                var entity = (IAuditableEntity)entry.Entity;
                DateTimeOffset now = DateTimeOffset.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedDate = now;
                    entity.CreatedBy = CurrentUserId;
                    entity.Active = true;
                }
                else
                {
                    base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                    base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                }

                entity.UpdatedDate = now;
                entity.UpdatedBy = CurrentUserId;
            }
        }
    }
}
