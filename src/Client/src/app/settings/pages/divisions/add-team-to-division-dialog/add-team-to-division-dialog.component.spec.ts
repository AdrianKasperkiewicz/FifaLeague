import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddTeamToDivisionDialogComponent } from './add-team-to-division-dialog.component';

describe('AddTeamToDivisionDialogComponent', () => {
  let component: AddTeamToDivisionDialogComponent;
  let fixture: ComponentFixture<AddTeamToDivisionDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddTeamToDivisionDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddTeamToDivisionDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
