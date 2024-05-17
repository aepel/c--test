
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { forgotComponent } from './forgot.component';
import {ForgotRoutingModule} from './forgot-routing.module';
import {SharedModule} from '../../../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    ForgotRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [forgotComponent]
})
export class ForgotModule { }
