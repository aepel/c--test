import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DatetimePickerComponent } from './datetime-picker/datetime-picker.component';
import {CalendarModule} from 'primeng/calendar';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    CalendarModule,
    FormsModule
  ],
  declarations: [DatetimePickerComponent],
  exports: [DatetimePickerComponent]
})
export class DatetimePickerModule { }
