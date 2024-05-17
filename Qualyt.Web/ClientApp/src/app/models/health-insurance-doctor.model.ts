import { Moment } from 'moment/moment';
import { Field } from './field.model';
import { Pathology } from './pathology.model';
import { HealthInsurance } from './health-insurance.model';

export class HealthInsuranceDoctor
{
    healthInsuranceId: number
    doctorId: string
    healthInsurance: HealthInsurance
}
