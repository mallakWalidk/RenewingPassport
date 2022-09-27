import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { NgxSpinner, NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { AdminService } from 'src/app/Services/admin.service';

@Component({
  selector: 'app-website-pages',
  templateUrl: './website-pages.component.html',
  styleUrls: ['./website-pages.component.css',
  '../../../assets/Dashboard/css/animate.css/css/animate.css',
  '../../../assets/Dashboard/css/bootstrap/css/bootstrap.min.css',
  '../../../assets/Dashboard/css/style.css',
  '../../../assets/Dashboard/css/jquery.mCustomScrollbar.css']
})
export class WebsitePagesComponent implements OnInit {

Data:any={};
WebsitePages:FormGroup=new FormGroup({
  websitePagesName:new FormControl('',Validators.required),
  home_Id:new FormControl('',Validators.required),
  contactUs_Id:new FormControl('',Validators.required),
  contactInfo_Id:new FormControl('',Validators.required),
  aboutUs_Id:new FormControl('',Validators.required),
  
})

UpdateWebsitePages:FormGroup=new FormGroup({
  websitePagesId:new FormControl('',Validators.required),
  websitePagesName:new FormControl('',Validators.required),
  home_Id:new FormControl('',Validators.required),
  contactUs_Id:new FormControl('',Validators.required),
  contactInfo_Id:new FormControl('',Validators.required),
  aboutUs_Id:new FormControl('',Validators.required),
  status:new FormControl('',Validators.required),

})
@ViewChild('Website') Website! :TemplateRef<any>;
@ViewChild('DeleteWebsite') DeleteWebsite! :TemplateRef<any>;
@ViewChild('UpdateWebsite') UpdateWebsite! :TemplateRef<any>;
check:Boolean=false;
homePages: any = [{}];
contactPages: any = [{}];
ContactInfo: any = [{}];
AboutUs: any = [{}];

constructor(public service:AdminService,public dialog: MatDialog,private spinner:NgxSpinnerService,private toastr:ToastrService) { }
  ngOnInit(): void {
  
    this.service.GetHome().subscribe(
        (res) => {
          this.homePages = res;
          this.spinner.hide();
        },
        (err) => {
          this.spinner.hide();
          this.toastr.error('Something is wrong');
        }
      );
    
  
    this.service.getContactInfo().subscribe(
              (res) => {
          this.ContactInfo = res;
          this.spinner.hide();
        },
        (err) => {
          this.spinner.hide();
          this.toastr.error('Something is wrong');
        }
      );
  
    
  
    this.service.getAboutUs().subscribe(
        (res) => {
          this.AboutUs = res;
          this.spinner.hide();
        },
        (err) => {
          this.spinner.hide();
          this.toastr.error('Something is wrong');
        }
      );
  
    
  
    this.service.GetContactUs().subscribe(
        (res) => {
          this.contactPages = res;
          this.spinner.hide();
        },
        (err) => {
          this.spinner.hide();
          this.toastr.error('Something is wrong');
        }
      );
  
  this.service.GetWebsite();
  }

  newWebsitePage(){

    this.service.CreateWebsite(this.WebsitePages.value);
  }

  OpenCreate(){
    this.dialog.open(this.Website);

  }

  deleteAbout(id:number){
        const dialogVal= this.dialog.open(this.DeleteWebsite);
    dialogVal.afterClosed().subscribe((result)=>{
      if(result!=undefined)
        {
          if(result=='yes')
          this.service.DeleteWebsite(id);
   
             } })

}

OpenUpdate(body:any){
  
  this.Data={
    websitePagesId:body.websitePagesId,
    websitePagesName:body.websitePagesName,

    home_Id:body.home_Id,
    contactUs_Id:body.contactUs_Id,
    aboutUs_Id:body.aboutUs_Id,
    contactInfo_Id:body.contactInfo_Id,

    aboutUsName:body.aboutUsName,
    contactInfoName:body.contactInfoName,
    contactUsName:body.contactUsName,
    homeName:body.homeName
  }

  this.UpdateWebsitePages.controls['websitePagesId'].setValue(body.websitePagesId);
  this.UpdateWebsitePages.controls['status'].setValue(body.status);
  this.dialog.open(this.UpdateWebsite);

}
  
OpenUpdateWebsite(){
  this.service.UpdateWebsite(this.UpdateWebsitePages.value);
}

OpenActivate(obj:any,st:string){
obj.status=st;

this.service.UpdateWebsite(obj);
}

CheckActivate(){
  this.service.Data.forEach((element: { status: string; }) => {
    if (element.status=='Enabled')
    {
      this.check=true;
    }
  }); 
  return this.check;
}

}
