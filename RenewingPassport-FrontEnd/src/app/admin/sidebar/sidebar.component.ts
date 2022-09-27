import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/Services/admin.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css'
 ,
  '../../../assets/Dashboard/pages/waves/css/waves.min.css',
  
  '../../../assets/Dashboard/css/bootstrap/css/bootstrap.min.css',
  '../../../assets/Dashboard/pages/waves/css/waves.min.css',
  '../../../assets/Dashboard/icon/themify-icons/themify-icons.css',
  '../../../assets/Dashboard/icon/font-awesome/css/font-awesome.min.css',
 
  '../../../assets/Dashboard/css/style.css',
  '../../../assets/Dashboard/css/jquery.mCustomScrollbar.css'
]
})
export class SidebarComponent implements OnInit {

  constructor(public admin:AdminService) { }

  ngOnInit(): void {
    this.admin.getUserProfileById( Number(localStorage.getItem('id')));
  }

}
