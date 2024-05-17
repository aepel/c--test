import { Component, OnInit, ViewChild } from '@angular/core';
import { DoctorsService } from '../../../services/doctors.service';
import { AlertService, MessageSeverity } from '../../../services/alert.service';
import { DatatableColumn } from '../../../models/datatable-column.model';
import { DatatableComponent } from '../../datatable/datatable/datatable.component';

@Component({
  selector: 'app-doctors-list',
  templateUrl: './doctors-list.component.html',
  styleUrls: ['./doctors-list.component.scss']
})
export class DoctorsListComponent implements OnInit {

  constructor(public service: DoctorsService, public alertService: AlertService) { }
  public columns: DatatableColumn[] = [];
  @ViewChild("modalDefault") deleteModal: any;
  @ViewChild("dataTable") dt: DatatableComponent;

  deletedid: number;

  ngOnInit() {
    this.setupColumns();
  }

  setupColumns() {
    this.columns.push(new DatatableColumn("fullName", "Nombre completo"));
    this.columns.push(new DatatableColumn("salesContact.fullName", "Representante"));
    this.columns.push(new DatatableColumn("specialty.name", "Especialidad"));
    this.columns.push(new DatatableColumn("attentionPlace.name", "Lugar de atención"));
    this.columns.push(new DatatableColumn("country.name", "País"));
  }

  deleteCatcher(id: number) {
    this.deletedid = id;

    this.deleteModal.show();
  }
  confirmDeleted(id: number) {
    this.service.delete(this.deletedid).subscribe(result => {
      this.dt.update();
      this.deleteModal.hide();
      this.alertService.showMessage("Médicas/os", "Se ha borrado con exito", MessageSeverity.success);
    }, error => {
      this.alertService.showMessage("Médicas/os", "No se ha podido borrar la/el médica/o", MessageSeverity.error);
      console.log(error);
      this.deleteModal.hide();
    }
    );

  }

}
