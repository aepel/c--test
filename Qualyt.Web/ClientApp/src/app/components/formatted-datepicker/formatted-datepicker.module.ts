import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormattedDatepickerComponent } from './formatted-datepicker/formatted-datepicker.component';
import { MatDatepickerModule, MatFormFieldModule, MatInputModule } from '@angular/material';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule
  ],
  declarations: [FormattedDatepickerComponent],
  exports: [FormattedDatepickerComponent]
})
export class FormattedDatepickerModule { }
