import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FieldsManagerComponent } from './fields-manager.component';

describe('FieldsManagerComponent', () => {
  let component: FieldsManagerComponent;
  let fixture: ComponentFixture<FieldsManagerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FieldsManagerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FieldsManagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
