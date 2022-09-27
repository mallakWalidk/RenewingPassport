import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PassportsComponent } from './passports.component';

describe('PassportsComponent', () => {
  let component: PassportsComponent;
  let fixture: ComponentFixture<PassportsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PassportsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PassportsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
