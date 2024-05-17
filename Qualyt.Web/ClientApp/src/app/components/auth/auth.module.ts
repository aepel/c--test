import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {AuthRoutingModule} from './auth-routing.module';
import { SharedModule } from '../../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AlertService } from '../../services/alert.service';
import { AuthenticationService } from '../../services/authentication.service';
import { ConfigurationService } from '../../services/configuration.service';
import { LocalStoreManager } from '../../services/local-store-manager.service';
import { LoginModule } from './login/login.module';
import { RouterModule } from '@angular/router';


@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    AuthRoutingModule,
    SharedModule,
    LoginModule,
    ReactiveFormsModule
  ],
  providers: [AlertService, AuthenticationService, ConfigurationService, LocalStoreManager],
  declarations: []
  
})
export class AuthModule { }
