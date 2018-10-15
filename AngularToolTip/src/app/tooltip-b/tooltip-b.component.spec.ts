import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TooltipBComponent } from './tooltip-b.component';

describe('TooltipBComponent', () => {
  let component: TooltipBComponent;
  let fixture: ComponentFixture<TooltipBComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TooltipBComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TooltipBComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
