import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdminService } from 'src/app/Services/admin.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private router: Router,public admin:AdminService) { }

  ngOnInit(): void {
    this.admin.getUserProfileById( Number(localStorage.getItem('id')));
  }

  Logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    localStorage.removeItem('id');
    localStorage.removeItem('role');
    localStorage.removeItem('given_name');
    localStorage.removeItem('unique_name');  
    this.router.navigate(['auth/'])
  }
}
