import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ResetPaswwordComponent } from './reset-paswword.component';

describe('ResetPaswwordComponent', () => {
  let component: ResetPaswwordComponent;
  let fixture: ComponentFixture<ResetPaswwordComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ResetPaswwordComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ResetPaswwordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
