import { Component, OnInit } from '@angular/core';
import { PostsService } from 'src/app/services/post/posts.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { PostCategory } from 'src/app/services/post/post.model';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-postshow',
  templateUrl: './postshow.component.html',
  styleUrls: ['./postshow.component.css']
})
export class PostshowComponent implements OnInit {

  ELEMENT_DATA : PostCategory[];
  displayedColumns: string[] = ['ID', 'PostCategoryName', 'Alias', 'Action'];
  dataSource = new MatTableDataSource<PostCategory>(this.ELEMENT_DATA);
  //PostCategory: any = [];
  applyFilter(filterValue: string){
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  constructor(
    public postCate : PostsService,
  ) { }

  ngOnInit() {
    this.loadPosts()
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
