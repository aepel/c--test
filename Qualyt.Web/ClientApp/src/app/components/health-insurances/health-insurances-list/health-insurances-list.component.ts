import { Component, OnInit, ViewChild } from '@angular/core';
import { HealthInsurancesService } from '../../../services/health-insurance.service';
import { DatatableColumn } from '../../../models/datatable-column.model';
import { DatatableComponent } from '../../datatable/datatable/datatable.component';
import { AlertService, MessageSeverity } from '../../../services/alert.service';

@Component({
  selector: 'app-health-insurances-list',
  templateUrl: './health-insurances-list.component.html',
  styleUrls: ['./health-insurances-list.component.scss']
})
export class HealthInsurancesListComponent implements OnInit {

  constructor(public service: HealthInsurancesService, public alertService: AlertService) { }
  public columns: DatatableColumn[] = [];
  @ViewChild("modalDefault") deleteModal: any;
  @ViewChild("dataTable") dt: DatatableComponent;
  
  deletedid: number;

  ngOnInit() {
    this.setupColumns();
  }

  setupColumns() {
    this.columns.push(new DatatableColumn("name", "Nombre"));
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
      this.alertService.showMessage("Seguros médicos", "Se ha borrado con exito", MessageSeverity.success);
  //    this.notification.addToast({ title: 'Paciente borrado', msg: 'El paciente ha sido borrado con exito', showClose: true, timeout: 5000, theme: 'bootstrap', type: 'default', position: 'top-right', closeOther: true })
    }, error => {
      this.alertService.showMessage("Seguros médicos", "No se ha podido borrar al seguro médico", MessageSeverity.error);
      console.log(error);
      this.deleteModal.hide();
      }
    );
    
  }
    
}
