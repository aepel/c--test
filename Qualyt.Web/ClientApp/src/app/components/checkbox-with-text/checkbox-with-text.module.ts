import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CheckboxWithTextComponent } from './checkbox-with-text/checkbox-with-text.component';
import { MatSlideToggleModule, MatFormFieldModule, MatInputModule, MatCheckboxModule } from '@angular/material';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    MatSlideToggleModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatCheckboxModule
  ],
  declarations: [CheckboxWithTextComponent],
  exports: [CheckboxWithTextComponent]
})
export class CheckboxWithTextModule { }
