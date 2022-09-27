import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChartGenderComponent } from './chart-gender.component';

describe('ChartGenderComponent', () => {
  let component: ChartGenderComponent;
  let fixture: ComponentFixture<ChartGenderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChartGenderComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChartGenderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
