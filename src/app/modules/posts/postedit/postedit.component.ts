import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { PostsService } from 'src/app/services/post/posts.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-postedit',
  templateUrl: './postedit.component.html',
  styleUrls: ['./postedit.component.css']
})
export class PosteditComponent implements OnInit {

  constructor(public dialogbox : MatDialogRef<PosteditComponent>,
    private service : PostsService,
    private snackBar:MatSnackBar) { }

  ngOnInit(): void {
  }
  onClose(){
    this.dialogbox.close();
    this.service.filter('Register click');
  }


  onSubmit(form:NgForm){
    this.service.updatePost(form.value).subscribe(res=>{
      this.snackBar.open(res.toString(),'',{
        duration:5000,
        verticalPosition:'top'

      })
    })
  }

}
