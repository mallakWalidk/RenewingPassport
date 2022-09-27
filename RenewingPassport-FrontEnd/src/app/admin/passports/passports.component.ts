import { Component,OnInit, OnDestroy, AfterViewInit, ViewChild, TemplateRef } from '@angular/core';
import { AdminService } from 'src/app/Services/admin.service';
import 'rxjs';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';
import { ToastrService } from 'ngx-toastr';
import { MatDialog } from '@angular/material/dialog';
@Component({
  selector: 'app-passports',
  templateUrl: './passports.component.html',
  styleUrls: ['./passports.component.css',
  '../../../assets/Dashboard/css/animate.css/css/animate.css',
  '../../../assets/Dashboard/css/bootstrap/css/bootstrap.min.css',
  '../../../assets/Dashboard/css/style.css',
  '../../../assets/Dashboard/css/jquery.mCustomScrollbar.css']
})
export class PassportsComponent implements OnInit {
Data:any=[]
dtOptions: DataTables.Settings = {};

@ViewChild('DetailsPassport') DetailsPassport! :TemplateRef<any>;
selectedRequest:any={};
 

  constructor(
    public service:AdminService
    ,private spinner:NgxSpinnerService
    ,private toastr:ToastrService
    ,private dialog:MatDialog
   ) { }



  ngOnInit(): void {

    this.dtOptions = {
      dom: 'Bfrtip',
      lengthMenu: [
          [ 10, 25, 50, -1 ],
          [ '10 rows', '25 rows', '50 rows', 'Show all' ]
      ],
   

    };
    this.GetPassport()
    
   };
  
   GetPassport(){
    
    this.service.GetPassport().subscribe((res:any)=>{
      
      this.Data=res;
      
       
        
      this.spinner.hide()
      
     
    },err=>{
      this.spinner.hide()
    })
    
   }
  startdate:any='';
  endDate:any='';
  status='';
  startValue(ev:any){
    this.startdate=ev.target.value;
   

   
  }
  clearFillter(){
    
   this.startdate='';
   this.endDate='';
   this.status='';
   this.search()
   
  }
  statusValue(ev:any){
    this.status=ev.target.value;
  }
  endValue(ev:any){
    this.endDate=ev.target.value;
   

   
  }
  search(){

    const statusobj={
      status:(this.status).toString()
    }
    
    const passportObj=
    { 
      dateofIssue: (this.startdate).toString(),
      dateOfExpiry: (this.endDate).toString(),
      status:(this.status).toString()
      
    };
    const issueObj=
    { 
      dateofIssue: (this.startdate).toString(),
      status:(this.status).toString()
      
    };
    const endObj=
    { 
      dateofIssue: (this.endDate).toString(),
      status:(this.status).toString()
      
      
    };
    

     
    if(passportObj.dateofIssue!=''&& passportObj.dateOfExpiry=='')
    {
      this.service.searchDate(issueObj,'https://localhost:44351/api/passport/SearchBystartDate')
      .subscribe((res:any)=>{
        this.Data=res
        
        this.spinner.hide()
        
        },err=>{
          this.spinner.hide()
          this.toastr.error('Something Wrong')
        });
    }
    else if(passportObj.dateofIssue==''&& passportObj.dateOfExpiry!=''){
      this.service.searchDate(endObj,'https://localhost:44351/api/passport/SearchByEndDate')
      .subscribe((res)=>{
        this.Data=res
       
        this.spinner.hide()
        },err=>{
          this.spinner.hide()
          this.toastr.error('Something Wrong')
        
        });
    }
    else if(passportObj.dateofIssue!=''&& passportObj.dateOfExpiry!=''){
      this.service.searchDate(passportObj,'https://localhost:44351/api/passport/SearchByInterval')
      .subscribe((res)=>{
        this.spinner.hide()
        this.Data=res
     
        },err=>{
          this.spinner.hide()
          this.toastr.error('Something Wrong')
        
        });
    }
    else{
      this.service.searchDate(statusobj,'https://localhost:44351/api/passport/GetPassportByStatus')
      .subscribe((res)=>{
        this.spinner.hide()
        this.Data=res
     
        },err=>{
          this.spinner.hide()
          this.toastr.error('Something Wrong')
        
        });
    }
    
    }
    goToProfile(obj:any){
      this.selectedRequest={
        passId:obj.passId,
        fullName:obj.fullName,
        userName:obj.userName,
       
        userImagePath:obj.userImagePath,
        nationalNumber:obj.nationalNumber,
        motherName:obj.motherName,
        gender:obj.gender,
        placeOfBirth:obj.placeOfBirth,
        userBD:obj.userBD,
        athority:obj.athority,
        dateOfIssue:obj.dateOfIssue,
        dateOfExpiry:obj.dateOfExpiry,
        status:obj.status,
        oldPassportPath:obj.oldPassportPath,
        identityPath:obj.identityPath
      }
    
     
      const dialogVal = this.dialog.open(this.DetailsPassport, {
        height: '500px'
      });
      
    }
}
