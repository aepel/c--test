import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PatientsClinicalHistoryComponent } from './patients-clinical-history.component';

describe('PatientsClinicalHistoryComponent', () => {
  let component: PatientsClinicalHistoryComponent;
  let fixture: ComponentFixture<PatientsClinicalHistoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PatientsClinicalHistoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PatientsClinicalHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
