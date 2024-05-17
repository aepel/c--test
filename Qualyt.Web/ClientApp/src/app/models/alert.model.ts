import { Moment } from 'moment/moment';
import { Field } from './field.model';
import { Location } from './location.model';
import { AttentionPlace } from './attention-place.model';
import { SalesContact } from './sales-contact.model';
import { DoctorSpecialty } from './doctor-specialty.model';
import { HealthInsuranceDoctor } from './health-insurance-doctor.model';
import { ApplicationUser } from './application-user.model';
import { AlertType } from './enums.model';

export class Alert  {
  title: string;
  description: string;
  route: string;
  params: any;
  type: AlertType;
}

export class PatientWithoutConsentAlert extends Alert {
  patientId: number;
  patientName: string;
}

export class TodayControlAlert extends Alert {
  treatmentId: number;
  patientName: string;
}
