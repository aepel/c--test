import { Component, OnInit, Input } from '@angular/core';
import { Treatment } from '../../../models/treatment.model';
import { ActivatedRoute } from '@angular/router';
import { TreatmentsService } from '../../../services/treatments.service';
import { NgxRolesService } from 'ngx-permissions';

@Component({
  selector: 'app-treatment-summary',
  templateUrl: './treatment-summary.component.html',
  styleUrls: ['./treatment-summary.component.scss']
})
export class TreatmentSummaryComponent implements OnInit {
  @Input() treatment: Treatment;
  @Input() disabled: boolean;
  @Input() noCard: boolean;
  isLaboratory: boolean;
   
  constructor(
    private route: ActivatedRoute,
    private rolesService: NgxRolesService,
    private treatmentsService: TreatmentsService
  ) { }

  ngOnInit() {
    this.rolesService.hasOnlyRoles("LABORATORIO").then(x => {
      this.isLaboratory = x;
    });
    this.route.queryParams.subscribe(params => {
      if(!this.treatment && params["treatmentId"]){
        if(params["disabled"])
          this.disabled=true;
        this.treatmentsService.getOne(params["treatmentId"]).subscribe(x=>{
          this.treatment=x as Treatment;
        });
      }
    });
  }

}
