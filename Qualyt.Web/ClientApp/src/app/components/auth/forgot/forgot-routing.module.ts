import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {forgotComponent} from './forgot.component';

const routes: Routes = [
  {
    path: '',
    component: forgotComponent,
    data: {
      title: 'Forgot'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ForgotRoutingModule { }
