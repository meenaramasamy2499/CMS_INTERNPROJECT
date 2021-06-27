import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewFeesDetailsComponent } from './view-fees-details.component';

describe('ViewFeesDetailsComponent', () => {
  let component: ViewFeesDetailsComponent;
  let fixture: ComponentFixture<ViewFeesDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewFeesDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewFeesDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
