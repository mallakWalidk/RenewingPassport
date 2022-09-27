import { Component, OnInit } from '@angular/core';
import { ChartService } from 'src/app/Services/chart.service';

@Component({
  selector: 'app-chart-date',
  templateUrl: './chart-date.component.html',
  styleUrls: [
    './chart-date.component.css',
  '../../../assets/Dashboard/css/animate.css/css/animate.css',
  '../../../assets/Dashboard/css/bootstrap/css/bootstrap.min.css',
  '../../../assets/Dashboard/css/style.css',
  '../../../assets/Dashboard/css/jquery.mCustomScrollbar.css']
})
export class ChartDateComponent implements OnInit {

  constructor(private chart:ChartService) { }

  ngOnInit(): void {
    this.chart.GetCountByDate()
  }

}
