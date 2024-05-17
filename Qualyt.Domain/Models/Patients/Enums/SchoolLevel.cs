using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Qualyt.Domain.Models.Patients.Enums
{
    public enum SchoolLevel
    {
        [Display(Name = "Básica")]
        ElementarySchool,
        [Display(Name = "Media")]
        SecondaryEducation,
        [Display(Name = "Universitaria")]
        PostSecondaryEducation,
        [Display(Name = "Posgrado")]
        PostDoctoral
    }
}
