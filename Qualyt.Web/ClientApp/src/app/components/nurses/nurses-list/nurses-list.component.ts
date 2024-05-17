import { Component, OnInit, ViewChild } from '@angular/core';
import { NursesService } from '../../../services/nurses.service';
import { DatatableColumn } from '../../../models/datatable-column.model';
import { DatatableComponent } from '../../datatable/datatable/datatable.component';
import { AlertService, MessageSeverity } from '../../../services/alert.service';

@Component({
  selector: 'app-nurses-list',
  templateUrl: './nurses-list.component.html',
  styleUrls: ['./nurses-list.component.scss']
})

export class NursesListComponent implements OnInit {

  constructor(public service: NursesService, public alertService: AlertService) { }
  public columns: DatatableColumn[] = [];
  @ViewChild("modalDefault") deleteModal: any;
  @ViewChild("dataTable") dt: DatatableComponent;

  deletedid: number;

  ngOnInit() {
    this.setupColumns();
  }

  setupColumns() {
    this.columns.push(new DatatableColumn("fullName", "Nombre completo"));
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
      this.alertService.showMessage("Enfermeras/os", "Se ha borrado con exito", MessageSeverity.success);
    }, error => {
      this.alertService.showMessage("Enfermeras/os", "No se ha podido borrar la/el enfermera/o", MessageSeverity.error);
      console.log(error);
      this.deleteModal.hide();
    }
    );

  }

}

