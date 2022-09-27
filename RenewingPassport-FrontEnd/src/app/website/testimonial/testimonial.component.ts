import { getNumberOfCurrencyDigits } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { HomeService } from 'src/app/Services/home.service';

@Component({
  selector: 'app-testimonial',
  templateUrl: './testimonial.component.html',
  styleUrls: ['./testimonial.component.css']
})
export class TestimonialComponent implements OnInit {

  constructor(public dialog: MatDialog,public home: HomeService,private toastr:ToastrService) { }
  @ViewChild('CallTestimonialDailog') CallTestimonialDailog! :TemplateRef<any>;

  ngOnInit(): void {
  this.home.GetTestimonial();
  
  }

  CreateTestimonialForm :FormGroup =new FormGroup({
    senderName:new FormControl('',Validators.required),
    message:new FormControl('',Validators.required),
    imagePath:new FormControl( )
  })

  TestimonialDailog()
  {
    this.dialog.open(this.CallTestimonialDailog)
  }
  
  uploadImage(file:any,type:string)
  {
    if(file.length==0)
    return ; 
    let fileToUpload=<File>file[0];//
    const formDate=new FormData();//object 
    formDate.append('file',fileToUpload,fileToUpload.name);
    this.home.uploadAttachment(formDate,type);
  }

  Create(){
    this.home.CreateTestimonial(this.CreateTestimonialForm.value);
    window.location.reload();
  }

}
