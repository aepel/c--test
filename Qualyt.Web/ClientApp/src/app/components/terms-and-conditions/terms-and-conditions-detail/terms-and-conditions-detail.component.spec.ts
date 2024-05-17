import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TermsAndConditionsDetailComponent } from './terms-and-conditions-detail.component';

describe('TermsAndConditionsDetailComponent', () => {
  let component: TermsAndConditionsDetailComponent;
  let fixture: ComponentFixture<TermsAndConditionsDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TermsAndConditionsDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TermsAndConditionsDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
