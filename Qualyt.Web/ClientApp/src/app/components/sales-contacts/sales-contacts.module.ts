import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SalesContactsRoutingModule } from './sales-contacts-routing.module';
import { SalesContactsListComponent } from './sales-contacts-list/sales-contacts-list.component';
import { SalesContactsDetailComponent } from './sales-contacts-detail/sales-contacts-detail.component';
import { SalesContactsService } from '../../services/sales-contacts.service';
import { AlertService } from '../../services/alert.service';
import { DatatableModule } from '../datatable/datatable.module';
import { SharedModule } from '../../shared/shared.module';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule, MatInputModule } from '@angular/material';

@NgModule({
  imports: [
    CommonModule,
    SalesContactsRoutingModule,
    DatatableModule,
    SharedModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule
  ],
  declarations: [SalesContactsListComponent, SalesContactsDetailComponent],
  exports: [SalesContactsListComponent, SalesContactsDetailComponent],
  providers: [SalesContactsService]
})
export class SalesContactsModule { }
