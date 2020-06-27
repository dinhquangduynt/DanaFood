import { Component, OnInit, ViewChild } from '@angular/core';
import { PostsService } from 'src/app/services/post/posts.service';
import { PostCategory } from 'src/app/services/post/post.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-postshow',
  templateUrl: './postshow.component.html',
  styleUrls: ['./postshow.component.css']
})
export class PostshowComponent implements OnInit {

  ELEMENT_DATA : PostCategory[];
  displayedColumns: string[] = ['ID', 'PostCategoryName', 'Alias', 'Action'];
  dataSource = new MatTableDataSource<PostCategory>(this.ELEMENT_DATA);

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  applyFilter(filterValue: string){
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  constructor(
    public postCate : PostsService,
  ) { }

  ngOnInit() {
    this.loadPosts()
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  public loadPosts() {
    let productcate = this.postCate.getAllPosts();
    productcate.subscribe(postCateItem => this.dataSource.data = postCateItem as PostCategory[]);
  }
  onDelete(id : number) {
    if (window.confirm('Are you sure, you want to delete?')){
      this.postCate.deletePostById(id).subscribe(data => {
        this.loadPosts()
      })
    }
  }

}
