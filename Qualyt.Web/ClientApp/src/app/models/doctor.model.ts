import { Moment } from 'moment/moment';
import { Field } from './field.model';
import { Location } from './location.model';
import { AttentionPlace } from './attention-place.model';
import { SalesContact } from './sales-contact.model';
import { DoctorSpecialty } from './doctor-specialty.model';
import { HealthInsuranceDoctor } from './health-insurance-doctor.model';
import { ApplicationUser } from './application-user.model';
import { Country } from './country.model';

export class Doctor extends ApplicationUser {
  constructor() {
    super();
    this.attentionPlace = new AttentionPlace();
    this.location = new Location();
  }
    name: string
    surname: string
    mothersSurname: string
  fullName: string
  fullNameAndSpecialty: string;
  cellPhoneNumber: string
  phoneNumber: string
  idNumber: number
  longitude: number
  country: Country;
  countryId: number;
  attentionPlace: AttentionPlace
  
  attentionPlaceId: number
  salesContact: SalesContact
  salesContactId: number
  location: Location
  specialty: DoctorSpecialty
  specialtyId: number
  healthInsuranceDoctors: HealthInsuranceDoctor[]
}
