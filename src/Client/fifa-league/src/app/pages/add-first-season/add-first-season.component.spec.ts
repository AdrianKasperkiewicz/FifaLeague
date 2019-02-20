import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddFirstSeasonComponent } from './add-first-season.component';

describe('AddFirstSeasonComponent', () => {
  let component: AddFirstSeasonComponent;
  let fixture: ComponentFixture<AddFirstSeasonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddFirstSeasonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddFirstSeasonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
