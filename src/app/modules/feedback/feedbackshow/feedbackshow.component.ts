import { Component, OnInit, ViewChild } from '@angular/core';
import { Feedback } from 'src/app/services/feedback/feedback';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { FeedbackService } from 'src/app/services/feedback/feedback.service';
import { ActivatedRoute } from '@angular/router';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-feedbackshow',
  templateUrl: './feedbackshow.component.html',
  styleUrls: ['./feedbackshow.component.css']
})
export class FeedbackshowComponent implements OnInit {

  ELEMENT_DATA : Feedback[];
  displayedColumns: string[] = ['ID', 'Name', 'Email','Message','Action'];
  dataSource = new MatTableDataSource<Feedback>(this.ELEMENT_DATA);
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  //feedbackgory: any = [];
  applyFilter(filterValue: string){
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  constructor(
    public feedback : FeedbackService,
    private route: ActivatedRoute,
    private service : SharedService
  ) { }

  ngOnInit() {
    this.loadPosts();
    this.dataSource.paginator = this.paginator;
  }

  public loadPosts() {
    let productcate = this.feedback.getAllFeedbacks();
    productcate.subscribe(postCateItem => this.dataSource.data = postCateItem as Feedback[]);
  }


}

