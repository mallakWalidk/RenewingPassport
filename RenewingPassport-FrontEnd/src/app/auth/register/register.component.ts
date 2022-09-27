import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

import { AdminService } from 'src/app/Services/admin.service';
import { AuthService } from 'src/app/Services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css',
  '../../../assets/Dashboard/css/animate.css/css/animate.css',
  '../../../assets/Dashboard/css/bootstrap/css/bootstrap.min.css',
  '../../../assets/Dashboard/css/style.css',
  '../../../assets/Dashboard/css/jquery.mCustomScrollbar.css']
})
export class RegisterComponent implements OnInit {

  constructor(private router: Router,public auth:AuthService,public admin:AdminService, private toaster:ToastrService) { }
checkEmail:boolean=false;
emailError:string="";
checkUsername:boolean=false;
usernameError:string="";
hide = true;
  @Output('ngModelChange') update = new EventEmitter();
  
  ngOnInit(): void {
    this.admin.GetUsernameAndEmail();
  }

  RegisterForm:FormGroup=new FormGroup({
    fullName:new FormControl('',Validators.required),
    userName:new FormControl('',Validators.required),
    user_Email:new FormControl('',[Validators.required,Validators.email]),
    phoneNumber:new FormControl(''),
    userBD:new FormControl('',Validators.required),
    gender:new FormControl('',Validators.required),
    Password:new FormControl('',[Validators.required,Validators.minLength(8),Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%?&])[A-Za-z\d$@$!%?&]{0,}$/)]),
    PasswordRepeated:new FormControl('',Validators.required)
  })


  Register(){
this.auth.Register(this.RegisterForm.value);
this.router.navigate(['auth/login']);
  }


  CheckUsername(event:string)
  {
    this.checkUsername=false;
    this.usernameError="";
    this.admin.UsernameAndEmail.forEach((element:any) => {

      const userName:string=element.userName;
      const userName1:string=event.toLowerCase();

      if(userName== userName1.trim())
        {
          this.checkUsername=true;
          this.usernameError="Username invalid"
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
  
      if(email== email1)
      {
        this.checkEmail=true;
        this.emailError="Email invalid"
      }

    });

  }

  CheckPassword()
  {
    if(this.RegisterForm.controls['Password'].value==this.RegisterForm.controls['PasswordRepeated'].value)
    this.RegisterForm.controls['PasswordRepeated'].setErrors(null)
    else 
    this.RegisterForm.controls['PasswordRepeated'].setErrors({mismatch:true})
  }

}
