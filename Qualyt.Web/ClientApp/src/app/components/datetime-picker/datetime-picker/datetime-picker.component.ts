import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { Moment } from 'moment/moment';
import * as moment from "moment";

@Component({
  selector: 'app-datetime-picker',
  templateUrl: './datetime-picker.component.html',
  styleUrls: ['./datetime-picker.component.scss']
})
export class DatetimePickerComponent implements OnInit {
  @Input() date: Moment|Date;
  @Input() required: boolean;
  @Input() form: any;
  @Input() min: Moment|Date;
  @Input() max: Moment|Date;
  @Input() placeholder: string;
  @Input() disabled: boolean;
  @Input() controlName: string;

  @Output() dateChange: EventEmitter<any> = new EventEmitter();

  @ViewChild("control") control;

  es: any;

  constructor() { }

  ngOnInit() {
    if (typeof this.date == 'string')
      this.date = moment(this.date).toDate();
    if (this.min && typeof this.min == 'string')
      this.min = (moment(this.min)).toDate();
    if (this.max && typeof this.max == 'string')
      this.max = (moment(this.max)).toDate();
    
    this.es = {
      firstDayOfWeek: 1,
      dayNames: ["domingo", "lunes", "martes", "miércoles", "jueves", "viernes", "sábado"],
      dayNamesShort: ["dom", "lun", "mar", "mié", "jue", "vie", "sáb"],
      dayNamesMin: ["D", "L", "M", "X", "J", "V", "S"],
      monthNames: ["enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre"],
      monthNamesShort: ["ene", "feb", "mar", "abr", "may", "jun", "jul", "ago", "sep", "oct", "nov", "dic"],
      today: 'Hoy',
      clear: 'Borrar'
    }
  }

  ngAfterViewInit(): void {
    if (this.control) {
      if (this.form && this.form.form)
        this.form.form.addControl(this.controlName, this.control.control);
    }
  }

  onSelectChange() {
    this.dateChange.emit(this.date);
  }

}
