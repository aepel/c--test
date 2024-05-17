using AutoMapper;
using Qualyt.Domain.Models.FormTemplates;
using Qualyt.Domain.Models.HealthInsurances;
using Qualyt.Domain.Models.Laboratories;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;
using Qualyt.Web.ViewModels;
using System;

namespace Qualyt.Web.Helpers
{
    public class AutoMapperConfiguration
    {

        public static IMapper GetMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<ProductViewModel, Product>()
                .ForMember(dest => dest.Fields, src => src.ResolveUsing(x => Factory.GetCamposPersonalizadosByModel(x.Fields)))
                .Include<ProductViewModel, Device>()
                .Include<ProductViewModel, Medicine>();

                cfg.CreateMap<ProductViewModel, Medicine>();

                cfg.CreateMap<ProductViewModel, Device>();

                cfg.CreateMap<ApplicationUserViewModel, ApplicationUser>()
                .ForMember(dest => dest.Roles, src => src.MapFrom(x => x.RolesCollection))
                .ForMember(dest => dest.RolesList, src => src.MapFrom(x => x.Roles))
                .Include<ApplicationUserViewModel, LaboratoryUser>()
                .ReverseMap();

                cfg.CreateMap<ApplicationUserViewModel, LaboratoryUser>()
                .ReverseMap();

                cfg.CreateMap<TreatmentViewModel, Treatment>()
                .ForMember(dest => dest.PathologyFields, src => src.ResolveUsing(x => Factory.GetCamposPersonalizadosByModel(x.PathologyFields)))
                .ForMember(dest => dest.ProductFields, src => src.ResolveUsing(x => Factory.GetCamposPersonalizadosByModel(x.ProductFields)));

                cfg.CreateMap<PathologyViewModel, Pathology>()
                .ForMember(dest => dest.Fields, src => src.ResolveUsing(x => Factory.GetCamposPersonalizadosByModel(x.Fields)));

                cfg.CreateMap<PatientViewModel, Patient>()
                .ForMember(dest => dest.HealthInsuranceFields, src => src.ResolveUsing(x => Factory.GetCamposPersonalizadosByModel(x.HealthInsuranceFields)));

                cfg.CreateMap<HealthInsuranceViewModel, HealthInsurance>()
                .ForMember(dest => dest.Fields, src => src.ResolveUsing(x => Factory.GetCamposPersonalizadosByModel(x.Fields)));

                cfg.CreateMap<FieldViewModel, Field>()
                .Include<FieldViewModel, BinaryField>()
                .Include<FieldViewModel, DateField>()
                .Include<FieldViewModel, NumericField>()
                .Include<FieldViewModel, TextField>()
                .Include<FieldViewModel, OptionsField>();

                cfg.CreateMap<FieldViewModel, BinaryField>()
                .ForMember(dest => dest.Value, src => src.MapFrom(x => x.Value != null ? (bool?)Convert.ToBoolean(x.Value) :null));

                cfg.CreateMap<FieldViewModel, DateField>()
                .ForMember(dest => dest.Value, src => src.MapFrom(x => x.Value != null ? (DateTimeOffset?)Convert.ToDateTime(x.Value) :null));

                cfg.CreateMap<FieldViewModel, NumericField>()
                .ForMember(dest => dest.Value, src => src.MapFrom(x => x.Value != null ? (long?)Convert.ToInt64(x.Value) :null));

                cfg.CreateMap<FieldViewModel, TextField>()
                .ForMember(dest => dest.Value, src => src.MapFrom(x => Convert.ToString(x.Value)));

                cfg.CreateMap<FieldViewModel, OptionsField>();

            });

            return config.CreateMapper();
        }

    }
}

    
