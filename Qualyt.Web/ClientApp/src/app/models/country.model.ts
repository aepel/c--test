import { Moment } from 'moment/moment';
import { Field } from './field.model';

export class Country {
  id: number;
  name: string;
  prefix: string;
  idPattern: string;
  digitsOfACellPhoneNumber: number;
}
