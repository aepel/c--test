import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TreatmentBasicInfoComponent } from './treatment-basic-info.component';

describe('TreatmentBasicInfoComponent', () => {
  let component: TreatmentBasicInfoComponent;
  let fixture: ComponentFixture<TreatmentBasicInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TreatmentBasicInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TreatmentBasicInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
