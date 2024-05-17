import { Injectable, Inject } from '@angular/core';
import { Http, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';  
import 'rxjs/add/operator/catch';  
import 'rxjs/add/observable/throw'; 
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { AuthenticationService } from './authentication.service';
import { Plan } from '../models/plan.model';
import { SalesContact } from '../models/sales-contact.model';
import { PivotTableData } from '../models/pivot-table-data.model';
import { ApplicationUser } from '../models/application-user.model';

@Injectable()
export class UsersService extends BaseService<ApplicationUser>  {
    
    myAppUrl: string = "";  

  constructor(_http: Http, client: HttpClient, @Inject('BASE_URL') baseUrl: string, authService: AuthenticationService) {
    super(_http, client, baseUrl + "api/Users/", authService);
        this.myAppUrl = baseUrl;
  }

    errorHandler(error: Response) {  
        console.log(error);  
        return Observable.throw(error);  
    }
}  
