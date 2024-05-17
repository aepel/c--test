import { Component, OnInit, ViewChild } from '@angular/core';
import { SalesContactsService } from '../../../services/sales-contacts.service';
import { AlertService, MessageSeverity } from '../../../services/alert.service';
import { DatatableColumn } from '../../../models/datatable-column.model';
import { DatatableComponent } from '../../datatable/datatable/datatable.component';

@Component({
  selector: 'app-sales-contacts-list',
  templateUrl: './sales-contacts-list.component.html',
  styleUrls: ['./sales-contacts-list.component.scss']
})
export class SalesContactsListComponent implements OnInit {

  constructor(public service: SalesContactsService, public alertService: AlertService) { }
  public columns: DatatableColumn[] = [];
  @ViewChild("modalDefault") deleteModal: any;
  @ViewChild("dataTable") dt: DatatableComponent;

  deletedid: number;

  ngOnInit() {
    this.setupColumns();
  }

  setupColumns() {
    this.columns.push(new DatatableColumn("fullName", "Nombre completo"));
  }

  deleteCatcher(id: number) {
    this.deletedid = id;

    this.deleteModal.show();
  }
  confirmDeleted(id: number) {
    this.service.delete(this.deletedid).subscribe(result => {
      this.dt.update();
      this.deleteModal.hide();
      this.alertService.showMessage("Representantes", "Se ha borrado con exito", MessageSeverity.success);
    }, error => {
      this.alertService.showMessage("Representantes", "No se ha podido borrar el representante", MessageSeverity.error);
      console.log(error);
      this.deleteModal.hide();
    }
    );

  }

}


