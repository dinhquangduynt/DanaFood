import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OrdershowComponent } from './ordershow.component';

describe('OrdershowComponent', () => {
  let component: OrdershowComponent;
  let fixture: ComponentFixture<OrdershowComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OrdershowComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OrdershowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
