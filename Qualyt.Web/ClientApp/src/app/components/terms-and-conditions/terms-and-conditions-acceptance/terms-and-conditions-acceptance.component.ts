import { Component, OnInit, ViewChild } from '@angular/core';
import { TermsAndConditionsService } from '../../../services/terms-and-conditions.service';
import { PatientsService } from '../../../services/patients.service';
import { ActivatedRoute } from '@angular/router';
import { Patient } from '../../../models/patient.model';
import html2canvas from 'html2canvas';
import * as jspdf from 'jspdf';
import { MessageSeverity, AlertService } from '../../../services/alert.service';

@Component({
  selector: 'app-terms-and-conditions-acceptance',
  templateUrl: './terms-and-conditions-acceptance.component.html',
  styleUrls: ['./terms-and-conditions-acceptance.component.scss']
})
export class TermsAndConditionsAcceptanceComponent implements OnInit {

  patient: Patient = new Patient();
  basePatient: Patient;
  verified: boolean = false;
  accepted: boolean = false;
  text: string;
  emailToReceive: string;
  @ViewChild("modalDefault") modal: any;

  constructor(private service: TermsAndConditionsService,
    private patientsService: PatientsService,
    private route: ActivatedRoute,
    private alertService: AlertService) { }

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      if (params['id'] && params['number']) {
        this.doSearch(params['id'], params['number']);
      }
    });
    this.service.getEmailToReceive().subscribe(result=>
    {
      console.log(result);
      this.emailToReceive=result;
    }
      , error => console.error(error)
    );
  }

  doSearch(id: string, number: string): void {
    this.patientsService.getHashed(id, number).subscribe(result => {
      this.basePatient = result as Patient;
    }
      , error => console.error(error)
    );
  }

  onSubmit(valid: boolean) {
    if (!valid)
      return;

    if (this.patient.email == this.basePatient.email && this.patient.idNumber == this.basePatient.idNumber)
    {
      this.service.getText().subscribe(x =>
      {
        this.text = x;
        this.verified = true;
      });
    }
    else
      this.alertService.showMessage("Verificación de datos", "Los datos ingresados no concuerdan con los datos cargados previamente por nuestros operadores. Inténtelo nuevamente o comuníquese telefónicamente.", MessageSeverity.error);

  }

  accept() {
    //this.patientsService.acceptTerms(this.basePatient.id).subscribe(x => {
    //});
    this.modal.show();
  }

  confirm() {


    var quotes:any = document.getElementById('contentToConvert');
    quotes=quotes.children[0].children[0];
    html2canvas(quotes).then(canvas => {
      //! MAKE YOUR PDF
      var pdf = new jspdf('p', 'pt', 'a4');
      var html=window.document.getElementsByClassName("ql-editor")[0];
      pdf.fromHTML(
          html,
          15,
          15,
          {
            'width': 550
          });
      pdf.save(this.basePatient.fullName + '.consent.pdf');
      this.verified = false;
      this.accepted = true;
      this.modal.hide();
    });

    //   for (var i = 0; i <= quotes.clientHeight / 980; i++) {
    //     //! This is all just html2canvas stuff
    //     var srcImg = canvas;
    //     var sX = 0;
    //     var sY = 1120 * i; // start 980 pixels down for every new page
    //     var sWidth = 778;
    //     var sHeight = 1120;
    //     var dX = 0;
    //     var dY = 0;
    //     var dWidth = 778;
    //     var dHeight = 1120;

    //     let onePageCanvas = document.createElement("canvas");
    //     onePageCanvas.setAttribute('width', '778');
    //     onePageCanvas.setAttribute('height', '1120');
    //     var ctx = onePageCanvas.getContext('2d');
    //     ctx.drawImage(srcImg, sX, sY, sWidth, sHeight, dX, dY, dWidth, dHeight);

    //     // document.body.appendChild(canvas);
    //     var canvasDataURL = onePageCanvas.toDataURL("image/png", 1.0);

    //     var width = onePageCanvas.width;
    //     var height = onePageCanvas.clientHeight;

        

    //     var source = window.document.getElementsByClassName("ql-editor")[0];
        
    //     // pdf.output("dataurlnewwindow");


    //     // //! If we're on anything other than the first page,
    //     // // add another page
    //     // if (i > 0) {
    //     //   pdf.addPage(595, 842); //8.5" x 11" in pts (in*72)
    //     // }
    //     // //! now we declare that we're working on that page
    //     // pdf.setPage(i + 1);
    //     // //! now we add content to that page!
    //     // pdf.addImage(canvasDataURL, 'PNG', 10, 10, (width * .72), (height * .71));

    //   }
    //   //! after the for loop is finished running, we save the pdf.
    //   pdf.save(this.basePatient.fullName + '.consent.pdf');
    // });
  }

}
