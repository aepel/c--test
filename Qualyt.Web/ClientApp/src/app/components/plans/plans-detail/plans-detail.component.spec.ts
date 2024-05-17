import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlansDetailComponent } from './plans-detail.component';

describe('PlansDetailComponent', () => {
  let component: PlansDetailComponent;
  let fixture: ComponentFixture<PlansDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlansDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlansDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
