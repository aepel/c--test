import { Moment } from 'moment/moment';
import { Field } from './field.model';
import { Product } from './product.model';

export class PlanProduct {
  constructor(_planId, _productId, _product?) {
    this.planId = _planId;
    this.productId = _productId;
    this.product = _product;
  }
    planId: number;
    productId: number;
    product:Product;
}
