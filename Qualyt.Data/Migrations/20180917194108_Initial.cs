using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualyt.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "attentionplaces",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attentionplaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "doctorspecialties",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctorspecialties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "healthinsurances",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_healthinsurances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "laboratories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_laboratories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictApplications",
                columns: table => new
                {
                    ClientId = table.Column<string>(nullable: false),
                    ClientSecret = table.Column<string>(nullable: true),
                    ConcurrencyToken = table.Column<string>(nullable: true),
                    ConsentType = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: false),
                    Permissions = table.Column<string>(nullable: true),
                    PostLogoutRedirectUris = table.Column<string>(nullable: true),
                    Properties = table.Column<string>(nullable: true),
                    RedirectUris = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictApplications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictScopes",
                columns: table => new
                {
                    ConcurrencyToken = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Properties = table.Column<string>(nullable: true),
                    Resources = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictScopes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pathologies",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    SerializedFields = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pathologies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "termsandconditions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true),
                    PublishedDate = table.Column<DateTimeOffset>(nullable: true),
                    PublishedBy = table.Column<string>(nullable: true),
                    Version = table.Column<long>(nullable: true),
                    Published = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_termsandconditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    MothersSurname = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: true),
                    HealthInsuranceId = table.Column<long>(nullable: false),
                    SecondHealthInsurance = table.Column<bool>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    IdNumber = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTimeOffset>(nullable: false),
                    MaritalStatus = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    PreferedContactMethod = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    CellPhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_patients_healthinsurances_HealthInsuranceId",
                        column: x => x.HealthInsuranceId,
                        principalTable: "healthinsurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    MothersSurname = table.Column<string>(nullable: true),
                    IdNumber = table.Column<string>(nullable: true),
                    AttentionPlaceId = table.Column<long>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: true),
                    Longitude = table.Column<double>(nullable: true),
                    CellPhoneNumber = table.Column<string>(nullable: true),
                    SpecialtyId = table.Column<long>(nullable: true),
                    LaboratoryId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_attentionplaces_AttentionPlaceId",
                        column: x => x.AttentionPlaceId,
                        principalTable: "attentionplaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_doctorspecialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "doctorspecialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_laboratories_LaboratoryId",
                        column: x => x.LaboratoryId,
                        principalTable: "laboratories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    LaboratoryId = table.Column<long>(nullable: false),
                    Amount = table.Column<long>(nullable: false),
                    SerializedFields = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Form = table.Column<int>(nullable: true),
                    Variation = table.Column<double>(nullable: true),
                    VariationUnit = table.Column<int>(nullable: true),
                    DefinedDailyDose = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_products_laboratories_LaboratoryId",
                        column: x => x.LaboratoryId,
                        principalTable: "laboratories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictAuthorizations",
                columns: table => new
                {
                    ApplicationId = table.Column<string>(nullable: true),
                    ConcurrencyToken = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: false),
                    Properties = table.Column<string>(nullable: true),
                    Scopes = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: false),
                    Subject = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictAuthorizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenIddictAuthorizations_OpenIddictApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "OpenIddictApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "patientpathologies",
                columns: table => new
                {
                    PatientId = table.Column<long>(nullable: false),
                    PathologyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patientpathologies", x => new { x.PathologyId, x.PatientId });
                    table.ForeignKey(
                        name: "FK_patientpathologies_pathologies_PathologyId",
                        column: x => x.PathologyId,
                        principalTable: "pathologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_patientpathologies_patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "patienttermsandconditions",
                columns: table => new
                {
                    PatientId = table.Column<long>(nullable: false),
                    TermsAndConditionsId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patienttermsandconditions", x => new { x.TermsAndConditionsId, x.PatientId });
                    table.ForeignKey(
                        name: "FK_patienttermsandconditions_patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_patienttermsandconditions_termsandconditions_TermsAndConditi~",
                        column: x => x.TermsAndConditionsId,
                        principalTable: "termsandconditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "healthinsurancedoctors",
                columns: table => new
                {
                    HealthInsuranceId = table.Column<long>(nullable: false),
                    DoctorId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_healthinsurancedoctors", x => new { x.DoctorId, x.HealthInsuranceId });
                    table.ForeignKey(
                        name: "FK_healthinsurancedoctors_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_healthinsurancedoctors_healthinsurances_HealthInsuranceId",
                        column: x => x.HealthInsuranceId,
                        principalTable: "healthinsurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usercountries",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    CountryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usercountries", x => new { x.UserId, x.CountryId });
                    table.ForeignKey(
                        name: "FK_usercountries_countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usercountries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "treatments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    PathologyId = table.Column<long>(nullable: false),
                    DoctorId = table.Column<string>(nullable: true),
                    ProductId = table.Column<long>(nullable: false),
                    PatientId = table.Column<long>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    StateReason = table.Column<int>(nullable: true),
                    Dose = table.Column<double>(nullable: false),
                    DoseFrequency = table.Column<double>(nullable: false),
                    DoseFrequencyType = table.Column<int>(nullable: false),
                    Duration = table.Column<double>(nullable: false),
                    DurationType = table.Column<int>(nullable: false),
                    SerializedPathologyFields = table.Column<string>(nullable: true),
                    SerializedProductFields = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_treatments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_treatments_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_treatments_pathologies_PathologyId",
                        column: x => x.PathologyId,
                        principalTable: "pathologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_treatments_patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_treatments_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictTokens",
                columns: table => new
                {
                    ApplicationId = table.Column<string>(nullable: true),
                    AuthorizationId = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(nullable: true),
                    ExpirationDate = table.Column<DateTimeOffset>(nullable: true),
                    ConcurrencyToken = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: false),
                    Payload = table.Column<string>(nullable: true),
                    Properties = table.Column<string>(nullable: true),
                    ReferenceId = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenIddictTokens_OpenIddictApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "OpenIddictApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OpenIddictTokens_OpenIddictAuthorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "OpenIddictAuthorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "controltrackings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    NextControl = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    TreatmentId = table.Column<long>(nullable: false),
                    ContactMethod = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_controltrackings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_controltrackings_treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AttentionPlaceId",
                table: "AspNetUsers",
                column: "AttentionPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SpecialtyId",
                table: "AspNetUsers",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LaboratoryId",
                table: "AspNetUsers",
                column: "LaboratoryId");

            migrationBuilder.CreateIndex(
                name: "IX_attentionplaces_Name",
                table: "attentionplaces",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_controltrackings_TreatmentId",
                table: "controltrackings",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_countries_Name",
                table: "countries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_doctorspecialties_Name",
                table: "doctorspecialties",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_healthinsurancedoctors_HealthInsuranceId",
                table: "healthinsurancedoctors",
                column: "HealthInsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_healthinsurances_Name",
                table: "healthinsurances",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_laboratories_Name",
                table: "laboratories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictApplications_ClientId",
                table: "OpenIddictApplications",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictAuthorizations_ApplicationId",
                table: "OpenIddictAuthorizations",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictScopes_Name",
                table: "OpenIddictScopes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_ApplicationId",
                table: "OpenIddictTokens",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_AuthorizationId",
                table: "OpenIddictTokens",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_ReferenceId",
                table: "OpenIddictTokens",
                column: "ReferenceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_patientpathologies_PatientId",
                table: "patientpathologies",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_patients_HealthInsuranceId",
                table: "patients",
                column: "HealthInsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_patienttermsandconditions_PatientId",
                table: "patienttermsandconditions",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_products_LaboratoryId",
                table: "products",
                column: "LaboratoryId");

            migrationBuilder.CreateIndex(
                name: "IX_products_Name",
                table: "products",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_treatments_DoctorId",
                table: "treatments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_treatments_PathologyId",
                table: "treatments",
                column: "PathologyId");

            migrationBuilder.CreateIndex(
                name: "IX_treatments_PatientId",
                table: "treatments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_treatments_ProductId",
                table: "treatments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_usercountries_CountryId",
                table: "usercountries",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "controltrackings");

            migrationBuilder.DropTable(
                name: "healthinsurancedoctors");

            migrationBuilder.DropTable(
                name: "OpenIddictScopes");

            migrationBuilder.DropTable(
                name: "OpenIddictTokens");

            migrationBuilder.DropTable(
                name: "patientpathologies");

            migrationBuilder.DropTable(
                name: "patienttermsandconditions");

            migrationBuilder.DropTable(
                name: "usercountries");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "treatments");

            migrationBuilder.DropTable(
                name: "OpenIddictAuthorizations");

            migrationBuilder.DropTable(
                name: "termsandconditions");

            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "pathologies");

            migrationBuilder.DropTable(
                name: "patients");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "OpenIddictApplications");

            migrationBuilder.DropTable(
                name: "attentionplaces");

            migrationBuilder.DropTable(
                name: "doctorspecialties");

            migrationBuilder.DropTable(
                name: "healthinsurances");

            migrationBuilder.DropTable(
                name: "laboratories");
        }
    }
}
