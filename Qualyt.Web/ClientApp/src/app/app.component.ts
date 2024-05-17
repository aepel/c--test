import { Component, OnInit, ViewEncapsulation} from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { ToastaService, ToastaConfig, ToastOptions, ToastData } from 'ngx-toasta';
import { AlertService, MessageSeverity, AlertMessage } from './services/alert.service';
import { AuthenticationService } from './services/authentication.service';
import { debug } from 'util';
import { NgxRolesService } from 'ngx-permissions';
import { LocalStoreManager } from './services/local-store-manager.service';
import { DBkeys } from './services/db-keys.service';
import { IdToken } from './models/login-response';
import { JwtHelper } from './services/jwt-helper.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  encapsulation: ViewEncapsulation.None

})
export class AppComponent implements OnInit {
  title = 'MCA Latam';
  stickyToasties: number[] = [];
  newNotificationCount = 0;
  appTitle = "MCA Latam";
  dataLoadingConsecutiveFailurs = 0;
  notificationsLoadingSubscription: any;
  constructor(private router: Router, private toastaService: ToastaService, private toastaConfig: ToastaConfig,
    private localStorage: LocalStoreManager, private alertService: AlertService,
    private authService: AuthenticationService, private rolesService: NgxRolesService)
{
    this.toastaConfig.theme = 'bootstrap';
    this.toastaConfig.position = 'top-right';
    this.toastaConfig.limit = 100;
    this.toastaConfig.showClose = true;

  }

  ngOnInit() {
    if(this.authService.isLoggedIn){
      if (!this.localStorage.getData(DBkeys.REMEMBER_ME)) {
        this.authService.logout();
        this.router.navigate([""]);
      }
      else {
        let idToken = this.localStorage.getData(DBkeys.ID_TOKEN);
        let jwtHelper = new JwtHelper();
        let decodedIdToken = <IdToken>jwtHelper.decodeToken(idToken);
        let rolesArray = Array.isArray(decodedIdToken.role) ? decodedIdToken.role : [decodedIdToken.role];
        var self = this;
        rolesArray.forEach(function (item) {
          self.rolesService.addRole(item, []);
        });
      }
    }

    setTimeout(() => {
      if (this.authService.isLoggedIn && !this.authService.isSessionExpired) {
        this.alertService.resetStickyMessage();

        //if (!this.authService.isSessionExpired)
        this.alertService.showMessage("Login", `¡Bienvenido nuevamente ${this.authService.currentUser.fullName}!`, MessageSeverity.default);
        //this.router.navigate(['/dashboard']);
        //else
        //    this.alertService.showStickyMessage("Session Expired", "Your Session has expired. Please log in again", MessageSeverity.warn);
      }

    }, 2000);

    this.alertService.getMessageEvent().subscribe(message => this.showToast(message, false));
    this.alertService.getStickyMessageEvent().subscribe(message => this.showToast(message, true));


    this.router.events.subscribe((evt) => {
      if (!(evt instanceof NavigationEnd)) {
        return;
      }
      window.scrollTo(0, 0);
    });
  }
  
 
  showToast(message: AlertMessage, isSticky: boolean) {
    
    if (message == null) {
      for (let id of this.stickyToasties.slice(0)) {
        this.toastaService.clear(id);
      }

      return;
    }

    let toastOptions: ToastOptions = {
      title: message.summary,
      msg: message.detail,
      timeout: isSticky ? 0 : 4000
    };


    if (isSticky) {
      toastOptions.onAdd = (toast: ToastData) => this.stickyToasties.push(toast.id);

      toastOptions.onRemove = (toast: ToastData) => {
        let index = this.stickyToasties.indexOf(toast.id, 0);

        if (index > -1) {
          this.stickyToasties.splice(index, 1);
        }

        toast.onAdd = null;
        toast.onRemove = null;
      };
    }


    switch (message.severity) {
      case MessageSeverity.default: this.toastaService.default(toastOptions); break;
      case MessageSeverity.info: this.toastaService.info(toastOptions); break;
      case MessageSeverity.success: this.toastaService.success(toastOptions); break;
      case MessageSeverity.error: this.toastaService.error(toastOptions); break;
      case MessageSeverity.warn: this.toastaService.warning(toastOptions); break;
      case MessageSeverity.wait: this.toastaService.wait(toastOptions); break;
    }
  }


}
