import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DoctorsDetailComponent } from './doctors-detail/doctors-detail.component';
import { DoctorsListComponent } from './doctors-list/doctors-list.component';

const routes: Routes = [
  {
    path: '',
    component: DoctorsListComponent,
    data: {
      title: 'Médicas/os',
      icon: 'icon-layout-sidebar-left',
      caption: 'Desde esta pagina vas a poder crear, modificar y dar de baja a las/os distintas/os médicas/os.',
      status: true
    }
  },
  {
    path: 'detail',
    component: DoctorsDetailComponent,
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
export class DoctorsRoutingModule { }
