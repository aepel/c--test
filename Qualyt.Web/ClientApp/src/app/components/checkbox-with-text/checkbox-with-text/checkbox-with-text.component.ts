import { Component, OnInit, Input, OnChanges } from '@angular/core';

@Component({
  selector: 'app-checkbox-with-text',
  templateUrl: './checkbox-with-text.component.html',
  styleUrls: ['./checkbox-with-text.component.scss']
})
export class CheckboxWithTextComponent implements OnInit {

  @Input() model;
  @Input() booleanPropertyName;
  @Input() booleanPlaceholder;
  @Input() stringPropertyName;
  @Input() stringPlaceholder;
  @Input() stringOcurrenceValue;
  @Input() requiredMessage;
  @Input() form;
  @Input() stringPattern;
  @Input() classes;

  constructor() { }

  ngOnInit() {
  }

}
