import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import jwt_decode from "jwt-decode";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private router:Router, 
    private http: HttpClient,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService
  ) { }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  login(email: any, pass: any) {
    
    let body = {
      email: email.toString().toLowerCase(),
      password: pass.toString()
    }

    const headerDict = {
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    }

    const requestOptions = {
      headers: new HttpHeaders(headerDict)
    }
    
    
    this.spinner.show();
    this.http.post('https://localhost:44351/api/JWT/login/', body, requestOptions).subscribe((res) => {
      const responce = {
        token: res.toString()
      }
      this.spinner.hide();
      localStorage.setItem('token', responce.token); // ecoded token
      let data: any = jwt_decode(responce.token); // decoded token
      
      localStorage.setItem('user', JSON.stringify({ ...data }));
      localStorage.setItem('id', data.nameid);
      localStorage.setItem('role',data.role);
      localStorage.setItem('given_name',data.given_name);
      localStorage.setItem('unique_name',data.unique_name);  
      
      if (data.role == 'Admin') {
        this.router.navigate(['admin']);
      } else if (data.role == 'User') {
        this.router.navigate(['user']);
      }
      
    }, err => {
      this.toastr.error(err.message, err.status)
      this.spinner.hide();
    });

  }

Register(body:any)
{ body.userName=body.userName.toLowerCase()
  body.user_Email=body.user_Email.toLowerCase()
  this.spinner.show();
  this.http.post('https://localhost:44351/api/user/Register/',body).subscribe(
  (res) => {
    
    this.spinner.hide();
    this.toastr.success('Created Succesfuly');
    this.reloadCurrentRoute()
  },
  (err) => {
    this.spinner.hide();
    this.toastr.error('Something is wrong');
  });

}

}


