import { Component, OnInit, ViewChild } from '@angular/core';
import { PlansService } from '../../../services/plans.service';
import { AlertService, MessageSeverity } from '../../../services/alert.service';
import { DatatableColumn } from '../../../models/datatable-column.model';
import { DatatableComponent } from '../../datatable/datatable/datatable.component';

@Component({
  selector: 'app-plans-list',
  templateUrl: './plans-list.component.html',
  styleUrls: ['./plans-list.component.scss']
})
export class PlansListComponent implements OnInit {

  constructor(public service: PlansService, public alertService: AlertService) { }
  public columns: DatatableColumn[] = [];
  @ViewChild("modalDefault") deleteModal: any;
  @ViewChild("dataTable") dt: DatatableComponent;

  deletedid: number;

  ngOnInit() {
    this.setupColumns();
  }

  setupColumns() {
    this.columns.push(new DatatableColumn("name", "Nombre"));
    this.columns.push(new DatatableColumn("laboratory.name", "Laboratorio"));
    this.columns.push(new DatatableColumn("country.name", "País"));
    var col = new DatatableColumn("start", "Fecha de inicio");
    col["datePipe"] = "d/M/yy, h:mm a";
    this.columns.push(col);
    col = new DatatableColumn("end", "Fecha de cierre");
    col["datePipe"] = "d/M/yy, h:mm a";
    this.columns.push(col);
  }

  deleteCatcher(id: number) {
    this.deletedid = id;

    this.deleteModal.show();
  }
  confirmDeleted(id: number) {
    this.service.delete(this.deletedid).subscribe(result => {
      this.dt.update();
      this.deleteModal.hide();
      this.alertService.showMessage("Programas", "Se ha borrado con exito", MessageSeverity.success);
    }, error => {
      this.alertService.showMessage("Programas", "No se ha podido borrar el programa", MessageSeverity.error);
      console.log(error);
      this.deleteModal.hide();
    }
    );

  }

}
