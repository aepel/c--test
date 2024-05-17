import { Injectable } from '@angular/core';

import { Resolve } from '@angular/router';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/delay';
import { PathologiesService } from '../services/pathologies.service';
import { Pathology } from '../models/pathology.model';

@Injectable()
export class PathologiesResolver implements Resolve<Observable<Pathology[]>> {
  constructor(private service:PathologiesService) {}

    resolve() {
        return this.service.getAll();
    }
}
