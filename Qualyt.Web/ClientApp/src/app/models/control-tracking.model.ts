import { Moment } from 'moment/moment';
import { Field } from './field.model';
import { ControlContactType, ControlType } from './enums.model';

export class ControlTracking {
  id: number;
  createdBy: string;
  updatedBy: string;
  createdDate: Moment;
  nextControl?: Moment;
  updatedDate?: Moment;
  active: boolean;
  followingTheTreatment?: boolean;
  treatmentStart?: Moment;
  nextTreatment?: Moment;
  nextDoctorVisit?: Moment;
  treatmentInterruptReason: string;
  treatmentInterruptDate?: Moment;
  comments: string;
  treatmentId: number;
  contactMethod: ControlContactType;
  type:ControlType;
  contactMethodName: string;
  editable: boolean;
  editableByOperator: boolean;
  startRegister: boolean;
  endRegister: boolean;
}
