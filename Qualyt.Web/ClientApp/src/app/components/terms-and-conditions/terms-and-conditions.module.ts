import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TermsAndConditionsListComponent } from './terms-and-conditions-list/terms-and-conditions-list.component';
import { TermsAndConditionsDetailComponent } from './terms-and-conditions-detail/terms-and-conditions-detail.component';
import { SharedModule } from '../../shared/shared.module';
import { AlertService } from '../../services/alert.service';
import { TermsAndConditionsService } from '../../services/terms-and-conditions.service';
import { TermsAndConditionsRoutingModule } from './terms-and-conditions-routing.module';
import { HttpModule } from '@angular/http';
import { TokenStorage } from '../../auth/token-storage.service';
import { UtilsService } from '../../services/utils.service';
import { DatatableModule } from '../datatable/datatable.module';
import { FormsModule } from '@angular/forms';
import { QuillModule } from 'ngx-quill'
import { MatButtonModule, MatFormFieldModule, MatInputModule } from '@angular/material';
import { AuthenticationService } from '../../services/authentication.service';
import { TermsAndConditionsAcceptanceComponent } from './terms-and-conditions-acceptance/terms-and-conditions-acceptance.component';
import { PatientsService } from '../../services/patients.service';



@NgModule({
  imports: [
    CommonModule,
    TermsAndConditionsRoutingModule,
    SharedModule,
    DatatableModule,
    HttpModule,
    FormsModule,
    QuillModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule
  ],
  declarations: [TermsAndConditionsListComponent, TermsAndConditionsDetailComponent, TermsAndConditionsAcceptanceComponent],
  providers:
[
TermsAndConditionsService,
AuthenticationService,
TokenStorage,
      UtilsService,
      PatientsService
]
})
export class TermsAndConditionsModule { }
