import { Component, OnInit } from '@angular/core';
import { Chart } from 'chart.js';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';



import { ChartService } from 'src/app/Services/chart.service';
@Component({
  selector: 'app-chart-gender',
  templateUrl: './chart-gender.component.html',
  styleUrls: ['./chart-gender.component.css',
  '../../../assets/Dashboard/css/animate.css/css/animate.css',
  '../../../assets/Dashboard/css/bootstrap/css/bootstrap.min.css',
  '../../../assets/Dashboard/css/style.css',
  '../../../assets/Dashboard/css/jquery.mCustomScrollbar.css']
})
export class ChartGenderComponent implements OnInit {

  constructor(
    private chartservice:ChartService,
  
   ) { }

  ngOnInit(): void {
    this.chartservice.GetByGender();
   
   
  }
  


  }


