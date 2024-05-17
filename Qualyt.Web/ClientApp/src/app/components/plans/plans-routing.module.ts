import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PlansListComponent } from './plans-list/plans-list.component';
import { PlansDetailComponent } from './plans-detail/plans-detail.component';

const routes: Routes = [
  {
    path: '',
    component: PlansListComponent,
    data: {
      title: 'Programas',
      icon: 'icon-layout-sidebar-left',
      caption: 'Desde esta pagina vas a poder crear, modificar y dar de baja los distintos programas.',
      status: true
    }
  },
  {
    path: 'detail',
    component: PlansDetailComponent,
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
export class PlansRoutingModule { }
