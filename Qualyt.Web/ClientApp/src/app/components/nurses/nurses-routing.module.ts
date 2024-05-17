import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NursesListComponent } from './nurses-list/nurses-list.component';
import { NursesDetailComponent } from './nurses-detail/nurses-detail.component';

const routes: Routes = [
  {
    path: '',
    component: NursesListComponent,
    data: {
      title: 'Enfermeras/os',
      icon: 'icon-layout-sidebar-left',
      caption: 'Desde esta pagina vas a poder crear, modificar y dar de baja a las/los distintas/os enfermeras/os.',
      status: true
    }
  },
  {
    path: 'detail',
    component: NursesDetailComponent,
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
export class NursesRoutingModule { }
