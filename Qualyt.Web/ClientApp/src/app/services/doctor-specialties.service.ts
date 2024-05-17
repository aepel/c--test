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
import { SalesContact } from '../models/sales-contact.model';
import { AttentionPlace } from '../models/attention-place.model';
import { DoctorSpecialty } from '../models/doctor-specialty.model';

@Injectable()
export class DoctorSpecialtiesService extends BaseService<DoctorSpecialty>  {
    
    myAppUrl: string = "";  

  constructor(_http: Http, client: HttpClient, @Inject('BASE_URL') baseUrl: string, authService: AuthenticationService) {
    super(_http, client, baseUrl + "api/DoctorSpecialties/", authService);
        this.myAppUrl = baseUrl;
    }

    errorHandler(error: Response) {  
        console.log(error);  
        return Observable.throw(error);  
    }
}  
