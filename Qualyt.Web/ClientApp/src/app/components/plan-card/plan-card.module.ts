import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PlanCardComponent } from './plan-card/plan-card.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [PlanCardComponent],
  exports: [PlanCardComponent]
})
export class PlanCardModule { }
