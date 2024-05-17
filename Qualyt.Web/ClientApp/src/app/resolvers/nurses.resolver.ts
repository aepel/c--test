import { Injectable } from '@angular/core';

import { Resolve } from '@angular/router';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/delay';
import { NursesService } from '../services/nurses.service';
import { Nurse } from '../models/nurse.model';

@Injectable()
export class NursesResolver implements Resolve<Observable<Nurse[]>> {
  constructor(private service:NursesService) {}

    resolve() {
        return this.service.getAll();
    }
}
