import { Moment } from 'moment/moment';
import { Field } from './field.model';
import { PatientTermsAndConditions } from './patient-terms-and-conditions.model';
import { PatientPathology } from './patient-pathology.model';
import { HealthInsurance } from './health-insurance.model';
import { Location } from './location.model';
import { Laboratory } from './laboratory.model';
import { ProductType, DeviceType } from './enums.model';
import { Product } from './product.model';

export class Device extends Product{
  deviceType: string;
}
