import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InfoTreatmentComponent } from './info-treatment/info-treatment.component';
import { PatientsService } from '../../services/patients.service';
import { SharedModule } from '../../shared/shared.module';
import { TreatmentsService } from '../../services/treatments.service';

@NgModule({
  imports: [
    CommonModule,
    SharedModule
  ],
  declarations: [InfoTreatmentComponent],
  exports: [InfoTreatmentComponent],
  providers: [PatientsService, TreatmentsService]
})
export class InfoTreatmentModule { }
