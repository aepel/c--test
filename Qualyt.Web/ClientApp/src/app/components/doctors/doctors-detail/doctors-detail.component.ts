import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';
import { Doctor } from '../../../models/doctor.model';
import { SalesContact } from '../../../models/sales-contact.model';
import { ActivatedRoute, Router } from '@angular/router';
import { SalesContactsService } from '../../../services/sales-contacts.service';
import { DoctorsService } from '../../../services/doctors.service';
import { AlertService, MessageSeverity } from '../../../services/alert.service';
import { Country } from '../../../models/country.model';
import { CountriesService } from '../../../services/countries.service';
import { AttentionPlace } from '../../../models/attention-place.model';
import { AttentionPlacesService } from '../../../services/attention-places.service';
import { DoctorSpecialty } from '../../../models/doctor-specialty.model';
import { DoctorSpecialtiesService } from '../../../services/doctor-specialties.service';
import { Address } from 'ngx-google-places-autocomplete/objects/address';
import { Location } from '../../../models/location.model';

@Component({
  selector: 'app-doctors-detail',
  templateUrl: './doctors-detail.component.html',
  styleUrls: ['./doctors-detail.component.scss']
})
export class DoctorsDetailComponent implements OnInit {

  public doctor?: Doctor;
  public countries: Country[];
  public salesContacts: SalesContact[];
  public attentionPlaces: AttentionPlace[];
  public selectedCountry: Country;
  public specialties: DoctorSpecialty[];

  @Output() ConfirmEvent: EventEmitter<any> = new EventEmitter();
  @Output() CancelEvent: EventEmitter<any> = new EventEmitter();
  get isDialog(): boolean {
    return this.ConfirmEvent.observers.length > 0;
  };
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: DoctorsService,
    private countriesService: CountriesService,
    private alertService: AlertService,
    private salesContactsService: SalesContactsService,
    private attentionPlacesService: AttentionPlacesService,
    private specialtiesService: DoctorSpecialtiesService
  ) {

}

  doSearch(id: string): void {
    this.service.getOneById(id).subscribe(result => {
      this.doctor = result as Doctor;
      this.selectedCountry = this.doctor.country;
    }
      , error => console.error(error)
    );
  }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.countriesService.getAllByUser().subscribe(result => {
        this.countries = result as Country[];
      });
      this.salesContactsService.getAll().subscribe(result => {
        this.salesContacts = result as SalesContact[];
      });
      this.attentionPlacesService.getAll().subscribe(result => {
        this.attentionPlaces = result as AttentionPlace[];
      });
      this.specialtiesService.getAll().subscribe(result => {
        this.specialties = result as DoctorSpecialty[];
      });
      if (params['id'] && !this.isDialog) {
        this.doSearch(params['id'])
      }
      else
        this.doctor = new Doctor();

    });
  }

  setSelectedCountry(selected: Country) {
    this.selectedCountry = selected;
  }

  public handleAddressChange(address: Address) {
    if (address.formatted_address.indexOf(address.name) != -1)
      this.doctor.location.address = address.formatted_address;
    else
      this.doctor.location.address = address.name + " - " + address.formatted_address;
    this.doctor.location.latitude = address.geometry.location.lat();
    this.doctor.location.longitude = address.geometry.location.lng();
    

  }


  onSubmit(valid: boolean) {
    if (!valid)
      return;

    if (this.doctor.id == null) {
      this.service.insert(this.doctor).subscribe(
        result => {
          this.alertService.showMessage("Médica/o", "Actualización exitosa", MessageSeverity.success);
          if (this.ConfirmEvent.observers.length==0) {
              this.router.navigate(['/doctors']);

          }
          else {
            this.ConfirmEvent.emit(result as Doctor);
          }
        }
        , response => {
          this.alertService.showMessage("Médica/o", response.error.errors[0].message, MessageSeverity.error);
        });
    }
    else {
      this.service.update(this.doctor).subscribe(result => {
        this.alertService.showMessage("Médica/o", "Actualización exitosa", MessageSeverity.success);
        this.router.navigate(['/doctors']);
      }
        , response => {
          this.alertService.showMessage("Médica/o", response.error.errors[0].message, MessageSeverity.error);
        });
    }

  }
}
