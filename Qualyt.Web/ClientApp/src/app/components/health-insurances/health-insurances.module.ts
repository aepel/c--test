import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HealthInsurancesRoutingModule } from './health-insurances-routing.module';
import { HealthInsurancesListComponent } from './health-insurances-list/health-insurances-list.component';
import { HealthInsurancesService } from '../../services/health-insurance.service';
import { HealthInsurancesDetailComponent } from './health-insurances-detail/health-insurances-detail.component';
import { DatatableModule } from '../datatable/datatable.module';
import { FieldsManagerModule } from '../fields-manager/fields-manager.module';
import { SharedModule } from '../../shared/shared.module';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule, MatSelectModule, MatInputModule } from '@angular/material';
import { CountriesService } from '../../services/countries.service';
import { DropdownWithFilterModule } from '../dropdown-with-filter/dropdown-with-filter.module';

@NgModule({
  imports: [
    CommonModule,
    HealthInsurancesRoutingModule,
    DatatableModule,
    SharedModule,
    HttpModule,
    FormsModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    FieldsManagerModule,
    DropdownWithFilterModule
  ],
  providers:
  [
      HealthInsurancesService,
      CountriesService
  ],
  declarations: [HealthInsurancesListComponent, HealthInsurancesDetailComponent],
  exports: [HealthInsurancesListComponent, HealthInsurancesDetailComponent]
})
export class HealthInsurancesModule { }
