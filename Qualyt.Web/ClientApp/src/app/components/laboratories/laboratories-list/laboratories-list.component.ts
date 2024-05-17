import { Component, OnInit, ViewChild } from '@angular/core';
import { Laboratory } from '../../../models/laboratory.model';
import { ActivatedRoute, Router } from '@angular/router';
import { LaboratoriesService } from '../../../services/laboratories.service';
import { AlertService, MessageSeverity } from '../../../services/alert.service';
import { DatatableColumn } from '../../../models/datatable-column.model';
import { DatatableComponent } from '../../datatable/datatable/datatable.component';

@Component({
  selector: 'app-laboratories-list',
  templateUrl: './laboratories-list.component.html',
  styleUrls: ['./laboratories-list.component.scss']
})
export class LaboratoriesListComponent implements OnInit {

  constructor(public service: LaboratoriesService, public alertService: AlertService) { }
  public columns: DatatableColumn[] = [];
  @ViewChild("modalDefault") deleteModal: any;
  @ViewChild("dataTable") dt: DatatableComponent;

  deletedid: number;

  ngOnInit() {
    this.setupColumns();
  }

  setupColumns() {
    this.columns.push(new DatatableColumn("name", "Nombre"));
  }

  deleteCatcher(id: number) {
    this.deletedid = id;

    this.deleteModal.show();
  }
  confirmDeleted(id: number) {
    this.service.delete(this.deletedid).subscribe(result => {
      this.dt.update();
      this.deleteModal.hide();
      this.alertService.showMessage("Laboratorios", "Se ha borrado con exito", MessageSeverity.success);
    }, error => {
      this.alertService.showMessage("Laboratorios", "No se ha podido borrar el laboratorio", MessageSeverity.error);
      console.log(error);
      this.deleteModal.hide();
    }
    );

  }

}
