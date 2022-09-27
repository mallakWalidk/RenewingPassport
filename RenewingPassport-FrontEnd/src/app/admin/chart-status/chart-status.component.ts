import { Component, OnInit } from '@angular/core';
import { ChartService } from 'src/app/Services/chart.service';

@Component({
  selector: 'app-chart-status',
  templateUrl: './chart-status.component.html',
 
  styleUrls: [
    
    './chart-status.component.css',
  '../../../assets/Dashboard/css/animate.css/css/animate.css',
  '../../../assets/Dashboard/css/bootstrap/css/bootstrap.min.css',
  '../../../assets/Dashboard/css/style.css',
  '../../../assets/Dashboard/css/jquery.mCustomScrollbar.css']
})
export class ChartStatusComponent implements OnInit {

  constructor( private chartservice:ChartService) { }

  ngOnInit(): void {
    this.chartservice.GetCountByStatus()
  }

}
