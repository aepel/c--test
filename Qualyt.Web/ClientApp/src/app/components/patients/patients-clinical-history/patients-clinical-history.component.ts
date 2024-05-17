import { Component, OnInit } from '@angular/core';
import * as jspdf from 'jspdf';
import html2canvas from 'html2canvas';
import { Patient } from '../../../models/patient.model';
import { ActivatedRoute, Router } from '@angular/router';
import { PatientsService } from '../../../services/patients.service';
import { EnumValDesc, Gender, LivesWith, SchoolLevel, BloodType, RhFactor, BirthsType } from '../../../models/enums.model';
import { ClinicalHistory } from '../../../models/clinical-history.model';
import { MessageSeverity, AlertService } from '../../../services/alert.service';
import { Document, Packer, Paragraph, Styles } from "docx";
import htmlDocx from 'html-docx-js/dist/html-docx';
import { saveAs } from 'file-saver';

@Component({
  selector: 'app-patients-clinical-history',
  templateUrl: './patients-clinical-history.component.html',
  styleUrls: ['./patients-clinical-history.component.scss']
})
export class PatientsClinicalHistoryComponent implements OnInit
{

  public patient?: Patient;
  public genders;
  public livesWiths;
  public schoolLevels;
  public bloodTypes;
  public rhFactors;
  public birthsTypes;
  public Gender = Gender;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private service: PatientsService,
    private alertService: AlertService
  )
  {
    this.genders = EnumValDesc(Gender);
    this.livesWiths = EnumValDesc(LivesWith);
    this.schoolLevels = EnumValDesc(SchoolLevel);
    this.bloodTypes = EnumValDesc(BloodType);
    this.rhFactors = EnumValDesc(RhFactor);
    this.birthsTypes = EnumValDesc(BirthsType);
  }

  ngOnInit()
  {
    this.route.queryParams.subscribe(params => {
      if (params['id']) {
        this.doSearch(params['id'])
      }
      else {
        this.patient = new Patient();
        this.patient.clinicalHistory = new ClinicalHistory();
      }
    });
  }

  doSearch(pacienteId: number): void
  {
    this.service.getOne(pacienteId).subscribe(result => {
      this.patient = result as Patient;
      if (!this.patient.clinicalHistory)
        this.patient.clinicalHistory = new ClinicalHistory();
    }
      , error => console.error(error)
    );
  }

  onSubmit(valid: boolean) {
    if (!valid)
      return;

    this.service.update(this.patient).subscribe(result => {
      this.alertService.showMessage("Historia clínica", "Actualización exitosa", MessageSeverity.success);
      this.router.navigate(['/patients']);
    }
      , response => {
        this.alertService.showMessage("Historia clínica", response.error.errors[0].message, MessageSeverity.error);
    });

  }

  export() {
    const doc = new Document();
    doc.Styles.createParagraphStyle("p", "p").size(24);
    doc.createParagraph("Historia clínica").title().center();
    var content = Array.from(document.querySelectorAll(".exportable"));
    
    content.forEach(function (item) {
      let placeholder: string;
      let value: string;
      if (item.localName == "div" || item.localName == "mat-form-field")
        item = item.firstElementChild;
      switch (item.localName) {
        case "input":
          placeholder = item["placeholder"];
          value = item["value"];
          break;
        case "mat-select":
          placeholder = item.nextSibling.lastChild.childNodes[2]["data"];
          value = item["textContent"];
          break;
        case "mat-datepicker":
          placeholder = item["previousSibling"]["placeholder"];
          value = item["previousSibling"]["value"];
          break;
        case "mat-checkbox":
          placeholder = item["textContent"];
          value = item.firstElementChild.firstElementChild.firstElementChild["checked"] ? "Si" : "No";
          break;
        case "p":
          doc.createParagraph(item["textContent"].trim()).heading1();
          value = undefined;
          break;
        default: console.log("localName not registered")
      }
      if (value) {
        doc.createParagraph(placeholder.trim() + ": " + value.trim()).style("p");
      }
    });
    const packer = new Packer();
    packer.toBlob(doc).then(blob => {
      saveAs(blob, "example.docx");
    });
  }
}
