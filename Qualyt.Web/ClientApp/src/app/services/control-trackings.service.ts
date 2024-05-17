import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';  
import 'rxjs/add/operator/catch';  
import 'rxjs/add/observable/throw'; 
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { ControlTracking } from '../models/control-tracking.model';
import { KeyValue } from '../models/datatable-column.model';
import { DatatableResponse } from '../models/datatable-response.model';
import { QueryParameters } from '../models/query-parameters.model';
import { AuthenticationService } from './authentication.service';

@Injectable()
export class ControlTrackingsService extends BaseService<ControlTracking>  {
    
    myAppUrl: string = "";  

  constructor(_http: Http, client: HttpClient, @Inject('BASE_URL') baseUrl: string, authService: AuthenticationService) {
    super(_http, client, baseUrl + "api/ControlTrackings/", authService);
        this.myAppUrl = baseUrl;
  }

  list(queryParameters: QueryParameters, otherParams: KeyValue[]): Observable<DatatableResponse> {
    const head = this.authService.getRequestHTTPHeaders();
    return this.client.post<DatatableResponse>(this.actionUrl + "listwithotherparams",
                                              { queryParameters, otherParams },
                                              { headers: head });
  }
  
    errorHandler(error: Response) {  
        console.log(error);  
        return Observable.throw(error);  
    }
}  
