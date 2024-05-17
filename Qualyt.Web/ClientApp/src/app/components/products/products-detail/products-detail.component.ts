import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product.model';
import { Laboratory } from 'src/app/models/laboratory.model';
import { ActivatedRoute, Router } from '@angular/router';
import { LaboratoriesService } from 'src/app/services/laboratories.service';
import { ProductsService } from 'src/app/services/products.service';
import { AlertService, MessageSeverity } from 'src/app/services/alert.service';
import { EnumValDesc, ProductType, DeviceType, DosageForm, VariationUnit } from 'src/app/models/enums.model';
import { Medicine } from 'src/app/models/medicine.model';
import { Device } from 'src/app/models/device.model';

@Component({
  selector: 'app-products-detail',
  templateUrl: './products-detail.component.html',
  styleUrls: ['./products-detail.component.scss']
})
export class ProductsDetailComponent implements OnInit {

  public product?: Product;

  public laboratories: Laboratory[];
  public productTypes;
  public deviceTypes;
  public dosageForms;
  public variationUnits;
  public ProductType = ProductType;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private laboratoriesService: LaboratoriesService,
    private service: ProductsService,
    private alertService: AlertService
  ) {
  }
  doSearch(id: number): void {
    this.service.getOne(id).subscribe(result => {
      this.product = result as Product;
    }
      , error => console.error(error)
    );
  }

  ngOnInit(): void {
    this.laboratoriesService.getAll().subscribe(result => {
      this.laboratories = result as Laboratory[];
    });
    this.route.queryParams.subscribe(params => {
      if (params['id'])
        this.doSearch(params['id'])
      else {
        this.product = new Product();
        this.product.fields = [];
      }
    });
    this.productTypes = EnumValDesc(ProductType);
    this.deviceTypes = EnumValDesc(DeviceType);
    this.dosageForms = EnumValDesc(DosageForm);
    this.variationUnits = EnumValDesc(VariationUnit);
  }

  onSubmit(form) {

    if (!form.valid)
      return;
    this.product["serializedFields"] = undefined;
    if (this.product.productType == ProductType.device)
      this.product = this.product as Device;
    if (this.product.productType == ProductType.medicine)
      this.product = this.product as Medicine;

    if (this.product) {

      if (this.product.id == null) {

        this.service.insert(this.product).subscribe(
          result => {
            this.router.navigate(['/products']);
            this.alertService.showMessage("Productos", "Actualización exitosa", MessageSeverity.success);
          }
          , response => {
            this.alertService.showMessage("Productos", response.error.errors[0].message, MessageSeverity.error);
          });
      }
      else {
        this.service.update(this.product).subscribe(result => {
          this.router.navigate(['/products']);
          this.alertService.showMessage("Productos", "Actualización exitosa", MessageSeverity.success);
        }
          , response => {
            this.alertService.showMessage("Productos", response.error.errors[0].message, MessageSeverity.error);
          });
      }
    }

  }
}
