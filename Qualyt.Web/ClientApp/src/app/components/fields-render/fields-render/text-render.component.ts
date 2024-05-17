import { Component, Input, OnInit } from '@angular/core';
//import { DataService } from './data.service';

@Component({
    selector: 'app-text-render',
    templateUrl: './text-render.component.html'
})
export class TextRenderComponent {
    @Input() data;
  @Input() disabled: boolean;
  @Input() _formGroup;
}
