import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WebsitePagesComponent } from './website-pages.component';

describe('WebsitePagesComponent', () => {
  let component: WebsitePagesComponent;
  let fixture: ComponentFixture<WebsitePagesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WebsitePagesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WebsitePagesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
