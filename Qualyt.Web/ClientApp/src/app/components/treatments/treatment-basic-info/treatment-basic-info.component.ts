import { Component, OnInit, Input, Output, EventEmitter, OnChanges } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Treatment } from '../../../models/treatment.model';
import { DoctorsService } from '../../../services/doctors.service';
import { Doctor } from '../../../models/doctor.model';
import { MatSelectChange, MatSelect } from '@angular/material';
import { PlansService } from '../../../services/plans.service';
import { PatientsService } from '../../../services/patients.service';
import { Patient } from '../../../models/patient.model';
import { PathologiesService } from '../../../services/pathologies.service';
import { Pathology } from '../../../models/pathology.model';
import { Product } from '../../../models/product.model';
import { Plan } from '../../../models/plan.model';
import { ProductsService } from '../../../services/products.service';
import { AlertService, MessageSeverity } from '../../../services/alert.service';

@Component({
  selector: 'app-treatment-basic-info',
  templateUrl: './treatment-basic-info.component.html',
  styleUrls: ['./treatment-basic-info.component.scss']
})
export class TreatmentBasicInfoComponent implements OnInit, OnChanges {

  @Input() treatment: Treatment;
  @Input() form: any;
  @Input() readonly: boolean;
  @Input() isLaboratory: boolean;
  @Input() planId: number;
  @Output() pathologySelectedEvent: EventEmitter<Pathology> = new EventEmitter();
  doctors: Doctor[];
  patients: Patient[];
  pathologies: Pathology[];
  products: Product[];


  constructor(private doctorsService: DoctorsService,
    private patientsService: PatientsService,
    private pathologiesService: PathologiesService,
    private plansService: PlansService,
    private productsService: ProductsService,
    private alertService: AlertService) { }

  ngOnInit() {}

  ngOnChanges() {
    this.doctorsService.getAll().subscribe(x =>
      this.doctors = x as Doctor[]
    );
    if(this.planId){
      this.plansService.getOne(this.planId).subscribe(x=>{
        let arr = [];
        for(let planProduct of (x as Plan).planProducts) {
          arr.push(planProduct.product);
        }
        this.products = arr;
      });
    }
    else{
      this.productsService.getAll().subscribe(x =>
        this.products = x as Product[]
      );
    }
    if (this.treatment.doctor)
      this.doctorSelected(this.treatment.doctor,this.treatment.patient!=undefined);
    if (this.treatment.patient)
      this.patientSelected(this.treatment.patient);
  }

  doctorSelected(selected: Doctor, patientSetted:boolean=false) {
    this.patientsService.getByDoctor(selected.id).subscribe(x => {
      if (x.length || patientSetted){
        if(patientSetted)
          x.push(this.treatment.patient);
        this.patients = x as Patient[];
      }
      else {
        this.patients = undefined;
        this.alertService.showMessage("Tratamientos", "Este médico no tiene pacientes asociados.", MessageSeverity.warn);
      }
    });
  }

  patientSelected(selected: Patient) {
    this.pathologiesService.getByPatient(selected.id).subscribe(x => {
      if (x.length)
        this.pathologies = x as Pathology[];
      else {
        this.pathologies = undefined;
        this.alertService.showMessage("Tratamientos", "Este paciente no tiene patologías asociadas.", MessageSeverity.warn);
      }
    });
  }

  pathologySelected(selected: Pathology) {
    this.pathologiesService.getOne(selected.id).subscribe(x => {
        this.treatment.pathologyFields = (x as Pathology).fields;
    });
  }

  productSelected(selected: Product) {
    this.productsService.getOne(selected.id).subscribe(x => {
      
        this.treatment.productFields = (x as Product).fields;
    });
  }

}
