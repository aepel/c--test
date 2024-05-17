using Qualyt.Domain.Models.Laboratories;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Users;

namespace Qualyt.Domain.Models.Interfaces
{
    public class PivotGroupingObject
    {
        public Plan Plan { get; set; }
        public Laboratory Labo { get; set; }
        public Country Coun { get; set; }
        public Patient Pati { get; set; }
        public Nurse Nurs { get; set; }
        public Doctor Doct { get; set; }
        public SalesContact Sale { get; set; }
        public Pathology Path { get; set; }
        public Product Prod { get; set; }
        public ControlTracking Cont { get; set; }
        public Treatment Trea { get; set; }
    }
}