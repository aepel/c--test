import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';  
import 'rxjs/add/operator/catch';  
import 'rxjs/add/observable/throw'; 
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { AuthenticationService } from './authentication.service';
import { Plan } from '../models/plan.model';
import { DashboardFilter } from '../models/dashboard-filter.model';
import { PivotTableData } from '../models/pivot-table-data.model';

@Injectable()
export class PlansService extends BaseService<Plan>  {
    
    myAppUrl: string = "";  

  constructor(_http: Http, client: HttpClient, @Inject('BASE_URL') baseUrl: string, authService: AuthenticationService) {
    super(_http, client, baseUrl + "api/Plans/", authService);
        this.myAppUrl = baseUrl;
  }

  getAllByUser(): Observable<Plan[]> {
    const head = this.authService.getRequestHTTPHeaders();
    return this.client.get<Plan[]>(this.actionUrl + "getAllByUser", { headers: head });
  }

  getActivesByUser(): Observable<Plan[]> {
    const head = this.authService.getRequestHTTPHeaders();
    return this.client.get<Plan[]>(this.actionUrl + "getActivesByUser", { headers: head });
  }

  getPivotTableData(filter:DashboardFilter): Observable<PivotTableData[]> {
    const head = this.authService.getRequestHTTPHeaders();
    return this.client.post<PivotTableData[]>(this.actionUrl + 'getPivotTableData/', filter, { headers: head });
  }

    errorHandler(error: Response) {  
        console.log(error);  
        return Observable.throw(error);  
    }
}  
