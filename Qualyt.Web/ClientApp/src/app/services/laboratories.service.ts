import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';  
import 'rxjs/add/operator/catch';  
import 'rxjs/add/observable/throw'; 
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { Laboratory } from '../models/laboratory.model';
import { AuthenticationService } from './authentication.service';

@Injectable()
export class LaboratoriesService extends BaseService<Laboratory>  {
    
    myAppUrl: string = "";  

  constructor(_http: Http, client: HttpClient, @Inject('BASE_URL') baseUrl: string, authService: AuthenticationService) {
    super(_http, client, baseUrl + "api/Laboratories/", authService);
        this.myAppUrl = baseUrl;
  }

  getWithIcon(): Observable<Laboratory[]> {
    const head = this.authService.getRequestHTTPHeaders();
    return this.client.get<Laboratory[]>(this.actionUrl + "getWithIcon", { headers: head });
  }
  
    errorHandler(error: Response) {  
        console.log(error);  
        return Observable.throw(error);  
    }
}  
