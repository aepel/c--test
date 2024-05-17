import { Moment } from 'moment/moment';
import { Laboratory } from './laboratory.model';
import { ApplicationUser } from './application-user.model';

export class LaboratoryUser extends ApplicationUser {
  laboratory: Laboratory;
  laboratoryId: number;
}
