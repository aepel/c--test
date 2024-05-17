import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NursesListComponent } from './nurses-list.component';

describe('NursesListComponent', () => {
  let component: NursesListComponent;
  let fixture: ComponentFixture<NursesListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NursesListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NursesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
