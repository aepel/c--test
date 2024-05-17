import { Injectable } from '@angular/core';

import { Resolve } from '@angular/router';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/delay';
import { HealthInsurance } from '../models/health-insurance.model';
import { HealthInsurancesService } from '../services/health-insurance.service';

@Injectable()
export class HealthInsurancesResolver implements Resolve<Observable<HealthInsurance[]>> {
  constructor(private service:HealthInsurancesService) {}

    resolve() {
        return this.service.getAll();
    }
}
