import { Moment } from 'moment/moment';
import { Field } from './field.model';

export class TermsAndConditions {

    id: number
    text: string
    publishedDate?: Moment
    publishedBy: string
    version?: number
    published: boolean
    active: boolean
    publishable: boolean
    deletable: boolean
}
