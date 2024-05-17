import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DatatableComponent } from './datatable/datatable.component';
import { RouterModule } from '@angular/router';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatInputModule } from '@angular/material/input';
import { SharedModule } from '../../shared/shared.module';
import { MatTooltipModule } from '@angular/material/tooltip';



@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    MatFormFieldModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatInputModule,
    SharedModule,
    MatTooltipModule
  ],
  declarations: [DatatableComponent],
  exports: [DatatableComponent]
})
export class DatatableModule { }
