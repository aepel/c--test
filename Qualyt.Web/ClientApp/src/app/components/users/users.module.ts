import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersRoutingModule } from './users-routing.module';
import { UsersDetailComponent } from './users-detail/users-detail.component';
import { UsersListComponent } from './users-list/users-list.component';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule, MatCheckboxModule, MatSelectModule, MatInputModule } from '@angular/material';
import { DropdownWithFilterModule } from '../dropdown-with-filter/dropdown-with-filter.module';
import { MultidropdownWithFilterModule } from '../multidropdown-with-filter/multidropdown-with-filter.module';
import { DatatableModule } from '../datatable/datatable.module';
import { UsersService } from 'src/app/services/users.service';
import { CountriesService } from 'src/app/services/countries.service';
import { PlansService } from 'src/app/services/plans.service';
import { LaboratoriesService } from 'src/app/services/laboratories.service';

@NgModule({
  imports: [
    CommonModule,
    UsersRoutingModule,
    FormsModule,
    MatFormFieldModule,
    MatCheckboxModule,
    MatSelectModule,
    DropdownWithFilterModule,
    MultidropdownWithFilterModule,
    DatatableModule,
    MatInputModule
  ],
  declarations: [UsersDetailComponent, UsersListComponent],
  providers:
    [
      UsersService,
      CountriesService,
      PlansService,
      LaboratoriesService
    ]
})
export class UsersModule { }
