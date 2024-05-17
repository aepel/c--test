import { Component, Input, OnInit, OnChanges } from '@angular/core';
import { MatSelectChange } from '@angular/material';
import { Option, OptionsField } from '../../../models/field.model';

@Component({
    selector: 'app-options-render',
    templateUrl: './options-render.component.html'
})
export class OptionsRenderComponent implements OnChanges {
  @Input() data;
  @Input() disabled: boolean;
  @Input() _formGroup;

  ngOnChanges() {
    var test=(this.data as OptionsField);
    this.data.value = this.data.options.find(x => x.selected) ? this.data.options.find(x => x.selected).text:"";
  }

  selection(event: MatSelectChange) {
    this.data.value = event.value;
    this.data.options.forEach(x => x.selected = this.data.value == x.text);
  }
}
