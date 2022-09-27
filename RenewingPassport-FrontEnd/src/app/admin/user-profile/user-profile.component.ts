import { Component, EventEmitter, OnInit, Output, TemplateRef, ViewChild } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { AdminService } from 'src/app/Services/admin.service';


@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  constructor(public dialog: MatDialog,public admin:AdminService) { }
checkEmail:boolean=false;
emailError:string="";
checkUsername:boolean=false;
usernameError:string="";
checkPassword:boolean=false;

  @ViewChild('CallUpdateProfileDailog') CallUpdateProfileDailog! :TemplateRef<any>;
  @ViewChild('CallUpdatePasswordDailog') CallUpdatePasswordDailog! :TemplateRef<any>;
  @Output('ngModelChange') update = new EventEmitter();
  
  ngOnInit(): void {
  
    this.admin.getUserProfileById(Number(localStorage.getItem('id')));
    this.admin.GetUsernameAndEmail();
    
  }

  UpdateUserForm:FormGroup=new FormGroup({
    userId:new FormControl(Validators.required),
    fullName:new FormControl('',Validators.required),
    userName:new FormControl('',Validators.required),
    user_Email:new FormControl('',[Validators.required,Validators.email]),
    phoneNumber:new FormControl(''),
    userBD:new FormControl('',Validators.required),
    userImagePath:new FormControl('',Validators.required),
    gender:new FormControl('',Validators.required)

  })

  UpdatePasswordForm:FormGroup=new FormGroup({
    userId:new FormControl(Validators.required),
    oldPassword:new FormControl('',Validators.required),
    newPassword:new FormControl('',[Validators.required,Validators.minLength(8),Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%?&])[A-Za-z\d$@$!%?&]{0,}$/)]),
    newPasswordRepeated:new FormControl('',Validators.required)
  })


  p_data:any={};

  UpdateProfileDailog(obj:any){
   
    this.p_data={
      userId:obj.userId,
      fullName:obj.fullName,
      userName:obj.userName,
      phoneNumber:obj.phoneNumber,
      userBD:new Date(obj.userBD).toISOString().split('T')[0],
      gender:obj.gender,
      userImagePath:obj.userImagePath,
      user_Email:obj.user_Email
    }
 
    this.UpdateUserForm.controls['userId'].setValue(this.p_data.userId); 
    this.UpdateUserForm.controls['userImagePath'].setValue(this.p_data.userImagePath); 
    this.UpdateUserForm.controls['userBD'].setValue(this.p_data.userBD); 
    this.dialog.open(this.CallUpdateProfileDailog)
    
  }
  UpdateProfile(){
    this.admin.UpdateUserProfile(this.UpdateUserForm.value);
  }

  UpdatePasswordDailog(id:number)
  {
    this.p_data={
      userId:id,
    }
    this.UpdatePasswordForm.controls['userId'].setValue(this.p_data.userId); 
    this.dialog.open(this.CallUpdatePasswordDailog,{height:'450px'})

  }

  UpdatePassword(){
    
   
   this.admin.UpdateUserPassword(this.UpdatePasswordForm.value);
  }

  CheckUsername(event:string)
  {
    this.checkUsername=false;
    this.usernameError="";
    this.admin.UsernameAndEmail.forEach((element:any) => {

      const userName:string=element.userName;
      const userName1:string=event.toLowerCase();

      if(userName== userName1.trim() &&element.userId!=this.p_data.userId)
        {
          this.checkUsername=true;
          this.usernameError="Username invalid try another one"
        }
    });

  }
  CheckEmail(event:string)
  {
    this.checkEmail=false;
    this.emailError="";
    this.admin.UsernameAndEmail.forEach((element:any) => {

      const email:string=element.user_Email;
      const email1:string=event.toLowerCase();
  
      if(email== email1 &&element.userId!=this.p_data.userId)
      {
        this.checkEmail=true;
        this.emailError="Email invalid try another one"
      }

    });

  }

  CheckPassword()
  {
    if(this.UpdatePasswordForm.controls['newPassword'].value==this.UpdatePasswordForm.controls['newPasswordRepeated'].value)
    this.UpdatePasswordForm.controls['newPasswordRepeated'].setErrors(null)
    else 
    this.UpdatePasswordForm.controls['newPasswordRepeated'].setErrors({mismatch:true})
  }

  uploadImage(file:any,type:string)
  {
    
    if(file.length==0)
    return ; 
    let fileToUpload=<File>file[0];//
    const formDate=new FormData();//object 
    formDate.append('file',fileToUpload,fileToUpload.name);
   
    this.admin.uploadAttachment(formDate,type);
  }

}
