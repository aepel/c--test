import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UsersListComponent } from './users-list/users-list.component';
import { UsersDetailComponent } from './users-detail/users-detail.component';
import { NgxPermissionsGuard } from 'ngx-permissions';
import { AuthGuard } from 'src/app/auth/auth.guard';

const routes: Routes = [
  {
    path: '',
    component: UsersListComponent,
    canActivate: [AuthGuard, NgxPermissionsGuard],
    data: {
      title: 'Usuarios',
      icon: 'icon-layout-sidebar-left',
      caption: 'Desde esta pagina vas a poder crear, modificar y dar de baja los distintos usuarios.',
      status: true,
      permissions: {
        only: ['ADMIN'],
        redirectTo: '/dashboard'
      }
    }
  },
  {
    path: 'detail',
    component: UsersDetailComponent,
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
export class UsersRoutingModule { }
