import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SalesContactsDetailComponent } from './sales-contacts-detail.component';

describe('SalesContactsDetailComponent', () => {
  let component: SalesContactsDetailComponent;
  let fixture: ComponentFixture<SalesContactsDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SalesContactsDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SalesContactsDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
