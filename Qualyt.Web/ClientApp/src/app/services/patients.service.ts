import { Injectable, Inject } from '@angular/core';
import { Http, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';  
import 'rxjs/add/operator/catch';  
import 'rxjs/add/observable/throw'; 
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { Pathology } from '../models/pathology.model';
import { DashboardFilter } from '../models/dashboard-filter.model';
import { Patient } from '../models/patient.model';
import { AuthenticationService } from './authentication.service';

@Injectable()
export class PatientsService extends BaseService<Patient>  {
    
    myAppUrl: string = "";  

  constructor(_http: Http, client: HttpClient, @Inject('BASE_URL') baseUrl: string, authService: AuthenticationService) {
    super(_http, client, baseUrl + "api/Patients/", authService);
        this.myAppUrl = baseUrl;
  }

  getByDoctor(id: string): Observable<Patient[]> {
    const head = this.authService.getRequestHTTPHeaders();
    return this.client.get<Patient[]>(this.actionUrl + 'getByDoctor/' + id, { headers: head });
  }

  getWithoutFiles(id: number): Observable<Patient> {
    const head = this.authService.getRequestHTTPHeaders();
    return this.client.get<Patient>(this.actionUrl + 'getWithoutFiles/' + id, { headers: head });
  }

  acceptTerms(id: number): Observable<void> {
    const head = this.authService.getRequestHTTPHeaders();
    return this.client.post<void>(this.myAppUrl + 'api/PatientsTermsAcceptance/acceptTerms/', id, { headers: head });
  }

  toggleActive(id: number): Observable<void> {
    const head = this.authService.getRequestHTTPHeaders();
    return this.client.post<void>(this.actionUrl + 'toggleActive/', id, { headers: head });
  }

  getHashed(id: string, number:string): Observable<Patient> {
    const head = this.authService.getRequestHTTPHeaders();
    id = encodeURIComponent(id);
    return this.client.get<Patient>(this.myAppUrl + 'api/PatientsTermsAcceptance/getHashed?hash=' + id + '&number=' + number, { headers: head });
  }
  getCount(filter: DashboardFilter): Observable<number> {
    const head = this.authService.getRequestHTTPHeaders();
    return this.client.post<number>(this.myAppUrl + 'api/Patients/GetPatientsCount/', filter, { headers: head });

  }
  getCountLastMonth(filter: DashboardFilter): Observable<number> {
    const head = this.authService.getRequestHTTPHeaders();
    return this.client.post<number>(this.myAppUrl + 'api/Patients/GetPatientsCountLastMonth/', filter, { headers: head });

  }
    errorHandler(error: Response) {  
        console.log(error);  
        return Observable.throw(error);  
    }
}  
