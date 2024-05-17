import { Injectable, Input } from '@angular/core';

import { Resolve } from '@angular/router';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/delay';
import { DoctorsService } from '../services/doctors.service';
import { Doctor } from '../models/doctor.model';

@Injectable()
export class DoctorsResolver implements Resolve<Observable<Doctor[]>> {
    constructor(private service:DoctorsService) {}

    resolve() {
        return this.service.getAll();
    }
}
