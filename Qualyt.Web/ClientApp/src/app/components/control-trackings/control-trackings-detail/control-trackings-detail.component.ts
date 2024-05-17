import { Component, OnInit, Inject } from '@angular/core';
import { ControlTracking } from '../../../models/control-tracking.model';
import { Treatment } from '../../../models/treatment.model';
import { ControlContactType, EnumValDesc } from '../../../models/enums.model';
import { ControlTrackingsService } from '../../../services/control-trackings.service';
import { TreatmentsService } from '../../../services/treatments.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Route } from '@angular/compiler/src/core';
import { MessageSeverity, AlertService } from '../../../services/alert.service';
import { ControlType, TreatmentState } from '../../../models/enums.model';
import { NgxRolesService } from 'ngx-permissions';
import { Moment } from 'moment';
import * as moment from 'moment';
import { NotificationsUpdater } from '../../../interfaces/notifications-updater.interface';
import { AdminComponent } from '../../../layout/admin/admin.component';

@Component({
  selector: 'app-control-trackings-detail',
  templateUrl: './control-trackings-detail.component.html',
  styleUrls: ['./control-trackings-detail.component.scss']
})

export class ControlTrackingsDetailComponent implements OnInit {

  public control: ControlTracking;
  public treatment: Treatment;
  tomorrow:Moment;
  public contactMethods;
  ControlType=ControlType;
  public TreatmentState:any = TreatmentState;
  private nextDoctor?:Moment;
  constructor(private service: ControlTrackingsService,
    private router: Router,
    private treatmentsService: TreatmentsService,
    
    private route: ActivatedRoute,
    private alertService: AlertService,
    @Inject(AdminComponent) private notificationsUpdater:AdminComponent) { }


  get isPending():boolean {
      return this.treatment.state==TreatmentState.pending;
  }

  get greaterPending():boolean{
    return this.treatment.state>TreatmentState.pending;
  }
  ngOnInit() {
    this.tomorrow=moment().add(1,"day");
    this.route.queryParams.subscribe(params => {
      if(params)
      {
        if (params['id'])
          this.doSearch(params['id']);
        else
        {
          this.control = new ControlTracking();
          if(params["treatmentId"])
            this.control.treatmentId = params["treatmentId"];
        }
        if (params['treatmentId'])
        {
          this.treatmentsService.getOne(params["treatmentId"]).subscribe(x => {
            this.treatment = x as Treatment;
            if(this.treatment.controlTrackings[this.treatment.controlTrackings.length-1])
              this.nextDoctor=this.treatment.controlTrackings[this.treatment.controlTrackings.length-1].nextDoctorVisit;
            this.control.nextDoctorVisit=this.nextDoctor;
          });
          this.control.type=this.ControlType.normal;
          this.control.nextDoctorVisit=this.nextDoctor;
        }
        if(params["type"])
        {
          this.control.type = params["type"];
          if (this.control.type == this.ControlType.start)
            this.control.followingTheTreatment = true;
          if (this.control.type == this.ControlType.end)
            this.control.followingTheTreatment = false;
        }
      }
    });
    this.contactMethods = EnumValDesc(ControlContactType)
  }

  doSearch(id: number): void {
    this.service.getOne(id).subscribe(result => {
      this.control = result as ControlTracking;
      
    }
      , error => console.error(error)
    );
  }

  onSubmit() {

    if (this.control.id == null) {
      this.service.insert(this.control).subscribe(
        result => {
          this.notificationsUpdater.refreshNotifications();
          this.router.navigate(['/control-trackings'], { queryParams: { treatmentId: this.control.treatmentId } });
          }
        );
      }
    else {
      this.service.update(this.control).subscribe(result => {
        this.notificationsUpdater.refreshNotifications();
        this.router.navigate(['/control-trackings'], { queryParams: { treatmentId: this.control.treatmentId } });
        });
      }
      this.alertService.showMessage("Seguimientos", "Actualización exitosa", MessageSeverity.success);
    }

}
