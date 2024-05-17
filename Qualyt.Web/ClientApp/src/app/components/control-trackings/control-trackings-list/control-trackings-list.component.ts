import { Component, OnInit, ViewChild } from '@angular/core';
import { DatatableColumn, KeyValue, DatatableColor } from '../../../models/datatable-column.model';
import { ControlTrackingsService } from '../../../services/control-trackings.service';
import { ActivatedRoute } from '@angular/router';
import { DatatableComponent } from '../../datatable/datatable/datatable.component';
import { InfoTreatmentComponent } from '../../info-treatment/info-treatment/info-treatment.component';
import { AlertService, MessageSeverity } from '../../../services/alert.service';
import { TreatmentsService } from '../../../services/treatments.service';
import { Treatment } from '../../../models/treatment.model';
import { TreatmentState, PatientState, ControlType } from '../../../models/enums.model';
import { NgxRolesService } from 'ngx-permissions';

@Component({
  selector: 'app-control-trackings-list',
  templateUrl: './control-trackings-list.component.html',
  styleUrls: ['./control-trackings-list.component.scss']
})
export class ControlTrackingsListComponent implements OnInit {

  datatableParams: KeyValue[] = []
  @ViewChild("modalDefault") deleteModal: any;
  @ViewChild("dataTable") dt: DatatableComponent;
  @ViewChild("infoTreatment") infoTreatment: InfoTreatmentComponent;
  deletedid: number;
  treatment: Treatment;
  TreatmentState = TreatmentState;
  PatientState = PatientState;
  ControlType = ControlType;
  isAdmin: boolean;
  isLaboratory: boolean=true;
  public columns: DatatableColumn[] = [];
  public colors: DatatableColor[] = [];

  constructor(private route: ActivatedRoute,
    public service: ControlTrackingsService,
    private rolesService: NgxRolesService,
    public serviceTreatment: TreatmentsService,
    public alertService: AlertService) { }


  ngOnInit() {
    this.rolesService.hasOnlyRoles("ADMIN").then(x => {
      this.isAdmin = x;
    });
    this.rolesService.hasOnlyRoles("LABORATORIO").then(x => {
      this.isLaboratory = x;
    });
    var col = new DatatableColumn("createdDate", "Fecha de creación");
    col["datePipe"] = "d/M/yy";
    this.columns.push(col);
    var col = new DatatableColumn("nextControl", "Próximo seguimiento");
    col["datePipe"] = "d/M/yy";
    this.columns.push(col);
    this.columns.push(new DatatableColumn("comments", "Comentarios"));
    this.columns.push(new DatatableColumn("createdByUser.userName", "Operador"));

    this.colors.push(new DatatableColor("startRegister","#28a745"));
    this.colors.push(new DatatableColor("endRegister", "#dc3545"));

    this.route.queryParams.subscribe(params => {
      if (params && params["treatmentId"]) {
        this.datatableParams.push(new KeyValue("treatmentId", params["treatmentId"]))
        this.searchTreatment(params["treatmentId"]); 
      }
    });
  }

  searchTreatment(id){
    this.serviceTreatment.getById(id).subscribe(treatment => {
      this.treatment = treatment as Treatment;
    });
  }

  deleteCatcher(id: number) {
    this.deletedid = id;
    this.deleteModal.show();
  }
  confirmDeleted(id: number) {
    this.service.delete(this.deletedid).subscribe(result => {
      this.dt.update();
      this.infoTreatment.update();
      this.searchTreatment(this.treatment.id);
      this.deleteModal.hide();
      this.alertService.showMessage("Seguimientos", "Se ha borrado con éxito", MessageSeverity.success);
      //    this.notification.addToast({ title: 'Paciente borrado', msg: 'El paciente ha sido borrado con exito', showClose: true, timeout: 5000, theme: 'bootstrap', type: 'default', position: 'top-right', closeOther: true })
    }, error => {
      this.alertService.showMessage("Seguimientos", "No se ha podido borrar con éxito", MessageSeverity.error);
      console.log(error);
      this.deleteModal.hide();
    }
    );

  }
  }
