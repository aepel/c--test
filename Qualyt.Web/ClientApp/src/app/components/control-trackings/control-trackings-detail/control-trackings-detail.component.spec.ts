import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ControlTrackingDetailsComponent } from './control-trackings-detail.component';

describe('ControlTrackingDetailsComponent', () => {
  let component: ControlTrackingDetailsComponent;
  let fixture: ComponentFixture<ControlTrackingDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ControlTrackingDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ControlTrackingDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
