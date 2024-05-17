import { Moment } from 'moment/moment';
import { Field } from './field.model';
import { Laboratory } from './laboratory.model';
import { Product } from './product.model';
import { Country } from './country.model';
import { PlanPathology } from './plan-pathology.model';
import { PlanProduct } from './plan-product.model';

export class Plan {
  id: number;
  name: string;
  surname: string;
  fullName: string;
  laboratoryId: number;
  laboratory: Laboratory;
  productId: number;
  product: Product;
  countryId: number;
  country: Country;
  start: Moment;
  end: Moment;
  planPathologies: PlanPathology[];
  planProducts: PlanProduct[];
  active: boolean;
  createdBy: string;
  updatedBy: string;
  createdDate: Moment;
  updatedDate?: Moment;
}
