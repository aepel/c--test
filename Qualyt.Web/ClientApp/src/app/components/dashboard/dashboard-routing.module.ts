import {NgModule} from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard.component';
import { PlansByUserResolver } from 'src/app/resolvers/plans-by-user.resolver';

const routes: Routes = [
  {
    path: '',
    component: DashboardComponent,
    data: {
      icon: 'icon-layout-sidebar-left',
      status: true
    },
    resolve:{
      plans:PlansByUserResolver
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
