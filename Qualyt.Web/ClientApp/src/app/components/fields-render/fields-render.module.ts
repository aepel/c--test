import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FieldsRenderComponent } from './fields-render/fields-render.component';
import { CheckboxRenderComponent } from './fields-render/checkbox-render.component';
import { DateRenderComponent } from './fields-render/date-render.component';
import { NumericRenderComponent } from './fields-render/numeric-render.component';
import { TextRenderComponent } from './fields-render/text-render.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatCheckboxModule, MatFormFieldModule, MatInputModule, MatSelectModule } from '@angular/material';
import { FormattedDatepickerModule } from '../formatted-datepicker/formatted-datepicker.module';
import { OptionsRenderComponent } from './fields-render/options-render.component';


@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatCheckboxModule,
    FormattedDatepickerModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule
  ],
  declarations:
  [
      FieldsRenderComponent,
      CheckboxRenderComponent,
      DateRenderComponent,
      NumericRenderComponent,
      TextRenderComponent,
      OptionsRenderComponent
  ],
  exports: [FieldsRenderComponent]
})
export class FieldsRenderModule { }
