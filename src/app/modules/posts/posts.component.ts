import { Component, OnInit } from '@angular/core';
import { PostsService } from 'src/app/services/post/posts.service';
import { MatTableDataSource } from '@angular/material/table';


@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit {
  constructor() { }

  ngOnInit() {
  }

}
