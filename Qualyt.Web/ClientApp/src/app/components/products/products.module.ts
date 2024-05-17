import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductsRoutingModule } from './products-routing.module';
import { ProductsDetailComponent } from './products-detail/products-detail.component';
import { ProductsListComponent } from './products-list/products-list.component';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule, MatInputModule } from '@angular/material';
import { DropdownWithFilterModule } from '../dropdown-with-filter/dropdown-with-filter.module';
import { FieldsManagerModule } from '../fields-manager/fields-manager.module';
import { DatatableModule } from '../datatable/datatable.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { ProductsService } from 'src/app/services/products.service';
import { LaboratoriesModule } from '../laboratories/laboratories.module';
import { LaboratoriesService } from 'src/app/services/laboratories.service';

@NgModule({
  imports: [
    CommonModule,
    ProductsRoutingModule,
    FormsModule,
    MatFormFieldModule,
    DropdownWithFilterModule,
    FieldsManagerModule,
    DatatableModule,
    SharedModule,
    MatInputModule
  ],
  providers: [
    ProductsService,
    LaboratoriesService
  ],
  declarations: [ProductsDetailComponent, ProductsListComponent]
})
export class ProductsModule { }
