import { AfterViewInit, Component, OnDestroy, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import {  Subject } from 'rxjs';
import 'rxjs';
import { AdminService } from 'src/app/Services/admin.service';
import { ReportService } from 'src/app/Services/report.service';
import * as XLSX from 'xlsx';
@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: [
    './reports.component.css',
 
  '../../../assets/Dashboard/css/animate.css/css/animate.css',
  '../../../assets/Dashboard/css/bootstrap/css/bootstrap.min.css',
  '../../../assets/Dashboard/css/style.css',
  '../../../assets/Dashboard/css/jquery.mCustomScrollbar.css']
})
export class ReportsComponent implements OnInit ,AfterViewInit{
  months:any=[];
  years:any=[];
  fileName= 'ExcelSheet.xlsx';
  dtOptions: any = {};
  dtTrigger: Subject<any> = new Subject<any>();
  dtOption: any = { };
  dtTriggers: Subject<any> = new Subject<any>();
  constructor(
    public admin:AdminService
    ,private report:ReportService
    ,private toastr:ToastrService
    ,private spinner:NgxSpinnerService) { }
  ngAfterViewInit(): void {
    
  }
 
 
  ngOnInit(): void {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 3,
      processing: true,
      dom: 'Bfrtip',
        buttons: [
            'copy', 'csv', 'excel', 'print'
        ]
    };
   
    this.GetReportAnnual()
    this.GetReportMonthly()
   
   

  }
  exportReportMonthly(): void
  {
    /* pass here the table id */
    let element = document.getElementById('Monthly');
    const ws: XLSX.WorkSheet =XLSX.utils.table_to_sheet(element);
 
    /* generate workbook and add the worksheet */
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
 
    /* save to file */  
    XLSX.writeFile(wb, 'MonthlyReport.xlsx');
 
  }
  exportReportYearly(): void
  {
    /* pass here the table id */
    let element = document.getElementById('Yearly');
    const ws: XLSX.WorkSheet =XLSX.utils.table_to_sheet(element);
 
    /* generate workbook and add the worksheet */
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
 
    /* save to file */  
    XLSX.writeFile(wb, 'AnualReport.xlsx');
 
  }

   
     GetReportAnnual(){
    
  
    this.spinner.show();
    this.report.GetReportAnnual().subscribe(res=>{
      
      this.spinner.hide()
     
      this.years=res
      this.dtTrigger.next(res)
     
      
      
      
      
      

    },err=>{
       this.spinner.hide()
      this.toastr.error('Something Wrong')})
    }
    GetReportMonthly(){
      this.spinner.show();
      this.report.GetReportMonthly().subscribe(res=>{
        this.spinner.hide();
 
        this.months=res;
        this.dtTriggers.next(res)
        
      },err=>{
        this.spinner.hide()
       this.toastr.error('Something Wrong')})
      }

}
