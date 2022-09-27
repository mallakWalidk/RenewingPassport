import { Component, OnDestroy, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Subject } from 'rxjs';
import { AdminService } from 'src/app/Services/admin.service';

@Component({
  selector: 'app-manage-feedback',
  templateUrl: './manage-feedback.component.html',
  styleUrls: ['./manage-feedback.component.css',
  '../../../assets/Dashboard/css/animate.css/css/animate.css',
  '../../../assets/Dashboard/css/bootstrap/css/bootstrap.min.css',
  '../../../assets/Dashboard/css/style.css',
  '../../../assets/Dashboard/css/jquery.mCustomScrollbar.css']
})
export class ManageFeedbackComponent implements OnInit,OnDestroy {
  dtTrigger: Subject<any> = new Subject<any>();
  Data:any=[{}];
  selectedFeedBack:any={};
  constructor(public service:AdminService,private dialog:MatDialog) { }
  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe()
  }
  @ViewChild('DeleteFeedbacks') DeleteFeedbacks! :TemplateRef<any>;
  @ViewChild('DetailsFeedbacks') DetailsFeedbacks! :TemplateRef<any>;

  ngOnInit(): void {
    this.service.GetFeedbacks().subscribe((res) => {
      this.Data = res;
      this.dtTrigger.next(this.Data)
      this.service.spinner.hide();
    }, err => {
      this.service.spinner.hide();
      this.service.toastr.error("Something is wrong");
    });
  }

  DeleteFeedback(id:number){

  const dialogVal= this.dialog.open(this.DeleteFeedbacks);
  dialogVal.afterClosed().subscribe((result)=>{
    if(result!=undefined)
      {
        if(result=='yes')
        this.service.DeleteFeedback(id);
 
           } })
  }
  goToProfile(obj:any){
    this.selectedFeedBack={
      feedBackID:obj.feedBackID,
      createdBy:obj.createdBy,
      feedBack_Name:obj.feedBack_Name,
      message:obj.message,
      email:obj.email,
      phoneNumber:obj.phoneNumber,
      message_Date:obj.message_Date,
      
      
   
    }
  
   
   this.dialog.open(this.DetailsFeedbacks, {
      height: '650px'
    });
    
  }


}
