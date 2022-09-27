import { Dialog } from '@angular/cdk/dialog';
import { Component, OnDestroy, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Subject } from 'rxjs';
import { AdminService } from 'src/app/Services/admin.service';

@Component({
  selector: 'app-requests',
  templateUrl: './requests.component.html',
  styleUrls: ['./requests.component.css',
  '../../../assets/Dashboard/css/animate.css/css/animate.css',
  '../../../assets/Dashboard/css/bootstrap/css/bootstrap.min.css',
  '../../../assets/Dashboard/css/style.css',
  '../../../assets/Dashboard/css/jquery.mCustomScrollbar.css']
})
export class RequestsComponent implements OnInit,OnDestroy {
  @ViewChild('RejectRequest') RejectRequest! :TemplateRef<any>;
  @ViewChild('ApproveRequest') ApproveRequest! :TemplateRef<any>;
  @ViewChild('DeleteRequests') DeleteRequests! :TemplateRef<any>;
  @ViewChild('DetailsRequests') DetailsRequests! :TemplateRef<any>;
  selectedRequest:any={};
  dtTrigger: Subject<any> = new Subject<any>();
  Data:any=[{}]
  reason:string='';
  constructor(public service:AdminService,private dialog:MatDialog) { }
  ngOnDestroy(): void {
    
  }

  ngOnInit(): void {
    this.service.GetRequesus().subscribe(
      (res) => {
        this.Data = res;
        this.dtTrigger.next(this.Data)
        this.service.spinner.hide();
        
       
      },
      (err) => {
        this.service.spinner.hide();
        this.service.toastr.error('Something is wrong');
      }
    );;
  }

  OpenRequest(obj:any,status:string){
    
    var  dialogVal;
    if(status=='Approved'){
     dialogVal= this.dialog.open(this.ApproveRequest);
    }
    else{
      dialogVal= this.dialog.open(this.RejectRequest);
    }

    dialogVal.afterClosed().subscribe((result)=>{
      if(result!=undefined)
        {
          if(result=='yes')
          obj.status=status;
          obj.rejectReason=this.reason;
          this.service.UpdateRequest(obj);
   
             } })
            }
      

  OpenDelete(id:number){
    const dialogVal= this.dialog.open(this.DeleteRequests);
    dialogVal.afterClosed().subscribe((result)=>{
      if(result!=undefined)
        {
          if(result=='yes')
          this.service.DeleteRequest(id);
   
             } })

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
  
  
    const dialogVal = this.dialog.open(this.DetailsRequests, {
      height: '650px'
    });
    
  }

}
