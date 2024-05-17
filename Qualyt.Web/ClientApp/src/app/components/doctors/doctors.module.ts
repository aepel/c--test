import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DoctorsRoutingModule } from './doctors-routing.module';
import { DoctorsDetailComponent } from './doctors-detail/doctors-detail.component';
import { DoctorsListComponent } from './doctors-list/doctors-list.component';
import { DoctorsService } from '../../services/doctors.service';
import { CountriesService } from '../../services/countries.service';
import { SalesContactsService } from '../../services/sales-contacts.service';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule, MatSelectModule, MatInputModule } from '@angular/material';
import { DatatableModule } from '../datatable/datatable.module';
import { SharedModule } from '../../shared/shared.module';
import { AttentionPlacesService } from '../../services/attention-places.service';
import { DoctorSpecialtiesService } from '../../services/doctor-specialties.service';
import { DropdownWithFilterModule } from '../dropdown-with-filter/dropdown-with-filter.module';
import { GooglePlaceModule } from 'ngx-google-places-autocomplete';



@NgModule({
  imports: [
    CommonModule,
    DoctorsRoutingModule,
    FormsModule,
    MatFormFieldModule,
    MatSelectModule,
    DatatableModule,
    SharedModule,
    MatInputModule,
    DropdownWithFilterModule,
GooglePlaceModule
  ],
  declarations: [DoctorsDetailComponent, DoctorsListComponent],
  exports: [DoctorsDetailComponent, DoctorsListComponent],
  providers:
    [
      DoctorsService,
      SalesContactsService,
      AttentionPlacesService,
      DoctorSpecialtiesService,
      CountriesService
    ]
})
export class DoctorsModule { }
