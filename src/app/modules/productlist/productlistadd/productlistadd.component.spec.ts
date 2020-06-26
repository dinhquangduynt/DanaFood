import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductlistaddComponent } from './productlistadd.component';

describe('ProductlistaddComponent', () => {
  let component: ProductlistaddComponent;
  let fixture: ComponentFixture<ProductlistaddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductlistaddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductlistaddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
