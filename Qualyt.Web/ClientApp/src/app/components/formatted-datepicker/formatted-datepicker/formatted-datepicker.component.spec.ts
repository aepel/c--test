import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FormattedDatepickerComponent } from './formatted-datepicker.component';

describe('FormattedDatepickerComponent', () => {
  let component: FormattedDatepickerComponent;
  let fixture: ComponentFixture<FormattedDatepickerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormattedDatepickerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormattedDatepickerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
