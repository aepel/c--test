import { Injectable } from '@angular/core';

import { Resolve } from '@angular/router';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/delay';
import { CountriesService } from '../services/countries.service';
import { Country } from '../models/country.model';

@Injectable()
export class CountriesByUserResolver implements Resolve<Observable<Country[]>> {
  constructor(private service:CountriesService) {}

    resolve() {
        return this.service.getAllByUser();
    }
}
