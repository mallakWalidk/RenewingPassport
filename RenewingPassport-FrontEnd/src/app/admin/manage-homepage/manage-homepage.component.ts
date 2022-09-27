import { ThisReceiver } from '@angular/compiler';
import { Component, Input, OnDestroy, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs';
import { AdminService } from 'src/app/Services/admin.service';

@Component({
  selector: 'app-manage-homepage',
  templateUrl: './manage-homepage.component.html',
  styleUrls: ['./manage-homepage.component.css',
  '../../../assets/Dashboard/css/animate.css/css/animate.css',
  '../../../assets/Dashboard/css/bootstrap/css/bootstrap.min.css',
  '../../../assets/Dashboard/css/style.css',
  '../../../assets/Dashboard/css/jquery.mCustomScrollbar.css']
})
export class ManageHomepageComponent implements OnInit,OnDestroy  {
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject<any>();
homepages:any=[{}];
selectedHome:any={};
  constructor(public dialog: MatDialog,
    public admin:AdminService,
    private spinner:NgxSpinnerService,
   
    private toastr:ToastrService) { }
  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();
  }

  ngOnInit(): void {
    this.admin.GetHome().subscribe(
      (res) => {
        this.homepages = res;
        this.dtTrigger.next(this.homepages)
     
        this.spinner.hide();
        
        
      },
      (err) => {
        this.spinner.hide();
        this.toastr.error('Something is wrong');
      }
    );
    this.dtOptions = {
      pagingType: 'full_numbers'
    };
  }
  @ViewChild('CallCreateDailog') CallCreateDailog! :TemplateRef<any>;
  @ViewChild('CallUpdateDailog') CallUpdateDailog! :TemplateRef<any>;
  @ViewChild('CallDeleteDailog') CallDeleteDailog! :TemplateRef<any>;
  @ViewChild('DetailsHome') DetailsHome! :TemplateRef<any>;

  createHomeForm:FormGroup=new FormGroup({
    homeName:new FormControl('',Validators.required),
    imagePath1:new FormControl(''),
    imagePath2:new FormControl(''),
    imagePath3:new FormControl(''),
    imagePath4:new FormControl(''),
    text1:new FormControl(''),
    text2:new FormControl(''),
    text3:new FormControl(''),
    text4:new FormControl(''),
    text5:new FormControl('')
  })

  UpdateHomeForm:FormGroup=new FormGroup({
    homeId:new FormControl(Validators.required),
    homeName:new FormControl('',Validators.required),
    imagePath1:new FormControl(''),
    imagePath2:new FormControl(''),
    imagePath3:new FormControl(''),
    imagePath4:new FormControl(''),
    text1:new FormControl(''),
    text2:new FormControl(''),
    text3:new FormControl(''),
    text4:new FormControl(''),
    text5:new FormControl('')
  })

  CreateDialog(){
    this.dialog.open(this.CallCreateDailog,{width:"700px"})
  }
Create()
{
  this.admin.CreateHome(this.createHomeForm.value);
  
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
    homeId:obj.homeId,
    homeName:obj.homeName,
    imagePath1:obj.imagePath1,
    imagePath2:obj.imagePath2,
    imagePath3:obj.imagePath3,
    imagePath4:obj.imagePath4,
    text1:obj.text1,
    text2:obj.text2,
    text3:obj.text3,
    text4:obj.text4,
    text5:obj.text5,
  }

  this.UpdateHomeForm.controls['homeId'].setValue(this.p_data.homeId); 
  this.UpdateHomeForm.controls['imagePath1'].setValue(this.p_data.imagePath1); 
  this.UpdateHomeForm.controls['imagePath2'].setValue(this.p_data.imagePath2); 
  this.UpdateHomeForm.controls['imagePath3'].setValue(this.p_data.imagePath3); 
  this.UpdateHomeForm.controls['imagePath4'].setValue(this.p_data.imagePath4); 
  this.dialog.open(this.CallUpdateDailog,{width:"700px"})
  
}
Update(){
  
  this.admin.UpdateHome(this.UpdateHomeForm.value);
 
}

Delete(id:number)
{
  const dialogVal= this.dialog.open(this.CallDeleteDailog);
  dialogVal.afterClosed().subscribe((result)=>{
    if(result!=undefined)
      {
        if(result=='yes')
        {
        this.admin.DeleteHome(id);
      
        }
      else (result=='no')
     
           }
  })

}

goToProfile(obj:any){
  debugger;
  this.selectedHome={
    homeId:obj.homeId,
    homeName:obj.homeName,
    imagePath1:obj.imagePath1,
    imagePath2:obj.imagePath2,
    imagePath3:obj.imagePath3,
    imagePath4:obj.imagePath4,
    text1:obj.text1,
    text2:obj.text2,
    text3:obj.text3,
    text4:obj.text4,
    text5:obj.text5,
  }


  const dialogVal = this.dialog.open(this.DetailsHome, {
    height: '500px'
  });
  
}
}


