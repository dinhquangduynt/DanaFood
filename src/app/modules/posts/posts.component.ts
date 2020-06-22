import { Component, OnInit } from '@angular/core';
import { PostsService } from 'src/app/services/post/posts.service';
import { MatTableDataSource } from '@angular/material/table';
import { PostCategory } from 'src/app/services/post/post.model';
import { MatDialogConfig, MatDialog } from '@angular/material/dialog';
import { PostItemComponent } from './post-item/post-item.component';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit {
  ELEMENT_DATA : PostCategory[];
  displayedColumns: string[] = ['ID', 'PostCategoryName', 'CreatedDate', 'Action'];
  dataSource = new MatTableDataSource<PostCategory>(this.ELEMENT_DATA);
  //PostCategory: any = [];

  constructor(
    public postCate : PostsService,
    private dialog: MatDialog,
  ) { }

  ngOnInit() {
    this.loadPosts()
  }

  public loadPosts() {
    //  return this.postCate.getAllPosts().subscribe((postCateItem: {}) => {
    //   this.dataSource.data = postCateItem;
    //  })
    let productcate = this.postCate.getAllPosts();
    productcate.subscribe(postCateItem => this.dataSource.data = postCateItem as PostCategory[]);
  }
  onEdit(row){
    //this.postCate.populateForm(row);
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "60%";
    this.dialog.open(PostItemComponent,dialogConfig);
  }
  onCreate() {
    //this.service.initializeFormGroup();
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "60%";
    this.dialog.open(PostItemComponent,dialogConfig);
  }

  onDelete(id : number) {
    if (window.confirm('Are you sure, you want to delete?')){
      this.postCate.deletePostById(id).subscribe(data => {
        this.loadPosts()
      })
    }
  }

}
