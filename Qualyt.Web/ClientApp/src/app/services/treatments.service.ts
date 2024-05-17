import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';  
import 'rxjs/add/operator/catch';  
import 'rxjs/add/observable/throw'; 
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { Patient } from '../models/patient.model';
import { DashboardFilter } from '../models/dashboard-filter.model';
import { Treatment } from '../models/treatment.model';
import { AuthenticationService } from './authentication.service';

@Injectable()
export class TreatmentsService extends BaseService<Treatment>  {
    
    myAppUrl: string = "";  

  constructor(_http: Http, client: HttpClient, @Inject('BASE_URL') baseUrl: string, authService: AuthenticationService) {
    super(_http, client, baseUrl + "api/Treatments/", authService);
        this.myAppUrl = baseUrl;
  }

  getCount(filter: DashboardFilter): Observable<number> {
    const head = this.authService.getRequestHTTPHeaders();
    return this.client.post<number>(this.myAppUrl + 'api/Treatments/GetTreatmentsCount/', filter,{ headers: head });
  }

  getCountLastMonth(filter: DashboardFilter): Observable<number> {
    const head = this.authService.getRequestHTTPHeaders();
    return this.client.post<number>(this.myAppUrl + 'api/Treatments/GetTreatmentsCountLastMonth/', filter, { headers: head });

  }
    errorHandler(error: Response) {  
        console.log(error);  
        return Observable.throw(error);  
    }
}  
