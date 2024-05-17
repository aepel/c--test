import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatFormFieldModule } from '@angular/material/form-field';
import { DatatableModule } from '../datatable/datatable.module';
import { PathologiesService } from '../../services/pathologies.service';
import { Http, HttpModule } from '@angular/http';
import { TokenStorage } from '../../auth/token-storage.service';
import { UtilsService } from '../../services/utils.service';
import { TreatmentsService } from '../../services/treatments.service';
import { TreatmentsDetailComponent } from './treatments-detail/treatments-detail.component';
import { TreatmentsListComponent } from './treatments-list/treatments-list.component';
import { TreatmentsRoutingModule } from './treatments-routing.module';
import { MatStepperModule } from '@angular/material/stepper';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule, MatButtonModule, MatSelectModule } from '@angular/material';
import { TreatmentBasicInfoComponent } from './treatment-basic-info/treatment-basic-info.component';
import { FormsModule } from '@angular/forms';
import { DoctorsService } from '../../services/doctors.service';
import { PatientsService } from '../../services/patients.service';
import { PlansService } from '../../services/plans.service';
import { ProductsService } from '../../services/products.service';
import { FieldsRenderModule } from '../fields-render/fields-render.module';
import { AlertService } from '../../services/alert.service';
import { SharedModule } from '../../shared/shared.module';
import { AuthenticationService } from '../../services/authentication.service';
import { DropdownWithFilterModule } from '../dropdown-with-filter/dropdown-with-filter.module';
import { InfoTreatmentModule } from '../info-treatment/info-treatment.module';
import { TreatmentSummaryComponent } from './treatment-summary/treatment-summary.component';

@NgModule({
  imports: [
    CommonModule,
    TreatmentsRoutingModule,
    DatatableModule,
    HttpModule,
    MatStepperModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    FormsModule,
    MatSelectModule,
    FieldsRenderModule,
    SharedModule,
    DropdownWithFilterModule,
    InfoTreatmentModule
  ],
  declarations: [TreatmentsDetailComponent, TreatmentsListComponent, TreatmentBasicInfoComponent, TreatmentSummaryComponent],
  providers:
    [
      TreatmentsService,
      AuthenticationService,
      TokenStorage,
      UtilsService,
      DoctorsService,
      PatientsService,
      PathologiesService,
      PlansService,
      ProductsService
    ]
})
export class TreatmentsModule { }
