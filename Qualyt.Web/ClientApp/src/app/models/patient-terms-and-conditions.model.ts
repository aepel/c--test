import { Moment } from 'moment/moment';
import { Field } from './field.model';
import { TermsAndConditions } from './terms-and-conditions.model';

export class PatientTermsAndConditions {
    patientId: number
    termsAndConditionsId: number
    termsAndConditions: TermsAndConditions
}
