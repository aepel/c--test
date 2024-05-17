import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HealthInsurancesDetailComponent } from './health-insurances-detail.component';

describe('HealthInsurancesDetailComponent', () => {
  let component: HealthInsurancesDetailComponent;
  let fixture: ComponentFixture<HealthInsurancesDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HealthInsurancesDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HealthInsurancesDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
