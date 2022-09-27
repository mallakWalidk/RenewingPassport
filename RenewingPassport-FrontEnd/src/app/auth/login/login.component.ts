import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

import { AuthService } from 'src/app/Services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css',
  '../../../assets/Dashboard/css/animate.css/css/animate.css',
  '../../../assets/Dashboard/css/bootstrap/css/bootstrap.min.css',
  '../../../assets/Dashboard/css/style.css',
  '../../../assets/Dashboard/css/jquery.mCustomScrollbar.css']
})
export class LoginComponent implements OnInit {
  Email:String|any="";
  Pass:String|any="";
  email:FormControl= new FormControl('', [Validators.required,Validators.email]);
  password:FormControl = new FormControl('',Validators.required);
  rememberMe:boolean=false;
  constructor(private router:Router, public auth: AuthService,private spinner : NgxSpinnerService, private toaster:ToastrService) { }

  login(){
    if(this.rememberMe)
    {
      localStorage.setItem("email",this.email.value);
      localStorage.setItem("password",this.password.value);
    }
    else
    {
      localStorage.clear();
    }
    this.auth.login(this.email.value, this.password.value);
  }
  ngOnInit(): void {
    this.Email=localStorage.getItem('email');
    this.Pass=localStorage.getItem('password');
  }
  RememberMe()
  {
    this.rememberMe=!this.rememberMe
  }
}
