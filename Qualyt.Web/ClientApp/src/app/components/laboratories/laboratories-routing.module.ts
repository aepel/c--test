import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LaboratoriesListComponent } from './laboratories-list/laboratories-list.component';
import { LaboratoriesDetailComponent } from './laboratories-detail/laboratories-detail.component';

const routes: Routes = [
  {
    path: '',
    component: LaboratoriesListComponent,
    data: {
      title: 'Laboratorios',
      icon: 'icon-layout-sidebar-left',
      caption: 'Desde esta pagina vas a poder crear, modificar y dar de baja a los distintos laboratorios.',
      status: true
    }
  },
  {
    path: 'detail',
    component: LaboratoriesDetailComponent,
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
export class LaboratoriesRoutingModule { }
