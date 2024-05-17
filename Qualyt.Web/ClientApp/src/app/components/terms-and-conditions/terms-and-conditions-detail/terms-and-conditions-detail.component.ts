import { TermsAndConditionsService } from '../../../services/terms-and-conditions.service';
import { TermsAndConditions } from '../../../models/terms-and-conditions.model';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-terms-and-conditions-detail',
  templateUrl: './terms-and-conditions-detail.component.html',
  styleUrls: ['./terms-and-conditions-detail.component.scss']
})
export class TermsAndConditionsDetailComponent implements OnInit {

    public termsAndConditions?: TermsAndConditions
    public create: boolean = false
    public edit: boolean = false

    constructor(private route: ActivatedRoute,
private router: Router,
private sv: TermsAndConditionsService) {
    }

    ngOnInit(): void {
        this.route.queryParams.subscribe(params => {
            if (params['id']) {
                this.doSearch(params['id']);
                if(!params['detail'])
                    this.edit = true;
            } else {
                this.termsAndConditions = new TermsAndConditions();
                this.create = true;
            }
        });
    }

  doSearch(id: number): void {
    this.sv.getOne(id).subscribe(result => {
            this.termsAndConditions = result as TermsAndConditions;
        }, error => console.error(error)
        );
    }

    getLastPublishedText() {
      this.sv.getText().subscribe(result => {
        this.termsAndConditions.text = result;
        }, error => console.error(error));
    }

    onSubmit() {
        if (this.create)
        {
          this.sv.insert(this.termsAndConditions as TermsAndConditions).subscribe(result => {
                this.router.navigate(['/terms-and-conditions']);
            }, error => {
            });
        }
        else
        {
            this.sv.update(this.termsAndConditions as TermsAndConditions).subscribe(result =>
            {
                this.router.navigate(['/terms-and-conditions']);
            }, error => {
            })
        }
    } 
}
