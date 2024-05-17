import { Moment } from 'moment/moment';
import { Field } from './field.model';
import { Pathology } from './pathology.model';
import { Doctor } from './doctor.model';
import { Product } from './product.model';
import { ControlTracking } from './control-tracking.model';
import { Patient } from './patient.model';
import { ApplicationUser } from './application-user.model';
import { TreatmentState } from './enums.model';

export class Treatment {
  id: number;
  createdBy: string;
  createdByUser: ApplicationUser;
  updatedBy: string;
  createdDate: Moment;
  updatedDate?: Moment;
  active: boolean;
  editable: boolean;
  pathology: Pathology;
  pathologyId: number;
  doctor: Doctor;
  doctorId: string;
  product: Product;
  productId: number;
  patient: Patient;
  patientId: number;
  state: TreatmentState;
  stateName: string;
  stateReasonName: string;
  dose: number;
  doseFrequency: number;
  doseFrequencyTypeName: string;
  duration: number;
  durationTypeName: string;
  code: string;
  controlTrackings: ControlTracking[];
  pathologyFields: Field[];
  productFields: Field[];
}
