import { Injectable, Inject } from '@angular/core';
import { Http, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';  
import 'rxjs/add/operator/catch';  
import 'rxjs/add/observable/throw'; 
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { Product } from '../models/product.model';
import { AuthenticationService } from './authentication.service';

@Injectable()
export class ProductsService extends BaseService<Product>  {
    
    myAppUrl: string = "";  

  constructor(_http: Http, client: HttpClient, @Inject('BASE_URL') baseUrl: string, authService: AuthenticationService) {
    super(_http, client, baseUrl + "api/Products/", authService);
        this.myAppUrl = baseUrl;
    }

  getByLaboratory(id: number): Observable<Product[]> {
    const head = this.authService.getRequestHTTPHeaders();
    return this.client.get<Product[]>(this.actionUrl + 'getByLaboratory/' + id, { headers: head });
  }

    errorHandler(error: Response) {  
        console.log(error);  
        return Observable.throw(error);  
    }
}  
