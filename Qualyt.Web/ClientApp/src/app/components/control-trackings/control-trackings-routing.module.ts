import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ControlTrackingsListComponent } from './control-trackings-list/control-trackings-list.component';
import { ControlTrackingsDetailComponent } from './control-trackings-detail/control-trackings-detail.component';

const routes: Routes = [
  {
    path: '',
    component: ControlTrackingsListComponent,
    data: {
      icon: 'icon-layout-sidebar-left',
      status: true
    }
  },
  {
    path: 'detail',
    component: ControlTrackingsDetailComponent,
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
export class ControlTrackingsRoutingModule { }
