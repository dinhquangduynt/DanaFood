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
    let productcate = this.postCate.getAllPosts();
    productcate.subscribe(postCateItem => this.dataSource.data = postCateItem as PostCategory[]);
  }
  // onEdit(postcate : PostCategory){
  //   this.postCate.formData = postcate;
  //   const dialogConfig = new MatDialogConfig();
  //   dialogConfig.disableClose = true;
  //   dialogConfig.autoFocus= true;
  //   dialogConfig.width= "70%";
  //   this.dialog.open(PostaddComponent, dialogConfig);
  // }
  //  onCreate() {
  //   const dialogConfig = new MatDialogConfig();
  //   dialogConfig.disableClose = true;
  //   dialogConfig.autoFocus= true;
  //   dialogConfig.width= "70%";
  //   this.dialog.open(PostaddComponent, dialogConfig);
  //  }

  onDelete(id : number) {
    if (window.confirm('Are you sure, you want to delete?')){
      this.postCate.deletePostById(id).subscribe(data => {
        this.loadPosts()
      })
    }
  }

}
