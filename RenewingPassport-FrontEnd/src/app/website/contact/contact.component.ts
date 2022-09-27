import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DateAdapter } from '@angular/material/core';
import { HomeService } from 'src/app/Services/home.service';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {
  FeedbackForm:FormGroup=new FormGroup({
    email : new FormControl('', [Validators.required, Validators.email]),
    phoneNumber : new FormControl('', [Validators.required]),
    feedBack_Name : new FormControl('', [Validators.required]),
    createdBy : new FormControl('', [Validators.required]),
    message : new FormControl('', [Validators.required]),
    message_Date : new FormControl(new Date),

    })
    
  constructor(public  home:HomeService) { }

  ngOnInit(): void {
    this.home.GetContact();
    this.home.getContactInfo();
  }
  AddFeedback(){
    this.home.postFeedback(this.FeedbackForm.value);
  }
}
