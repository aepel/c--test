import { Component, Inject, Pipe, OnInit, Input, SimpleChanges, OnChanges } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Field } from '../../../models/field.model';

@Component({
    selector: 'app-fields-render',
    templateUrl: './fields-render.component.html',
})
export class FieldsRenderComponent implements OnInit, OnChanges {
  @Input() _formGroup: FormGroup
  @Input() fields: Field[];
  @Input() todosLosCampos: Field[];
  @Input() parentFields: Field[];
  @Input() childFields: Field[];
  @Input() disabled: boolean;
  obj = {}


  ngOnChanges(changes: SimpleChanges): void {
    this.prepareFields();
  }

  constructor(private _formBuilder: FormBuilder) {
        

  }

  ngOnInit(): void {
  }

  prepareFields() {
    this.childFields = this.fields.filter(x => x.parentId != null);
    this.parentFields = this.fields.filter(x => x.parentId === null);
    for (let parent of this.parentFields) {
      parent = this.cargarHijos(parent);
    }
    this.cargarFormGroup(this.parentFields);
    this._formGroup = this._formBuilder.group(this.obj);
  }

  cargarFormGroup(campos: Field[])
  {
      if (campos.length>0)
          for (let campo of campos) {
            this.obj[campo.id] = ['',];
            if (campo.childFields && campo.childFields.length > 0)
              this.cargarFormGroup(campo.childFields);
      }
  }



  getHijos(parentId: number): Field[] {
    return this.childFields.filter(x => x.parentId == parentId);
  }


  cargarHijos(padre: Field): Field {
    for (let hijo of this.getHijos(padre.id)) {
      if (!padre.childFields) {
        padre.childFields = [];
      }
      hijo = this.cargarHijos(hijo);
      padre.childFields.push(hijo);
    }
    return padre;
  }

}
