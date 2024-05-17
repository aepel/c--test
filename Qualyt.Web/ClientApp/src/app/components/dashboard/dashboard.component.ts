import {Component, OnInit, ViewChild} from '@angular/core';

import { Router, ActivatedRoute } from '@angular/router';
import { Address } from 'ngx-google-places-autocomplete/objects/address';
import * as moment from 'moment'
declare const AmCharts: any;

interface IData {
  a: string;
  b: string;
  c: string;
  d: number;
}

import '../../../assets/charts/amchart/amcharts.js';
import '../../../assets/charts/amchart/gauge.js';
import '../../../assets/charts/amchart/pie.js';
import '../../../assets/charts/amchart/serial.js';
import '../../../assets/charts/amchart/light.js';
import '../../../assets/charts/amchart/ammap.js';
import '../../../assets/charts/amchart/worldLow.js';
import '../../../assets/charts/amchart/continentsLow.js';
import 'd3';
import { PatientsService } from '../../services/patients.service';
import { DoctorsService } from '../../services/doctors.service';
import { TreatmentsService } from '../../services/treatments.service';
import { PathologiesService } from '../../services/pathologies.service';
import { NgxRolesService } from 'ngx-permissions';
import { PlansService } from '../../services/plans.service';
import { Moment } from 'moment/moment';
import { Plan } from '../../models/plan.model';
import { DashboardFilter } from '../../models/dashboard-filter.model';
import { PivotTableData } from 'src/app/models/pivot-table-data.model.js';
@Component({
  selector: 'dashboard-page',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss',
  ],

})

export class DashboardComponent implements OnInit {
  filter: DashboardFilter;
  treatmentsCount: number;
  treatmentsCountLastMonth: number;
  doctorsCount: number;
  doctorsCountLastMonth: number;
  pathologiesCount: number;
  pathologiesCountLastMonth: number;
  patientsCount: number;
  patientsCountLastMonth: number;
  isLaboratory: boolean;
  isAdmin: boolean;
  isOperator: boolean;
  amountCardData: any;
  amountCardOption: any;
  plans: Plan[];
  selectedPlans: Plan[];
  pivotTableData: PivotTableData[];
  

  constructor(
    private route: ActivatedRoute,
    private patientService: PatientsService,
    private doctorsService: DoctorsService,
    private treatmentsService: TreatmentsService,
    private pathologiesService: PathologiesService,
    private plansService: PlansService,
    private rolesService: NgxRolesService,
    private router: Router) { }

  
  public handleAddressChange(address: Address) {
    alert(address);
  }

  createPatient(id) {
    this.router.navigate(['/patients/detail'], { queryParams: { planId: id } });
  }

  setLastMonthStats() {
    this.treatmentsService.getCountLastMonth(this.filter).subscribe(x => this.treatmentsCountLastMonth = x);
    this.pathologiesService.getCountLastMonth(this.filter).subscribe(x => this.pathologiesCountLastMonth = x);
    this.patientService.getCountLastMonth(this.filter).subscribe(x => this.patientsCountLastMonth = x);
    this.doctorsService.getCountLastMonth(this.filter).subscribe(x => this.doctorsCountLastMonth = x);
  }

  setFilteredStats() {
    this.treatmentsService.getCount(this.filter).subscribe(x => this.treatmentsCount = x);
    this.pathologiesService.getCount(this.filter).subscribe(x => this.pathologiesCount = x);
    this.patientService.getCount(this.filter).subscribe(x => this.patientsCount = x);
    this.doctorsService.getCount(this.filter).subscribe(x => this.doctorsCount = x);
  }

  setPivotTableData() {
    this.plansService.getPivotTableData(this.filter).subscribe(x => {
      this.pivotTableData = x as PivotTableData[];
    });
  }

  clearCardValues() {
    this.treatmentsCountLastMonth = undefined;
    this.pathologiesCountLastMonth = undefined;
    this.patientsCountLastMonth = undefined;
    this.doctorsCountLastMonth = undefined;
    this.treatmentsCount = undefined;
    this.pathologiesCount = undefined;
    this.patientsCount = undefined;
    this.doctorsCount = undefined;
    this.pivotTableData = undefined;
  }

  onSubmit() {
    this.filter.selectedPlanIds=this.selectedPlans.map(x=>x.id);
    this.clearCardValues();
    this.setLastMonthStats();
    this.setFilteredStats();
    this.setPivotTableData();
  }

  ngOnInit(): void {
    this.filter = new DashboardFilter();
    this.filter.start=moment().subtract(3, 'months');
    this.filter.end=moment();
    this.plans = this.route.snapshot.data.plans as Plan[];
    this.selectedPlans = this.plans;
    this.rolesService.hasOnlyRoles("LABORATORIO").then(x => {
      this.isLaboratory = x;
      if (this.isLaboratory) {
        this.onSubmit();
      }
    });
    this.rolesService.hasOnlyRoles("ADMIN").then(x => {
      this.isAdmin = x;
      if (this.isAdmin) {
        this.onSubmit();
      }
    });
    this.rolesService.hasOnlyRoles("OPERADOR").then(x => {
      this.isOperator = x;
    });
  }

}
