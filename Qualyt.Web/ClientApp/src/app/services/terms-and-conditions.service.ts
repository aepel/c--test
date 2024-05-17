import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';  
import 'rxjs/add/operator/catch';  
import 'rxjs/add/observable/throw'; 
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { Patient } from '../models/patient.model';
import { TermsAndConditions } from '../models/terms-and-conditions.model';
import { AuthenticationService } from './authentication.service';
import { Resolve } from '@angular/router';

@Injectable()
export class TermsAndConditionsService extends BaseService<TermsAndConditions>  {
    
    myAppUrl: string = "";  

  constructor(_http: Http, client: HttpClient, @Inject('BASE_URL') baseUrl: string, authService: AuthenticationService) {
    super(_http, client, baseUrl + "api/TermsAndConditions/", authService);
        this.myAppUrl = baseUrl;
    }

  getText(): Observable<string> {
    let head = this.authService.getHeaders();
    return this._http.get(this.actionUrl + "getText", {headers:head})
      .map(res => res["_body"])
      .catch(this.errorHandler);
  }

  publish(id: number): Observable<boolean> {
    let head = this.authService.getRequestHTTPHeaders();
    return this.client.post<boolean>(this.actionUrl + "publish", id, { headers:head })
      .catch(this.errorHandler);
  }

  getEmailToReceive():Observable<string>{
    let head = this.authService.getHeaders();
    return this._http.get(this.actionUrl + "getEmailToReceive", {headers:head})
      .map(res => res["_body"])
      .catch(this.errorHandler);
  }

    errorHandler(error: Response) {  
        console.log(error);  
        return Observable.throw(error);  
    }
}  
