import { DatatableColumn, DatatableAction } from '../../../models/datatable-column.model';
import { Component, OnInit, ViewChild } from '@angular/core';
import { AlertService, MessageSeverity } from '../../../services/alert.service';
import { TermsAndConditionsService } from '../../../services/terms-and-conditions.service';
import { DatatableComponent } from '../../datatable/datatable/datatable.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-terms-and-conditions-list',
  templateUrl: './terms-and-conditions-list.component.html',
  styleUrls: ['./terms-and-conditions-list.component.scss']
})
export class TermsAndConditionsListComponent implements OnInit {

  constructor(public service: TermsAndConditionsService, public alertService: AlertService) { }
  public columns: DatatableColumn[] = [];
  public actions: DatatableAction[] = [];
  @ViewChild("modalDefault") deleteModal: any;
  @ViewChild("dataTable") dt: DatatableComponent;
  
  deletedid: number;
  private self: any;

  ngOnInit() {
    this.setupColumns();
    
  }

  setupColumns() {
    var col = new DatatableColumn("publishedDate", "Fecha de publicación");
    col["datePipe"] = "d/M/yy, h:mm a";
    this.columns.push(col);
    var col = new DatatableColumn("version", "Versión");
    this.columns.push(col);
    var col = new DatatableColumn("published", "Publicado");
    col["booleanPipe"] = true;
    this.columns.push(col);
    var col = new DatatableColumn("active", "Activo");
    col["booleanPipe"] = true;
    this.columns.push(col);
    this.actions.push(new DatatableAction("arrow_upward", this.publish, true, "Publicar", "publishable"))
    this.actions.push(new DatatableAction("visibility", this.detail, true, "Detalle"))
  }

  deleteCatcher(id: number) {
    this.deletedid = id;

    this.deleteModal.show();
  }
  confirmDeleted(id: number) {
    this.service.delete(this.deletedid).subscribe(result => {
      this.dt.update();
      this.deleteModal.hide();
      this.alertService.showMessage("Términos y Condiciones", "Se ha borrado con exito", MessageSeverity.success);
  //    this.notification.addToast({ title: 'Paciente borrado', msg: 'El paciente ha sido borrado con exito', showClose: true, timeout: 5000, theme: 'bootstrap', type: 'default', position: 'top-right', closeOther: true })
    }, error => {
      this.alertService.showMessage("Términos y Condiciones", "No se han podido borrar los términos y condiciones", MessageSeverity.error);
      this.deleteModal.hide();
      }
    );
    
  }

  publish(id: number, router: Router, service: any, alertService: AlertService, dt: DatatableComponent) {
    service.publish(id).subscribe(x => {
      dt.update();
      alertService.showMessage("Términos y Condiciones", "Se ha publicado con éxito", MessageSeverity.success);
    }, error => {
      alertService.showMessage("Términos y Condiciones", "No se ha podido publicar", MessageSeverity.error);
    });
  }

  edit(id: number, router: Router) {
    router.navigate(['/terms-and-conditions/detail'], { queryParams: { id:id } });
  }

  detail(id: number, router: Router) {
    router.navigate(['/terms-and-conditions/detail'], { queryParams: { id: id, detail:true } });
  }
    
}
