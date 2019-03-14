import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StartSeasonComponent } from './start-season.component';

describe('StartSeasonComponent', () => {
  let component: StartSeasonComponent;
  let fixture: ComponentFixture<StartSeasonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StartSeasonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StartSeasonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
