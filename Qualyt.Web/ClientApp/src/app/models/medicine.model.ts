import { Moment } from 'moment/moment';
import { Field } from './field.model';
import { PatientTermsAndConditions } from './patient-terms-and-conditions.model';
import { PatientPathology } from './patient-pathology.model';
import { HealthInsurance } from './health-insurance.model';
import { Location } from './location.model';
import { Laboratory } from './laboratory.model';
import { ProductType, DosageForm, VariationUnit } from './enums.model';
import { Product } from './product.model';

export class Medicine extends Product{
  form: DosageForm;
  variation: number;
  variationUnit: VariationUnit;
  definedDailyDose: string;
  activeSubstance:string;
}
