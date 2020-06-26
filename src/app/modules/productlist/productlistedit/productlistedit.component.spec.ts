import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductlisteditComponent } from './productlistedit.component';

describe('ProductlisteditComponent', () => {
  let component: ProductlisteditComponent;
  let fixture: ComponentFixture<ProductlisteditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductlisteditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductlisteditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
