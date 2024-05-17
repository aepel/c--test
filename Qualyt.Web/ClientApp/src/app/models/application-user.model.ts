import { Moment } from 'moment/moment';
import { UserCountry } from './user-country.model';
import { UserPlan } from './user-plan.model';

export class ApplicationUser {
    id: string
  name: string
  active: boolean
  enabled: boolean
  isLockedOut: boolean
  createdBy: string
  updatedBy: string
  createdDate: Moment
  updatedDate?: Moment
  countries: UserCountry[];
  plans: UserPlan[];

  constructor(id?: string, userName?: string, fullName?: string, email?: string, jobTitle?: string, phoneNumber?: string, roles?: string[]) {

    this.id = id;
    this.userName = userName;
    this.fullName = fullName;
    this.email = email;
    this.jobTitle = jobTitle;
    this.phoneNumber = phoneNumber;
    this.roles = roles;
  }

  getfriendlyName(): string {
    let name = this.fullName || this.userName;

    if (this.jobTitle)
      name = this.jobTitle + " " + name;

    return name;
  }


  public userName: string;
  public normalizedUserName: string;
  public normalizedEmail: string;
  public fullName: string;
  public email: string;
  public jobTitle: string;
  public passwordChange: string;
  public phoneNumber: string;
  public isEnabled: boolean;
  public roles: string[];
  public rolesCollection: IdentityUserRole;
}

export class IdentityUserRole {
  userId: string;
  roleId: string;
}



