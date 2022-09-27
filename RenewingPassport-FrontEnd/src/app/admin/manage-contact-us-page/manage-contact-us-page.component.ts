import { Component, OnDestroy, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Subject } from 'rxjs';
import { AdminService } from 'src/app/Services/admin.service';

@Component({
  selector: 'app-contact-us',
  templateUrl: './manage-contact-us-page.component.html',
  styleUrls: ['./manage-contact-us-page.component.css',
  
  '../../../assets/Dashboard/css/animate.css/css/animate.css',
  '../../../assets/Dashboard/css/bootstrap/css/bootstrap.min.css',
  '../../../assets/Dashboard/css/style.css',
  '../../../assets/Dashboard/css/jquery.mCustomScrollbar.css']
})
export class ManageContactUsPageComponent implements OnInit,OnDestroy {
  dtTrigger: Subject<any> = new Subject<any>();
  @ViewChild('DetailsContactUs') DetailsContactUs! :TemplateRef<any>;
  selectedContactUs:any={};
  constructor(public dialog: MatDialog,public admin:AdminService) { }
  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe()
  }
  contactPages:any=[{}]
  ngOnInit(): void {
    this.admin.GetContactUs().subscribe(
      (res) => {
        this.contactPages = res;
        this.dtTrigger.next(this.contactPages)
        this.admin.spinner.hide();
      
      },
      (err) => {
        this.admin.spinner.hide();
        this.admin.toastr.error('Something is wrong');
      }
    );
  }
  @ViewChild('CallCreateDailog') CallCreateDailog! :TemplateRef<any>;
  @ViewChild('CallUpdateDailog') CallUpdateDailog! :TemplateRef<any>;
  @ViewChild('CallDeleteDailog') CallDeleteDailog! :TemplateRef<any>;


  CreateContactUsForm:FormGroup=new FormGroup({
    contactUsName:new FormControl('',Validators.required),
    header1:new FormControl(''),
    header2:new FormControl(''),
    text1:new FormControl(''),
    text2:new FormControl(''),
    imagePath1:new FormControl(''),
    imagePath2:new FormControl(''),
  })

  UpdateContactUsForm:FormGroup=new FormGroup({
    contactUsId:new FormControl(Validators.required),
    contactUsName:new FormControl('',Validators.required),
    header1:new FormControl(''),
    header2:new FormControl(''),
    text1:new FormControl(''),
    text2:new FormControl(''),
    imagePath1:new FormControl(''),
    imagePath2:new FormControl('')
  })

  CreateDialog(){
    this.dialog.open(this.CallCreateDailog,{width:"700px"})
  }
Create()
{
  this.admin.CreateContactUs(this.CreateContactUsForm.value);
  
}

uploadImage(file:any,type:string)
{
  
  if(file.length==0)
  return ; 
  let fileToUpload=<File>file[0];//
  const formDate=new FormData();//object 
  formDate.append('file',fileToUpload,fileToUpload.name);
  this.admin.uploadAttachment(formDate,type);
}
p_data:any={};
UpdateDailog(obj:any){
  
  this.p_data={
    contactUsId:obj.contactUsId,
    contactUsName:obj.contactUsName,
    header1:obj.header1,
    header2:obj.header2,
    text1:obj.text1,
    text2:obj.text2,
    imagePath1:obj.imagePath1,
    imagePath2:obj.imagePath2,
  }
  
  this.UpdateContactUsForm.controls['contactUsId'].setValue(this.p_data.contactUsId); 
  this.UpdateContactUsForm.controls['imagePath1'].setValue(this.p_data.imagePath1); 
  this.UpdateContactUsForm.controls['imagePath2'].setValue(this.p_data.imagePath2); 
  this.dialog.open(this.CallUpdateDailog,{width:"700px"})
  
}
Update(){
  
  this.admin.UpdateContactUs(this.UpdateContactUsForm.value);
}

Delete(id:number)
{
  
  const dialogVal= this.dialog.open(this.CallDeleteDailog);
  dialogVal.afterClosed().subscribe((result)=>{
    if(result!=undefined)
      {
        if(result=='yes')
        this.admin.DeleteContactUs(id);
      else (result=='no')
     
           }
  })
}
goToProfile(obj:any){
  this.selectedContactUs={
    contactUsId:obj.contactUsId,
    contactUsName:obj.contactUsName,
    header1:obj.header1,
    header2:obj.header2,
    text1:obj.text1,
    text2:obj.text2,
    imagePath1:obj.imagePath1,
    imagePath2:obj.imagePath2,
   
  }
  const dialogVal = this.dialog.open(this.DetailsContactUs, {
    height: '500px'
  });
}
}
