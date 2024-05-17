using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Qualyt.Domain.Models.Interfaces;
using Qualyt.Domain.Models.Laboratories;
using Qualyt.Domain.Models.Localization;
using Qualyt.Domain.Models.MedicalTreatments;
using Qualyt.Domain.Models.Patients;
using Qualyt.Domain.Models.Patients.Enums;
using Qualyt.Domain.Models.Users;

namespace Qualyt.Domain.Models.Stats
{
    public class PivotTableData
    {
        public PivotTableData()
        {

        }

        //public PivotTableData(IGrouping<long, PivotGroupingObject> g, bool isLaboratory)
        //{
        //    PlanName = g.FirstOrDefault().Plan.Name;
        //    LaboratoryName = g.FirstOrDefault().Labo.Name;
        //    CountryName = g.FirstOrDefault().Coun.Name;
        //    PatientFullName = g.FirstOrDefault().Pati != null ? (isLaboratory?g.FirstOrDefault().Pati.Code:g.FirstOrDefault().Pati.FullName) : null;
        //    PatientState = g.FirstOrDefault().Pati != null ? g.FirstOrDefault().Pati.StateName : null;
        //    AttentionAddress = g.FirstOrDefault().Pati != null ? g.FirstOrDefault().Pati.Location.Address : null;
        //    AttentionPlaceName = g.FirstOrDefault().Doct != null ? g.FirstOrDefault().Doct.AttentionPlace.Name : null;
        //    NurseFullName = g.FirstOrDefault().Pati != null ? g.FirstOrDefault().Nurs.Name + " " + g.FirstOrDefault().Nurs.Surname + " " + g.FirstOrDefault().Nurs.MothersSurname : null;
        //    DoctorFullName = g.FirstOrDefault().Pati != null ? g.FirstOrDefault().Doct.Name + " " + g.FirstOrDefault().Doct.Surname + " " + g.FirstOrDefault().Doct.MothersSurname : null;
        //    SalesContactFullName = g.FirstOrDefault().Pati != null ? g.FirstOrDefault().Sale.Name + " " + g.FirstOrDefault().Sale.Surname + " " + g.FirstOrDefault().Sale.MothersSurname : null;
        //    TreatmentCode = g.FirstOrDefault().Trea != null ? g.FirstOrDefault().Trea.Id.ToString() + g.FirstOrDefault().Path.Name[0] + g.FirstOrDefault().Prod.Name[0] + g.FirstOrDefault().Pati.Name[0] + g.FirstOrDefault().Pati.Surname[0] : null;
        //    TreatmentState = g.FirstOrDefault().Trea != null ? g.FirstOrDefault().Trea.StateName : null;
        //    PathologyName = g.FirstOrDefault().Trea != null ? g.FirstOrDefault().Path.Name : null;
        //    ProductName = g.FirstOrDefault().Trea != null ? g.FirstOrDefault().Prod.Name : null;
        //    ControlTrackingsCount = g.Count(x => x.Cont != null);
        //}

        public string PlanName { get; set; }
        public string LaboratoryName { get; set; }
        public string CountryName { get; set; }
        public bool IsLaboratory { get; set; }


        public string PatientFullName => PatientHasValue ? (IsLaboratory ? PatientCode : PatientFullNameLogic) : string.Empty;

        public string PatientState => PatientHasValue ? PatientStateName : string.Empty;

        public string AttentionAddress => PatientHasValue && PatientLocationHasValue ? PatientLocationAddress : string.Empty;

        public string AttentionPlaceName => Doctor != null ? Doctor.AttentionPlace.Name +" - "+ Doctor.Location.Address : string.Empty;

        public string NurseFullName => PatientHasValue  && Nurse!=null? Nurse?.Name + " " + Nurse?.Surname + " " + Nurse?.MothersSurname : string.Empty;

        public string DoctorFullName => PatientHasValue ? Doctor.Name + " " + Doctor.Surname + " " + Doctor.MothersSurname : string.Empty;

        public string SalesContactFullName
        {
            get {
                if (PatientHasValue)
                    try {
                        return SalesContact.Name + " " + SalesContact.Surname + " " + SalesContact.MothersSurname;
                    }
                    catch {
                        return SalesContact.Name + " " + SalesContact.Surname;
                    }
                return string.Empty;
            }
        }           

        public string TreatmentCode => Treatment != null ? Treatment.Id.ToString() + Pathology.Name[0] + Product.Name[0] + PatientName[0] + PatientSurname[0] : string.Empty;

        public string TreatmentState => Treatment != null ? Treatment.StateName : string.Empty;

        public string PathologyName => Treatment != null ? Pathology.Name : string.Empty;

        public string ProductName => Treatment != null ? Product.Name : string.Empty;

        public string Control => ControlTracking != null ? RemoveDiacritics(ControlTracking.CreatedDate.ToString("d/M/y") + " - " + ControlTracking.Comments) : string.Empty;

        public string Planid => PatientPlanId!=null? PatientPlanId.ToString():string.Empty;

        public Treatment Treatment { get; set; }
        public bool PatientHasValue { get; set; }
        public bool PatientLocationHasValue { get; set; }
        public string PatientLocationAddress { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string PatientMothersSurname { get; set; }
        public long? PatientId { get; set; }
        public long? PatientPlanId { get; set; }
        public PatientState? PatientStateEnum { get; set; }
        public string PatientStateName { get { return PatientStateEnum!=null?EnumHelper<PatientState>.GetDisplayValue(PatientStateEnum.Value):string.Empty; } }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public Nurse Nurse { get; set; }
        public Pathology Pathology { get; set; }
        public Product Product { get; set; }
        public ControlTracking ControlTracking { get; set; }
        public SalesContact SalesContact { get; set; }

        public string PatientCode
        {
            get
            {
                try
                {
                    return "" + PatientName[0] + PatientName[1] + PatientSurname[0] + PatientSurname[1] + PatientId.ToString();
                }
                catch
                {
                    try
                    {
                        return "" + PatientName[0] + PatientSurname[0] + PatientSurname[1] + PatientId.ToString();
                    }
                    catch
                    {
                        try
                        {
                            return "" + PatientName[0] + PatientName[1] + PatientSurname[0] + PatientId.ToString();
                        }
                        catch
                        {
                            try
                            {
                                return "" + PatientName[0] + PatientSurname[0] + PatientId.ToString();
                            }
                            catch
                            {
                                return string.Empty;
                            }
                        }
                    }
                }
            }
        }

        public string PatientFullNameLogic
        {
            get
            {
                try
                {
                    return PatientName + " " + PatientSurname + " " + PatientMothersSurname;
                }
                catch
                {
                    try
                    { 
                        return PatientName + " " + PatientSurname;
                    }
                    catch
                    {
                        return string.Empty;
                    }
                }
            }
        }
        public string RemoveDiacritics(string text)
        {
            string formD = text.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char ch in formD)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
