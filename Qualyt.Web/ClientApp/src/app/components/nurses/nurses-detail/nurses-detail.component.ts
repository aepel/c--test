import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Nurse } from '../../../models/nurse.model';
import { Country } from '../../../models/country.model';
import { NursesService } from '../../../services/nurses.service';
import { AlertService, MessageSeverity } from '../../../services/alert.service';
import { CountriesService } from '../../../services/countries.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-nurses-detail',
  templateUrl: './nurses-detail.component.html',
  styleUrls: ['./nurses-detail.component.scss']
})
export class NursesDetailComponent implements OnInit {

  public nurse?: Nurse;
  public selectedCountry: Country;
  public countries: Country[];
  @Output() ConfirmEvent: EventEmitter<any> = new EventEmitter();
  @Output() CancelEvent: EventEmitter<any> = new EventEmitter();
  get isDialog(): boolean {
    return this.ConfirmEvent.observers.length > 0;
  };
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private countriesService: CountriesService,
    private service: NursesService,
    private alertService: AlertService
  ) {}

  doSearch(id: number): void {
    this.service.getOne(id).subscribe(result => {
      this.nurse = result as Nurse;
      this.setSelectedCountry(this.nurse.country);
    }
      , error => console.error(error)
    );
  }

  ngOnInit(): void {
    this.countriesService.getAllByUser().subscribe(result => {
      this.countries = result as Country[];
    });
    this.route.queryParams.subscribe(params => {
      if (params['id'] && !this.isDialog) {
        this.doSearch(params['id'])
      }
      else
        this.nurse = new Nurse();

    });
  }

  setSelectedCountry(selected: Country) {
    this.selectedCountry = selected;
  }

  onSubmit(valid: boolean) {
    if (!valid)
      return;

    if (this.nurse.id == null) {
      this.service.insert(this.nurse).subscribe(
        result => {
          this.alertService.showMessage("Enfermera/o", "Actualización exitosa", MessageSeverity.success);
          if (!this.isDialog)
            this.router.navigate(['/nurses']);
          else
            this.ConfirmEvent.emit(result as Nurse);
        }
        , response => {
          this.alertService.showMessage("Enfermera/o", response.error.errors[0].message, MessageSeverity.error);
        });
    }
    else {
      this.service.update(this.nurse).subscribe(result => {
        this.alertService.showMessage("Enfermera/o", "Actualización exitosa", MessageSeverity.success);
        this.router.navigate(['/nurses']);
      }
        , response => {
          this.alertService.showMessage("Enfermera/o", response.error.errors[0].message, MessageSeverity.error);
        });
    }

  }
}

