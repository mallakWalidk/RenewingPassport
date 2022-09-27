import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/Services/admin.service';
import { ChartService } from 'src/app/Services/chart.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: [
    './layout.component.css',
 
  '../../../assets/Dashboard/css/animate.css/css/animate.css',
  '../../../assets/Dashboard/css/bootstrap/css/bootstrap.min.css',
  '../../../assets/Dashboard/css/style.css',
  '../../../assets/Dashboard/css/jquery.mCustomScrollbar.css']
  
  
})
export class LayoutComponent implements OnInit {

  constructor(public chart:ChartService, private admin:AdminService) { }

  ngOnInit(): void {
    this.chart.GetCountRequests();
    this.chart.GetCountUser();
    this.admin.GenerateExpired();
  }

}
