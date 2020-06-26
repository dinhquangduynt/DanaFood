import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PostlistAddComponent } from './postlist-add.component';

describe('PostlistAddComponent', () => {
  let component: PostlistAddComponent;
  let fixture: ComponentFixture<PostlistAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PostlistAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PostlistAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
