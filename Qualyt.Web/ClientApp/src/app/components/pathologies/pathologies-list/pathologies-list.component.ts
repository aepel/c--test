import { Component, OnInit, ViewChild } from '@angular/core';
import { PathologiesService } from '../../../services/pathologies.service';
import { DatatableColumn } from '../../../models/datatable-column.model';
import { AlertService, MessageSeverity } from '../../../services/alert.service';
import { DatatableComponent } from '../../datatable/datatable/datatable.component';

@Component({
  selector: 'app-pathologies-list',
  templateUrl: './pathologies-list.component.html',
  styleUrls: ['./pathologies-list.component.scss']
})
export class PathologiesListComponent implements OnInit {

  constructor(public service: PathologiesService, public alertService: AlertService) { }
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
  }

  deleteCatcher(id: number) {
    this.deletedid = id;

    this.deleteModal.show();
  }
  confirmDeleted(id: number) {
    this.service.delete(this.deletedid).subscribe(result => {
      this.dt.update();
      this.deleteModal.hide();
      this.alertService.showMessage("Patologías", "Se ha borrado con exito", MessageSeverity.success);
      //    this.notification.addToast({ title: 'Paciente borrado', msg: 'El paciente ha sido borrado con exito', showClose: true, timeout: 5000, theme: 'bootstrap', type: 'default', position: 'top-right', closeOther: true })
    }, error => {
      this.alertService.showMessage("Patologías", "No se ha podido borrar la patología", MessageSeverity.error);
      console.log(error);
      this.deleteModal.hide();
    }
    );

  }

}
