import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LaboratoriesDetailComponent } from './laboratories-detail.component';

describe('LaboratoriesDetailComponent', () => {
  let component: LaboratoriesDetailComponent;
  let fixture: ComponentFixture<LaboratoriesDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LaboratoriesDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LaboratoriesDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
