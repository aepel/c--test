import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MultidropdownWithFilterComponent } from './multidropdown-with-filter.component';

describe('MultidropdownWithFilterComponent', () => {
  let component: MultidropdownWithFilterComponent;
  let fixture: ComponentFixture<MultidropdownWithFilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [MultidropdownWithFilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MultidropdownWithFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
