import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BasicLoginComponent } from './components/auth/login/basic-login/basic-login.component';
import { AdminComponent } from './layout/admin/admin.component';
import { AuthGuard } from './auth/auth.guard';
import { TermsAndConditionsAcceptanceComponent } from './components/terms-and-conditions/terms-and-conditions-acceptance/terms-and-conditions-acceptance.component';
import { NgxPermissionsGuard } from 'ngx-permissions';
import { ResetPaswwordComponent } from './components/auth/login/reset-paswword/reset-paswword.component';


const routes: Routes = [
  {
    path: '',
    component: BasicLoginComponent,
  },
  {
    path: 'ResetPassword',
    component: ResetPaswwordComponent,
  },
  {
    path: 'acceptance',
    component: TermsAndConditionsAcceptanceComponent,
  },
  {
    path: 'dashboard',
    component: AdminComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: '',
        loadChildren: './components/dashboard/dashboard.module#DashboardModule'
        
      }
    ]
  },
  {
    path: 'pathologies',
    component: AdminComponent,
    canActivate: [AuthGuard, NgxPermissionsGuard],
    data: {
      permissions: {
        only: ['ADMIN'],
        redirectTo: 'dashboard'
      }
    },
    children: [
      {
        path: '',
        loadChildren: './components/pathologies/pathologies.module#PathologiesModule'
      }
    ]
  },
  {
    path: 'treatments',
    component: AdminComponent,
    canActivate: [AuthGuard, NgxPermissionsGuard],
    data: {
      permissions: {
        only: ['ADMIN','OPERADOR','LABORATORIO'],
        redirectTo: 'dashboard'
      }
    },
    children: [
      {
        path: '',
        loadChildren: './components/treatments/treatments.module#TreatmentsModule'
      }
    ]
  },
  {
    path: 'control-trackings',
    canActivate: [AuthGuard, NgxPermissionsGuard],
    data: {
      permissions: {
        only: ['ADMIN','OPERADOR','LABORATORIO'],
        redirectTo: 'dashboard'
      }
    },
    component: AdminComponent,
    children: [
      {
        path: '',
        loadChildren: './components/control-trackings/control-trackings.module#ControlTrackingsModule'
      }
    ]
  },
  {
    path: 'patients',
    component: AdminComponent,
    canActivate: [AuthGuard, NgxPermissionsGuard],
    data: {
      permissions: {
        only: ['ADMIN', 'OPERADOR'],
        redirectTo: 'dashboard'
      }
    },
    children: [
      {
        path: '',
        loadChildren: './components/patients/patients.module#PatientsModule'
      }
    ]
  },
  {
    path: 'plans',
    component: AdminComponent,
    canActivate: [AuthGuard, NgxPermissionsGuard],
    data: {
      permissions: {
        only: ['ADMIN'],
        redirectTo: 'dashboard'
      }
    },
    children: [
      {
        path: '',
        loadChildren: './components/plans/plans.module#PlansModule'
      }
    ]
  },
  {
    path: 'nurses',
    component: AdminComponent,
    canActivate: [AuthGuard, NgxPermissionsGuard],
    data: {
      permissions: {
        only: ['ADMIN'],
        redirectTo: 'dashboard'
      }
    },
    children: [
      {
        path: '',
        loadChildren: './components/nurses/nurses.module#NursesModule'
      }
    ]
  },
  {
    path: 'sales-contacts',
    component: AdminComponent,
    canActivate: [AuthGuard, NgxPermissionsGuard],
    data: {
      permissions: {
        only: ['ADMIN'],
        redirectTo: 'dashboard'
      }
    },
    children: [
      {
        path: '',
        loadChildren: './components/sales-contacts/sales-contacts.module#SalesContactsModule'
      }
    ]
  },
  {
    path: 'doctors',
    component: AdminComponent,
    canActivate: [AuthGuard, NgxPermissionsGuard],
    data: {
      permissions: {
        only: ['ADMIN'],
        redirectTo: 'dashboard'
      }
    },
    children: [
      {
        path: '',
        loadChildren: './components/doctors/doctors.module#DoctorsModule'
      }
    ]
  },
  {
    path: 'users',
    component: AdminComponent,
    canActivate: [AuthGuard, NgxPermissionsGuard],
    data: {
      permissions: {
        only: ['ADMIN','OPERADOR'],
        redirectTo: 'dashboard'
      }
    },
    children: [
      {
        path: '',
        loadChildren: './components/users/users.module#UsersModule'
      }
    ]
  },
  {
    path: 'laboratories',
    component: AdminComponent,
    canActivate: [AuthGuard, NgxPermissionsGuard],
    data: {
      permissions: {
        only: ['ADMIN'],
        redirectTo: 'dashboard'
      }
    },
    children: [
      {
        path: '',
        loadChildren: './components/laboratories/laboratories.module#LaboratoriesModule'
      }
    ]
  },
  {
    path: 'products',
    component: AdminComponent,
    canActivate: [AuthGuard, NgxPermissionsGuard],
    data: {
      permissions: {
        only: ['ADMIN'],
        redirectTo: 'dashboard'
      }
    },
    children: [
      {
        path: '',
        loadChildren: './components/products/products.module#ProductsModule'
      }
    ]
  },
  {
    path: 'health-insurances',
    component: AdminComponent,
    canActivate: [AuthGuard, NgxPermissionsGuard],
    data: {
      permissions: {
        only: ['ADMIN'],
        redirectTo: 'dashboard'
      }
    },
    children: [
      {
        path: '',
        loadChildren: './components/health-insurances/health-insurances.module#HealthInsurancesModule'
      }
    ]
  },
  {
    path: 'terms-and-conditions',
    component: AdminComponent,
    canActivate: [AuthGuard, NgxPermissionsGuard],
    data: {
      permissions: {
        only: ['ADMIN'],
        redirectTo: 'dashboard'
      }
    },
    children: [
      {
        path: '',
        loadChildren: './components/terms-and-conditions/terms-and-conditions.module#TermsAndConditionsModule'
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
