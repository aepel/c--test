import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HealthInsurancesListComponent } from './health-insurances-list.component';

describe('HealthInsurancesListComponent', () => {
  let component: HealthInsurancesListComponent;
  let fixture: ComponentFixture<HealthInsurancesListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HealthInsurancesListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HealthInsurancesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
