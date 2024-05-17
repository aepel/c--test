import { Component, Input, OnInit } from '@angular/core';
//import { DataService } from './data.service';

@Component({
    selector: 'app-date-render',
    templateUrl: './date-render.component.html'
})
export class DateRenderComponent {
    @Input() data;
  @Input() disabled: boolean;
  @Input() _formGroup;
}
