import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SendfeedbackemailComponent } from './sendfeedbackemail.component';

describe('SendfeedbackemailComponent', () => {
  let component: SendfeedbackemailComponent;
  let fixture: ComponentFixture<SendfeedbackemailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SendfeedbackemailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SendfeedbackemailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
