import { Moment } from 'moment/moment';
import { FieldType } from './enums.model';

export class Field {
    id: number
    name: string
    required: boolean
    type: FieldType
    typeName: string
    parentId?: number
  parentName?: string
  childFields?: Field[];
  value?:any;
  options?:Option[];
}

export class BinaryField extends Field {
  value?: boolean
}

export class DateField extends Field {
  value?: Moment
}

export class TextField extends Field {
  value: string
}

export class NumericField extends Field {
  value?: number
  minimum?: number
  maximum?: number
}

export class OptionsField extends Field {
}

export class Option{
  constructor(_text: string) {
    this.text = _text;
  }

  text:string
  selected:boolean
}

