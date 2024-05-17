import { Moment } from 'moment/moment';
import { Field } from './field.model';
import { Pathology } from './pathology.model';

export class PlanPathology {
  constructor(_planId, _pathologyId, _pathology?) {
    this.planId = _planId;
    this.pathologyId = _pathologyId;
    this.pathology = _pathology;
  }
    planId: number;
    pathologyId: number;
    pathology:Pathology;
}
