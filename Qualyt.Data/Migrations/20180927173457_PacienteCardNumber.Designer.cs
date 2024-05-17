﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Qualyt.Data;

namespace Qualyt.Data.Migrations
{
    [DbContext(typeof(MCADbContext))]
    [Migration("20180927173457_PacienteCardNumber")]
    partial class PacienteCardNumber
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("OpenIddict.EntityFrameworkCore.Models.OpenIddictApplication", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClientId")
                        .IsRequired();

                    b.Property<string>("ClientSecret");

                    b.Property<string>("ConcurrencyToken")
                        .IsConcurrencyToken();

                    b.Property<string>("ConsentType");

                    b.Property<string>("DisplayName");

                    b.Property<string>("Permissions");

                    b.Property<string>("PostLogoutRedirectUris");

                    b.Property<string>("Properties");

                    b.Property<string>("RedirectUris");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("OpenIddictApplications");
                });

            modelBuilder.Entity("OpenIddict.EntityFrameworkCore.Models.OpenIddictAuthorization", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationId");

                    b.Property<string>("ConcurrencyToken")
                        .IsConcurrencyToken();

                    b.Property<string>("Properties");

                    b.Property<string>("Scopes");

                    b.Property<string>("Status")
                        .IsRequired();

                    b.Property<string>("Subject")
                        .IsRequired();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.ToTable("OpenIddictAuthorizations");
                });

            modelBuilder.Entity("OpenIddict.EntityFrameworkCore.Models.OpenIddictScope", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyToken")
                        .IsConcurrencyToken();

                    b.Property<string>("Description");

                    b.Property<string>("DisplayName");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Properties");

                    b.Property<string>("Resources");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("OpenIddictScopes");
                });

            modelBuilder.Entity("OpenIddict.EntityFrameworkCore.Models.OpenIddictToken", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationId");

                    b.Property<string>("AuthorizationId");

                    b.Property<string>("ConcurrencyToken")
                        .IsConcurrencyToken();

                    b.Property<DateTimeOffset?>("CreationDate");

                    b.Property<DateTimeOffset?>("ExpirationDate");

                    b.Property<string>("Payload");

                    b.Property<string>("Properties");

                    b.Property<string>("ReferenceId");

                    b.Property<string>("Status");

                    b.Property<string>("Subject")
                        .IsRequired();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("AuthorizationId");

                    b.HasIndex("ReferenceId")
                        .IsUnique();

                    b.ToTable("OpenIddictTokens");
                });

            modelBuilder.Entity("Qualyt.Domain.Models.AssociativeClasses.HealthInsuranceDoctor", b =>
                {
                    b.Property<string>("DoctorId");

                    b.Property<long>("HealthInsuranceId");

                    b.HasKey("DoctorId", "HealthInsuranceId");

                    b.HasIndex("HealthInsuranceId");

                    b.ToTable("healthinsurancedoctors");
                });

            modelBuilder.Entity("Qualyt.Domain.Models.AssociativeClasses.PatientPathology", b =>
                {
                    b.Property<long>("PathologyId");

                    b.Property<long>("PatientId");

                    b.HasKey("PathologyId", "PatientId");

                    b.HasIndex("PatientId");

                    b.ToTable("patientpathologies");
                });

            modelBuilder.Entity("Qualyt.Domain.Models.AssociativeClasses.PatientTermsAndConditions", b =>
                {
                    b.Property<long>("TermsAndConditionsId");

                    b.Property<long>("PatientId");

                    b.HasKey("TermsAndConditionsId", "PatientId");

                    b.HasIndex("PatientId");

                    b.ToTable("patienttermsandconditions");
                });

            modelBuilder.Entity("Qualyt.Domain.Models.AssociativeClasses.UserCountry", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<long>("CountryId");

                    b.HasKey("UserId", "CountryId");

                    b.HasIndex("CountryId");

                    b.ToTable("usercountries");
                });

            modelBuilder.Entity("Qualyt.Domain.Models.HealthInsurances.HealthInsurance", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<string>("Name");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTimeOffset?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("healthinsurances");
                });

            modelBuilder.Entity("Qualyt.Domain.Models.Laboratories.Laboratory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<string>("Name");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTimeOffset?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("laboratories");
                });

            modelBuilder.Entity("Qualyt.Domain.Models.Laboratories.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<long>("Amount");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<long>("LaboratoryId");

                    b.Property<long?>("LaboratoryId1");

                    b.Property<string>("Name");

                    b.Property<string>("SerializedFields");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTimeOffset?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("LaboratoryId");

                    b.HasIndex("LaboratoryId1");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("products");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Product");
                });

            modelBuilder.Entity("Qualyt.Domain.Models.MedicalTreatments.ControlTracking", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Comments");

                    b.Property<int>("ContactMethod");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<DateTimeOffset>("NextControl");

                    b.Property<long>("TreatmentId");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTimeOffset?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("TreatmentId");

                    b.ToTable("controltrackings");
                });

            modelBuilder.Entity("Qualyt.Domain.Models.MedicalTreatments.Pathology", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<string>("Name");

                    b.Property<string>("SerializedFields");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTimeOffset?>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("pathologies");
                });

            modelBuilder.Entity("Qualyt.Domain.Models.MedicalTreatments.Treatment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<string>("DoctorId");

                    b.Property<double>("Dose");

                    b.Property<double>("DoseFrequency");

                    b.Property<int>("DoseFrequencyType");

                    b.Property<double>("Duration");

                    b.Property<int>("DurationType");

                    b.Property<long>("PathologyId");

                    b.Property<long>("PatientId");

                    b.Property<long>("ProductId");

                    b.Property<string>("SerializedPathologyFields");

                    b.Property<string>("SerializedProductFields");

                    b.Property<int>("State");

                    b.Property<int?>("StateReason");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTimeOffset?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PathologyId");

                    b.HasIndex("PatientId");

                    b.HasIndex("ProductId");

                    b.ToTable("treatments");
                });

            modelBuilder.Entity("Qualyt.Domain.Models.Patients.Patient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTimeOffset>("BirthDate");

                    b.Property<string>("CardNumber");

                    b.Property<string>("CellPhoneNumber");

                    b.Property<long>("CountryId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<string>("DoctorId");

                    b.Property<string>("Email");

                    b.Property<int>("Gender");

                    b.Property<long>("HealthInsuranceId");

                    b.Property<string>("IdNumber");

                    b.Property<int>("MaritalStatus");

                    b.Property<string>("MothersSurname");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("PreferedContactMethod");

                    b.Property<bool>("SecondHealthInsurance");

                    b.Property<string>("Surname");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTimeOffset?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("HealthInsuranceId");

                    b.ToTable("patients");
                });

            modelBuilder.Entity("Qualyt.Domain.Models.Patients.TermsAndConditions", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Published");

                    b.Property<string>("PublishedBy");

                    b.Property<DateTimeOffset?>("PublishedDate");

                    b.Property<string>("Text");

                    b.Property<long?>("Version");

                    b.HasKey("Id");

                    b.ToTable("termsandconditions");
                });

            modelBuilder.Entity("Qualyt.Domain.Models.Users.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTimeOffset?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Qualyt.Domain.Models.Users.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<bool>("Active");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTimeOffset?>("UpdatedDate");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Qualyt.Domain.Models.Users.AttentionPlace", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("attentionplaces");
                });

            modelBuilder.Entity("Qualyt.Domain.Models.Users.Country", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Prefix");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("countries");
                });

            modelBuilder.Entity("Qualyt.Domain.Models.Users.DoctorSpecialty", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("doctorspecialties");
                });

            modelBuilder.Entity("Qualyt.Domain.Models.Users.SalesContact", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("salescontact");
                });

            modelBuilder.Entity("Qualyt.Domain.Models.Laboratories.Device", b =>
                {
                    b.HasBaseType("Qualyt.Domain.Models.Laboratories.Product");

                    b.Property<int>("Type");

                    b.ToTable("Device");

                    b.HasDiscriminator().HasValue("Device");
                });

            modelBuilder.Entity("Qualyt.Domain.Models.Laboratories.Medicine", b =>
                {
                    b.HasBaseType("Qualyt.Domain.Models.Laboratories.Product");

                    b.Property<string>("DefinedDailyDose");

                    b.Property<int>("Form");

                    b.Property<double>("Variation");

                    b.Property<int>("VariationUnit");

                    b.ToTable("Medicine");

                    b.HasDiscriminator().HasValue("Medicine");
                });

            modelBuilder.Entity("Qualyt.Domain.Models.Users.Doctor", b =>
                {
                    b.HasBaseType("Qualyt.Domain.Models.Users.ApplicationUser");

                    b.Property<long>("AttentionPlaceId");

                    b.Property<string>("CellPhoneNumber");

                    b.Property<string>("IdNumber");

                    b.Property<string>("MothersSurname");

                    b.Property<string>("Name");

                    b.Property<long>("SalesContactId");

                    b.Property<long>("SpecialtyId");

                    b.Property<string>("Surname");

                    b.HasIndex("AttentionPlaceId");

                    b.HasIndex("SalesContactId");

                    b.HasIndex("SpecialtyId");

                    b.ToTable("Doctor");

                    b.HasDiscriminator().HasValue("Doctor");
                });

            modelBuilder.Entity("Qualyt.Domain.Models.Users.LaboratoryUser", b =>
                {
                    b.HasBaseType("Qualyt.Domain.Models.Users.ApplicationUser");

                    b.Property<long>("LaboratoryId");

                    b.HasIndex("LaboratoryId");

                    b.ToTable("LaboratoryUser");

                    b.HasDiscriminator().HasValue("LaboratoryUser");
                });

            modelBuilder.Entity("Qualyt.Domain.Models.Users.Operator", b =>
                {
                    b.HasBaseType("Qualyt.Domain.Models.Users.ApplicationUser");


                    b.ToTable("Operator");

                    b.HasDiscriminator().HasValue("Operator");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Qualyt.Domain.Models.Users.ApplicationRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Qualyt.Domain.Models.Users.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Qualyt.Domain.Models.Users.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Qualyt.Domain.Models.Users.ApplicationRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Qualyt.Domain.Models.Users.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Qualyt.Domain.Models.Users.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OpenIddict.EntityFrameworkCore.Models.OpenIddictAuthorization", b =>
                {
                    b.HasOne("OpenIddict.EntityFrameworkCore.Models.OpenIddictApplication", "Application")
                        .WithMany("Authorizations")
                        .HasForeignKey("ApplicationId");
                });

            modelBuilder.Entity("OpenIddict.EntityFrameworkCore.Models.OpenIddictToken", b =>
                {
                    b.HasOne("OpenIddict.EntityFrameworkCore.Models.OpenIddictApplication", "Application")
                        .WithMany("Tokens")
                        .HasForeignKey("ApplicationId");

                    b.HasOne("OpenIddict.EntityFrameworkCore.Models.OpenIddictAuthorization", "Authorization")
                        .WithMany("Tokens")
                        .HasForeignKey("AuthorizationId");
                });

            modelBuilder.Entity("Qualyt.Domain.Models.AssociativeClasses.HealthInsuranceDoctor", b =>
                {
                    b.HasOne("Qualyt.Domain.Models.Users.Doctor")
                        .WithMany("HealthInsuranceDoctors")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Qualyt.Domain.Models.HealthInsurances.HealthInsurance", "HealthInsurance")
                        .WithMany()
                        .HasForeignKey("HealthInsuranceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Qualyt.Domain.Models.AssociativeClasses.PatientPathology", b =>
                {
                    b.HasOne("Qualyt.Domain.Models.MedicalTreatments.Pathology", "Pathology")
                        .WithMany()
                        .HasForeignKey("PathologyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Qualyt.Domain.Models.Patients.Patient")
                        .WithMany("PatientPathologies")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Qualyt.Domain.Models.AssociativeClasses.PatientTermsAndConditions", b =>
                {
                    b.HasOne("Qualyt.Domain.Models.Patients.Patient")
                        .WithMany("PatientTermsAndConditions")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Qualyt.Domain.Models.Patients.TermsAndConditions", "TermsAndConditions")
                        .WithMany()
                        .HasForeignKey("TermsAndConditionsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Qualyt.Domain.Models.AssociativeClasses.UserCountry", b =>
                {
                    b.HasOne("Qualyt.Domain.Models.Users.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Qualyt.Domain.Models.Users.ApplicationUser")
                        .WithMany("Countries")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Qualyt.Domain.Models.Laboratories.Product", b =>
                {
                    b.HasOne("Qualyt.Domain.Models.Laboratories.Laboratory", "Laboratory")
                        .WithMany()
                        .HasForeignKey("LaboratoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Qualyt.Domain.Models.Laboratories.Laboratory")
                        .WithMany("Products")
                        .HasForeignKey("LaboratoryId1");
                });

            modelBuilder.Entity("Qualyt.Domain.Models.MedicalTreatments.ControlTracking", b =>
                {
                    b.HasOne("Qualyt.Domain.Models.MedicalTreatments.Treatment")
                        .WithMany("ControlTrackings")
                        .HasForeignKey("TreatmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Qualyt.Domain.Models.MedicalTreatments.Treatment", b =>
                {
                    b.HasOne("Qualyt.Domain.Models.Users.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.HasOne("Qualyt.Domain.Models.MedicalTreatments.Pathology", "Pathology")
                        .WithMany()
                        .HasForeignKey("PathologyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Qualyt.Domain.Models.Patients.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Qualyt.Domain.Models.Laboratories.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Qualyt.Domain.Models.Patients.Patient", b =>
                {
                    b.HasOne("Qualyt.Domain.Models.Users.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Qualyt.Domain.Models.Users.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.HasOne("Qualyt.Domain.Models.HealthInsurances.HealthInsurance", "HealthInsurance")
                        .WithMany()
                        .HasForeignKey("HealthInsuranceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("Qualyt.Domain.Models.Localization.Location", "Location", b1 =>
                        {
                            b1.Property<long>("PatientId");

                            b1.Property<string>("Address")
                                .HasColumnName("Address");

                            b1.Property<double>("Latitude")
                                .HasColumnName("Latitude");

                            b1.Property<double>("Longitude")
                                .HasColumnName("Longitude");

                            b1.ToTable("patients");

                            b1.HasOne("Qualyt.Domain.Models.Patients.Patient")
                                .WithOne("Location")
                                .HasForeignKey("Qualyt.Domain.Models.Localization.Location", "PatientId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Qualyt.Domain.Models.Users.Doctor", b =>
                {
                    b.HasOne("Qualyt.Domain.Models.Users.AttentionPlace", "AttentionPlace")
                        .WithMany()
                        .HasForeignKey("AttentionPlaceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Qualyt.Domain.Models.Users.SalesContact", "SalesContact")
                        .WithMany()
                        .HasForeignKey("SalesContactId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Qualyt.Domain.Models.Users.DoctorSpecialty", "Specialty")
                        .WithMany()
                        .HasForeignKey("SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("Qualyt.Domain.Models.Localization.Location", "Location", b1 =>
                        {
                            b1.Property<string>("DoctorId");

                            b1.Property<string>("Address")
                                .HasColumnName("Address");

                            b1.Property<double>("Latitude")
                                .HasColumnName("Latitude");

                            b1.Property<double>("Longitude")
                                .HasColumnName("Longitude");

                            b1.ToTable("AspNetUsers");

                            b1.HasOne("Qualyt.Domain.Models.Users.Doctor")
                                .WithOne("Location")
                                .HasForeignKey("Qualyt.Domain.Models.Localization.Location", "DoctorId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Qualyt.Domain.Models.Users.LaboratoryUser", b =>
                {
                    b.HasOne("Qualyt.Domain.Models.Laboratories.Laboratory", "Laboratory")
                        .WithMany()
                        .HasForeignKey("LaboratoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
