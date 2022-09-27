import { Component, OnDestroy, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Subject } from 'rxjs';
import { AdminService } from 'src/app/Services/admin.service';

@Component({
  selector: 'app-manage-contact-info',
  templateUrl: './manage-contact-info.component.html',
  styleUrls: ['./manage-contact-info.component.css',
  '../../../assets/Dashboard/css/animate.css/css/animate.css',
  '../../../assets/Dashboard/css/bootstrap/css/bootstrap.min.css',
  '../../../assets/Dashboard/css/style.css',
  '../../../assets/Dashboard/css/jquery.mCustomScrollbar.css']
})
export class ManageContactInfoComponent implements OnInit,OnDestroy {
  record:any={};
  cInfo:any=[{}]
  selectedContact:any={};
  @ViewChild('CreateContact') CreateContact! :TemplateRef<any>;
  @ViewChild('UpdateContact') UpdateContact! :TemplateRef<any>;
  @ViewChild('DeleteContact') DeleteContact! :TemplateRef<any>;
  @ViewChild('DetailsContact') DetailsContact! :TemplateRef<any>;
  dtTrigger: Subject<any> = new Subject<any>();
  ContactInfo:FormGroup=new FormGroup({
    contactInfoName:new FormControl('',Validators.required),
    email:new FormControl('',Validators.required),
    phoneNumber:new FormControl('',Validators.required),
    instagram:new FormControl('',Validators.required),
    facebook:new FormControl('',Validators.required),
    twitter:new FormControl('',Validators.required),
    youtube:new FormControl('',Validators.required),

  })

  ContactInfoUpdate:FormGroup=new FormGroup({
    contactInfoId:new FormControl(''),
    contactInfoName:new FormControl('',Validators.required),
    email:new FormControl('',Validators.required),
    phoneNumber:new FormControl('',Validators.required),
    instagram:new FormControl('',Validators.required),
    facebook:new FormControl('',Validators.required),
    twitter:new FormControl('',Validators.required),
    youtube:new FormControl('',Validators.required),

  })
  constructor(public service:AdminService, public dialog:MatDialog) { }
  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe()
  }

  ngOnInit(): void {
    this.service.getContactInfo().subscribe(
      (res) => {
        this.cInfo = res;
        this.dtTrigger.next(this.cInfo)
        this.service.spinner.hide();
      },
      (err) => {
        this.service.spinner.hide();
        this.service.toastr.error('Something is wrong');
      }
    );
  }
  goToProfile(obj:any){
    this.selectedContact={
      contactInfoId:obj.contactInfoId,
      contactInfoName:obj.contactInfoName,
      email:obj.email,
      phoneNumber:obj.phoneNumber,
      instagram:obj.instagram,
      facebook:obj.facebook,
      twitter:obj.twitter,
      youtube:obj.youtube,
   
    }
  
    const dialogVal = this.dialog.open(this.DetailsContact, {
      height: '450px'
    });
    
  }

  OpenCreate(){
this.dialog.open(this.CreateContact,{width:"700px"});
  }


  newContact(){
    this.service.CreateContactInfo(this.ContactInfo.value);
  }

  OpenUpdate(obj:any){
    this.record.contactInfoId=obj.contactInfoId;
  this.record.contactInfoName=obj.contactInfoName;
  this.record.email=obj.email;
  this.record.phoneNumber=obj.phoneNumber;
  this.record.instagram=obj.instagram;
  this.record.twitter=obj.twitter;
  this.record.facebook=obj.facebook;
  this.record.youtube=obj.youtube;
  this.ContactInfoUpdate.controls['contactInfoId'].setValue(obj.contactInfoId);

  this.dialog.open(this.UpdateContact);
  }

  updateContact(){
    this.service.updateContact(this.ContactInfoUpdate.value);
  }

  deleteContact(id:number){
    const dialogVal= this.dialog.open(this.DeleteContact);
    dialogVal.afterClosed().subscribe((result)=>{
      if(result!=undefined)
        {
          if(result=='yes')
          this.service.deleteContact(id);
   
             } })}

}
