import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ResetPaswwordComponent } from './reset-paswword.component';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';





@NgModule({
  imports: [
    CommonModule, RouterModule,
    FormsModule,
    ReactiveFormsModule
    
  ],
  declarations: [ResetPaswwordComponent]
})
export class ResetPaswwordModule { }
