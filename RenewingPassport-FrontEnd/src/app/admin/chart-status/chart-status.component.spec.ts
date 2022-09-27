import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChartStatusComponent } from './chart-status.component';

describe('ChartStatusComponent', () => {
  let component: ChartStatusComponent;
  let fixture: ComponentFixture<ChartStatusComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChartStatusComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChartStatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
