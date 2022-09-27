
import { Component, Input, OnDestroy, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Subject } from 'rxjs';
import { AdminService } from 'src/app/Services/admin.service';

@Component({
  selector: 'app-manage-about-us',
  templateUrl: './manage-about-us.component.html',
  styleUrls: ['./manage-about-us.component.css',

  '../../../assets/Dashboard/css/animate.css/css/animate.css',

  '../../../assets/Dashboard/css/style.css',
  '../../../assets/Dashboard/css/jquery.mCustomScrollbar.css']
})
export class ManageAboutUsComponent implements OnInit {
  record:any={};
  aboutus:any=[{}];
  selectedAbout:any={};
  @ViewChild('CreateAbout') CreateAbout! :TemplateRef<any>;
  @ViewChild('UpdateAbout') UpdateAbout! :TemplateRef<any>;
  @ViewChild('DeleteAbout') DeleteAbout! :TemplateRef<any>;
  @ViewChild('DetailsAbout') DetailsAbout! :TemplateRef<any>;
 
  dtOptions: DataTables.Settings = {};

  dtTrigger: Subject<any> = new Subject<any>();
  AboutUs:FormGroup=new FormGroup({
    aboutUsName:new FormControl('',Validators.required),
    header1:new FormControl('',Validators.required),
    header2:new FormControl('',Validators.required),
    instagram:new FormControl('',Validators.required),
    text1:new FormControl('',Validators.required),
    text2:new FormControl('',Validators.required),
    imagePath1:new FormControl(''),
    imagePath2:new FormControl(''),
    imagePath3:new FormControl(''),

  })

  AboutUsUpdate:FormGroup=new FormGroup({
    aboutUsName:new FormControl('',Validators.required),
    aboutUsId:new FormControl('',Validators.required),
    header1:new FormControl('',Validators.required),
    header2:new FormControl('',Validators.required),
    instagram:new FormControl('',Validators.required),
    text1:new FormControl('',Validators.required),
    text2:new FormControl('',Validators.required),
    imagePath1:new FormControl(''),
    imagePath2:new FormControl(''),
    imagePath3:new FormControl(''),

  })

  constructor(public dialog: MatDialog,public service:AdminService) { }

  p_data:any={};
  ngOnInit(): void {
    this.service.getAboutUs().subscribe(
      (res) => {
        this.aboutus = res;
       this.dtTrigger.next(this.aboutus)
        this.service.spinner.hide();
      },
      (err) => {
        this.service.spinner.hide();
        this.service.toastr.error('Something is wrong');
      }
    );;
    
  }

  uploadImage(file:any,type:string)
  {
    
    if(file.length==0)
    return ; 
    let fileToUpload=<File>file[0];//
    const formDate=new FormData();//object 
    formDate.append('file',fileToUpload,fileToUpload.name);
  
    this.service.uploadAttachment(formDate,type);
  }
  
  newAbout(){
    
this.service.createAbout(this.AboutUs.value);
  }

  OpenCreate(){
    this.dialog.open(this.CreateAbout);
  }

OpenUpdate(obj:any){
  this.p_data={
    aboutUsId:obj.aboutUsId,
    aboutUsName:obj.aboutUsName,
    header1:obj.header1,
    header2:obj.header2,
    text1:obj.text1,
    text2:obj.text2,
    imagePath1:obj.imagePath1,
    imagePath2:obj.imagePath2,
    imagePath3:obj.imagePath3
  }

    this.dialog.open(this.UpdateAbout);
    this.AboutUsUpdate.controls['aboutUsId'].setValue(this.p_data.aboutUsId); 
    this.AboutUsUpdate.controls['imagePath1'].setValue(this.p_data.imagePath1); 
    this.AboutUsUpdate.controls['imagePath2'].setValue(this.p_data.imagePath2); 
    this.AboutUsUpdate.controls['imagePath3'].setValue(this.p_data.imagePath3); 

}
  


UpdateAboutUs(){

  this.service.UpdateAboutUs(this.AboutUsUpdate.value);

}

  deleteAbout(id: number) {
    
    const dialogVal = this.dialog.open(this.DeleteAbout);
    dialogVal.afterClosed().subscribe((result) => {
      if (result != undefined) {
        if (result == 'yes')
          this.service.DeleteAbout(id);

      }
    })

  }
  goToProfile(obj:any){
    this.selectedAbout={
      aboutUsId:obj.aboutUsId,
      aboutUsName:obj.aboutUsName,
     header1:obj.header1,
     header2:obj.header2,
     text1:obj.text1,
     text2:obj.text2,
    imagePath1:obj.imagePath1,
    imagePath2:obj.imagePath2,
    imagePath3:obj.imagePath3,
    }
  

    const dialogVal = this.dialog.open(this.DetailsAbout, {
      height: '500px'
    });
    
  }
}