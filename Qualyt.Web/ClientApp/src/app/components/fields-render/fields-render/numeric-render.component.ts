import { Component, Input, Pipe, OnInit } from '@angular/core';
import { PipeTransform } from '@angular/core/src/change_detection/pipe_transform';
import { Field, NumericField } from '../../../models/field.model';
//import { DataService } from './data.service';

@Component({
    selector: 'app-numeric-render',
    templateUrl: './numeric-render.component.html'
})
export class NumericRenderComponent {
  @Input() data: NumericField;
  @Input() disabled: boolean;
  @Input() _formGroup;
}
