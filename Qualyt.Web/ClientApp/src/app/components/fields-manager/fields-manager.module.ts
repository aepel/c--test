import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FieldsManagerComponent } from './fields-manager/fields-manager.component';
import { FormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material';
import { SharedModule } from '../../shared/shared.module';
import { DropdownWithFilterModule } from '../dropdown-with-filter/dropdown-with-filter.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    MatTableModule,
    SharedModule,
    DropdownWithFilterModule
  ],
  declarations: [FieldsManagerComponent],
  exports: [FieldsManagerComponent]
})
export class FieldsManagerModule { }
