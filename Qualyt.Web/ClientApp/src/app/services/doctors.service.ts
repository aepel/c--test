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
import { Doctor } from '../models/doctor.model';
import { DashboardFilter } from '../models/dashboard-filter.model';
import { AuthenticationService } from './authentication.service';

@Injectable()
export class DoctorsService extends BaseService<Doctor>  {
    
    myAppUrl: string = "";  

  constructor(_http: Http, client: HttpClient, @Inject('BASE_URL') baseUrl: string, authService: AuthenticationService) {
    super(_http, client, baseUrl + "api/Doctors/", authService);
        this.myAppUrl = baseUrl;
  }

  getOneById(id: string) {
    let head = { headers: this.authService.getRequestHTTPHeaders() };
    return this.client.get(this.actionUrl + 'getOneById/' + id, head);
  }
  getCount(filter:DashboardFilter): Observable<number> {
    const head = this.authService.getRequestHTTPHeaders();
    return this.client.post<number>(this.myAppUrl + 'api/Doctors/GetDoctorsCount/', filter, { headers: head });

  }
  getCountLastMonth(filter: DashboardFilter): Observable<number> {
    const head = this.authService.getRequestHTTPHeaders();
    return this.client.post<number>(this.myAppUrl + 'api/Doctors/GetDoctorsCountLastMonth/', filter, { headers: head });

  }
  
    errorHandler(error: Response) {  
        console.log(error);  
        return Observable.throw(error);  
    }
}  
