import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PatientsListComponent } from './patients-list/patients-list.component';
import { PatientsDetailComponent } from './patients-detail/patients-detail.component';
import { PatientsClinicalHistoryComponent } from './patients-clinical-history/patients-clinical-history.component';
import { PatientsDetailResolver } from '../../resolvers/patients-detail.resolver';
import { PathologiesResolver } from '../../resolvers/pathologies.resolver';
import { DoctorsResolver } from 'src/app/resolvers/doctors.resolver';
import { NursesResolver } from 'src/app/resolvers/nurses.resolver';
import { CountriesByUserResolver } from 'src/app/resolvers/countries-by-user.resolver';
import { HealthInsurancesResolver } from 'src/app/resolvers/health-insurances.resolver';

const routes: Routes = [
  {
    path: '',
    component: PatientsListComponent,
    data: {
      title: 'Pacientes',
      icon: 'icon-layout-sidebar-left',
      caption: 'Desde esta pagina vas a poder crear, modificar y dar de baja a los distintos pacientes.',
      status: true
    }
  },
  {
    path: 'detail',
    component: PatientsDetailComponent,
    resolve: 
    { 
      patient: PatientsDetailResolver,
      pathologies: PathologiesResolver,
      doctors: DoctorsResolver,
      nurses: NursesResolver,
      countries: CountriesByUserResolver,
      healthInsurances: HealthInsurancesResolver
    },
    data: {
      icon: 'icon-layout-sidebar-left',
      status: true
    }
  },
  {
    path: 'clinical-history',
    component: PatientsClinicalHistoryComponent,
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
export class PatientsRoutingModule { }
