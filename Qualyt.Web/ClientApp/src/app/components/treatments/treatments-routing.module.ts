import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TreatmentsListComponent } from './treatments-list/treatments-list.component';
import { TreatmentsDetailComponent } from './treatments-detail/treatments-detail.component';
import { TreatmentSummaryComponent } from './treatment-summary/treatment-summary.component';

const routes: Routes = [
  {
    path: '',
    component: TreatmentsListComponent,
    data: {
      title: 'Tratamientos',
      icon: 'icon-layout-sidebar-left',
      status: true
    }
  },
  {
    path: 'detail',
    component: TreatmentsDetailComponent,
    data: {
      icon: 'icon-layout-sidebar-left',
      status: true
    }
  },
  {
    path: 'treatment-summary',
    component: TreatmentSummaryComponent,
    data: {
      icon: 'icon-layout-sidebar-left',
      status: true
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TreatmentsRoutingModule { }
