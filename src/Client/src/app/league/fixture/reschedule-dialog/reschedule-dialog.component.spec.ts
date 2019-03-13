import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RescheduleDialogComponent } from './reschedule-dialog.component';

describe('RescheduleDialogComponent', () => {
  let component: RescheduleDialogComponent;
  let fixture: ComponentFixture<RescheduleDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RescheduleDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RescheduleDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
