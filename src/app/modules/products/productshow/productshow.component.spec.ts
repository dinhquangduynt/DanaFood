import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductshowComponent } from './productshow.component';

describe('ProductshowComponent', () => {
  let component: ProductshowComponent;
  let fixture: ComponentFixture<ProductshowComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductshowComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductshowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
