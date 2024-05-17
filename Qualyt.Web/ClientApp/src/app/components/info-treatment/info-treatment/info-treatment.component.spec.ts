import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InfoTreatmentComponent } from './info-treatment.component';

describe('InfoTreatmentComponent', () => {
  let component: InfoTreatmentComponent;
  let fixture: ComponentFixture<InfoTreatmentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InfoTreatmentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InfoTreatmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
