import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';  
import 'rxjs/add/operator/catch';  
import 'rxjs/add/observable/throw'; 
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { Pathology } from '../models/pathology.model';
import { DashboardFilter } from '../models/dashboard-filter.model';
import { AuthenticationService } from './authentication.service';

@Injectable()
export class PathologiesService extends BaseService<Pathology>  {
    
    myAppUrl: string = "";  

  constructor(_http: Http, client: HttpClient, @Inject('BASE_URL') baseUrl: string, authService: AuthenticationService) {
    super(_http, client, baseUrl + "api/Pathologies/", authService);
        this.myAppUrl = baseUrl;
  }

  getByPatient(id: number): Observable<Pathology[]> {
    const head = this.authService.getRequestHTTPHeaders();
    return this.client.get<Pathology[]>(this.actionUrl + 'getByPatient/' + id, { headers: head });
  }
  getCount(filter:DashboardFilter): Observable<number> {
    const head = this.authService.getRequestHTTPHeaders();
    return this.client.post<number>(this.myAppUrl + 'api/Pathologies/GetPathologiesCount/', filter, { headers: head });

  }
  getCountLastMonth(filter: DashboardFilter): Observable<number> {
    const head = this.authService.getRequestHTTPHeaders();
    return this.client.post<number>(this.myAppUrl + 'api/Pathologies/GetPathologiesCountLastMonth/', filter, { headers: head });

  }
    errorHandler(error: Response) {  
        console.log(error);  
        return Observable.throw(error);  
    }
}  
