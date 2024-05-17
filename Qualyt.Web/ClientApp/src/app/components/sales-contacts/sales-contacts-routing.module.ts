import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SalesContactsListComponent } from './sales-contacts-list/sales-contacts-list.component';
import { SalesContactsDetailComponent } from './sales-contacts-detail/sales-contacts-detail.component';

const routes: Routes = [
  {
    path: '',
    component: SalesContactsListComponent,
    data: {
      title: 'Representantes',
      icon: 'icon-layout-sidebar-left',
      caption: 'Desde esta pagina vas a poder crear, modificar y dar de baja a los distintos representantes.',
      status: true
    }
  },
  {
    path: 'detail',
    component: SalesContactsDetailComponent,
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
export class SalesContactsRoutingModule { }
