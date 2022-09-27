import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Chart } from 'chart.js';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ChartService {
  countRequest: any = [{}];
  countUser: any = [{}];
  constructor(
    private http: HttpClient,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService
  ) { }

  GetByGender(){
    this.spinner.show();
    this.http.get<any>('https://localhost:44351/api/chart/GetCountByGender').subscribe(res=>{
      const myChart = new Chart("genderChart", {
        
        type: 'pie',
         data: {
      labels:res.map((i:any)=>i.gender.toUpperCase( )),
      datasets: [{
        label: 'My First Dataset',
        data: res.map((i:any)=>i.passports),
        
        
        backgroundColor: [
          'rgb(255, 99, 132)',
          'rgb(54, 162, 235)',
          
        ],
      
       
      }]
      }
      });
    this.spinner.hide()
    
    
    })
  }
  
  GetCountByStatus(){
    this.spinner.show();
    this.http.get<any>('https://localhost:44351/api/chart/GetCountByStatus').subscribe(res=>{
      const myChart = new Chart("countStatus", {
        
        type: 'doughnut',
         data: {
      labels:res.map((i:any)=>i.status),
      datasets: [{
        label: 'My First Dataset',
        data: res.map((i:any)=>i.passports),
        
        
        backgroundColor: [
          'rgb(255, 99, 132)',
          'rgb(54, 162, 235)',
          'rgb(255, 205, 86)',
          '#6f42c1',
          '#6c757d',
          '#198754',
          '#343a40'
          
        ],
        hoverBackgroundColor:[ 
          'rgb(255, 99, 132)',
        'rgb(54, 162, 235)',
        'rgb(255, 205, 86)',
        '#6f42c1',
          '#6c757d',
          '#198754',
        '#343a40']
      
       
      }]
      }
      });
    this.spinner.hide()
    })
  }
  GetCountByDate(){
    this.spinner.show();
    this.http.get<any>('https://localhost:44351/api/chart/GetCountByDate').subscribe(res=>{
      const myChart = new Chart("countDate", {
        type: 'bar',
        data: {
          labels: res.map((i:any)=>i.month),
          datasets: [{
            label: 'count renewed by date',
            data: res.map((i:any)=>i.passports),
            
            borderColor: 'rgb(54, 162, 235)',
            backgroundColor:'rgb(54, 162, 235)',
            hoverBackgroundColor:'rgb(54, 162, 235)'
          
          }]
        }
    
      });
    this.spinner.hide()
    })
  }
  GetCountRequests() {
  
    this.http
      .get('https://localhost:44351/api/passport/GetCountRequests')
      .subscribe(
        (res) => {
          this.countRequest = res;
          
        },
        (err: any) => {
          this.spinner.hide();
          this.toastr.error(err.message);
        }
      );
  }
  GetCountUser() {
  
    this.http
      .get('https://localhost:44351/api/user/GetUsersCount')
      .subscribe(
        (res) => {
          this.countUser = res;
          
        },
        (err: any) => {
          this.spinner.hide();
          this.toastr.error(err.message);
        }
      );
  }
}
