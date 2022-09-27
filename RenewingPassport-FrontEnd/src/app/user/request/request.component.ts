import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-request',
  templateUrl: './request.component.html',
  styleUrls: ['./request.component.css']
})
export class RequestComponent implements OnInit {
  data:any;
  passportInfo:any;
  passport:any;
  passportId:any;
  @ViewChild('NewRequest') NewRequest! :TemplateRef<any>;
  @ViewChild('RenewPassport') RenewPassport! :TemplateRef<any>;
  @ViewChild('Payment') Payment! :TemplateRef<any>;

  RequestForm:FormGroup=new FormGroup({
    userId:new FormControl(''),
    fullName:new FormControl('',Validators.required),
    userBD:new FormControl('',Validators.required),
    userImagePath:new FormControl(''),
    nationalNumber:new FormControl('',[Validators.required,Validators.minLength(10)]),
    motherName:new FormControl('',Validators.required),
    gender:new FormControl('',Validators.required),
    placeOfBirth:new FormControl('',Validators.required),
     oldPassportPath:new FormControl(''),
    identityPath:new FormControl(''),

  })

  PaymentForm:FormGroup=new FormGroup({
    name_On_Visa:new FormControl('',Validators.required),
    visa_Number:new FormControl('',Validators.required),
    visa_Cvv:new FormControl('',Validators.required),
    month1:new FormControl('',Validators.required),
    year1:new FormControl('',Validators.required),

  })
  // RenewForm:FormGroup=new FormGroup({
  //   userId:new FormControl(''),
  //   fullName:new FormControl('',Validators.required),
  //   userBD:new FormControl('',Validators.required),
  //   userImagePath:new FormControl(''),
  //   nationalNumber:new FormControl('',Validators.required),
  //   motherName:new FormControl('',Validators.required),
  //   gender:new FormControl('',Validators.required),
  //   placeOfBirth:new FormControl('',Validators.required),
  //    oldPassportPath:new FormControl('',Validators.required),
  //   identityPath:new FormControl('',Validators.required),

  // })
  constructor(public user:UserService,private dialog:MatDialog) { }
  ngOnInit(): void {

    this.user.GetPassport(Number(localStorage.getItem('id')));
    
    this.user.GetUserById(Number(localStorage.getItem('id')));
  }

//New Request

  requestNew(){
this.data=this.user.user[0];

this.data.userBD=new Date(this.data.userBD).toISOString().split('T')[0];
this.RequestForm.controls['userId'].setValue(this.data.userId);
this.RequestForm.controls['userImagePath'].setValue(this.data.userImagePath);
this.dialog.open(this.NewRequest);
  }

  uploadImage(file:any,type:string)
  {
    debugger;
    if(file.length==0)
    return ; 
    let fileToUpload=<File>file[0];//
    const formDate=new FormData();//object 
    formDate.append('file',fileToUpload,fileToUpload.name);
    this.user.uploadAttachment(formDate,type);
  }

  confirmRequest(){
    
    this.passportInfo={
      user_Id:this.RequestForm.controls['userId'].value,
      DateOfIssue:new Date(),
      status:"Pending"

    }
    this.user.NewPassport(this.RequestForm.value,this.passportInfo);

  }
  //New Request

  requestRenew(){
    this.data=this.user.user[0];

this.data.userBD=new Date(this.data.userBD).toISOString().split('T')[0];
this.RequestForm.controls['userId'].setValue(this.data.userId);
this.RequestForm.controls['userImagePath'].setValue(this.data.userImagePath);
this.dialog.open(this.RenewPassport);
  }

  // confirmRenew(){
  //   
  //   this.passportInfo={
  //     user_Id:this.RenewForm.controls['userId'].value,
  //     // DateOfIssue:new Date(),
  //     status:"Pending"

  //   }
  //   this.user.NewPassport(this.RenewForm.value,this.passportInfo);

  // }

//Payment
openPayment(){
this.dialog.open(this.Payment);
}

confirmPayment(){
  this.data={
    passId:this.user.passports.passId,
    status:"Renewed",
    user_Id:this.user.passports.user_Id
  }
  this.user.ChechVisa(this.PaymentForm.value,this.data);
}
}
