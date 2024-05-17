///// <reference path="alert.service.spec.ts" />

import { Injectable, Inject } from '@angular/core';
import { Headers,Http,Response } from '@angular/http';
import { Router, NavigationExtras } from "@angular/router";
import { Observable, Subject } from 'rxjs';
import { map } from 'rxjs/operators';
import { ApplicationUser } from '../models/application-user.model';
import { ConfigurationService } from './configuration.service';
import { LocalStoreManager } from './local-store-manager.service';
import { DBkeys } from './db-keys.service';
import { LoginResponse, IdToken } from '../models/login-response';
import { JwtHelper } from './jwt-helper.service';
import { PermissionValues } from '../models/permissions.model';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { NgxRolesService } from 'ngx-permissions';
import { LaboratoryUser } from '../models/laboratoryUser.model';
import { AlertService, MessageSeverity } from './alert.service';
@Injectable()
export class AuthenticationService {
  getLaboratoryUser() {
    let head = { headers: this.getRequestHTTPHeaders() };
    return this.client.get(this.baseUrl + 'api/LaboratoryUsers/getOneById/' + this.currentUser.id, head);
  }

  public get loginUrl() { return this.configurations.loginUrl; }
  public get homeUrl() { return this.configurations.homeUrl; }
  public get changePasswordUrl(){return this.baseUrl + `api/Authorization/ResetPassword`}
  public resetPassword( id : string, token:string , password:string,passwordConfirm:string )
  {
    console.log("entre al service");
    console.log(token);
    
    let header = new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' });
    if (password == passwordConfirm) {
      let params = new HttpParams()
        .append('userid', id)
        .append('token', token)
        .append('nuevoPassword', password)
      let requestBody = params.toString();
      this.client.post(this.changePasswordUrl, requestBody, { headers: header }).subscribe(
        result => {
          alert("La constraseña ha sido cambiado de forma exitosa!, esta siendo redirigido a la ventana de login");
          
          this.redirectForLogin();
        },
        response => {
          console.log(response);
          debugger;
          var errores = {
            "PasswordRequiresNonAlphanumeric": "La contraseña debe tener al menos un caracter no alfanumérico;",
            "PasswordRequiresDigit": "La contraseña debe tener al menos un número;",
            "PasswordRequiresUpper": "La contraseña debe tener al menos una letra mayúscula;",
            "PasswordTooShort": "La contraseña es demasiado corta, debe tener al menos 6 caracteres;",
            "PasswordRequiresLower": "La contraseña debe tener al menos una letra minúscula;",
            "PasswordRequiresUniqueChars": "La contraseña debe tener al menos un caracter único;",
            "InvalidToken": "El token que recibió por mail ha expirado, si ya recibió uno nuevo y sigue visualizando este error pongase en contacto con el proveedor de la herramienta;"

          };
          var responseErrores = response.error.error_description.split('/');
          responseErrores = responseErrores.map(x => { if (errores[x] != undefined) { return errores[x]; } return x; });
          
          alert(responseErrores.join(' '));
        })
    }
    else { alert("Las constraseñas deben ser iguales"); }
    
    
       
  }
  public forgotPassword(usermail: string) {
    console.log("entra en forgot password del service");
    console.log(usermail);
    

    let header = new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' });
    let params = new HttpParams()
      .append('usermail', usermail)
      ;
    let requestBody = params.toString();
    
    return this.client.post(this.baseUrl + 'api/Authorization/SendPasswordResetLink', requestBody, { headers: header }).subscribe(
      result => {
        this.alertService.logMessage("Se ha enviado un mail para continuar con los pasos de la recuperacion de contraseña");
        this.alertService.showStickyMessage("Se ha enviado un mail para continuar con los pasos de la recuperacion de contraseña");
        this.redirectForLogin();
      },
      response => { console.log(response); this.alertService.showMessage("", response.error.error_description, MessageSeverity.error); }
    );

  };
  public loginRedirectUrl: string;
  public logoutRedirectUrl: string;
  public passwordRestore : string;

  public reLoginDelegate: () => void;

  private previousIsLoggedInCheck = false;
  private _loginStatus = new Subject<boolean>();
  
  constructor
  (
    private router: Router, 
    private configurations: ConfigurationService,
    private localStorage: LocalStoreManager,
    protected client: HttpClient,
    @Inject('BASE_URL') public baseUrl: string,
    private rolesService: NgxRolesService,
    private alertService: AlertService
    )
    {
      this.initializeLoginStatus();
    }


