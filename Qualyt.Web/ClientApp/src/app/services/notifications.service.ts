import { Http, RequestOptions, Response } from "@angular/http";
import { Observable } from "rxjs/Observable";
import { HttpClient } from "@angular/common/http";
import { Injectable, Inject } from '@angular/core';
import { QueryParameters } from "../models/query-parameters.model";
import { DatatableResponse } from "../models/datatable-response.model";
import { KeyValue } from "../models/datatable-column.model";
import { AuthenticationService } from "./authentication.service";
import { Alert, PatientWithoutConsentAlert, TodayControlAlert } from "../models/alert.model";
import { AlertType } from "../models/enums.model";

export class NotificationsService {

  url:string;

  constructor(
    protected client: HttpClient,
    @Inject('BASE_URL') public baseUrl: string,
    public authService: AuthenticationService
  )
  {
    this.url=baseUrl+"api/Alerts/";
  }

  getAll(): Observable<Alert[]> {
    const head = this.authService.getRequestHTTPHeaders();
    return this.client.get<Alert[]>(this.url + "getAlerts", { headers: head }).map(x => this.alertsBuilder(x));
  }

  alertsBuilder(alerts: Alert[]): Alert[]{
    for (let alert of alerts) {
      switch (alert.type) {
        case AlertType.patientWithoutConsent:
          alert.title = "Términos y condiciones no aceptados.";
          alert.description = "El paciente " + (alert as PatientWithoutConsentAlert).patientName + " fue ingresado hace más de 48hs y todavía no se registró el consentimiento.";
          alert.route = "/patients/detail";
          alert.params = { id: (alert as PatientWithoutConsentAlert).patientId }
          break;
        case AlertType.todayControl:
          alert.title = "Seguimiento a realizar hoy.";
          alert.description = "El paciente " + (alert as TodayControlAlert).patientName + " tiene un seguimiento programado para el día de hoy.";
          alert.route = "/control-trackings";
          alert.params = { treatmentId: (alert as TodayControlAlert).treatmentId }
          break;
        default: console.log("The alerts builder fail.");
      }
    }
    return alerts;
  }
} 
