import { NgModule } from '@angular/core';
import {LoginRoutingModule} from './login-routing.module';
import { ForgotModule } from '../forgot/forgot.module';
import { AuthModule } from '../auth.module';
import { AppModule } from '../../../app.module';
import { BasicLoginModule } from './basic-login/basic-login.module';
import { ResetPaswwordModule } from './reset-paswword/reset-paswword.module';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';




@NgModule({
  imports: [
    BrowserModule,
    LoginRoutingModule,
    ForgotModule,
    CommonModule,
    RouterModule,
    BasicLoginModule,
    ResetPaswwordModule
    ,  FormsModule, ReactiveFormsModule
  ],
  
  declarations: [],
  
})
export class LoginModule { }
