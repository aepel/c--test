import { Http, RequestOptions, Response } from "@angular/http";
import { Observable } from "rxjs/Observable";
import { HttpClient } from "@angular/common/http";
import { QueryParameters } from "../models/query-parameters.model";
import { DatatableResponse } from "../models/datatable-response.model";
import { KeyValue } from "../models/datatable-column.model";
import { AuthenticationService } from "./authentication.service";

export abstract class BaseService<T> {

  constructor(protected _http: Http, protected client: HttpClient,
    protected actionUrl: string,
    public authService: AuthenticationService, private ViewBagsUrl?: string) {
  }

  getAll(): Observable<T[]> {
    const head = this.authService.getRequestHTTPHeaders();
    return this.client.get<T[]>(this.actionUrl + "get", { headers: head });
  }

  list(queryParameters: QueryParameters, otherParams: KeyValue[])
  list(queryParameters: QueryParameters): Observable<DatatableResponse> {
    const head = this.authService.getRequestHTTPHeaders();
    return this.client.post<DatatableResponse>(this.actionUrl + "list", queryParameters, { headers: head });
  }

  getOne(id: number) {
    let head = { headers: this.authService.getRequestHTTPHeaders() };
    return this.client.get(this.actionUrl + 'get/' + id, head);
  }
  getById(id: string) {
    let head = { headers: this.authService.getRequestHTTPHeaders() };
    return this.client.get(this.actionUrl + 'get/' + id, head);
  }
  update(objeto: T) {
    const head = this.authService.getRequestHTTPHeaders();
    return this.client.put(this.actionUrl + 'put', objeto, { headers: head });//.map(resp => resp.json() as T);

  }

  insert(objeto: T) {
    const head = this.authService.getRequestHTTPHeaders();
    
    return this.client.post(this.actionUrl + 'post', objeto, { headers: head });//.map(resp => resp.json() as T);

  }

  delete(id: any): Observable<T> {
    const head = this.authService.getRequestHTTPHeaders();
    
    return this.client.delete<T>(this.actionUrl + 'delete/' + id, { headers: head });//.map(resp => resp.json() as T);

  }

  loadViewBags(): Observable<any> {

    return this.client.get(this.actionUrl + this.ViewBagsUrl)
    // .catch(this.errorHandler);

  }
} 
