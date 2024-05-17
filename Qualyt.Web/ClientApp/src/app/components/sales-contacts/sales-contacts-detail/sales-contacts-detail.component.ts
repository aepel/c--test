import { Component, OnInit } from '@angular/core';
import { SalesContact } from '../../../models/sales-contact.model';
import { ActivatedRoute, Router } from '@angular/router';
import { SalesContactsService } from '../../../services/sales-contacts.service';
import { AlertService, MessageSeverity } from '../../../services/alert.service';

@Component({
  selector: 'app-sales-contacts-detail',
  templateUrl: './sales-contacts-detail.component.html',
  styleUrls: ['./sales-contacts-detail.component.scss']
})
export class SalesContactsDetailComponent implements OnInit {

  public salesContact?: SalesContact;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: SalesContactsService,
    private alertService: AlertService
  ) { }

  doSearch(id: number): void {
    this.service.getOne(id).subscribe(result => {
      this.salesContact = result as SalesContact;
    }
      , error => console.error(error)
    );
  }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      if (params['id']) {
        this.doSearch(params['id'])
      }
      else
        this.salesContact = new SalesContact();

    });
  }

  onSubmit(valid: boolean) {
    if (!valid)
      return;

    if (this.salesContact.id == null) {
      this.service.insert(this.salesContact).subscribe(
        result => {
          this.alertService.showMessage("Representante", "Actualización exitosa", MessageSeverity.success);
          this.router.navigate(['/sales-contacts']);
        }
        , response => {
          this.alertService.showMessage("Representante", response.error.errors[0].message, MessageSeverity.error);
        });
    }
    else {
      this.service.update(this.salesContact).subscribe(result => {
        this.alertService.showMessage("Representante", "Actualización exitosa", MessageSeverity.success);
        this.router.navigate(['/sales-contacts']);
      }
        , response => {
          this.alertService.showMessage("Representante", response.error.errors[0].message, MessageSeverity.error);
        });
    }

  }
}
