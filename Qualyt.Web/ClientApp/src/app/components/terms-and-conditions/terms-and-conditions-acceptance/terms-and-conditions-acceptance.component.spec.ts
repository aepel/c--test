import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TermsAndConditionsAcceptanceComponent } from './terms-and-conditions-acceptance.component';

describe('TermsAndConditionsAcceptanceComponent', () => {
  let component: TermsAndConditionsAcceptanceComponent;
  let fixture: ComponentFixture<TermsAndConditionsAcceptanceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TermsAndConditionsAcceptanceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TermsAndConditionsAcceptanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
