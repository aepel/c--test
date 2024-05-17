using AspNet.Security.OpenIdConnect.Primitives;
using AspNetCore.RouteAnalyzer;
using AutoMapper;
using CacheManager.Core;
using EFSecondLevelCache.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenIddict.Abstractions;
using Qualyt.Data;
using Qualyt.Data.Core;
using Qualyt.Data.Core.Interfaces;
using Qualyt.Data.Repositories;
using Qualyt.Data.Repositories.Interfaces;
using Qualyt.Domain.Models;
using Qualyt.Domain.Models.Mails;
using Qualyt.Domain.Models.Mails.Config;
using Qualyt.Domain.Models.Users;
using Qualyt.Services.Services;
using Qualyt.Web.Authorization;
using Qualyt.Web.Helpers;
using Qualyt.Web.ViewModels;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Globalization;
using AppPermissions = Qualyt.Data.Core.ApplicationPermissions;


namespace Qualyt.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEFSecondLevelCache();

            // Add an in-memory cache service provider
            services.AddSingleton(typeof(ICacheManager<>), typeof(BaseCacheManager<>));
            services.AddSingleton(typeof(ICacheManagerConfiguration),
                new CacheManager.Core.ConfigurationBuilder()
                        .WithJsonSerializer()
                        .WithMicrosoftMemoryCacheHandle()
                        .WithExpiration(ExpirationMode.Absolute, TimeSpan.FromMinutes(10))
                        .Build());

            services.AddRouteAnalyzer();
            services.AddDbContext<MCADbContext>(options =>
            {
                options.UseMySql(Configuration["ConnectionStrings:DefaultConnection"], b => b.MigrationsAssembly("Qualyt.Data"));
                options.UseOpenIddict();
            });

            // add identity
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<MCADbContext>()
                .AddDefaultTokenProviders();

            // Configure Identity options and password complexity here
            services.Configure<IdentityOptions>(options =>
            {
                // User settings
                options.User.RequireUniqueEmail = true;

                //    //// Password settings
                //    //options.Password.RequireDigit = true;
                //    //options.Password.RequiredLength = 8;
                //    //options.Password.RequireNonAlphanumeric = false;
                //    //options.Password.RequireUppercase = true;
                //    //options.Password.RequireLowercase = false;

                //    //// Lockout settings
                //    //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                //    //options.Lockout.MaxFailedAccessAttempts = 10;

                options.ClaimsIdentity.UserNameClaimType = OpenIdConnectConstants.Claims.Name;
                options.ClaimsIdentity.UserIdClaimType = OpenIdConnectConstants.Claims.Subject;
                options.ClaimsIdentity.RoleClaimType = OpenIdConnectConstants.Claims.Role;
            });




            // Register the OpenIddict services.
            services.AddOpenIddict()
                .AddCore(options =>
                {
                    options.UseEntityFrameworkCore().UseDbContext<MCADbContext>();
                })
                .AddServer(options =>
                {
                    options.UseMvc();
                    options.EnableTokenEndpoint("/connect/token");
                    options.AllowPasswordFlow();
                    options.AllowRefreshTokenFlow();
                    options.AcceptAnonymousClients();
                    options.DisableHttpsRequirement(); // Note: Comment this out in production
                    options.RegisterScopes(
                        OpenIdConnectConstants.Scopes.OpenId,
                        OpenIdConnectConstants.Scopes.Email,
                        OpenIdConnectConstants.Scopes.Phone,
                        OpenIdConnectConstants.Scopes.Profile,
                        OpenIdConnectConstants.Scopes.OfflineAccess,
                        OpenIddictConstants.Scopes.Roles);

                    // options.UseRollingTokens(); //Uncomment to renew refresh tokens on every refreshToken request
                    // Note: to use JWT access tokens instead of the default encrypted format, the following lines are required:
                    // options.UseJsonWebTokens();
                })
                .AddValidation(); //Only compatible with the default token format. For JWT tokens, use the Microsoft JWT bearer handler.



            // Add cors
            services.AddCors();

            services.AddAutoMapper();
            // Add framework services.
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });


            //Todo: ***Using DataAnnotations for validation until Swashbuckle supports FluentValidation***
            //services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());


            //.AddJsonOptions(opts =>
            //{
            //    opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //});



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "App name API", Version = "v1" });
                c.OperationFilter<AuthorizeCheckOperationFilter>();
                c.AddSecurityDefinition("oauth2", new OAuth2Scheme
                {
                    Type = "oauth2",
                    Flow = "password",
                    TokenUrl = "/connect/token",
                    Description = "Note: Leave client_id and client_secret blank"
                });
            });

            services.AddAuthorization(/*options =>
            {
                options.AddPolicy(Authorization.Policies.ViewAllUsersPolicy, policy => policy.RequireClaim(CustomClaimTypes.Permission, AppPermissions.ViewUsers));
                options.AddPolicy(Authorization.Policies.ManageAllUsersPolicy, policy => policy.RequireClaim(CustomClaimTypes.Permission, AppPermissions.ManageUsers));

                options.AddPolicy(Authorization.Policies.ViewAllRolesPolicy, policy => policy.RequireClaim(CustomClaimTypes.Permission, AppPermissions.ViewRoles));
                options.AddPolicy(Authorization.Policies.ViewRoleByRoleNamePolicy, policy => policy.Requirements.Add(new ViewRoleAuthorizationRequirement()));
                options.AddPolicy(Authorization.Policies.ManageAllRolesPolicy, policy => policy.RequireClaim(CustomClaimTypes.Permission, AppPermissions.ManageRoles));

                options.AddPolicy(Authorization.Policies.AssignAllowedRolesPolicy, policy => policy.Requirements.Add(new AssignRolesAuthorizationRequirement()));
            }*/);

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });


            // Configurations
            services.Configure<SmtpConfig>(Configuration.GetSection("SmtpConfig"));
            services.Configure<ApplicationUrls>(Configuration.GetSection("ApplicationUrls"));
            services.Configure<DatosTagSettings>(Configuration.GetSection("DatosTagSettings"));


            // Business Services
            services.AddScoped<IEmailSender, EmailSender>();


            // Repositories
            services.AddScoped<IUnitOfWork, HttpUnitOfWork>();
            services.AddScoped<IAccountManager, AccountManager>();
            // Auth Handlers
            services.AddSingleton<IAuthorizationHandler, ViewUserAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, ManageUserAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, ViewRoleAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, AssignRolesAuthorizationHandler>();

            // DB Creation and Seeding
            services.AddTransient<IDatabaseInitializer, DatabaseInitializer>();
            
            //services.AddProgressiveWebApp();



            DIConfiguration(services);
        }

        private void DIConfiguration(IServiceCollection services)
        {
            services.AddTransient<IPathologiesService, PathologiesService>();
            services.AddTransient<IPathologiesRepository, PathologiesRepository>();
            services.AddTransient<IControlTrackingsRepository, ControlTrackingsRepository>();
            services.AddTransient<IControlTrackingsService, ControlTrackingsService>();
            services.AddTransient<ITreatmentsRepository, TreatmentsRepository>();
            services.AddTransient<ITreatmentsService, TreatmentsService>();
            services.AddTransient<IPatientsService, PatientsService>();
            services.AddTransient<IPatientsRepository, PatientsRepository>();
            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<IProductsRepository, ProductsRepository>();
            services.AddTransient<IDoctorsService, DoctorsService>();
            services.AddTransient<IDoctorsRepository, DoctorsRepository>();
            services.AddTransient<IHealthInsurancesService, HealthInsurancesService>();
            services.AddTransient<IHealthInsurancesRepository, HealthInsurancesRepository>();
            services.AddTransient<ICountriesService, CountriesService>();
            services.AddTransient<ICountriesRepository, CountriesRepository>();
            services.AddTransient<ITermsAndConditionsService, TermsAndConditionsService>();
            services.AddTransient<ITermsAndConditionsRepository, TermsAndConditionsRepository>();
            services.AddTransient<IEmailTemplateService, EmailTemplateService>();
            services.AddTransient<IRepository<EmailTemplate>, Repository<EmailTemplate>>();
            services.AddTransient<IDatos, Datos>();
            services.AddTransient<ILaboratoriesService, LaboratoriesService>();
            services.AddTransient<ILaboratoriesRepository, LaboratoriesRepository>();
            services.AddTransient<INursesRepository, NursesRepository>();
            services.AddTransient<INursesService, NursesService>();
            services.AddTransient<ISalesContactsRepository, SalesContactsRepository>();
            services.AddTransient<ISalesContactsService, SalesContactsService>();
            services.AddTransient<IAttentionPlacesRepository, AttentionPlacesRepository>();
            services.AddTransient<IAttentionPlacesService, AttentionPlacesService>();
            services.AddTransient<IDoctorSpecialtiesRepository, DoctorSpecialtiesRepository>();
            services.AddTransient<IDoctorSpecialtiesService, DoctorSpecialtiesService>();
            services.AddTransient<ILaboratoryUsersService, LaboratoryUsersService>();
            services.AddTransient<ILaboratoryUsersRepository, LaboratoryUsersRepository>();
            services.AddTransient<IPlansService, PlansService>();
            services.AddTransient<IPlansRepository, PlansRepository>();
            services.AddTransient<IScheduleService, ScheduleService>();
            services.AddTransient<IScheduleRepository, ScheduleRepository>();
            services.AddTransient<IAlertsService, AlertsService>();
            services.AddTransient<IAlertsRepository, AlertsRepository>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IRolesService, RolesService>();
            services.AddTransient<IRolesRepository, RolesRepository>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseEFSecondLevelCache();
            var cultureInfo = new CultureInfo(Configuration["CultureInfo:Name"]);
            cultureInfo.NumberFormat.CurrencySymbol = Configuration["CultureInfo:CurrencySymbol"];
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug(LogLevel.Warning);
            loggerFactory.AddFile(Configuration.GetSection("Logging"));

            Utilities.ConfigureLogger(loggerFactory);
            EmailTemplates.Initialize(env);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }


            //Configure Cors
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());


            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseAuthentication();


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = "Swagger UI - Quick Application";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "App name API V1");
            });


            app.UseMvc(routes =>
            {
                routes.MapRouteAnalyzer("/routes");
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                    spa.Options.StartupTimeout = TimeSpan.FromSeconds(60); // Increase the timeout if angular app is taking longer to startup
                    //spa.UseProxyToSpaDevelopmentServer("http://localhost:4200"); // Use this instead to use the angular cli server
                }
            });
        }
    }
}
