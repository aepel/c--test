import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PathologiesRoutingModule } from './pathologies-routing.module';
import { PathologiesDetailComponent } from './pathologies-detail/pathologies-detail.component';
import { PathologiesListComponent } from './pathologies-list/pathologies-list.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatFormFieldModule } from '@angular/material/form-field';
import { DatatableModule } from '../datatable/datatable.module';
import { PathologiesService } from '../../services/pathologies.service';
import { Http, HttpModule } from '@angular/http';
import { TokenStorage } from '../../auth/token-storage.service';
import { UtilsService } from '../../services/utils.service';
import { AuthenticationService } from '../../services/authentication.service';
import { SharedModule } from '../../shared/shared.module';
import { FormsModule } from '@angular/forms';
import { MatSelectModule, MatInputModule } from '@angular/material';
import { LaboratoriesService } from '../../services/laboratories.service';
import { FieldsManagerModule } from '../fields-manager/fields-manager.module';
import { DropdownWithFilterModule } from '../dropdown-with-filter/dropdown-with-filter.module';

@NgModule({
  imports: [
    CommonModule,
    PathologiesRoutingModule,
    DatatableModule,
    HttpModule,
    SharedModule,
    FormsModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    FieldsManagerModule,
    DropdownWithFilterModule
  ],
  declarations: [PathologiesDetailComponent, PathologiesListComponent],
  providers:
    [
      PathologiesService,
      AuthenticationService,
      TokenStorage,
      UtilsService,
      LaboratoriesService
    ]
})
export class PathologiesModule { }


