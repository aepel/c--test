import { Component, OnInit, Input } from '@angular/core';
import { MAT_MOMENT_DATE_FORMATS, MomentDateAdapter } from '@angular/material-moment-adapter';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';

@Component({
  selector: 'app-formatted-datepicker',
  templateUrl: './formatted-datepicker.component.html',
  styleUrls: ['./formatted-datepicker.component.scss'],
  providers: [
    { provide: MAT_DATE_LOCALE, useValue: 'es-AR' },
  
    { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
    { provide: MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS },
  ],
})
export class FormattedDatepickerComponent implements OnInit {

  @Input() propertyName;
  @Input() model;
  @Input() requiredError;
  @Input() placeholder;
  @Input() required;
  @Input() form;
  @Input() disabled;
  @Input() classes;
  @Input() min;
  @Input() max;

  constructor() {
  }

  ngOnInit() {

  }

}
