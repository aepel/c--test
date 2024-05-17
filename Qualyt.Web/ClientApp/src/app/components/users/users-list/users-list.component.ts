import { Component, OnInit, ViewChild } from '@angular/core';
import { UsersService } from 'src/app/services/users.service';
import { AlertService } from 'src/app/services/alert.service';
import { DatatableColumn } from 'src/app/models/datatable-column.model';
import { DatatableComponent } from '../../datatable/datatable/datatable.component';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.scss']
})
export class UsersListComponent implements OnInit {

  constructor(public service: UsersService, public alertService: AlertService) { }
  public columns: DatatableColumn[] = [];
  @ViewChild("dataTable") dt: DatatableComponent;

  deletedid: number;

  ngOnInit() {
    this.setupColumns();
  }

  setupColumns() {
    this.columns.push(new DatatableColumn("email", "Email"));
    this.columns.push(new DatatableColumn("fullName", "Nombre"));
    var col = new DatatableColumn("enabled", "Habilitado");
    col["booleanPipe"] = true;
    this.columns.push(col);
  }
}
