import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TermsAndConditionsListComponent } from './terms-and-conditions-list/terms-and-conditions-list.component';
import { TermsAndConditionsDetailComponent } from './terms-and-conditions-detail/terms-and-conditions-detail.component';
import { TermsAndConditionsAcceptanceComponent } from './terms-and-conditions-acceptance/terms-and-conditions-acceptance.component';

const routes: Routes = [
  {
    path: '',
    component: TermsAndConditionsListComponent,
    data: {
      title: 'Términos y condiciones',
      icon: 'icon-layout-sidebar-left',
      caption: 'Desde esta pagina vas a poder crear, modificar y publicar las distintas versiones de términos y condiciones.',
      status: true
    }
  },
  {
    path: 'detail',
    component: TermsAndConditionsDetailComponent,
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
export class TermsAndConditionsRoutingModule { }
