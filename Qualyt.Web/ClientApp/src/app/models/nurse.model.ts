import { Moment } from 'moment/moment';
import { Field } from './field.model';
import { Country } from './country.model';

export class Nurse {
  id: number;
  name: string;
  surname: string;
  mothersSurname: string;
  idNumber: string;
  fullName: string;
  active: boolean;
  country: Country;
  countryId: number;
  createdBy: string;
  updatedBy: string;
  createdDate: Moment;
  updatedDate?: Moment;
}