  private initializeLoginStatus() {
    this.localStorage.getInitEvent().subscribe(() => {
      this.reevaluateLoginStatus();
    });
  }


  gotoPage(page: string, preserveParams = true) {

    let navigationExtras: NavigationExtras = {
      queryParamsHandling: preserveParams ? "merge" : "", preserveFragment: preserveParams
    };


    this.router.navigate([page], navigationExtras);
  }


  redirectLoginUser() {
    this.router.navigate(["dashboard"]);
  }


  redirectLogoutUser() {
    let redirect = this.logoutRedirectUrl ? this.logoutRedirectUrl : this.loginUrl;
    this.logoutRedirectUrl = null;

    this.router.navigate([redirect]);
  }


  redirectForLogin() {
    this.loginRedirectUrl = this.router.url;
    this.router.navigate([this.loginUrl]);
  }
  

  reLogin() {

    this.localStorage.deleteData(DBkeys.TOKEN_EXPIRES_IN);

    if (this.reLoginDelegate) {
      this.reLoginDelegate();
    }
    else {
      this.redirectForLogin();
    }
  }


  refreshLogin() {
  /*  return this.endpointFactory.getRefreshLoginEndpoint<LoginResponse>().pipe(
      map(response => this.processLoginResponse(response, this.rememberMe)));*/
  }


  login(userName: string, password: string, rememberMe?: boolean) {

    if (this.isLoggedIn)
      this.logout();
    let header = new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' });

    let params = new HttpParams()
      .append('username', userName)
      .append('password', password)
      .append('grant_type', 'password')
      .append('scope', 'openid email phone profile offline_access roles');

    let requestBody = params.toString();
    return this.client.post<LoginResponse>(this.baseUrl + "connect/token", requestBody, { headers: header })
      .pipe(map(response => this.processLoginResponse(response, rememberMe)));  
  }

  

  
  private processLoginResponse(response: LoginResponse, rememberMe: boolean) {
    
    let accessToken = response.access_token;

    if (accessToken == null)
      throw new Error("Received accessToken was empty");

    let idToken = response.id_token;
    let refreshToken = response.refresh_token || this.refreshToken;
    let expiresIn = response.expires_in;

    let tokenExpiryDate = new Date();
    tokenExpiryDate.setSeconds(tokenExpiryDate.getSeconds() + expiresIn);

    let accessTokenExpiry = tokenExpiryDate;

    let jwtHelper = new JwtHelper();
    let decodedIdToken = <IdToken>jwtHelper.decodeToken(response.id_token);

    let permissions: PermissionValues[] = Array.isArray(decodedIdToken.permission) ? decodedIdToken.permission : [decodedIdToken.permission];

    if (!this.isLoggedIn)
      this.configurations.import(decodedIdToken.configuration);

    let user = new ApplicationUser(
      decodedIdToken.sub,
      decodedIdToken.name,
      decodedIdToken.fullname,
      decodedIdToken.email,
      decodedIdToken.jobtitle,
      decodedIdToken.phone,
      Array.isArray(decodedIdToken.role) ? decodedIdToken.role : [decodedIdToken.role]);
    user.isEnabled = true;

    this.saveUserDetails(user, permissions, accessToken, idToken, refreshToken, accessTokenExpiry, rememberMe);
    let rolesArray = Array.isArray(decodedIdToken.role) ? decodedIdToken.role : [decodedIdToken.role];
    var self = this;
    rolesArray.forEach(function (item) {
      self.rolesService.addRole(item, []);
    });

    this.reevaluateLoginStatus(user);

    return user;
  }


  private saveUserDetails(user: ApplicationUser, permissions: PermissionValues[], accessToken: string, idToken: string, refreshToken: string, expiresIn: Date, rememberMe: boolean) {
    this.localStorage.saveSyncedSessionData(accessToken, DBkeys.ACCESS_TOKEN);
    this.localStorage.saveSyncedSessionData(idToken, DBkeys.ID_TOKEN);
    this.localStorage.saveSyncedSessionData(refreshToken, DBkeys.REFRESH_TOKEN);
    this.localStorage.saveSyncedSessionData(expiresIn, DBkeys.TOKEN_EXPIRES_IN);
    this.localStorage.saveSyncedSessionData(permissions, DBkeys.USER_PERMISSIONS);
    this.localStorage.saveSyncedSessionData(user, DBkeys.CURRENT_USER);
    this.localStorage.saveSyncedSessionData(rememberMe, DBkeys.REMEMBER_ME);
  }



