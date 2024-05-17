using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Qualyt.Data.Core;
using Qualyt.Data.Core.Interfaces;
using Qualyt.Domain;
using Qualyt.Domain.Models;
using Qualyt.Domain.Models.AssociativeClasses;
using Qualyt.Domain.Models.Mails;
using Qualyt.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qualyt.Data
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }




    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly MCADbContext _context;
        private readonly IAccountManager _accountManager;
        private readonly ILogger _logger;

        public DatabaseInitializer(MCADbContext context, IAccountManager accountManager, ILogger<DatabaseInitializer> logger)
        {
            _accountManager = accountManager;
            _context = context;
            _logger = logger;
        }
        



        private async Task EnsureRoleAsync(string roleName, string description, string[] claims)
        {
            if ((await _accountManager.GetRoleByNameAsync(roleName)) == null)
            {
                ApplicationRole applicationRole = new ApplicationRole(roleName, description);

                var result = await this._accountManager.CreateRoleAsync(applicationRole, claims);

                if (!result.Item1)
                    throw new Exception($"Seeding \"{description}\" role failed. Errors: {string.Join(Environment.NewLine, result.Item2)}");
            }
        }
        public async Task SeedAsync()
        {

            var Fields1 = new List<Domain.Models.FormTemplates.Field>();
            Fields1.Add(new Domain.Models.FormTemplates.BinaryField()
            {
                Id = 1,
                Name = "Ver mas campos",
                Type = Domain.Models.FormTemplates.Enums.FieldType.Checkbox,
            });
            Fields1.Add(new Domain.Models.FormTemplates.TextField()
            {
                Id = 2,
                Name = "Texto",
                Type = Domain.Models.FormTemplates.Enums.FieldType.Text,
                ParentId = 1,
                Required = true
            });
            Fields1.Add(new Domain.Models.FormTemplates.DateField()
            {
                Id = 3,
                Name = "Fecha",
                Type = Domain.Models.FormTemplates.Enums.FieldType.Date,
                ParentId = 1
            });
            Fields1.Add(new Domain.Models.FormTemplates.NumericField()
            {
                Id = 4,
                Name = "numeros",
                Type = Domain.Models.FormTemplates.Enums.FieldType.Numeric,
                ParentId = 1,
                Minimum = 0,
                Maximum = 11
            });
            var Fields2 = new List<Domain.Models.FormTemplates.Field>();
            Fields2.Add(new Domain.Models.FormTemplates.NumericField()
            {
                Id = 1,
                Name = "numeros",
                Type = Domain.Models.FormTemplates.Enums.FieldType.Numeric,
                Minimum = 0,
                Maximum = 11
            });
            var FieldsActreen = new List<Domain.Models.FormTemplates.Field>
            {
                new Domain.Models.FormTemplates.OptionsField()
                {
                    Id = 1,
                    Name = "¿Qué tipo de sonda usa?",
                    Type = Domain.Models.FormTemplates.Enums.FieldType.SimpleSelect,
                    Options = new List<Domain.Models.FormTemplates.Option>()
                {
                    new Domain.Models.FormTemplates.Option(){ Selected=false, Text="Nelaton"},
                    new Domain.Models.FormTemplates.Option(){ Selected=false, Text="Pre lubricada"}
                }
                },
                new Domain.Models.FormTemplates.NumericField()
                {
                    Id = 2,
                    Name = "¿Cuántas sonda usa por día?",
                    Type = Domain.Models.FormTemplates.Enums.FieldType.Numeric
                },
                new Domain.Models.FormTemplates.TextField()
                {
                    Id = 3,
                    Name = "¿Qué medida de sonda usa?",
                    Type = Domain.Models.FormTemplates.Enums.FieldType.Text
                }
            };
            var FieldsProxima = new List<Domain.Models.FormTemplates.Field>
            {
                new Domain.Models.FormTemplates.OptionsField()
                {
                    Id = 1,
                    Name = "¿Qué tipo de sistema usa?",
                    Type = Domain.Models.FormTemplates.Enums.FieldType.SimpleSelect,
                    Options = new List<Domain.Models.FormTemplates.Option>()
                {
                    new Domain.Models.FormTemplates.Option(){ Selected=false, Text="Una pieza"},
                    new Domain.Models.FormTemplates.Option(){ Selected=false, Text="Dos piezas"}
                }
                },
                new Domain.Models.FormTemplates.TextField()
                {
                    Id = 2,
                    Name = "¿Qué medida usa?",
                    Type = Domain.Models.FormTemplates.Enums.FieldType.Text
                },
                new Domain.Models.FormTemplates.TextField()
                {
                    Id = 3,
                    Name = "¿Utiliza productos de B. Braun o de otra compañía?",
                    Type = Domain.Models.FormTemplates.Enums.FieldType.Text
                },
                new Domain.Models.FormTemplates.NumericField()
                {
                    Id = 4,
                    Name = "¿Cada cuánto cambia su sistema? (3 a 5 días)",
                    Type = Domain.Models.FormTemplates.Enums.FieldType.Numeric,
                    Minimum=3,
                    Maximum=5
                }
            };

            var doctor = new Doctor()
            {
                Active = true,
                AttentionPlaceId = 1,
                Name = "Roberto Marcos",
                CellPhoneNumber = "1122553380",
                Email = "rmgaribaldi@gmail.com",
                EmailConfirmed = true,
                IdNumber = "39276931",
                MothersSurname = "Terranova",
                PasswordHash = "AQAAAAEAACcQAAAAEBbReawnV6NcDK7KHgMZm9kxbQvdbGgcBuEiwS17k0bd6jdLJsb9b39HMD1zqkxQ3A==",
                PhoneNumber = "42315132",
                PhoneNumberConfirmed = true,
                SalesContactId = 1,
                SpecialtyId = 1,
                Surname = "Garibaldi",
                UserName = "rmgaribaldi@gmail.com"
            };

            var patient = new Domain.Models.Patients.Patient()
            {
                Active = true,
                BirthDate = new DateTimeOffset(new DateTime(629549640000000000)),//19-12-1995 10:00:00
                CardNumber = "1234567890",
                CellPhoneNumber = "1122553380",
                CountryId = 1,
                DoctorId = doctor.Id,
                Email = "glopez@gmail.com",
                Gender = Domain.Models.Patients.Enums.Gender.Male,
                HealthInsuranceId = 17,
                Location = new Domain.Models.Localization.Location()
                {
                    Address = "Corrientes 2295, CABA, Argentina",
                    Latitude = -50,
                    Longitude = -30.2
                },
                IdNumber = "39276931",
                MaritalStatus = Domain.Models.Patients.Enums.MaritalStatus.Married,
                Name = "Gustavo",
                PhoneNumber = "42315132",
                PreferedContactMethod = Domain.Models.Patients.Enums.ContactMethod.Mail,
                SecondHealthInsurance = true,
                Surname = "López",
                NurseId=1
            };

            await _context.Database.MigrateAsync().ConfigureAwait(true);

            if (!await _context.EmailTemplates.AnyAsync())
            {

                await this._context.AddAsync<EmailTemplate>(new EmailTemplate() {   Body= @"&lt;p&gt;                                                                                          Estimado/a  {NAME} {SURNAME},&lt;/p&gt;                                                                                          &lt;p&gt;                                                                                          para poder acceder al Programa de Seguimiento de Pacientes, por favor pinche el link {URL_TERMS_AND_CONDITIONS_ACCEPTANCE} y siga las instrucciones.&lt;/p&gt;",
                                                                                    Subject = @"Aceptación de términos y condiciones",
                                                                                    TipoEmailTemplate =TipoEmailTemplate.TermsAndConditionsAcceptance});

            }

            if (!await _context.Users.AnyAsync())
            {
                _logger.LogInformation("Generating inbuilt accounts");

                const string adminRoleName = "ADMIN";
                const string userRoleName = "OPERADOR";
                const string laboratoryRoleName = "LABORATORIO";

                await EnsureRoleAsync(adminRoleName, "ADMINISTRADOR", new string[] { });
                await EnsureRoleAsync(userRoleName, "OPERADOR", new string[] { });
                await EnsureRoleAsync(laboratoryRoleName, "LABORATORIO", new string[] { });

                await CreateUserAsync("ADMIN", "Aa.123456", "Administrador", "info@qualyt.com", "+5491151545666", new string[] { adminRoleName });
                await CreateUserAsync("OPERADOR", "Aa.123456", "Standard User", "operador@qualyt.com", "+5491151545666", new string[] { userRoleName });

            }
            if (!await this._context.Countries.AnyAsync())
            {
                await this._context.AddAsync<Country>(new Country() { Name = "ARGENTINA", Prefix = "54", DigitsOfACellPhoneNumber=10 });
                await this._context.AddAsync<Country>(new Country() { Name = "CHILE", Prefix = "56", DigitsOfACellPhoneNumber = 9 });
                await this._context.AddAsync<Country>(new Country() { Name = "URUGUAY", Prefix = "598", DigitsOfACellPhoneNumber = 8 });
                await this._context.SaveChangesAsync();
                _logger.LogInformation("Inbuilt countries generation completed");

                if (!await this._context.HealthInsurances.AnyAsync())
                {
                    //Chilenas
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 2, Name = "Banmédica", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 2, Name = "Chuquicamata", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 2, Name = "Colmena", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 2, Name = "Consalud", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 2, Name = "Cruz Blanca", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 2, Name = "Cruz del Norte", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 2, Name = "FFAA", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 2, Name = "Fonasa", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 2, Name = "Fundación", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 2, Name = "Fusat", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 2, Name = "Nueva Masvida", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 2, Name = "Particular", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 2, Name = "Río Blanco", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 2, Name = "San Lorenzo", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 2, Name = "Vida Tres", });
                    //Argentinas
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "ACA SALUD (COMPANIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "ACA SALUD (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "ACTIVA SALUD (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "AGUA Y ENERGIA (DIRECTO)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "AGUA Y ENERGIA (SALTA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "ALTA SALUD (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "AMCA (SOLGEN)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "AMFFA ADHERENTES (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "AMFFA CAFAR (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "AMTTA (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "AMUR (COL.ENTRE RIOS)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "APOS LA RIOJA (DIRECTO)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "AR VIDA (SOLGEN)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "ASOC. JUDICIAL (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "AUSTRAL SALUD(COL.FARM.DE PILAR)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "BANCO PROVINCIA - AMEBPBA", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "BOREAL MEDICINA PREPAGA (SALTA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "BRISTOL MEDICINE (COMPANIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "CAJA DE SERVICIOS SOCIALES (SANTA CRUZ)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "CAJA NOTARIAL (COL.DE ENTRE RIOS)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "CAJA NOTARIAL C.S.S.COL.DE ESCRIBANOS (FARMALINK)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "CASA (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "CASA (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "CEMIC (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "CEMIC (PLANES 9000) (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "CENTRO MEDICO PUEYRREDON (DIRECTO)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "COBERMED CM SALUD VTE. L. (DIRECTO)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "COBERTURA PORTEÑA SALUD (COMPAÑIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "COMEI (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "CONSTRUIR SALUD (SM LAFKEN)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "CORPOR.MED.SAN MARTIN (DIRECTO)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "CORPORACION MEDICA ASISTENCIAL (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "DAS (COMPANIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "DASMI - UNIV.DE LUJAN (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "DASUTEN (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "DIBA (DIRECTO)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "DOS - I SALUD (SOLGEN)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "DOS SAN JUAN (COL.FARM.SAN JUAN)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "DOSEP (COL.FARM.SAN LUIS)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "DOSUBA (FARMMAS)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "ENSALUD (SOLGEN)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "ETICA SALUD (SOLGEN)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "EXCE SALUD (DIRECTO)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "FEBOS (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "FEDERADA SALUD 25 DE JUNIO (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "FEMEBA SALUD AVELLANEDA(COMPANIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "FEMECHACO (FEMECHACO)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "FEMEDICA (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "GENESEN (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "GERDANNA SALUD (FARMMAS)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "GRUPO RED TOTAL (DIRECTO)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "HEALTH MEDICAL (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "HOSP. ALEMAN (COMPAÑIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "HOSP. BRITANICO PLAN SALUD (COMPANIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "HOSP. ITALIANO (COMPANIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "IAPOS (SANTA FE)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "IASEP FORMOSA (DIRECTO)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "IBERO ASISTENCIA (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "INSSSEP (CHACO)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "INST.DE SEGUROS DE JUJUY (JUJUY)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "IOMA (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "IOSCOR (CORRIENTES)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "IOSE (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "IOSEP (SANTIAGO DEL ESTERO)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "IOSPER (COL.FARM.DE ENTRE RIOS)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "IPROSS RIO NEGRO (COMPAÑIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "IPS (SALTA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "IPSM (MISIONES)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "IPSST (TUCUMAN)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "ISSN (NEUQUEN)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "JERARQUICOS SALUD(S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "LUIS PASTEUR (FARMALINK)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "MEDICAMENTOS CRONICOS(SSSALUD)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "MEDICINA PRIVADA (DIRECTO)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "MEDICUS (FARMALINK)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "MEDICUS OSTEL (COMPAÑIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "MEDIFE ASOC.CIVIL (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "MEDISAN (DIRECTO)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "MGN - MAGNA SALUD (SOLGEN)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "MOA (COMPAÑIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "MUTUAL FED.25 DE JUNIO (COL.DE ENTRE RIOS)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "NORDICA SALUD", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "O.S.FED.DE LA CARNE (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "O.S.I.M. (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "O.S.PERS.FARMACIA (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "O.S.PETROLEROS PLAN 40 (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "O.S.PETROLEROS PLAN 40 PMO (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "O.S.PETROLEROS PLAN 50 (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "O.S.PETROLEROS PLAN 70 (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "O.S.SERVICIOS SOCIALES BANCARIOS (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OMINT (FARMALINK)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OMINT OSIM (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSA (COMPAÑIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSADRA (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSALARA (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSALARA (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSAM SALUD (FARMALINK)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSAMOC/OSTAXBA (SOLGEN)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSBLYCA (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSCHOCA (AUDIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSCI (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSCONARA (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSCTCP/MUTUAL UTA (DOSYS)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSDE BINARIO", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSDEPYM (COMPANIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSDIPP (FARMALINK)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSECAC (GMS)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSECAC TOTAL (GMS)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSEIV (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSEMM (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSEP (CATAMARCA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSEP MENDOZA", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSFATLYF (SIFAR)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSFATUN (COMPAÑIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSFE (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSFE FERROVIARIOS (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSFOT (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSIAD (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSIPA (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSJERA (COMPANIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSMATA (SIFAR)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSMECON SALUD E.ECHEVERRIA (FARMALINK)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSMECON SALUD S.MARTIN/3 DE FEB.(FARMALINK)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSMEDICA (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSMISS (COMPAÑIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSMITA (GERENFAR)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSOCNA (COMPAÑIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPA (AERONAUTICO)(COMPAÑIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPACARP (COMPAÑIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPACP (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPAGA (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPAP (FARMMAS)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPCYD (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPE (COMPANIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPEDYC (COMPANIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPEP (ENSEÑANZA PRIVADA)(ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPEP (PANADERIAS)(ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPEPBA (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPETAX (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPFESIQYP (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPIA (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPIC (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPIC (CINEMATOGRAFICA) (SOLGEN)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPICHA (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPIL AMPIL (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPILM (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPIM (MADEREROS)(FARMMAS)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPIM (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPIQYP (COMPAÑIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPIS (COMPAÑIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPIT (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPITEX (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPL (LADRILLEROS) (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPLAD (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPM (MOSAISTA) (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPOCE INTEGRAL/AMCI INTEGRAL (COMPANIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPP (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPPCYQ (COMPANIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPPCYQ (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPRERA MONOTRIBUTISTAS", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPRERA RURAL/OSPEP", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSPSA (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSRJA (COMPAÑIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSSACRA (FARMANDAT)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSSIMRA (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSTEE (FARMARECORD)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSTEL (COMPANIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSTIG (COMPANIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSTV VIALES (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "OSUTHGRA (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "PAMI", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "PLAMED (COL.DE QUILMES)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "PODER JUDICIAL DE LA NACION", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "POLICIA FEDERAL (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "POLICLINICO LOMAS (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "PREMEDIC (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "PREVENT SALUD(SALUD JUJUY) (COL.FARM.SALTA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "PRIVAMED (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "PROFE (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "PROGRAMAS MEDICOS (COL.FARM.DE LOMAS DE ZAMORA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "PROTEXIA (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "RECETARIO SOLIDARIO", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "SALTMED (COL.FARM.SALTA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "SALUD INTEGRAL 24 (SOLGEN)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "SALUD SEGURA MAS/MAX (FARMANEXUS)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "SAMA (DIRECTO)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "SAMI C.M.MATANZA (FARMALINK)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "SAMI SALUD (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "SANCOR SALUD (COMPAÑIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "SANCOR SUPRA SALUD(COMPAÑIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "SCIENTIS (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "SCIENTIS CRONICIDAD (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "SCIS HEALTH MEDICAL (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "SCIS MEDICINA PRIVADA", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "SCIS OSFFENTOS (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "SCIS OSPACA (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "SCIS OSSIMRA (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "SEMPRE (LA PAMPA )", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "SERVESALUD (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "SINDICATO TRABAJ.MUNICIPALES", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "SISTEMA MEDICO CONSEJO (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "SMAI (COMPAÑIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "SOEME (DIRECTO)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "SOSBA (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "SPM AMTCYA (ADMIFARM)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "SUME (COL.DE SAN ISIDRO)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "SUTEBA-IOMA (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "SUTEBA-OSPLAD (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "TV SALUD (COMPANIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "TV SALUD (EX OSPTV) (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "UAI SALUD (GERENFAR)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "UDOCBA (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "UNION PERSONAL ACCORD AREA METR.(SIFAR)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "UNION PERSONAL ACCORD PROV.BS.AS.(SIFAR)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "UNION PERSONAL CLASSIC/FAM AREA MET.(SIFAR)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "UNION PERSONAL CLASSIC/FAM.PROV.BS.AS.(SIFAR)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "UNION PERSONAL MEDICACION DIABETES (CHUBUT)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "UNIVERSIDAD DE LA PLATA (S/U)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "UNO SALUD (DIRECTO)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "UPCN SECC.CAP.FED.(SIFAR)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "VALESALUD (PRESERFAR)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "VALMED (COMPAÑIA)", });
                    await this._context.HealthInsurances.AddAsync(new Domain.Models.HealthInsurances.HealthInsurance() { Active = true, CountryId = 1, Name = "YOUR HEALTH (TODOS SALUD) (DIRECTO)", });

                    await this._context.SaveChangesAsync();

                    if (!await this._context.AttentionPlaces.AnyAsync())
                    {
                        await this._context.AttentionPlaces.AddAsync(new AttentionPlace()
                        {
                            Name = "Consultorio privado"
                        });
                        await this._context.AttentionPlaces.AddAsync(new AttentionPlace()
                        {
                            Name = "Clínica privada"
                        });
                        await this._context.AttentionPlaces.AddAsync(new AttentionPlace()
                        {
                            Name = "Hospital público"
                        });
                        await this._context.SaveChangesAsync();


                        if (!await this._context.SalesContacts.AnyAsync())
                        {
                            await this._context.SalesContacts.AddAsync(new SalesContact()
                            {
                                Name = "Mariano Perfumo"
                            });
                            await this._context.SaveChangesAsync();


                            if (!await this._context.DoctorSpecialties.AnyAsync())
                            {
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Anatomía patológica" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Anestesiología" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Cardiología" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Cirugía Cardiovascular" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Cirugía de Cabeza y Cuello y Maxilofacial" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Cirugía de Tórax" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Cirugía General" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Cirugía Pediátrica" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Cirugía Plástica y Reparadora" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Cirugía Vascular Periférica" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Coloproctología" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Dermatología" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Diabetología" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Endocrinología Adulto" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Endocrinología Pediátrica" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Enfermedades Respiratorias" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Enfermedades Respiratorias Adultos" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Enfermedades Respiratorias Pediátricas" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Farmacia Clínica" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Gastroenterología" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Gastroenterología Adulto" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Gastroenterología Pediátrica" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Genética Clínica" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Geriatría" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Ginecología Pediátrica y de la Adolescencia" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Hematología" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Imagenología" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Infectología" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Inmunología" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Laboratorio Clínico" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Medicina de Urgencia" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Medicina Familiar" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Medicina Física y Rehabilitación" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Medicina Intensiva Adulto" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Medicina Intensiva Pediátrica" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Medicina Interna" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Medicina Legal" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Medicina Materno Fetal" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Medicina Nuclear" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Nefrología Adulto" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Nefrología Pediátrica" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Neonatología" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Neurocirugía" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Neurología Adultos" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Neurología Pediátrica" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Obstetricia y ginecología" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Oftalmología" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Oncología Médica" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Otorrinolaringología" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Pediatría" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Psiquiatría Adultos" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Psiquiatría Pedriátrica y de la Adolescencia" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Radioterapia Oncológica" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Reumatología" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Salud Pública" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Traumatología y Ortopedia" });
                                await this._context.DoctorSpecialties.AddAsync(new DoctorSpecialty() { Name = "Urología" });

                                await this._context.SaveChangesAsync();

                                if (!await this._context.Doctors.AnyAsync())
                                {
                                    await this._context.Doctors.AddAsync(doctor);
                                    doctor.HealthInsuranceDoctors = new List<HealthInsuranceDoctor>
                                    {
                                        new HealthInsuranceDoctor()
                                        {
                                            DoctorId = doctor.Id,
                                            HealthInsuranceId = 1
                                        },
                                        new HealthInsuranceDoctor()
                                        {
                                            DoctorId = doctor.Id,
                                            HealthInsuranceId = 2
                                        }
                                    };
                                    await this._context.SaveChangesAsync();


                                    if (!await this._context.Laboratories.AnyAsync())
                                    {
                                        var labo = new LaboratoryUser
                                        {
                                            UserName = "LABORATORIO",
                                            Email = "labo@qualyt.com",
                                            EmailConfirmed = true,
                                            LaboratoryId = 1
                                        };
                                        await this._context.Laboratories.AddAsync(new Domain.Models.Laboratories.Laboratory()
                                        {
                                            Active = true,
                                            Name = "B. Braun"
                                        });

                                        await this._context.SaveChangesAsync();

                                        await _accountManager.CreateUserAsync(labo, new string[] { "LABORATORIO" }, "Aa.123456");

                                        await this._context.SaveChangesAsync();

                                        if (!await this._context.Pathologies.AnyAsync())
                                        {

                                            await this._context.Pathologies.AddAsync(new Domain.Models.MedicalTreatments.Pathology()
                                            {
                                                Name = "Patología con campos anidados",
                                                Active = true,
                                                Fields = Fields1,
                                                LaboratoryId = 1
                                            });
                                            await this._context.Pathologies.AddAsync(new Domain.Models.MedicalTreatments.Pathology()
                                            {
                                                Name = "Otra patología",
                                                Active = true,
                                                Fields = Fields2,
                                                LaboratoryId = 1
                                            });
                                            await this._context.SaveChangesAsync();

                                            if (!await this._context.Nurses.AnyAsync())
                                            {

                                                await this._context.Nurses.AddAsync(new Domain.Models.Patients.Nurse() {
                                                    Name="María",
                                                    Surname="Toledo"
                                                });
                                                await this._context.SaveChangesAsync();

                                                if (!await this._context.Patients.AnyAsync())
                                                {
                                                    await this._context.Patients.AddAsync(patient);
                                                    patient.PatientPathologies = new List<PatientPathology>();
                                                    patient.PatientPathologies.Add(new PatientPathology()
                                                    {
                                                        PathologyId = 1,
                                                        PatientId = patient.Id
                                                    });
                                                    patient.PatientPathologies.Add(new PatientPathology()
                                                    {
                                                        PathologyId = 2,
                                                        PatientId = patient.Id
                                                    });

                                                    await this._context.SaveChangesAsync();

                                                    if (!await this._context.Devices.AnyAsync())
                                                    {
                                                        await this._context.Devices.AddAsync(new Domain.Models.Laboratories.Device()
                                                        {
                                                            Active = true,
                                                            Amount = 1,
                                                            Fields = FieldsActreen,
                                                            LaboratoryId = 1,
                                                            Name = "Actreen Lite",
                                                            DeviceType = "Un tipo",
                                                            ProductType=Domain.Models.Laboratories.Enums.ProductType.Device
                                                        });
                                                        await this._context.Devices.AddAsync(new Domain.Models.Laboratories.Device()
                                                        {
                                                            Active = true,
                                                            Amount = 2,
                                                            Fields = FieldsActreen,
                                                            LaboratoryId = 1,
                                                            Name = "Actreen Glys Set",
                                                            DeviceType = "Un tipo",
                                                            ProductType = Domain.Models.Laboratories.Enums.ProductType.Device
                                                        });
                                                        await this._context.Devices.AddAsync(new Domain.Models.Laboratories.Device()
                                                        {
                                                            Active = true,
                                                            Amount = 2,
                                                            Fields = FieldsActreen,
                                                            LaboratoryId = 1,
                                                            Name = "Actreen Mini Cath",
                                                            DeviceType = "Un tipo",
                                                            ProductType = Domain.Models.Laboratories.Enums.ProductType.Device
                                                        });
                                                        await this._context.Devices.AddAsync(new Domain.Models.Laboratories.Device()
                                                        {
                                                            Active = true,
                                                            Amount = 2,
                                                            Fields = FieldsProxima,
                                                            LaboratoryId = 1,
                                                            Name = "Proxima Border",
                                                            DeviceType = "Un tipo",
                                                            ProductType = Domain.Models.Laboratories.Enums.ProductType.Device
                                                        });
                                                        await this._context.Devices.AddAsync(new Domain.Models.Laboratories.Device()
                                                        {
                                                            Active = true,
                                                            Amount = 2,
                                                            Fields = FieldsProxima,
                                                            LaboratoryId = 1,
                                                            Name = "Proxima Uro",
                                                            DeviceType = "Un tipo",
                                                            ProductType = Domain.Models.Laboratories.Enums.ProductType.Device
                                                        });
                                                        await this._context.Devices.AddAsync(new Domain.Models.Laboratories.Device()
                                                        {
                                                            Active = true,
                                                            Amount = 2,
                                                            Fields = FieldsProxima,
                                                            LaboratoryId = 1,
                                                            Name = "Proxima 2 (Normal)",
                                                            DeviceType = "Un tipo",
                                                            ProductType = Domain.Models.Laboratories.Enums.ProductType.Device
                                                        });
                                                        await this._context.Devices.AddAsync(new Domain.Models.Laboratories.Device()
                                                        {
                                                            Active = true,
                                                            Amount = 2,
                                                            Fields = FieldsProxima,
                                                            LaboratoryId = 1,
                                                            Name = "Proxima 2 Plus",
                                                            DeviceType = "Un tipo",
                                                            ProductType = Domain.Models.Laboratories.Enums.ProductType.Device
                                                        });

                                                        await this._context.SaveChangesAsync();
                                                        
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        private async Task<ApplicationUser> CreateUserAsync(string userName, string password, string fullName, string email, string phoneNumber, string[] roles)
        {
            ApplicationUser applicationUser = new ApplicationUser
            {
                UserName = userName,
                Email = email,
                PhoneNumber = phoneNumber,
                EmailConfirmed = true,
                Active = true
            };

            var result = await _accountManager.CreateUserAsync(applicationUser, roles, password);

            if (!result.Item1)
                throw new Exception($"Seeding \"{userName}\" user failed. Errors: {string.Join(Environment.NewLine, result.Item2)}");


            return applicationUser;
        }
    }
}
