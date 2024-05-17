import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MultidropdownWithFilterComponent } from './multidropdown-with-filter/multidropdown-with-filter.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MultiSelectModule } from 'primeng/multiselect';

@NgModule({
  imports: [
    CommonModule,
    MultiSelectModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [MultidropdownWithFilterComponent],
  exports: [MultidropdownWithFilterComponent]
})
export class MultidropdownWithFilterModule { }
