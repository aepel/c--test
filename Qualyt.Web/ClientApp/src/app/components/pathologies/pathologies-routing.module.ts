import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PathologiesListComponent } from './pathologies-list/pathologies-list.component';
import { PathologiesDetailComponent } from './pathologies-detail/pathologies-detail.component';

const routes: Routes = [
  {
    path: '',
    component: PathologiesListComponent,
    data: {
      title: 'Patologías',
      icon: 'icon-layout-sidebar-left',
      caption: 'Desde esta pagina vas a poder crear, modificar y dar de baja las distintas patologías.',
      status: true
    }
  },
  {
    path: 'detail',
    component: PathologiesDetailComponent,
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
export class PathologiesRoutingModule { }
