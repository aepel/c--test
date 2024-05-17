import { Component, OnInit } from '@angular/core';
import { Pathology } from '../../../models/pathology.model';
import { Laboratory } from '../../../models/laboratory.model';
import { ActivatedRoute, Router } from '@angular/router';
import { LaboratoriesService } from '../../../services/laboratories.service';
import { PathologiesService } from '../../../services/pathologies.service';
import { AlertService, MessageSeverity } from '../../../services/alert.service';

@Component({
  selector: 'app-pathologies-detail',
  templateUrl: './pathologies-detail.component.html',
  styleUrls: ['./pathologies-detail.component.scss']
})
export class PathologiesDetailComponent implements OnInit {

  public pathology?: Pathology;

  public laboratories: Laboratory[];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private laboratoriesService: LaboratoriesService,
    private service: PathologiesService,
    private alertService: AlertService
  ) {
  }
  doSearch(pacienteId: number): void {
    this.service.getOne(pacienteId).subscribe(result => {
      this.pathology = result as Pathology;
    }
      , error => console.error(error)
    );
  }

  ngOnInit(): void {
    this.laboratoriesService.getAll().subscribe(result => {
      this.laboratories = result as Laboratory[];
    });
    this.route.queryParams.subscribe(params => {
      this.pathology = new Pathology();
      if (params['id']) {
        this.doSearch(params['id'])
      }

    });
  }

  onSubmit(valid: boolean) {
    if (!valid)
      return;

    this.pathology["serializedFields"]=undefined;

    if (this.pathology) {

      if (this.pathology.id == null) {

        this.service.insert(this.pathology).subscribe(
          result => {
            var paciente = result as Pathology;
            this.router.navigate(['/pathologies']);
            this.alertService.showMessage("Patologías", "Actualización exitosa", MessageSeverity.success);
          }
          , response => {
            this.alertService.showMessage("Patologías", response.error.errors[0].message, MessageSeverity.error);
          });
      }
      else {
        this.service.update(this.pathology).subscribe(result => {
          this.router.navigate(['/pathologies']);
          this.alertService.showMessage("Patologías", "Actualización exitosa", MessageSeverity.success);
        }
          , response => {
            this.alertService.showMessage("Patologías", response.error.errors[0].message, MessageSeverity.error);
          });
      }
    }

  }
}
