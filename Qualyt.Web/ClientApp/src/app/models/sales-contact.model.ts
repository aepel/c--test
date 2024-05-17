import { Moment } from 'moment/moment';
import { Field } from './field.model';

export class SalesContact {
  id: number;
  name: string;
  surname: string;
  mothersSurname: string;
  fullName: string;
  active: boolean;
  createdBy: string;
  updatedBy: string;
  createdDate: Moment;
  updatedDate?: Moment;
}
