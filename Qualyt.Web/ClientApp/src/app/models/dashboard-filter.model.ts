import { Moment } from 'moment/moment';
import { Plan } from './plan.model';

export class DashboardFilter {
  constructor() {
    this.selectedPlanIds = [];
  }
  start?: Moment;
  end?: Moment;
  selectedPlanIds: number[];
}
