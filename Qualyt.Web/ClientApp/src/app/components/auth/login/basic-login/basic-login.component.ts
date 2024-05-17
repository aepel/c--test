import { Component, OnInit, OnDestroy, Input  } from '@angular/core';

import { Utilities } from '../../../../services/utilities.service';
import { AlertService, MessageSeverity, DialogType } from '../../../../services/alert.service';
import { AuthenticationService } from '../../../../services/authentication.service';
import { UserLogin } from '../../../../models/user-login.model';
import { ConfigurationService } from '../../../../services/configuration.service';

import { Router } from '@angular/router';


@Component({
  selector: 'app-basic-login',
  templateUrl: './basic-login.component.html',
  
  styleUrls: ['./basic-login.component.scss']
})
export class BasicLoginComponent implements  OnInit, OnDestroy {

  userLogin = new UserLogin();
  isLoading = false;
  formResetToggle = true;
  modalClosedCallback: () => void;
  loginStatusSubscription: any;

  @Input()
  isModal = false;
    error: boolean=false;


  constructor(private alertService: AlertService, private authService: AuthenticationService,
    private configurations: ConfigurationService,private router:Router) {

  }


  ngOnInit() {

    
    this.userLogin.rememberMe = this.authService.rememberMe;
    
    if (this.getShouldRedirect()) {
      this.authService.redirectLoginUser();
    }
    else {
      this.loginStatusSubscription = this.authService.getLoginStatusEvent().subscribe(isLoggedIn => {
        if (this.getShouldRedirect()) {
          this.authService.redirectLoginUser();
        }
      });
    }
  }


  ngOnDestroy() {
    if (this.loginStatusSubscription)
      this.loginStatusSubscription.unsubscribe();
  }


  getShouldRedirect() {
    return !this.isModal && this.authService.isLoggedIn && !this.authService.isSessionExpired;
  }


  showErrorAlert(caption: string, message: string) {
    this.alertService.showMessage(caption, message, MessageSeverity.error);
  }

  closeModal() {
    if (this.modalClosedCallback) {
      this.modalClosedCallback();
    }
  }


  login() {
    this.error = false;

    this.isLoading = true;
    this.alertService.showStickyMessage("", "Intentando Realizar el login", MessageSeverity.info);

    this.authService.login(this.userLogin.email, this.userLogin.password, this.userLogin.rememberMe)
      .subscribe(
        user => {
          setTimeout(() => {
            
            this.alertService.stopLoadingMessage();
            this.isLoading = false;

            this.alertService.showMessage("Login", `¡Bienvenido nuevamente!`, MessageSeverity.success);
            this.router.navigate(["dashboard"]);     
          }, 500);
        },
      error => {
        this.error = true;
        
          if (Utilities.checkNoNetwork(error)) {
            this.alertService.showStickyMessage(Utilities.noNetworkMessageCaption, Utilities.noNetworkMessageDetail, MessageSeverity.error, error);
            this.offerAlternateHost();
          }
          else {
            let errorMessage = Utilities.findHttpResponseMessage("error_description", error);

            if (errorMessage)
              this.alertService.showStickyMessage("Unable to login", errorMessage, MessageSeverity.error, error);
            else
              this.alertService.showStickyMessage("Unable to login", "An error occured whilst logging in, please try again later.\nError: " + Utilities.getResponseBody(error), MessageSeverity.error, error);
          }

          setTimeout(() => {
            this.isLoading = false;
          }, 500);
        });
  }


  offerAlternateHost() {

    if (Utilities.checkIsLocalHost(location.origin) && Utilities.checkIsLocalHost(this.configurations.baseUrl)) {
      this.alertService.showDialog("Dear Developer!\nIt appears your backend Web API service is not running...\n" +
        "Would you want to temporarily switch to the online Demo API below?(Or specify another)",
        DialogType.prompt,
        (value: string) => {
          this.configurations.baseUrl = value;
          this.alertService.showStickyMessage("API Changed!", "The target Web API has been changed to: " + value, MessageSeverity.warn);
        },
        null,
        null,
        null,
        this.configurations.fallbackBaseUrl);
    }
  }


  reset() {
    this.formResetToggle = false;

    setTimeout(() => {
      this.formResetToggle = true;
    });
  }
}



