import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SalesContactsListComponent } from './sales-contacts-list.component';

describe('SalesContactsListComponent', () => {
  let component: SalesContactsListComponent;
  let fixture: ComponentFixture<SalesContactsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SalesContactsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SalesContactsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
