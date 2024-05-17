import { Component, OnInit, Input, ViewChild, Output, EventEmitter, OnChanges, AfterViewInit } from '@angular/core';
import { FormControl, NgForm, NgModel, ControlContainer } from '@angular/forms';

@Component({
  selector: 'app-multidropdown-with-filter',
  templateUrl: './multidropdown-with-filter.component.html',
  styleUrls: ['./multidropdown-with-filter.component.scss']
})
export class MultidropdownWithFilterComponent implements OnChanges, AfterViewInit {

  @Input() options:any[];
  @Input() optionLabel:string;
  @Input() optionValue: string;
  @Input() form: NgForm;
  @Input() formGroup: any;
  @Input() placeholder:string;
  @Input() required: boolean;
  @Input() controlName: string;
  @Input() disabled: boolean;
  @Input() selecteds: any[];

  @Output() selectedsChange: EventEmitter<any> = new EventEmitter();

  @ViewChild("selectedId") selectedId;

  constructor() { }

  ngAfterViewInit(): void {
    if (this.selectedId) {
      if (this.formGroup)
        this.formGroup.control.addControl(this.controlName, this.selectedId.control);
      if (this.form && this.form.form)
        this.form.form.addControl(this.controlName, this.selectedId.control);
    }
  }

  ngOnChanges(changes) {
    if(this.options)
      this.selecteds=this.options.filter(x=>this.selecteds.some(y=>y.id==x.id))
    this.optionValue = this.optionValue ? this.optionValue : "id";
    this.disabled = this.disabled ? this.disabled : false;
  }

  onSelectChange(event) {
    this.selectedsChange.emit(this.selecteds);
  }

}
