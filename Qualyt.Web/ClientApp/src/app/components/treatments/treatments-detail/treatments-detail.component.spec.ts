import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TreatmentsDetailComponent } from './treatments-detail.component';

describe('TreatmentsDetailComponent', () => {
  let component: TreatmentsDetailComponent;
  let fixture: ComponentFixture<TreatmentsDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [TreatmentsDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TreatmentsDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
