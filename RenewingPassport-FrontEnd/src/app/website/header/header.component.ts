import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HomeService } from 'src/app/Services/home.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  CheckUser:boolean=false;
  CheckAdmin:boolean=false;
  constructor(public home:HomeService,private router: Router) { 
  }

  ngOnInit(): void {
    this.home.getContactInfo();
    this.User();
    this.Admin();
  }


  User(){
    if(localStorage.getItem('role')=="User")
      this.CheckUser=true;
    else
      this.CheckUser=false;

  }
  Admin(){
    if(localStorage.getItem('role')=="Admin")
      this.CheckAdmin=true;
    else
      this.CheckAdmin=false;

  }
  logout(){
   
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    localStorage.removeItem('id');
    localStorage.removeItem('role');
    localStorage.removeItem('given_name');
    localStorage.removeItem('unique_name');  
    this.router.navigate(['auth/'])
  }
}
