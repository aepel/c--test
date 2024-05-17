import { Component, OnInit } from '@angular/core';
import { Laboratory } from '../../../models/laboratory.model';
import { ActivatedRoute, Router } from '@angular/router';
import { LaboratoriesService } from '../../../services/laboratories.service';
import { AlertService, MessageSeverity } from '../../../services/alert.service';
import { AuthenticationService } from '../../../services/authentication.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-laboratories-detail',
  templateUrl: './laboratories-detail.component.html',
  styleUrls: ['./laboratories-detail.component.scss']
})
export class LaboratoriesDetailComponent implements OnInit {

  public laboratory?: Laboratory;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: LaboratoriesService,
    private alertService: AlertService,
    private authenticationService: AuthenticationService,
    private http: HttpClient
  ) { }

  doSearch(id: number): void {
    this.service.getOne(id).subscribe(result => {
      this.laboratory = result as Laboratory;
    }
      , error => console.error(error)
    );
  }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      if (params['id']) {
        this.doSearch(params['id'])
      }
      else {
        this.laboratory = new Laboratory();
        this.laboratory.color = "#62abff";
      }
    });
  }

  addHeaders(event) {
    event.xhr.setRequestHeader('Authorization', 'Bearer ' + this.authenticationService.accessToken);
  }

  downloadIcon(event) {
    let header = { headers: this.authenticationService.getRequestHTTPHeaders() };
    return this.http.get<any>('/api/Laboratories/downloadIcon?id=' + this.laboratory.id, header).subscribe(x => {
      this.laboratory.iconBytes = x as Int8Array;
    });
  }

  onSubmit(valid: boolean) {
    if (!valid)
      return;

    if (this.laboratory.id == null) {
      this.service.insert(this.laboratory).subscribe(
        result => {
          this.alertService.showMessage("Laboratorio", "Ahora puede seleccionar el color e icono del laboratorio.", MessageSeverity.info);
          this.laboratory = result as Laboratory;
        }
        , response => {
          this.alertService.showMessage("Laboratorio", response.error.errors[0].message, MessageSeverity.error);
        });
    }
    else {
      this.service.update(this.laboratory).subscribe(result => {
        this.alertService.showMessage("Laboratorio", "Actualización exitosa", MessageSeverity.success);
        this.router.navigate(['/laboratories']);
      }
        , response => {
          this.alertService.showMessage("Laboratorio", response.error.errors[0].message, MessageSeverity.error);
        });
    }

  }
}
