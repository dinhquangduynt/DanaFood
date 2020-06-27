import { Component, OnInit, ViewChild } from '@angular/core';
import { User } from 'src/app/services/user/user';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-usershow',
  templateUrl: './usershow.component.html',
  styleUrls: ['./usershow.component.css']
})
export class UsershowComponent implements OnInit {

  ELEMENT_DATA : User[];
  displayedColumns: string[] = ['UserName', 'FullName', 'Address','BirthDay', 'Email', 'PhoneNumber'];
  dataSource = new MatTableDataSource<User>(this.ELEMENT_DATA);
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  //PostCategory: any = [];
  applyFilter(filterValue: string){
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  constructor(
    public postCate : UserService,
  ) { }

  ngOnInit() {
    this.loadPosts();
    this.dataSource.paginator = this.paginator;
  }

  public loadPosts() {
    let productcate = this.postCate.getAllUsers();
    productcate.subscribe(postCateItem => this.dataSource.data = postCateItem as User[]);
  }

  // onDelete(id : number) {
  //   if (window.confirm('Are you sure, you want to delete?')){
  //     this.postCate.deleteUserById(id).subscribe(data => {
  //       this.loadPosts()
  //     })
  //   }
  // }

}

