import { Moment } from 'moment/moment';
import { Field } from './field.model';
import { Pathology } from './pathology.model';

export class PatientPathology {
    patientId: number
    pathologyId: number
    pathology:Pathology
}
