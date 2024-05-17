import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ControlTrackingsListComponent } from './control-trackings-list.component';

describe('ControlTrackingsListComponent', () => {
  let component: ControlTrackingsListComponent;
  let fixture: ComponentFixture<ControlTrackingsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ControlTrackingsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ControlTrackingsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