  logout(): void {
    this.localStorage.deleteData(DBkeys.ACCESS_TOKEN);
    this.localStorage.deleteData(DBkeys.ID_TOKEN);
    this.localStorage.deleteData(DBkeys.REFRESH_TOKEN);
    this.localStorage.deleteData(DBkeys.TOKEN_EXPIRES_IN);
    this.localStorage.deleteData(DBkeys.USER_PERMISSIONS);
    this.localStorage.deleteData(DBkeys.CURRENT_USER);
    this.localStorage.deleteData(DBkeys.REMEMBER_ME);

    this.configurations.clearLocalChanges();
    this.rolesService.flushRoles();

    this.reevaluateLoginStatus();
  }


  private reevaluateLoginStatus(currentUser?: ApplicationUser) {

    let user = currentUser || this.localStorage.getDataObject<ApplicationUser>(DBkeys.CURRENT_USER);
    let isLoggedIn = user != null;

    if (this.previousIsLoggedInCheck != isLoggedIn) {
      setTimeout(() => {
        this._loginStatus.next(isLoggedIn);
      });
    }

    this.previousIsLoggedInCheck = isLoggedIn;
  }


  getLoginStatusEvent(): Observable<boolean> {
    return this._loginStatus.asObservable();
  }


  get currentUser(): ApplicationUser {

    let user = this.localStorage.getDataObject<ApplicationUser>(DBkeys.CURRENT_USER);
    this.reevaluateLoginStatus(user);

    return user;
  }

  get userPermissions(): PermissionValues[] {
    return this.localStorage.getDataObject<PermissionValues[]>(DBkeys.USER_PERMISSIONS) || [];
  }

  get accessToken(): string {

    this.reevaluateLoginStatus();
    return this.localStorage.getData(DBkeys.ACCESS_TOKEN);
  }

  get accessTokenExpiryDate(): Date {

    this.reevaluateLoginStatus();
    return this.localStorage.getDataObject<Date>(DBkeys.TOKEN_EXPIRES_IN, true);
  }

  get isSessionExpired(): boolean {

    if (this.accessTokenExpiryDate == null) {
      return true;
    }

    return !(this.accessTokenExpiryDate.valueOf() > new Date().valueOf());
  }


  get idToken(): string {

    this.reevaluateLoginStatus();
    return this.localStorage.getData(DBkeys.ID_TOKEN);
  }

  get refreshToken(): string {

    this.reevaluateLoginStatus();
    return this.localStorage.getData(DBkeys.REFRESH_TOKEN);
  }

  get isLoggedIn(): boolean {
    return (this.currentUser != null) as boolean;
  }

  get rememberMe(): boolean {
    return this.localStorage.getDataObject<boolean>(DBkeys.REMEMBER_ME) == true;
  }

  public getRequestHTTPHeaders(): HttpHeaders {
    /*const headers = new HttpHeaders();
    headers.set('Authorization', 'Bearer ' + this.accessToken);
    headers.set('Content-Type', 'application/json');*/
    let headers = new HttpHeaders({
      'Authorization': 'Bearer ' + this.accessToken,
      'Content-Type': 'application/json',
      'Accept': `application/vnd.iman.v1+json, application/json, text/plain, */*`,
      'App-Version': ConfigurationService.appVersion
    });
    return headers;
  }

  public getHeaders(): Headers {
    let headers = new Headers({
      'Authorization': 'Bearer ' + this.accessToken,
      'Content-Type': 'application/json',
      'Accept': `application/vnd.iman.v1+json, application/json, text/plain, */*`,
      'App-Version': ConfigurationService.appVersion
    });
    return headers;
  }

  
  public getRequestHTTPHeadersString() {

    return [
      { name: 'Authorization', value: 'Bearer ' + this.accessToken },
      { name:'Content-Type', value:'application/json' },
      { name:'Accept', value:'application/vnd.iman.v1+json, application/json, text/plain, */*' },
      { name: 'App-Version', value: ConfigurationService.appVersion }
    ];
  }


}
