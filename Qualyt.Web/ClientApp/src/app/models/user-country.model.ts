import { Moment } from 'moment/moment';
import { Field } from './field.model';
import { Country } from './country.model';

export class UserCountry {
  constructor(_countryId, _userId, _country?) {
    this.countryId = _countryId;
    this.userId = _userId;
    this.country = _country;
  }
    userId: number
    countryId: number
    country: Country
}
