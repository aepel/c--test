import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NursesDetailComponent } from './nurses-detail.component';

describe('NursesDetailComponent', () => {
  let component: NursesDetailComponent;
  let fixture: ComponentFixture<NursesDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NursesDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NursesDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
