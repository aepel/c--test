import { Component, OnInit, ViewChild } from '@angular/core';
import { ProductsService } from 'src/app/services/products.service';
import { AlertService, MessageSeverity } from 'src/app/services/alert.service';
import { DatatableColumn } from 'src/app/models/datatable-column.model';
import { DatatableComponent } from '../../datatable/datatable/datatable.component';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.scss']
})
export class ProductsListComponent implements OnInit {

  constructor(public service: ProductsService, public alertService: AlertService) { }
  public columns: DatatableColumn[] = [];
  @ViewChild("modalDefault") deleteModal: any;
  @ViewChild("dataTable") dt: DatatableComponent;

  deletedid: number;

  ngOnInit() {
    this.setupColumns();
  }

  setupColumns() {
    this.columns.push(new DatatableColumn("name", "Nombre"));
    this.columns.push(new DatatableColumn("code", "Código"));
    this.columns.push(new DatatableColumn("laboratory.name", "Laboratorio"));
    this.columns.push(new DatatableColumn("activeSubstance", "Principio activo"));
    this.columns.push(new DatatableColumn("deviceType", "Tipo de dispositivo"));
  }

  deleteCatcher(id: number) {
    this.deletedid = id;

    this.deleteModal.show();
  }
  confirmDeleted(id: number) {
    this.service.delete(this.deletedid).subscribe(result => {
      this.dt.update();
      this.deleteModal.hide();
      this.alertService.showMessage("Productos", "Se ha borrado con exito", MessageSeverity.success);
    }, error => {
      this.alertService.showMessage("Productos", "No se ha podido borrar el producto", MessageSeverity.error);
      console.log(error);
      this.deleteModal.hide();
    }
    );

  }

}
