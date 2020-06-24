import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PostListshowComponent } from './post-listshow.component';

describe('PostListshowComponent', () => {
  let component: PostListshowComponent;
  let fixture: ComponentFixture<PostListshowComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PostListshowComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PostListshowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
