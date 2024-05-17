import { Injectable } from '@angular/core';

import { Resolve } from '@angular/router';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/delay';
import { ActivatedRouteSnapshot } from '@angular/router';
import { PatientsService } from 'src/app/services/patients.service';
import { Patient } from '../models/patient.model';

@Injectable()
export class PatientsDetailResolver implements Resolve<Observable<Patient>> {
  constructor(private service:PatientsService) {}

    resolve(r:ActivatedRouteSnapshot) {
        var patientId=r.queryParams['id'];
        if(patientId)
            return this.service.getWithoutFiles(patientId);
    }
}
