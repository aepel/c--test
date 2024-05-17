import { Injectable, PLATFORM_ID, Inject } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { isPlatformBrowser } from '@angular/common';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs';
//import { AuthenticationService } from 'app/services/authentication.service';
import { ActivatedRouteSnapshot } from '@angular/router';
import { RouterStateSnapshot } from '@angular/router';
import { AuthenticationService } from '../services/authentication.service';
//import { RoutesAvailable } from 'app/guard/roles.guard';
var jwt_decode; //= require("jwt-decode");
@Injectable()
export class AuthGuard implements CanActivate {

    constructor(private router: Router, @Inject(PLATFORM_ID) private platformId: Object, private authService:AuthenticationService
       /* , private roleguard: RoutesAvailable*/) { }
    private _loginStatus = new Subject<boolean>();
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        var url = state.url.replace('/', '').split('?')[0].split('/')[0];
        //console.log("Valida ruta"+ this.roleguard.checkAuthorization(url));
        if (this.isLoggedIn() /*&& this.roleguard.checkAuthorization(url)*/) {
            return true;

        } else {
            this.router.navigate(['/']);
            return false;

        }
    }

    public reevaluateLoginStatus() {


        setTimeout(() => {
            this._loginStatus.next(this.isLoggedIn());
        });

    }
    getLoginStatusEvent(): Observable<boolean> {
        return this._loginStatus.asObservable();
    }

  private isLoggedIn(): boolean {
    
    return this.authService.isLoggedIn && !this.authService.isSessionExpired;
    }

    getToken(): string | null {
        if (localStorage.getItem('TOKEN') == null) { return null; }
        return JSON.stringify(localStorage.getItem('TOKEN'));
    }

    getTokenExpirationDate(tok: string): Date | null {
        if (tok == null) return null;
        const decoded = jwt_decode(tok);

        
        if (decoded.exp === undefined) return null;

        const date = new Date(0);
        date.setUTCSeconds(decoded.exp);
        return date;
    }

    isTokenExpired(tok?: string | null): boolean {
        
        if (tok == null) tok = this.getToken();
        if (tok == null) return true;
        else {

        
            const date = this.getTokenExpirationDate(tok);
            if (date == null) return false;
            return !(date.valueOf() > new Date().valueOf());
        }
    }

    
}
