declare var jQuery: any;
declare var $: any;
import { Component, OnInit,Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { errorMessage } from 'src/app/models/errormessages.model';
import { ErrorMessageComponent } from 'src/app/models/errorshandler/error-message.component';
import { AuthenticationService } from 'src/app/services/authentication.service'
import { SSL_OP_ALL } from 'constants';
import { FormGroup, FormBuilder } from '@angular/forms';
@Component({
  selector: 'app-forgot',
  templateUrl: './forgot.component.html',
  providers: [AuthenticationService],
  styleUrls: ['./forgot.component.scss']
})
export class forgotComponent implements OnInit {

  forgotForm: FormGroup;

  constructor(
    private authservice: AuthenticationService,
    private formBuilder: FormBuilder
  ) { }
  isLoading = false;
  ngOnInit() 
  {
    
    this.forgotForm = this.formBuilder.group({
      email: ''
    })
  }

  sendResetPasswordLink()
  {
    this.isLoading = true;
    this.authservice.forgotPassword(this.forgotForm.controls.email.value)
    this.isLoading = false;
  }
  
}
