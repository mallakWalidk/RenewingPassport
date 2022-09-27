import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageContactUsPageComponent } from './manage-contact-us-page.component';

describe('ManageContactUsPageComponent', () => {
  let component: ManageContactUsPageComponent;
  let fixture: ComponentFixture<ManageContactUsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManageContactUsPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManageContactUsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
