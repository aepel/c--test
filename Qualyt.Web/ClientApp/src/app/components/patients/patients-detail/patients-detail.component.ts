import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Patient } from '../../../models/patient.model';
import { Pathology } from '../../../models/pathology.model';
import { HealthInsurance } from '../../../models/health-insurance.model';
import { Doctor } from '../../../models/doctor.model';
import { Plan } from '../../../models/plan.model';
import { ActivatedRoute, Router } from '@angular/router';
import { PatientsService } from '../../../services/patients.service';
import { PatientPathology } from '../../../models/patient-pathology.model';
import { PlansService } from '../../../services/plans.service';
import { Gender, EnumValDesc, MaritalStatus, ContactMethod } from '../../../models/enums.model';
import { Country } from '../../../models/country.model';
import { Address } from 'ngx-google-places-autocomplete/objects/address';
import { Location } from '../../../models/location.model';
import { AlertService, MessageSeverity } from '../../../services/alert.service';
import { Nurse } from '../../../models/nurse.model';


@Component({
  selector: 'app-patients-detail',
  templateUrl: './patients-detail.component.html',
  styleUrls: ['./patients-detail.component.scss'],

})
export class PatientsDetailComponent implements OnInit {

  http: Http;
  public patient?: Patient;
  submitted: boolean;
  isOperator: boolean;
  public pathologies: Pathology[]=[];
  public countries: Country[];
  public plans: Plan[];
  public plansAll: Plan[];
  public selectedCountry: Country;
  public selectedPlan: Plan;
  public healthInsurances: HealthInsurance[];
  public healthInsurancesAll: HealthInsurance[];
  public doctors: Doctor[];
  public nurses: Nurse[];
  public pathologiesSelected: number[] = [];
  public genders;
  public maritalStatuss;
  public contactMethods;
  display: boolean = false;
  displayEnfermera: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private pacienteService: PatientsService,
    private plansService: PlansService,
    private alertService: AlertService
  ) {
    this.router = router;
    this.submitted = false;
    this.patient = new Patient();
    this.genders = EnumValDesc(Gender);
    this.maritalStatuss = EnumValDesc(MaritalStatus);
    this.contactMethods = EnumValDesc(ContactMethod);
  }

  doSearch(): void {
    this.patient = this.route.snapshot.data.patient as Patient;
    this.setSelectedCountry(this.countries.find(x => x.id == this.patient.countryId));
    this.patient.patientPathologiesId = this.patient.patientPathologies[0].pathologyId;
  }

  listHealthInsurancesByCountryId(countryId: number) {
    this.healthInsurances = this.healthInsurancesAll.filter(x => x.countryId === countryId) as HealthInsurance[];
  }

  setSelectedCountry(selected: Country) {
    this.selectedCountry = selected;
    this.listHealthInsurancesByCountryId(selected.id);
    this.plans = this.plansAll.filter(x => x.countryId === selected.id) as Plan[];
    if (this.patient.planId)
      this.setSelectedPlan(this.plansAll.find(x => x.id == this.patient.planId));
  }

  setSelectedPlan(selected: Plan) {
    this.selectedPlan=selected;
    let arr = [];
    for(let planPathology of selected.planPathologies) {
      arr.push(planPathology.pathology);
    }
    this.pathologies = arr;
  }

  ngOnInit(): void {
    this.doctors=this.route.snapshot.data.doctors as Doctor[];
    this.nurses = this.route.snapshot.data.nurses as Nurse[];
    debugger
    this.countries=this.route.snapshot.data.countries as Country[];
    this.healthInsurancesAll=this.route.snapshot.data.healthInsurances as HealthInsurance[];
    this.route.queryParams.subscribe(params => {
      if (params['id']) {
        this.plansService.getAllByUser().subscribe(result => {
          this.plansAll = result as Plan[];
          this.doSearch();
        });
      }
      else {
        this.patient = new Patient();
        if(params['planId']) {
          this.plansService.getOne(params['planId']).subscribe(x => {
            let arr = [];
            let plan = (x as Plan);
            this.isOperator = true;
            this.plans = [plan];
            this.patient.planId=plan.id;
            this.patient.countryId = plan.countryId;
            this.listHealthInsurancesByCountryId(this.patient.countryId);
            for(let planPathology of plan.planPathologies) {
              arr.push(planPathology.pathology);
            }
            this.pathologies = arr;
          });
        }
        else {
          this.pathologies = this.route.snapshot.data.pathologies as Pathology[];
          this.plansService.getActivesByUser().subscribe(result => {
            this.plansAll = result as Plan[];
            if (this.countries.length == 1) {
              this.patient.countryId = this.countries[0].id;
              this.setSelectedCountry(this.countries[0]);
              if (this.plans.length == 1) {
                this.patient.planId = this.plans[0].id;
                this.setSelectedPlan(this.plans[0]);
              }
            }
          });
        }
      }
    });
  }
  public handleAddressChange(address: Address) {
    this.patient.location = new Location();
    if (address.formatted_address.indexOf(address.name) != -1)
      this.patient.location.address = address.formatted_address;
    else
      this.patient.location.address = address.name + " - " + address.formatted_address;
    this.patient.location.latitude = address.geometry.location.lat();
    this.patient.location.longitude = address.geometry.location.lng();
    

  }


  healthInsuranceSelected(selected: HealthInsurance) {
    this.patient.healthInsuranceFields = selected.fields;
  }

  onSubmit(valid: boolean) {
    if (!valid)
      return;
    
    if (this.patient) {
      this.patient.patientPathologies = [];
      let patologiaPorPaciente = new PatientPathology();
      patologiaPorPaciente.pathologyId = this.patient.patientPathologiesId;
      patologiaPorPaciente.patientId = this.patient.id;
      this.patient.patientPathologies.push(patologiaPorPaciente);

      this.capitalizeName();
      
      if (this.patient.id == null) {
        this.patient.active = true;

        this.pacienteService.insert(this.patient).subscribe(
          result => {
            this.alertService.showMessage("Pacientes", "Actualización exitosa", MessageSeverity.success);
            let createdPatient = result as Patient;
            this.router.navigate(['/treatments/detail'], { queryParams: { patientId: createdPatient.id, planId: createdPatient.planId } });
          }
          , response => {
            this.alertService.showMessage("Pacientes", response.error.errors[0].message, MessageSeverity.error);
          });
      }
      else {
        this.pacienteService.update(this.patient).subscribe(result => {
          this.alertService.showMessage("Pacientes", "Actualización exitosa", MessageSeverity.success);
          this.router.navigate(['/patients']);
        }
          , response => {
            this.alertService.showMessage("Pacientes", response.error.errors[0].message, MessageSeverity.error);
          });
      }
    }

  }

  capitalizeName() {
    this.patient.name = this.titleCase(this.patient.name);
    this.patient.surname = this.titleCase(this.patient.surname);
    if(this.patient.mothersSurname)
      this.patient.mothersSurname = this.titleCase(this.patient.mothersSurname);
  }

  show() {
    this.display = true;
  }

  showNurse() {
    this.displayEnfermera = true;
  }

  NuevoMedico(doctor: Doctor) {
    this.doctors = [...this.doctors, doctor];
    this.patient.doctorId = doctor.id;
    this.display = false;

  }
  NuevoEnfermera(nurse: Nurse) {
    this.nurses = [...this.nurses, nurse];
    this.patient.nurseId = nurse.id;
    this.displayEnfermera = false;
  }
  titleCase(str) {
    var splitStr = str.toLowerCase().split(' ');
    for (var i = 0; i < splitStr.length; i++) {
      // You do not need to check if i is larger than splitStr length, as your for does that for you
      // Assign it back to the array
      splitStr[i] = splitStr[i].charAt(0).toUpperCase() + splitStr[i].substring(1);
    }
    // Directly return the joined string
    return splitStr.join(' ');
  }
}
