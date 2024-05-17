import { Moment } from 'moment/moment';
import { Field } from './field.model';
import { Country } from './country.model';
import { Plan } from './plan.model';

export class UserPlan {
  constructor(_planId, _userId, _plan?) {
    this.planId = _planId;
    this.userId = _userId;
    this.plan = _plan;
  }
    userId: number
    planId: number
    plan: Plan
}
