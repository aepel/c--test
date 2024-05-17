import { Moment } from 'moment/moment';

export class Laboratory {
  id: number;
  name: string;
  color: string;
  createdBy: string;
  updatedBy: string;
  createdDate: Moment;
  updatedDate?: Moment;
  active: boolean;
  iconType: string;
  iconBytes: Int8Array;
}
