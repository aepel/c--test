import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LaboratoriesRoutingModule } from './laboratories-routing.module';
import { LaboratoriesListComponent } from './laboratories-list/laboratories-list.component';
import { LaboratoriesDetailComponent } from './laboratories-detail/laboratories-detail.component';
import { DatatableModule } from '../datatable/datatable.module';
import { SharedModule } from '../../shared/shared.module';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule, MatInputModule } from '@angular/material';
import { LaboratoriesService } from '../../services/laboratories.service';
import { ColorPickerModule } from 'primeng/colorpicker';
import {FileUploadModule} from 'primeng/fileupload';
import { AuthenticationService } from '../../services/authentication.service';

@NgModule({
  imports: [
    CommonModule,
    LaboratoriesRoutingModule,
    DatatableModule,
    SharedModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    ColorPickerModule,
    FileUploadModule
  ],
  declarations: [LaboratoriesListComponent, LaboratoriesDetailComponent],
  exports: [LaboratoriesListComponent, LaboratoriesDetailComponent],
  providers:
    [
      LaboratoriesService,
      AuthenticationService
    ]
})
export class LaboratoriesModule { }
