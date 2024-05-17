using Qualyt.Domain.Models.FormTemplates;
using Qualyt.Domain.Models.FormTemplates.Enums;
using Qualyt.Web.Helpers;
using Qualyt.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qualyt.Web.Helpers
{
    public class Factory
    {

        public static Field GetCampoPersonalizado(FieldType tipoCampo)
        {
            switch (tipoCampo)
            {
                case FieldType.Date:
                    return new DateField();
                case FieldType.Numeric:
                    return new NumericField();
                case FieldType.Checkbox:
                    return new BinaryField();
                case FieldType.Text:
                    return new TextField();
                case FieldType.SimpleSelect:
                    return new OptionsField();
                default:
                    throw new Exception("Falta definir un caso de la factory");
            }
        }

        public static List<Field> GetCamposPersonalizadosByModel(List<FieldViewModel> camposPersonalizadosModels)
        {
            var mapper = AutoMapperConfiguration.GetMapper();
            List<Field> result = new List<Field>();
            if (camposPersonalizadosModels != null)
                foreach (var campo in camposPersonalizadosModels)
                {
                    Field campoPersonalizado = GetCampoPersonalizado(campo.Type);
                    mapper.Map(campo, campoPersonalizado);
                    result.Add(campoPersonalizado);
                }
            return result;
        }


    }
}
