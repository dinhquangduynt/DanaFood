import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FeedbackshowComponent } from './feedbackshow.component';

describe('FeedbackshowComponent', () => {
  let component: FeedbackshowComponent;
  let fixture: ComponentFixture<FeedbackshowComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FeedbackshowComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FeedbackshowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
