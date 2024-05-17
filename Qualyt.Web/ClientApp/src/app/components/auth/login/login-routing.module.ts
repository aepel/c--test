import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';

const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Login',
      status: false
    },
    children: [
      {
        path: 'forgot',
        loadChildren: '../forgot/forgot.module'
      },
      {
        path: 'recover',
        loadChildren: '../forgot/forgot.module'
      }

      
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LoginRoutingModule { }
