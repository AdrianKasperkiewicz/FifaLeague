import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LeagueStepComponent } from './league-step.component';

describe('LeagueStepComponent', () => {
  let component: LeagueStepComponent;
  let fixture: ComponentFixture<LeagueStepComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LeagueStepComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LeagueStepComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
