import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductsListComponent } from './products-list/products-list.component';
import { ProductsDetailComponent } from './products-detail/products-detail.component';

const routes: Routes = [
  {
    path: '',
    component: ProductsListComponent,
    data: {
      title: 'Productos',
      icon: 'icon-layout-sidebar-left',
      caption: 'Desde esta pagina vas a poder crear, modificar y dar de baja los distintos productos.',
      status: true
    }
  },
  {
    path: 'detail',
    component: ProductsDetailComponent,
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
export class ProductsRoutingModule { }
