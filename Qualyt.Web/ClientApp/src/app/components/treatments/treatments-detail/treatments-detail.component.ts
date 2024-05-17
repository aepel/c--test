import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, NgForm, NgModelGroup } from '@angular/forms';
import { Treatment } from '../../../models/treatment.model';
import { Pathology } from '../../../models/pathology.model';
import { PathologiesService } from '../../../services/pathologies.service';
import { ProductsService } from '../../../services/products.service';
import { Product } from '../../../models/product.model';
import { TreatmentsService } from '../../../services/treatments.service';
import { Router, Route, ActivatedRoute } from '@angular/router';
import { AlertService, MessageSeverity } from '../../../services/alert.service';
import { PatientsService } from '../../../services/patients.service';
import { Patient } from '../../../models/patient.model';
import { NgxRolesService } from 'ngx-permissions';
import { Field } from '../../../models/field.model';
import { mergeAll } from 'rxjs-compat/operator/mergeAll';
import { TreatmentState } from '../../../models/enums.model';
import { animate } from '@angular/animations';

@Component({
  selector: 'app-treatments-detail',
  templateUrl: './treatments-detail.component.html',
  styleUrls: ['./treatments-detail.component.scss']
})
export class TreatmentsDetailComponent implements OnInit {
  @ViewChild("modal") modal: any;
  @ViewChild("form") form: NgForm;
  @ViewChild("firstFG") FFG: NgModelGroup;
  secondFormGroup: FormGroup;
  thirdFormGroup: FormGroup;
  treatment: Treatment;
  public TreatmentState:any = TreatmentState;
  lastStep = false;
  planId:number;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private _formBuilder: FormBuilder,
    private rolesService: NgxRolesService,
    private patientsService: PatientsService,
    private treatmentsService: TreatmentsService,
    private alertService: AlertService) { }



  doSearch(id: number): void {
    this.treatmentsService.getOne(id).subscribe(result => {
      this.treatment = result as Treatment;
      result=this.treatment.productFields.concat(this.treatment.product.fields);
      debugger
console.log(result);
      this.treatment["serializedPathologyFields"] = null;
      this.treatment["serializedProductFields"] = null;
      
      this.treatment.pathologyFields = this.mergeList(this.treatment.pathologyFields,this.treatment.pathology.fields);
      this.treatment.productFields = this.mergeList(this.treatment.productFields,this.treatment.product.fields);
      
    }
      , error => console.error(error)
    );
  }

  mergeList(lstTarget:Field[],lstSource:Field[]){
    return Array<Field>().concat(lstTarget,
    lstSource.map((x,i)=>{
      var element=lstTarget.find((y)=>y.parentId==x.parentId && y.name==x.name);
      if (!element){
        return x;
      }
    })).filter(x=>x!=undefined);
    
  }
  last() {
    this.lastStep = true;
  }

  setValuesByPatient(patientId: number): void {
    this.patientsService.getOne(patientId).subscribe(result => {
      this.treatment = new Treatment();
      this.treatment.patient = result as Patient;
      this.treatment.patientId = this.treatment.patient.id;
      this.treatment.doctor = this.treatment.patient.doctor;
      this.treatment.doctorId = this.treatment.patient.doctor.id;
      this.treatment.pathologyId = this.treatment.patient.patientPathologies[0].pathologyId;
       this.treatment.pathologyFields = this.treatment.patient.patientPathologies[0].pathology.fields;
      //this.treatment.pathology=this.treatment.patient.patientPathologies[0].pathology;
      this.treatment["serializedPathologyFields"] = null;
      this.treatment["serializedProductFields"] = null;
    }
      , error => console.error(error)
    );
  }

  ngOnInit() {

    this.route.queryParams.subscribe(params => {
      
      if (params['patientId'] && params['planId']){
        this.planId=params['planId'];

        this.setValuesByPatient(params['patientId']);
      }
      else if (params['id'])
        this.doSearch(params['id'])
      else {
        this.treatment = new Treatment();
      }
    });
    this.secondFormGroup = this._formBuilder.group([]);
    this.thirdFormGroup = this._formBuilder.group([]);
  }

  newControlTracking() {
    this.modal.hide();
    this.router.navigate(['/control-trackings/detail'], { queryParams: { treatmentId: this.treatment.id } });
  }

  cancel() {
    this.modal.hide();
    this.rolesService.hasOnlyRoles("OPERADOR").then(isOperator => {
      if (isOperator)
        this.router.navigate(['/dashboard']);
      else
        this.router.navigate(['/patients']);
    });
  }

  onSubmit() {
    if (this.treatment.id == null) {
      this.treatmentsService.insert(this.treatment).subscribe(
        result => {
          var createdTreatment = result as Treatment;
          this.alertService.showMessage("Tratamientos", "Actualización exitosa", MessageSeverity.success);
          this.treatment.id = createdTreatment.id;
          this.modal.show();
          }
        );
      }
    else {
      this.treatmentsService.update(this.treatment).subscribe(result => {
        this.alertService.showMessage("Tratamientos", "Actualización exitosa", MessageSeverity.success);
        this.router.navigate(['/treatments']);
      });
    }
  }
}
