import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DivisionCardComponent } from './division-card.component';

describe('DivisionCardComponent', () => {
  let component: DivisionCardComponent;
  let fixture: ComponentFixture<DivisionCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DivisionCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DivisionCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
