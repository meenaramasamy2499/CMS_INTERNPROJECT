import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddFeesDetailsComponent } from './add-fees-details.component';

describe('AddFeesDetailsComponent', () => {
  let component: AddFeesDetailsComponent;
  let fixture: ComponentFixture<AddFeesDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddFeesDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddFeesDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
