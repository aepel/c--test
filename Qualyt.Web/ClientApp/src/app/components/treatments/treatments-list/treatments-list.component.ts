import { Component, OnInit, ViewChild } from '@angular/core';
import { DatatableColumn, DatatableAction } from '../../../models/datatable-column.model';
import { TreatmentsService } from '../../../services/treatments.service';
import { Router } from '@angular/router';
import { AlertService, MessageSeverity } from '../../../services/alert.service';
import { NgxRolesService } from 'ngx-permissions';
import { DatatableComponent } from '../../datatable/datatable/datatable.component';

@Component({
  selector: 'app-treatments-list',
  templateUrl: './treatments-list.component.html',
  styleUrls: ['./treatments-list.component.scss']
})
export class TreatmentsListComponent implements OnInit {

  constructor(public service: TreatmentsService,
    public _router: Router,
    private rolesService: NgxRolesService,
    public alertService: AlertService) {
    this.router = _router;
  }


  public columns: DatatableColumn[] = [];
  public actions: DatatableAction[] = [];
  public router: Router;
  @ViewChild("modalDefault") deleteModal: any;
  @ViewChild("dataTable") dt: DatatableComponent;
  deletedid: number;
  tableReady:boolean;
  isLaboratory:boolean;

  ngOnInit() {
    this.rolesService.hasOnlyRoles("LABORATORIO").then(isLaboratory => {
      this.isLaboratory=isLaboratory;
      if (isLaboratory)
        this.columns.push(new DatatableColumn("patient.code", "Paciente"));
      else
        this.columns.push(new DatatableColumn("patient.fullName", "Paciente"));
      this.columns.push(new DatatableColumn("doctor.fullName", "Médico"));
      this.columns.push(new DatatableColumn("pathology.name", "Patología"));
      this.columns.push(new DatatableColumn("stateName", "Estado"));
      var col = new DatatableColumn("createdDate", "Fecha de creación");
      col["datePipe"] = "d/M/yy, h:mm a";
      this.columns.push(col);
      this.actions.push(new DatatableAction("list", this.controlsList, true, "Seguimientos"));
      this.actions.push(new DatatableAction("visibility", this.treatmentSummary, true, "Detalle"));
      this.tableReady=true;
    });
  }

  deleteCatcher(id: number) {
    this.deletedid = id;
    this.deleteModal.show();
  }

  confirmDeleted(id: number) {
    this.service.delete(this.deletedid).subscribe(result => {
      this.dt.update();
      this.deleteModal.hide();
      this.alertService.showMessage("Tratamientos", "Se ha borrado con éxito", MessageSeverity.success);
    }, error => {
      this.alertService.showMessage("Tratamientos", "No se ha podido borrar con éxito", MessageSeverity.error);
      console.log(error);
      this.deleteModal.hide();
    }
    );

  }

  controlsList(id: number, router: Router) {
    router.navigate(['/control-trackings'], { queryParams: { treatmentId: id } });
  }

  treatmentSummary(id: number, router: Router) {
    router.navigate(['/treatments/treatment-summary'], { queryParams: { treatmentId: id, disabled: true, } });
  }

}
