import { Component, OnInit } from '@angular/core';
import { ApplicationUser, IdentityUserRole } from 'src/app/models/application-user.model';
import { Country } from 'src/app/models/country.model';
import { Plan } from 'src/app/models/plan.model';
import { Laboratory } from 'src/app/models/laboratory.model';
import { LaboratoryUser } from 'src/app/models/laboratoryUser.model';
import { ActivatedRoute, Router } from '@angular/router';
import { UsersService } from 'src/app/services/users.service';
import { CountriesService } from 'src/app/services/countries.service';
import { LaboratoriesService } from 'src/app/services/laboratories.service';
import { PlansService } from 'src/app/services/plans.service';
import { AlertService, MessageSeverity } from 'src/app/services/alert.service';
import { PlanPathology } from 'src/app/models/plan-pathology.model';
import { UserPlan } from 'src/app/models/user-plan.model';
import { UserCountry } from 'src/app/models/user-country.model';

@Component({
  selector: 'app-users-detail',
  templateUrl: './users-detail.component.html',
  styleUrls: ['./users-detail.component.scss']
})
export class UsersDetailComponent implements OnInit {

  public user?: ApplicationUser;
  public isOperator: boolean;
  public isLaboratory: boolean;
  public role: string;
  public countries: Country[];
  public plans: Plan[];
  public plansAll: Plan[];
  public laboratories: Laboratory[];
  public selectedCountries: Country[] = [];
  public selectedPlans: Plan[] = [];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: UsersService,
    private countriesService: CountriesService,
    private laboratoriesService: LaboratoriesService,
    private plansService: PlansService,
    private alertService: AlertService
  ) { }

  doSearch(id: number): void {
    this.service.getOne(id).subscribe(result => {
      let arr: any[];
      this.user = result as ApplicationUser;
      this.role = this.user.roles[0];
      this.countriesService.getAll().subscribe(result => {
        this.countries = result as Country[];
        arr = [];
        for (let c of this.user.countries)
          arr.push(c.country);
        this.selectedCountries = arr;
      });
      this.plansService.getAll().subscribe(result => {
        this.plansAll = result as Plan[];
        this.plans = this.plansAll;
        arr = [];
        for (let p of this.user.plans) {
          let pl = this.plans.find(x => x.id == p.plan.id);
          if (pl)
            arr.push(pl);
        }
        this.selectedPlans = arr;
        this.countriesChange(this.selectedCountries);
        if (this.role == "LABORATORIO")
          this.laboratoryChange((this.user as LaboratoryUser).laboratory);
      });
    }
      , error => console.error(error)
    );
  }

  ngOnInit(): void {
    this.laboratoriesService.getAll().subscribe(result => {
      this.laboratories = result as Laboratory[];
    });
    this.route.queryParams.subscribe(params => {
      if (params['readOnly']) {
        this.isOperator = true;
      }
      if (params['id']) {
        this.doSearch(params['id'])
      }
      else {
        this.user = new ApplicationUser();
        this.countriesService.getAll().subscribe(result => {
          this.countries = result as Country[];
        });
        this.plansService.getAll().subscribe(result => {
          this.plansAll = result as Plan[];
        });
      }
    });
  }

  countriesChange(selectedCountries: Country[]) {
    this.selectedPlans = this.selectedPlans.filter(x => this.plans.some(y => y.id == x.id));
    this.updatePlansList();
  }

  laboratoryChange(laboratory) {
    this.selectedPlans = this.selectedPlans.filter(x => this.plans.some(y => y.id == x.id));
    this.updatePlansList();
  }

  updatePlansList(){
    this.plans = this.plansAll.filter(x => this.selectedCountries.some(y => y.id == x.countryId));
    if (this.role == "LABORATORIO")
      this.plans = this.plans.filter(x => x.laboratoryId == (this.user as LaboratoryUser).laboratoryId);
  }

  onSubmit(form) {
    if (!form.valid)
      return;

    this.user.userName = this.user.email;
    this.user.normalizedUserName = this.user.email.toUpperCase();
    this.user.normalizedEmail = this.user.email.toUpperCase();
    this.user.roles = [this.role];

    this.user.plans = [];
    for (let p of this.selectedPlans) {
      this.user.plans.push(new UserPlan(p.id,this.user.id ? this.user.id : 0));
    }
    this.user.countries = [];
    for (let c of this.selectedCountries) {
      this.user.countries.push(new UserCountry(c.id,this.user.id ? this.user.id : 0));
    }

    if (this.user.id == null) {
      this.service.insert(this.user).subscribe(
        result => {
          this.alertService.showMessage("Usuario", "Actualización exitosa", MessageSeverity.success);
          this.router.navigate(['/users']);
        }
        , response => {
          this.alertService.showMessage("Usuario", response.error.errors[0].message, MessageSeverity.error);
        });
    }
    else {
      this.service.update(this.user).subscribe(result => {
        this.alertService.showMessage("Usuario", "Actualización exitosa", MessageSeverity.success);
        this.router.navigate([(this.isOperator ? '/dashboard' : '/users')]);
      }
        , response => {
          this.alertService.showMessage("Usuario", response.error.errors[0].message, MessageSeverity.error);
        });
    }

  }
}
