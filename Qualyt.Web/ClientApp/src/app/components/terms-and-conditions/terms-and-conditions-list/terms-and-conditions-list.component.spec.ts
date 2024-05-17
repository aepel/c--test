import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TermsAndConditionsListComponent } from './terms-and-conditions-list.component';

describe('TermsAndConditionsListComponent', () => {
  let component: TermsAndConditionsListComponent;
  let fixture: ComponentFixture<TermsAndConditionsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TermsAndConditionsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TermsAndConditionsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
