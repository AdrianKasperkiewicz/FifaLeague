import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DivisionTabComponent } from './division-tab.component';

describe('DivisionTabComponent', () => {
  let component: DivisionTabComponent;
  let fixture: ComponentFixture<DivisionTabComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DivisionTabComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DivisionTabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
