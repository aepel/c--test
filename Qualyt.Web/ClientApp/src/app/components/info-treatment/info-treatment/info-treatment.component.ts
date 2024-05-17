import { Component, OnInit, Input } from '@angular/core';
import { PatientsService } from '../../../services/patients.service';
import { Treatment } from '../../../models/treatment.model';
import { Patient } from '../../../models/patient.model';
import { TreatmentsService } from '../../../services/treatments.service';

@Component({
  selector: 'app-info-treatment',
  templateUrl: './info-treatment.component.html',
  styleUrls: ['./info-treatment.component.scss']
})
export class InfoTreatmentComponent implements OnInit {

  @Input() treatmentId: number;
  @Input() patientId: number;
  @Input() isLaboratory: boolean;

  public patient: Patient;
  public treatment: Treatment;
  public patientFullName: string;
  public patientTelephoneNumber: string;
  public patientEmail: string;
  public treatmentDoctor: string;
  public treatmentProduct: string;
  public lastTreatment: string;
  public dailyDose: string;

  constructor(private treatmentsService: TreatmentsService,
    private patientsService: PatientsService) { }

  ngOnInit() {
    this.loadInfo();
  }

  update(){
    this.loadInfo();
  }

  loadInfo(){
    if (this.treatmentId) {
      this.treatmentsService.getOne(this.treatmentId).subscribe(x => {
        let treatment = x as Treatment;
        this.treatment = treatment;
        let patient = (x as Treatment).patient;
        this.patient = patient;
        this.patientFullName = patient.fullName;
        this.patientTelephoneNumber = patient.cellPhoneNumber;
        this.patientEmail = patient.email;
        this.treatmentDoctor = treatment.doctor.fullName;
        this.treatmentProduct = treatment.product.name;
      });
    }
    else if (this.patientId) {
      this.patientsService.getOne(this.patientId).subscribe(x => {
        let patient = x as Patient;
        this.patientFullName = patient.fullName;
        this.patientTelephoneNumber = patient.cellPhoneNumber;
        this.patientEmail = patient.email;
      });
    }
  }

}
