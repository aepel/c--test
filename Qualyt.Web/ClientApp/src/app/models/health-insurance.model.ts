import { Moment } from 'moment/moment';
import { Field } from './field.model';

export class HealthInsurance {
    id: number
    name: string
    createdBy: string
    updatedBy: string
    createdDate: Moment
    updatedDate?: Moment
    active: boolean
countryId:number
    fields: Field[]
}
