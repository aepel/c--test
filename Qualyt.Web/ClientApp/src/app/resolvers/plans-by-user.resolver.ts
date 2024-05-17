import { Injectable } from '@angular/core';

import { Resolve } from '@angular/router';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/delay';
import { Plan } from '../models/plan.model';
import { PlansService } from '../services/plans.service';

@Injectable()
export class PlansByUserResolver implements Resolve<Observable<Plan[]>> {
  constructor(private service:PlansService) {}

    resolve() {
        return this.service.getActivesByUser();
    }
}
