import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddTeamToDivisionComponent } from './add-team-to-division.component';

describe('AddTeamToDivisionComponent', () => {
  let component: AddTeamToDivisionComponent;
  let fixture: ComponentFixture<AddTeamToDivisionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddTeamToDivisionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddTeamToDivisionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
