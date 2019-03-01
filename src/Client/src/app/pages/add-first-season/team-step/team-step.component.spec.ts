import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TeamStepComponent } from './team-step.component';

describe('TeamStepComponent', () => {
  let component: TeamStepComponent;
  let fixture: ComponentFixture<TeamStepComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TeamStepComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TeamStepComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
