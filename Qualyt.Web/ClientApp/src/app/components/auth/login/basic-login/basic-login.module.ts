import { NgModule } from '@angular/core';
import { BasicLoginComponent } from './basic-login.component';
import {BasicLoginRoutingModule} from './basic-login-routing.module';
import { LoginModule } from '../login.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';




@NgModule({
  imports: [
    BasicLoginRoutingModule,
    BrowserModule,
    CommonModule, FormsModule, ReactiveFormsModule, RouterModule
  ],
  declarations: [BasicLoginComponent]
})
export class BasicLoginModule { }
