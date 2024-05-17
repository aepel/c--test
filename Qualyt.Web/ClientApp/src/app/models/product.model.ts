import { Moment } from 'moment/moment';
import { Field } from './field.model';
import { PatientTermsAndConditions } from './patient-terms-and-conditions.model';
import { PatientPathology } from './patient-pathology.model';
import { HealthInsurance } from './health-insurance.model';
import { Location } from './location.model';
import { Laboratory } from './laboratory.model';
import { ProductType } from './enums.model';

export class Product {
  id: number;
  name: string;
  createdBy: string;
  updatedBy: string;
  createdDate: Moment;
  updatedDate?: Moment;
  active: boolean;
  productType: ProductType;
  laboratory: Laboratory;
  laboratoryId: number;
  amount: number;
  code: string;
  fields: Field[];
}
