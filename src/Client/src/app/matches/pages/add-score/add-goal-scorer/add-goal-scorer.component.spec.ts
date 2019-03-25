import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddGoalScorerComponent } from './add-goal-scorer.component';

describe('AddGoalScorerComponent', () => {
  let component: AddGoalScorerComponent;
  let fixture: ComponentFixture<AddGoalScorerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddGoalScorerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddGoalScorerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
