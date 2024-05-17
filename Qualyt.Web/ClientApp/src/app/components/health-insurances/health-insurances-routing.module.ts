import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HealthInsurancesListComponent } from './health-insurances-list/health-insurances-list.component';
import { HealthInsurancesDetailComponent } from './health-insurances-detail/health-insurances-detail.component';

const routes: Routes = [
  {
    path: '',
    component: HealthInsurancesListComponent,
    data: {
      title: 'Seguros médicos',
      icon: 'icon-layout-sidebar-left',
      caption: 'Desde esta pagina vas a poder crear, modificar y dar de baja a las distintas compañias de seguros médicos.',
      status: true
    }
  },
  {
    path: 'detail',
    component: HealthInsurancesDetailComponent,
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
export class HealthInsurancesRoutingModule { }
