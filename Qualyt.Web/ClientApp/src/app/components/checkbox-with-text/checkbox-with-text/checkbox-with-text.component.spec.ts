import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CheckboxWithTextComponent } from './checkbox-with-text.component';

describe('CheckboxWithTextComponent', () => {
  let component: CheckboxWithTextComponent;
  let fixture: ComponentFixture<CheckboxWithTextComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CheckboxWithTextComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CheckboxWithTextComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
