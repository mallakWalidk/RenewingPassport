import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class ReportService {

  constructor( 
    private http: HttpClient,
   ) { }

    GetReportAnnual(){
    return  this.http.get('https://localhost:44351/api/passport/GetReportAnnual')
    }
    GetReportMonthly(){
      return  this.http.get('https://localhost:44351/api/passport/GetReportMonthly')
      }
}
