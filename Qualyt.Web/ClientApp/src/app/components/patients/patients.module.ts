import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DialogModule } from 'primeng/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { DatatableModule } from '../datatable/datatable.module';
import { PathologiesService } from '../../services/pathologies.service';
import { HttpModule } from '@angular/http';
import { TokenStorage } from '../../auth/token-storage.service';
import { UtilsService } from '../../services/utils.service';
import { PatientsService } from '../../services/patients.service';
import { PatientsDetailComponent } from './patients-detail/patients-detail.component';
import { PatientsListComponent } from './patients-list/patients-list.component';
import { PatientsRoutingModule } from './patients-routing.module';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { FormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MatNativeDateModule, MatInputModule, MatCheckboxModule } from '@angular/material';
import { HealthInsurancesService } from '../../services/health-insurance.service';
import { DoctorsService } from '../../services/doctors.service';
import { FormattedDatepickerModule } from '../formatted-datepicker/formatted-datepicker.module';
import { CountriesService } from '../../services/countries.service';
import { MatSlideToggleModule} from '@angular/material/slide-toggle';
import { GooglePlaceModule } from 'ngx-google-places-autocomplete';
import { SharedModule } from '../../shared/shared.module';
import { AuthenticationService } from '../../services/authentication.service';
import { FilesManagerModule } from '../files-manager/files-manager.module';
import { FieldsRenderModule } from '../fields-render/fields-render.module';
import { NursesService } from '../../services/nurses.service';
import { PlansService } from '../../services/plans.service';
import { PatientsClinicalHistoryComponent } from './patients-clinical-history/patients-clinical-history.component';
import { CheckboxWithTextModule } from '../checkbox-with-text/checkbox-with-text.module';
import { DropdownWithFilterModule } from '../dropdown-with-filter/dropdown-with-filter.module';
import {ConfirmDialogModule} from 'primeng/confirmdialog';
import { ConfirmationService } from 'primeng/api';
import {DoctorsModule} from '../doctors/doctors.module';
import { NursesModule } from '../nurses/nurses.module';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import { PatientsDetailResolver } from '../../resolvers/patients-detail.resolver';
import { PathologiesResolver } from '../../resolvers/pathologies.resolver';
import { DoctorsResolver } from 'src/app/resolvers/doctors.resolver';
import { NursesResolver } from 'src/app/resolvers/nurses.resolver';
import { CountriesByUserResolver } from 'src/app/resolvers/countries-by-user.resolver';
import { HealthInsurancesResolver } from 'src/app/resolvers/health-insurances.resolver';

@NgModule({
  imports: [
    CommonModule,
    PatientsRoutingModule,
    DatatableModule,
    HttpModule,
    MatProgressSpinnerModule,
    GooglePlaceModule,
    FormsModule,
    SharedModule,
    MatFormFieldModule,
    MatSelectModule,
    MatNativeDateModule,
    MatInputModule,
    FormattedDatepickerModule,
    MatSlideToggleModule,
    FilesManagerModule,
    FieldsRenderModule,
    CheckboxWithTextModule,
    MatCheckboxModule,
    DropdownWithFilterModule,
    DoctorsModule,
    NursesModule,
    ConfirmDialogModule,
    DialogModule,
    MatIconModule,
    MatButtonModule,
  ],
  declarations: [PatientsDetailComponent, PatientsListComponent, PatientsClinicalHistoryComponent],
  providers:
    [
      PatientsService,
      AuthenticationService,
      TokenStorage,
      UtilsService,
      PathologiesService,
      DoctorsService,
      HealthInsurancesService,
      CountriesService,
      NursesService,
      PlansService,
      ConfirmationService,
      PatientsDetailResolver,
      PathologiesResolver,
      DoctorsResolver,
      NursesResolver,
      CountriesByUserResolver,
      HealthInsurancesResolver
    ]
})
export class PatientsModule { }


