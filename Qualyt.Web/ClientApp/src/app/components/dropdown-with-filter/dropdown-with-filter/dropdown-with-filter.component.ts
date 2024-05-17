import { Component, OnInit, Input, ViewChild, Output, EventEmitter, OnChanges, AfterViewInit, ChangeDetectorRef } from '@angular/core';
import { FormControl, NgForm, NgModel, ControlContainer } from '@angular/forms';

@Component({
  selector: 'app-dropdown-with-filter',
  templateUrl: './dropdown-with-filter.component.html',
  styleUrls: ['./dropdown-with-filter.component.scss']
})
export class DropdownWithFilterComponent implements OnChanges, AfterViewInit {

  @Input() options:any[];
  @Input() optionLabel:string;
  @Input() optionValue: string;
  @Input() model: any;
  @Input() form: NgForm;
  @Input() formGroup: any;
  @Input() bindingProperty:string;
  @Input() placeholder:string;
  @Input() required: boolean;
  @Input() controlName: string;
  @Input() disabled: boolean;
  @Input() value: any;

  @Output() change: EventEmitter<any> = new EventEmitter();
  @Output() valueChange: EventEmitter<any> = new EventEmitter();

  @ViewChild("selectedId") selectedId;

  selected: any;

  constructor(private cdr: ChangeDetectorRef) { }

  ngAfterViewInit(): void {
    if (this.selectedId) {
      if (this.formGroup)
        this.formGroup.control.addControl(this.controlName, this.selectedId.control);
      if (this.form && this.form.form)
        this.form.form.addControl(this.controlName, this.selectedId.control);
    }
  }

  ngOnChanges(changes) {
    this.optionValue = this.optionValue ? this.optionValue : "id";
    if((this.value || this.value==0) && this.options)
      this.selected = this.options.find(x => x[this.optionValue] == this.value);
    this.cdr.detectChanges();
  }

  onSelectChange(event) {
    this.value = event.value[this.optionValue];
    this.valueChange.emit(this.value);
    this.change.emit(event.value);
  }

}
