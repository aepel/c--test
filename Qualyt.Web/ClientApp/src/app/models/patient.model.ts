import { Moment } from 'moment/moment';
import { Field } from './field.model';
import { PatientTermsAndConditions } from './patient-terms-and-conditions.model';
import { PatientPathology } from './patient-pathology.model';
import { HealthInsurance } from './health-insurance.model';
import { Location } from './location.model';
import { Gender, MaritalStatus, ContactMethod, PatientState } from './enums.model';
import { Doctor } from './doctor.model';
import { ClinicalHistory } from './clinical-history.model';
import { Country } from './country.model';
import { Nurse } from './nurse.model';
import { Plan } from './plan.model';

export class Patient {
  constructor() {
    this.location = new Location();
    this.clinicalHistory = new ClinicalHistory();
  }
  id: number;
  name: string;
  surname: string;
  mothersSurname: string;
  fullName: string;
  createdBy: string;
  updatedBy: string;
  cardNumber: string;
  createdDate: Moment;
  updatedDate?: Moment;
  patientTermsAndConditions: PatientTermsAndConditions[];
  patientPathologies: PatientPathology[];
  patientPathologiesId: number;
  healthInsurance: HealthInsurance;
  healthInsuranceFields: Field[];
  healthInsuranceId: number;
  secondHealthInsurance: boolean;
  code: string;
  active: boolean;
  genderName: string;
  gender: Gender;
  lastTermsAccepted: boolean;
  clinicalHistory: ClinicalHistory;
  doctor: Doctor;
  doctorId: string;
  plan: Plan;
  planId: number;
  country: Country;
  countryId: number;
  nurse: Nurse;
  nurseId: number;
  idNumber: string;
  birthDate: Moment;
  maritalStatus: MaritalStatus;
  state: PatientState;
  stateName: string;
  email: string;
  maritalStatusName: string;
  get addressName() {
    return this.location.address; 
  }
  get nameActive() {
    return this.active ? "Si" : "No";
  }
  location: Location;
  preferedContactMethodName: string;
  preferedContactMethod: ContactMethod;
  phoneNumber: string;
  cellPhoneNumber: string;
  emailSended: boolean;
}
