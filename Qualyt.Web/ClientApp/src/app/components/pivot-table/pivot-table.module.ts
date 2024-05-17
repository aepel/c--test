import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PivotTableComponent } from './pivot-table/pivot-table.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [PivotTableComponent],
  exports: [PivotTableComponent]
})
export class PivotTableModule { }
