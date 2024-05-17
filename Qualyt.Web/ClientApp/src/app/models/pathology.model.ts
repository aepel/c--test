import { Moment } from 'moment/moment';
import { Field } from './field.model';
import { Laboratory } from './laboratory.model';

export class Pathology {

  constructor() {
    this.fields=[]
  }

    id: number
    laboratoryId: number
    laboratory: Laboratory
    name: string
    createdBy: string
    updatedBy: string
    createdDate: Moment
    updatedDate?: Moment
    active: boolean
    lineaId: number
    fields: Field[]
}
