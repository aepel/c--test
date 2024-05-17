import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard.component';
import {DashboardRoutingModule} from './dashboard-routing.module';
import {SharedModule} from '../../shared/shared.module';
import { GeocodingModule } from '../geocoding/geocoding.module';
import { ChartModule } from 'angular2-chartjs';
import {FilesManagerModule} from '../files-manager/files-manager.module';
import { PatientsService } from '../../services/patients.service';
import { PathologiesService } from '../../services/pathologies.service';
import { TreatmentsService } from '../../services/treatments.service';
import { DoctorsService } from '../../services/doctors.service';
import { PlansService } from '../../services/plans.service';
import { PivotTableModule } from '../pivot-table/pivot-table.module';
import { PlanCardModule } from '../plan-card/plan-card.module';
import { FormattedDatepickerModule } from '../formatted-datepicker/formatted-datepicker.module';
import { MultidropdownWithFilterModule } from '../multidropdown-with-filter/multidropdown-with-filter.module';
import { FormsModule } from '@angular/forms';
import { PlansByUserResolver } from 'src/app/resolvers/plans-by-user.resolver';

@NgModule({
  imports: [
    CommonModule,
    GeocodingModule,
    ChartModule,
    DashboardRoutingModule,
    SharedModule,
    FilesManagerModule,
    PivotTableModule,
    PlanCardModule,
    FormattedDatepickerModule,
    MultidropdownWithFilterModule,
    FormsModule
  ],
  declarations: [DashboardComponent],
  providers:
    [
      PatientsService,
      PathologiesService,
      TreatmentsService,
      DoctorsService,
      PlansService,
      PlansByUserResolver
    ]
})
export class DashboardModule { }
