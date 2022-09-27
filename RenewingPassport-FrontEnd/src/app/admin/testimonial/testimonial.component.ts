import { Component, OnDestroy, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Subject } from 'rxjs';
import { AdminService } from 'src/app/Services/admin.service';

@Component({
  selector: 'app-testimonial',
  templateUrl: './testimonial.component.html',
  styleUrls: ['./testimonial.component.css',
  '../../../assets/Dashboard/css/animate.css/css/animate.css',
  '../../../assets/Dashboard/css/bootstrap/css/bootstrap.min.css',
  '../../../assets/Dashboard/css/style.css',
  '../../../assets/Dashboard/css/jquery.mCustomScrollbar.css']
})
export class TestimonialComponent implements OnInit,OnDestroy {
  @ViewChild('DeleteTestimonial') DeleteTestimonial! :TemplateRef<any>;
  @ViewChild('DetailsTestimonial') DetailsTestimonial! :TemplateRef<any>;
  selectedTestimonial:any={};
  constructor(public service:AdminService,private dialog:MatDialog) { }
  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe()
  }
  dtTrigger: Subject<any> = new Subject<any>();
  Data:any=[{}]
  ngOnInit(): void {
    this.service.getTestimonial().subscribe(
      (res) => {
        this.Data = res;
        this.dtTrigger.next(this.Data)
        this.service.spinner.hide();
      },
      (err) => {
        this.service.spinner.hide();
        this.service.toastr.error('Something is wrong');
      }
    );
  }

  ChangeStatus(obj:any,status:string){
    obj.status=status;
    this.service.ChangeStatus(obj);
  }
  DeleteTesti(id:number){

      const dialogVal= this.dialog.open(this.DeleteTestimonial);
  dialogVal.afterClosed().subscribe((result)=>{
    if(result!=undefined)
      {
        if(result=='yes')
        this.service.DeleteTestimonial(id);
 
           } })
  }
  goToProfile(obj:any){
    this.selectedTestimonial={
      testimonialID:obj.testimonialID,
      senderName:obj.senderName,
      message:obj.message,
      message_Date:obj.message_Date,
     
      imagePath:obj.imagePath,
      status:obj.status,
     
    }
  
   
    const dialogVal = this.dialog.open(this.DetailsTestimonial, {
      height: '670px'
    });
    
  }
}
