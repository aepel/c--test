import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DropdownWithFilterComponent } from './dropdown-with-filter/dropdown-with-filter.component';
import {DropdownModule} from 'primeng/dropdown';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    DropdownModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [DropdownWithFilterComponent],
  exports: [DropdownWithFilterComponent]
})
export class DropdownWithFilterModule { }
