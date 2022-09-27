import { Injectable } from '@angular/core';
import{HttpClient}from '@angular/common/http'
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from "ngx-spinner";

@Injectable({
  providedIn: 'root'
})
export class HomeService {
PagesInfo:any={};
contactInfo:any={};
aboutUs:any={};
contactUs:any={};
Testimonials:any=[];
Testimonials1:any=[{}];
 i: number = 0;
 display_Image: any = {};

  constructor(private http:HttpClient,private spinner:NgxSpinnerService,private toastr:ToastrService) {}

  getHome(){
  this.spinner.show();
  this.http.get("https://localhost:44351/api/homepage/getcurrentpage").subscribe((res)=>{
    this.PagesInfo=res;
    this.spinner.hide();
  },err=>{
    this.spinner.hide();
    this.toastr.error("Something is wrong");
  })}

  getContactInfo(){
    this.spinner.show();
    this.http.get("https://localhost:44351/api/contactinfo/getcurrentpage").subscribe((res)=>{
  
      this.contactInfo=res;
      this.spinner.hide();
    },err=>{
      this.spinner.hide();
      this.toastr.error("Something is wrong");
    })}
  
    getAbout(){
      this.spinner.show();
      this.http.get("https://localhost:44351/api/aboutus/getcurrentpage").subscribe((res)=>{
        this.aboutUs=res;
        console.log(res);
        this.spinner.hide();
      },err=>{
        this.spinner.hide();
        this.toastr.error("Something is wrong");
      })}
    
    GetContact(){
        this.spinner.show();
        this.http.get("https://localhost:44351/api/contactus/getcurrentpage").subscribe((res)=>{
          this.contactUs=res;
          this.spinner.hide();
        },err=>{
          this.spinner.hide();
          this.toastr.error("Something is wrong");
        })}

   GetTestimonial(){
          this.spinner.show();
          this.http.get("https://localhost:44351/api/Testimonial/GetAcceptedTestimonial").subscribe((res)=>{
            this.Testimonials1=res;
            

            
            if (this.Testimonials1.length <= 10) {
             
              this.Testimonials1.forEach((ts:any) => {
                
                if(this.i!=0){ 
                  if (ts.imagePath==null)
                  ts.imagePath='default.jpg';
                  this.Testimonials.push(ts)}
                  this.i++;
              });
         
            }
            else {
              
              this.Testimonials1.forEach((ts:any) => {
                
                if(this.i!=0 && this.i<10){
                  if (ts.imagePath==null)
                  ts.imagePath='default.jpg';
                  this.Testimonials.push(ts)  }

                  this.i++;
              });
            
            }
            
            this.spinner.hide();
          },err=>{
            this.spinner.hide();
            this.toastr.error("Something is wrong");
          });
        
        }
       

        CreateTestimonial(body:any){
          this.spinner.show();
          body.imagePath = this.display_Image.imagePath;
          if(this.display_Image.imagePath==null){
            body.imagePath='DefaultProfilePicture.png'
          }
          
          this.http.post("https://localhost:44351/api/Testimonial/",body).subscribe((res)=>{
            this.toastr.success('Thank you for your testimony ❤️');

            this.spinner.hide();
          },(err)=>{
            this.spinner.hide();
            
            this.toastr.error("Something is wrong");
            
          });
        
         
        }

        uploadAttachment(file: FormData, type: string) {
          
          this.http.post('https://localhost:44351/api/homepage/UploadImage', file).subscribe(
              (resp: any) => {
                if (resp) {
                  this.display_Image[type] = resp.imagePath1;
                }
              },
              (err) => {
              }
            );
        }

 postFeedback(body:any){
  this.spinner.show();
  this.http.post("https://localhost:44351/api/feedback",body).subscribe((res)=>{
    this.spinner.hide();
this.toastr.success("Your message has send");
  },err=>{
    this.spinner.hide();
    this.toastr.error("Something is wrong");
  })}

  

}
