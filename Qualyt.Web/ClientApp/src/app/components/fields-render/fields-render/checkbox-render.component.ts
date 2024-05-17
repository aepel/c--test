import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, Validators } from '@angular/forms';
import { Field } from '../../../models/field.model';
//import { DataService } from './data.service';

@Component({
    selector: 'app-checkbox-render',
  templateUrl: './checkbox-render.component.html'
})
export class CheckboxRenderComponent implements OnInit{

  ngOnInit(): void {
    if (this.data.childFields)
      for (let campo of this.data.childFields) {
          this.idsHijos.push(''+campo.id)
      }
  }

    @Input() data: Field;
   @Input() disabled: boolean;
    @Input() _formGroup;
    idsHijos:string[]=[]


    requiredToggle(_formGroup: FormGroup, controlNombre: string | string[], condicion: boolean = true) {
        if (condicion) {
            if (controlNombre instanceof Array)
                for (let ctrl of controlNombre)
                    this.requiredToggle(_formGroup, ctrl, condicion);
            else
                _formGroup.get(controlNombre).setValidators(Validators.required);
        }
        else {
            if (controlNombre instanceof Array)
                for (let ctrl of controlNombre)
                    this.requiredToggle(_formGroup, ctrl, condicion);
            else {
                _formGroup.get(controlNombre).clearValidators();
                _formGroup.get(controlNombre).reset();
            }
        }
    }
}
