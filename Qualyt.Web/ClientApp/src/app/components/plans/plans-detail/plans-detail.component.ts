import { Component, OnInit } from '@angular/core';
import { Plan } from '../../../models/plan.model';
import { Country } from '../../../models/country.model';
import { Laboratory } from '../../../models/laboratory.model';
import { Product } from '../../../models/product.model';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService, MessageSeverity } from '../../../services/alert.service';
import { CountriesService } from '../../../services/countries.service';
import { LaboratoriesService } from '../../../services/laboratories.service';
import { ProductsService } from '../../../services/products.service';
import { PlansService } from '../../../services/plans.service';
import { Pathology } from '../../../models/pathology.model';
import { PathologiesService } from '../../../services/pathologies.service';
import { PlanPathology } from '../../../models/plan-pathology.model';
import { PlanProduct } from '../../../models/plan-product.model';

@Component({
  selector: 'app-plans-detail',
  templateUrl: './plans-detail.component.html',
  styleUrls: ['./plans-detail.component.scss']
})
export class PlansDetailComponent implements OnInit {

  public plan?: Plan;
  public countries: Country[];
  public laboratories: Laboratory[];
  public products: Product[];
  public productsAll: Product[];
  public pathologies: Pathology[];
  public selectedProducts: Product[]=[];
  public selectedPathologies: Pathology[]=[];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: PlansService,
    private alertService: AlertService,
    private countriesService: CountriesService,
    private laboratoriesService: LaboratoriesService,
    private productsService: ProductsService,
    private pathologiesService: PathologiesService
  ) { }

  doSearch(id: number): void {
    this.service.getOne(id).subscribe(result => {
      this.plan = result as Plan;
      for (let pp of this.plan.planPathologies)
        this.selectedPathologies.push(pp.pathology);
      for (let pp of this.plan.planProducts)
        this.selectedProducts.push(pp.product);
      this.productsService.getAll().subscribe(result => {
        this.productsAll = result as Product[];
        this.laboratorySelected(this.plan.laboratory);
      });
    }
      , error => console.error(error)
    );
  }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.countriesService.getAll().subscribe(result => {
        this.countries = result as Country[];
      });
      this.laboratoriesService.getWithIcon().subscribe(result => {
        this.laboratories = result as Laboratory[];
      });
      this.pathologiesService.getAll().subscribe(result => {
        this.pathologies = result as Pathology[];
      });
      if (params['id']) {
        this.doSearch(params['id'])
      }
      else{
        this.productsService.getAll().subscribe(result => {
          this.productsAll = result as Product[];
        });
        this.plan = new Plan();
      }

    });
  }

  countrySelected(country){
    this.plan.country=country;
  }

  laboratorySelected(laboratory){
    this.plan.laboratory=laboratory;
    this.products=this.productsAll.filter(x=>x.laboratoryId==laboratory.id);
  }

  onSubmit(valid: boolean) {
    if (!valid)
      return;

    this.plan.planPathologies = [];
    for (let p of this.selectedPathologies) {
      this.plan.planPathologies.push(new PlanPathology(this.plan.id ? this.plan.id : 0, p.id));
    }
    this.plan.planProducts = [];
    for (let p of this.selectedProducts) {
      this.plan.planProducts.push(new PlanProduct(this.plan.id ? this.plan.id : 0, p.id));
    }

    this.plan.country = null;
    this.plan.laboratory = null;
    if (this.plan.id == null) {
      this.service.insert(this.plan).subscribe(
        result => {
          this.alertService.showMessage("Programa", "Actualización exitosa", MessageSeverity.success);
          this.router.navigate(['/plans']);
        }
        , response => {
          this.alertService.showMessage("Programa", response.error.errors[0].message, MessageSeverity.error);
        });
    }
    else {
      this.service.update(this.plan).subscribe(result => {
        this.alertService.showMessage("Programa", "Actualización exitosa", MessageSeverity.success);
        this.router.navigate(['/plans']);
      }
        , response => {
          this.alertService.showMessage("Programa", response.error.errors[0].message, MessageSeverity.error);
        });
    }

  }
}
