import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PathologiesListComponent } from './pathologies-list.component';

describe('PathologiesListComponent', () => {
  let component: PathologiesListComponent;
  let fixture: ComponentFixture<PathologiesListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PathologiesListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PathologiesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
