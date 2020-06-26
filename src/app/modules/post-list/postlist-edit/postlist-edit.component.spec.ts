import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PostlistEditComponent } from './postlist-edit.component';

describe('PostlistEditComponent', () => {
  let component: PostlistEditComponent;
  let fixture: ComponentFixture<PostlistEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PostlistEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PostlistEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
