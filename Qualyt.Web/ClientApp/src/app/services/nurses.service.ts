import { Injectable, Inject } from '@angular/core';
import { Http, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';  
import 'rxjs/add/operator/catch';  
import 'rxjs/add/observable/throw'; 
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { AuthenticationService } from './authentication.service';
import { Nurse } from '../models/nurse.model';

@Injectable()
export class NursesService extends BaseService<Nurse>  {
    
    myAppUrl: string = "";  

  constructor(_http: Http, client: HttpClient, @Inject('BASE_URL') baseUrl: string, authService: AuthenticationService) {
    super(_http, client, baseUrl + "api/Nurses/", authService);
        this.myAppUrl = baseUrl;
    }

    errorHandler(error: Response) {  
        console.log(error);
        return Observable.throw(error);  
    }
}  
