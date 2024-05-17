import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { HealthInsurance } from '../../../models/health-insurance.model';
import { Country } from '../../../models/country.model';
import { ActivatedRoute, Router } from '@angular/router';
import { CountriesService } from '../../../services/countries.service';
import { HealthInsurancesService } from '../../../services/health-insurance.service';
import { AlertService, MessageSeverity } from '../../../services/alert.service';

@Component({
  selector: 'app-health-insurances-detail',
  templateUrl: './health-insurances-detail.component.html',
  styleUrls: ['./health-insurances-detail.component.scss']
})
export class HealthInsurancesDetailComponent implements OnInit {

  http: Http;
  public healthInsurance?: HealthInsurance;
  submitted: boolean;
  
  public countries: Country[];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private countriesService: CountriesService,
    private service: HealthInsurancesService,
    private alertService: AlertService
  ) {
    this.router = router;
    this.submitted = false;
    this.healthInsurance = new HealthInsurance();
  }

  doSearch(pacienteId: number): void {
    this.service.getOne(pacienteId).subscribe(result => {
      this.healthInsurance = result as HealthInsurance;
    }
      , error => console.error(error)
    );
  }

  ngOnInit(): void {
    this.countriesService.getAll().subscribe(result => {
      this.countries = result as Country[];
    });
    this.route.queryParams.subscribe(params => {
      this.healthInsurance = new HealthInsurance();

      if (params['id']) {
        this.doSearch(params['id'])
      }

    });
  }

  onSubmit(valid: boolean) {
    if (!valid)
      return;

    this.healthInsurance["serializedFields"]=undefined;

    if (this.healthInsurance) {
      this.submitted = true;

      if (this.healthInsurance.id == null) {

        this.service.insert(this.healthInsurance).subscribe(
          result => {
            var paciente = result as HealthInsurance;
            this.router.navigate(['/health-insurances']);
            this.alertService.showMessage("Seguro médico", "Actualización exitosa", MessageSeverity.success);
          }
          , response => {
            this.alertService.showMessage("Seguro médico", response.error.errors[0].message, MessageSeverity.error);
          });
      }
      else {
        this.service.update(this.healthInsurance).subscribe(result => {
          this.router.navigate(['/health-insurances']);
          this.alertService.showMessage("Seguro médico", "Actualización exitosa", MessageSeverity.success);
        }
          , response => {
            this.alertService.showMessage("Seguro médico", response.error.errors[0].message, MessageSeverity.error);
          });
      }
    }

  }
}
