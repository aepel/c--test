import { Component, OnInit, ViewChild } from '@angular/core';
import { PatientsService } from '../../../services/patients.service';
import { DatatableColumn, DatatableAction } from '../../../models/datatable-column.model';
import { DatatableComponent } from '../../datatable/datatable/datatable.component';
import { AlertService, MessageSeverity } from '../../../services/alert.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-patients-list',
  templateUrl: './patients-list.component.html',
  styleUrls: ['./patients-list.component.scss']
})
export class PatientsListComponent implements OnInit {

  constructor(public service: PatientsService, public alertService: AlertService) { }
  public columns: DatatableColumn[] = [];
  public actions: DatatableAction[] = [];
  @ViewChild("modalDefault") deleteModal: any;
  @ViewChild("dataTable") dt: DatatableComponent;
  
  deletedid: number;

  ngOnInit() {
    this.setupColumns();
  }

  setupColumns() {
    this.columns.push(new DatatableColumn("code", "Codigo"));
    this.columns.push(new DatatableColumn("fullName", "Nombre completo"));
    this.columns.push(new DatatableColumn("doctor.fullName", "Médico"));
    this.columns.push(new DatatableColumn("plan.name", "Programa"));
    this.columns.push(new DatatableColumn("healthInsurance.name", "Seguro medico"));
    var col = new DatatableColumn("stateName", "Estado");
    this.columns.push(col);
    var col = new DatatableColumn("active", "Activo");
    col["booleanPipe"] = true;
    this.columns.push(col);
    var self = this;
    this.actions.push(new DatatableAction("assignment_ind", this.clinicalHistoryCatcher, true, "Historia clínica"));
    this.actions.push(new DatatableAction("import_export",
      function (id: number) {
        self.service.toggleActive(id).subscribe(x =>self.dt.update());
      }
      , true, "Activar/Desactivar"));
  }

  deleteCatcher(id: number) {
    this.deletedid = id;

    this.deleteModal.show();
  }
  confirmDeleted(id: number) {
    this.service.delete(this.deletedid).subscribe(result => {
      this.dt.update();
      this.deleteModal.hide();
      this.alertService.showMessage("Pacientes", "Se ha borrado con exito", MessageSeverity.success);
    }, error => {
      this.alertService.showMessage("Pacientes", "No se ha podido borrar al paciente", MessageSeverity.error);
      console.log(error);
      this.deleteModal.hide();
      }
    );
    
  }

  clinicalHistoryCatcher(id: number, router: Router) {
    router.navigate(['/patients/clinical-history'], { queryParams: { id: id } });
  }

  toggleActive(id: number, router: Router) {
  }

    
}
