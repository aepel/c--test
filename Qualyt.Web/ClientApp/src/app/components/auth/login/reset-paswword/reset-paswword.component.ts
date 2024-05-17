import { Component, OnInit } from '@angular/core';
import { AlertService, MessageSeverity, DialogType } from 'src/app/services/alert.service'
import { AuthenticationService } from 'src/app/services/authentication.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-reset-paswword',
  templateUrl: './reset-paswword.component.html',
  
  styleUrls: ['./reset-paswword.component.scss'],
})
export class ResetPaswwordComponent implements OnInit {

  constructor(private alertService: AlertService,
    private authService: AuthenticationService,
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute) { }
  isLoading = false
  
  resetForm: FormGroup;
   userid = '';
  token = '';
  
  ngOnInit() {
    
    this.resetForm = this.formBuilder.group({
      
      newpassword: '',
      passwordconfirm: ''
    })
    this.route.queryParams.subscribe(params => {
      
      if (params['token'] && params['userid']) {
        this.userid = params['userid'];
        this.token = encodeURIComponent(params['token']);
        console.log("El proximo token es el que traigo directamente de queryparams ");
        console.log(params['token']);
        console.log("El proximo token es el token desde el componente que esta encodeado para el service");
        console.log(this.token);
        
      }
    });
      }
  resetPassword()
  {
    
    this.authService.resetPassword( this.userid,
                                    this.token,
                                    this.resetForm.controls.newpassword.value,
                                    this.resetForm.controls.passwordconfirm.value);
    
  }
}
