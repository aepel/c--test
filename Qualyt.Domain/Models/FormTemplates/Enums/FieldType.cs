using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Qualyt.Domain.Models.FormTemplates.Enums
{
    public enum FieldType
    {
        [Display(Name="Checkbox")]
        Checkbox,
        [Display(Name="Listado Si/No")]
        YesOrNoSelect,
        [Display(Name="Texto")]
        Text,
        [Display(Name="Numérico")]
        Numeric,
        [Display(Name="Fecha")]
        Date,
        [Display(Name="Listado con opciones múltiples")]
        MultipleSelect,
        [Display(Name="Round button")]
        RoundButton,
        [Display(Name="Listado con opcion simple")]
        SimpleSelect
    }
}
