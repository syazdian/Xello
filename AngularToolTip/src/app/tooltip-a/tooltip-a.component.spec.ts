import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TooltipAComponent } from './tooltip-a.component';

describe('TooltipAComponent', () => {
  let component: TooltipAComponent;
  let fixture: ComponentFixture<TooltipAComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TooltipAComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TooltipAComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
