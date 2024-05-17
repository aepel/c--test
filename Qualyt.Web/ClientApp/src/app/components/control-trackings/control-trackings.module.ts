import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DatatableModule } from '../datatable/datatable.module';
import { PathologiesService } from '../../services/pathologies.service';
import { Http, HttpModule } from '@angular/http';
import { TokenStorage } from '../../auth/token-storage.service';
import { UtilsService } from '../../services/utils.service';
import { ControlTrackingsRoutingModule } from './control-trackings-routing.module';
import { ControlTrackingsListComponent } from './control-trackings-list/control-trackings-list.component';
import { ControlTrackingsDetailComponent } from './control-trackings-detail/control-trackings-detail.component';
import { ControlTrackingsService } from '../../services/control-trackings.service';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule, MatInputModule, MatSelectModule } from '@angular/material';
import { FormattedDatepickerModule } from '../formatted-datepicker/formatted-datepicker.module';
import { AlertService } from '../../services/alert.service';
import { SharedModule } from '../../shared/shared.module';
import { TreatmentsService } from '../../services/treatments.service';
import { AuthenticationService } from '../../services/authentication.service';
import { InfoTreatmentModule } from '../info-treatment/info-treatment.module';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import { MatTooltipModule } from '@angular/material/tooltip';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { AppModule } from '../../app.module';
import { NotificationsUpdater } from '../../interfaces/notifications-updater.interface';

@NgModule({
  imports: [
    CommonModule,
    ControlTrackingsRoutingModule,
    DatatableModule,
    HttpModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    FormattedDatepickerModule,
    SharedModule,
    InfoTreatmentModule,
    MatSlideToggleModule,
    MatTooltipModule,
    MatButtonModule,
    MatIconModule,
    MatCheckboxModule
  ],
  declarations: [ControlTrackingsListComponent, ControlTrackingsDetailComponent],
  providers:
    [
      ControlTrackingsService,
      AuthenticationService,
      TokenStorage,
      UtilsService,
      TreatmentsService
    ]
})
export class ControlTrackingsModule { }

