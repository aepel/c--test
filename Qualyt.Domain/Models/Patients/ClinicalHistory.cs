using Qualyt.Domain.Models.Patients.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Domain.Models.Patients
{
    public class ClinicalHistory
    {
        public int Height { get; set; }
        public int Weight { get; set; }
        public LivesWith LivesWith { get;set;}
        public SchoolLevel SchoolLevel { get;set; }
        public string Profession { get; set; }
        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; set; }
        public bool InMedicalTreatment { get; set; }
        public string MedicalTreatmentDetail { get; set; }
        public bool Allergic { get; set; }
        public string AllergyDetail { get; set; }
        public bool Hemorrhage { get; set; }
        public string HemorrhageDetail { get; set; }
        public bool Seizures { get; set; }
        public string SeizuresDetail { get; set; }
        public bool Smoker { get; set; }
        public string SmokerDetail { get; set; }
        public bool PracticeSports { get; set; }
        public string SportsDetail { get; set; }
        public bool RheumatoidArthritis { get; set; }
        public bool KidneyProblems { get; set; }
        public bool Asthma { get; set; }
        public bool ArterialHypertension { get; set; }
        public bool MellitusDiabetes1 { get; set; }
        public bool MellitusDiabetes2 { get; set; }
        public bool HIV { get; set; }
        public bool Anemia { get; set; }
        public bool Hepatitis { get; set; }
        public bool HeartProblems { get; set; }
        public bool Tuberculosis { get; set; }
        public bool Cancer { get; set; }
        public bool Headache { get; set; }
        public bool Epilepsy { get; set; }
        public bool COPD { get; set; }
        public bool Surgeries { get; set; }
        public bool Hypothyroidism { get; set; }
        public string OtherDiseases { get; set; }
        public bool Pacemaker { get; set; }
        public bool Prosthesis { get; set; }
        public string ProsthesisDetail { get; set; }
        public bool HasBeenPregnant { get; set; }
        public int Pregnancies { get; set; }
        public BirthsType BirthsType { get; set; }
        public int ChildrenBorn { get; set; }
        public bool FamiliarDiabetes { get; set; }
        public string FamiliarDiabetesDetail { get; set; }
        public bool FamiliarArterialHypertension { get; set; }
        public string FamiliarArterialHypertensionDetail { get; set; }
        public bool FamiliarHeartProblems { get; set; }
        public string FamiliarHeartProblemsDetail { get; set; }
        public bool FamiliarCancer { get; set; }
        public string FamiliarCancerDetail { get; set; }
        public string OtherFamilyDiseases { get; set; }
    }
}
