import { Component, OnInit } from '@angular/core';
import { PostItem } from 'src/app/services/post/post-item.model';
import { MatTableDataSource } from '@angular/material/table';
import { PostItemService } from 'src/app/services/post/post-item.service';
import { ActivatedRoute } from '@angular/router';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-post-listshow',
  templateUrl: './post-listshow.component.html',
  styleUrls: ['./post-listshow.component.css']
})
export class PostListshowComponent implements OnInit {

  ELEMENT_DATA : PostItem[];
  displayedColumns: string[] = ['ID', 'Name', 'Alias', 'CategoryID', 'Action'];
  dataSource = new MatTableDataSource<PostItem>(this.ELEMENT_DATA);
  //PostCategory: any = [];
  applyFilter(filterValue: string){
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  constructor(
    public postCate : PostItemService,
    private route: ActivatedRoute,
    private service : SharedService
  ) { }

  ngOnInit() {
    this.loadPosts()

  }

  public loadPosts() {
    const id =  this.route.snapshot.paramMap.get('id');
    this.service.send(id);
    let productcate = this.postCate.getAllPostByCategory(id);
    productcate.subscribe(postCateItem => this.dataSource.data = postCateItem as PostItem[]);
  }

  onDelete(id : number) {
    if (window.confirm('Are you sure, you want to delete?')){
      this.postCate.deletePostById(id).subscribe(data => {
        this.loadPosts()
      })
    }
  }

}

