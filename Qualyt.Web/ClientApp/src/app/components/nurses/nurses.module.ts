import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NursesRoutingModule } from './nurses-routing.module';
import { NursesDetailComponent } from './nurses-detail/nurses-detail.component';
import { NursesListComponent } from './nurses-list/nurses-list.component';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule, MatInputModule } from '@angular/material';
import { DatatableModule } from '../datatable/datatable.module';
import { SharedModule } from '../../shared/shared.module';
import { NursesService } from '../../services/nurses.service';
import { CountriesService } from '../../services/countries.service';
import { DropdownWithFilterModule } from '../dropdown-with-filter/dropdown-with-filter.module';

@NgModule({
  imports: [
    CommonModule,
    NursesRoutingModule,
    FormsModule,
    MatFormFieldModule,
    DatatableModule,
    SharedModule,
    MatInputModule,
    DropdownWithFilterModule
  ],
  providers: [NursesService, CountriesService],
  declarations: [NursesDetailComponent, NursesListComponent],
  exports: [NursesDetailComponent, NursesListComponent]
})
export class NursesModule { }
