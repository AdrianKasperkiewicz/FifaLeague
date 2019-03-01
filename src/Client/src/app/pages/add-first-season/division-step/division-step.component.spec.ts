import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DivisionStepComponent } from './division-step.component';

describe('DivisionStepComponent', () => {
  let component: DivisionStepComponent;
  let fixture: ComponentFixture<DivisionStepComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DivisionStepComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DivisionStepComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
