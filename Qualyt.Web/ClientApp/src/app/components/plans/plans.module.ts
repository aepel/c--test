import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PlansRoutingModule } from './plans-routing.module';
import { PlansDetailComponent } from './plans-detail/plans-detail.component';
import { PlansListComponent } from './plans-list/plans-list.component';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule, MatInputModule } from '@angular/material';
import { DropdownWithFilterModule } from '../dropdown-with-filter/dropdown-with-filter.module';
import { SharedModule } from '../../shared/shared.module';
import { DatatableModule } from '../datatable/datatable.module';
import { PlansService } from '../../services/plans.service';
import { CountriesService } from '../../services/countries.service';
import { LaboratoriesService } from '../../services/laboratories.service';
import { ProductsService } from '../../services/products.service';
import { MultidropdownWithFilterModule } from '../multidropdown-with-filter/multidropdown-with-filter.module';
import { PathologiesService } from '../../services/pathologies.service';
import { DatetimePickerModule } from '../datetime-picker/datetime-picker.module';
import { FormattedDatepickerModule } from '../formatted-datepicker/formatted-datepicker.module';
import { PlanCardModule } from '../plan-card/plan-card.module';

@NgModule({
  imports: [
    CommonModule,
    PlansRoutingModule,
    FormsModule,
    MatFormFieldModule,
    DropdownWithFilterModule,
    MultidropdownWithFilterModule,
    SharedModule,
    DatatableModule,
    MatInputModule,
    DatetimePickerModule,
    FormattedDatepickerModule,
    PlanCardModule
  ],
  declarations: [PlansDetailComponent, PlansListComponent],
  providers: [
    PlansService,
    CountriesService,
    LaboratoriesService,
    ProductsService,
    PathologiesService
  ]
})
export class PlansModule { }
