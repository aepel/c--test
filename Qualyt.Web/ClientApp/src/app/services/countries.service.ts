import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';  
import 'rxjs/add/operator/catch';  
import 'rxjs/add/observable/throw'; 
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { Pathology } from '../models/pathology.model';
import { Patient } from '../models/patient.model';
import { Country } from '../models/country.model';
import { AuthenticationService } from './authentication.service';

@Injectable()
export class CountriesService extends BaseService<Country>  {
    
    myAppUrl: string = "";  

  constructor(_http: Http, client: HttpClient, @Inject('BASE_URL') baseUrl: string, authService: AuthenticationService) {
    super(_http, client, baseUrl + "api/Countries/", authService);
        this.myAppUrl = baseUrl;
    }

  getAllByUser(): Observable<Country[]> {
      const head = this.authService.getRequestHTTPHeaders();
      return this.client.get<Country[]>(this.actionUrl + "getAllByUser", { headers: head });
  }

    errorHandler(error: Response) {  
        console.log(error);  
        return Observable.throw(error);  
    }
}  
