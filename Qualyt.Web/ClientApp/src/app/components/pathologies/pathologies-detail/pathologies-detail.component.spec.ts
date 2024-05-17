import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PathologiesDetailComponent } from './pathologies-detail.component';

describe('PathologiesDetailComponent', () => {
  let component: PathologiesDetailComponent;
  let fixture: ComponentFixture<PathologiesDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PathologiesDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PathologiesDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
