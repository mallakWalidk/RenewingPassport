import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AdminService {
  constructor(
    private http: HttpClient,
    public spinner: NgxSpinnerService,
    public toastr: ToastrService,
    private router :Router
  ) { }
  Data: any = [{}];
  obj: any = {};
  display_Image: any = {};

  
  user: any = [{}];
  UsernameAndEmail: any = [{}];

  //Home Manage//
  GetHome() {
    this.spinner.show();

    return this.http.get('https://localhost:44351/api/homepage')
  }

  CreateHome(body: any) {
    
    this.spinner.show();
    
    body.imagePath1 = this.display_Image.imagePath1;
    body.imagePath2 = this.display_Image.imagePath2;
    body.imagePath3 = this.display_Image.imagePath3;
    body.imagePath4 = this.display_Image.imagePath4;

    this.http.post('https://localhost:44351/api/homepage', body).subscribe(
      (res) => {
        this.spinner.hide();
        this.toastr.success('created Succesfuly');
        this.reloadCurrentRoute()
      },
      (err) => {
        this.spinner.hide();
        this.toastr.error('Something is wrong');
      }
    );
   
  }

  uploadAttachment(file: FormData, type: string) {
    
    this.http
      .post('https://localhost:44351/api/homepage/UploadImage', file)
      .subscribe(
        (resp: any) => {
          if (resp) {
            this.display_Image[type] = resp.imagePath1;
          }
        },
        (err) => {
        }
      );
  }

  UpdateHome(body: any) {
    this.spinner.show();
    
    if (this.display_Image.imagePath1 != null)
      body.imagePath1 = this.display_Image.imagePath1;
    if (this.display_Image.imagePath2 != null)
      body.imagePath2 = this.display_Image.imagePath2;
    if (this.display_Image.imagePath3 != null)
      body.imagePath3 = this.display_Image.imagePath3;
    if (this.display_Image.imagePath4 != null)
      body.imagePath4 = this.display_Image.imagePath4;

    this.http.put('https://localhost:44351/api/homepage', body).subscribe(
      (resp) => {
        this.spinner.hide();
        this.toastr.success('Updated Successfully');
        this.reloadCurrentRoute()
      },
      (err) => {
        this.spinner.hide();
        this.toastr.error(err.message);
      }
    );
   
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }

  DeleteHome(id: number) {
    this.spinner.show();
    this.http
      .delete('https://localhost:44351/api/homepage/delete/' + id)
      .subscribe(
        (resp) => {
          this.spinner.hide();
          this.toastr.success('Deleted Successfully');
          this.reloadCurrentRoute()
        },
        (err) => {
          this.spinner.hide();
          this.toastr.error(err.message);
        }
      );
    //window.location.reload();
  }
  //Home Manage//

  //Conact us Manage//
  GetContactUs() {
    this.spinner.show();

   return this.http.get('https://localhost:44351/api/contactus')
  }

  CreateContactUs(body: any) {
    
    this.spinner.show();
    
    body.imagePath1 = this.display_Image.imagePath1;
    body.imagePath2 = this.display_Image.imagePath2;

    this.http.post('https://localhost:44351/api/ContactUs', body).subscribe(
      (res) => {
        this.spinner.hide();
        this.toastr.success('Created Succesfuly');
        this.reloadCurrentRoute()
      },
      (err) => {
        this.spinner.hide();
        this.toastr.error('Something is wrong');
      }
    );
   
  }

  UpdateContactUs(body: any) {
    this.spinner.show();
    
    if (this.display_Image.imagePath1 != null)
      body.imagePath1 = this.display_Image.imagePath1;
    if (this.display_Image.imagePath2 != null)
      body.imagePath2 = this.display_Image.imagePath2;

    this.http.put('https://localhost:44351/api/ContactUs', body).subscribe(
      (resp) => {
        this.spinner.hide();
        this.toastr.success('Updated Successfully');
        this.reloadCurrentRoute()
      },
      (err) => {
        this.spinner.hide();
        this.toastr.error(err.message);
      }
    );
   
  }

  DeleteContactUs(id: number) {
    
    this.spinner.show();
    this.http
      .delete('https://localhost:44351/api/ContactUs/delete/' + id)
      .subscribe(
        (resp) => {
          this.spinner.hide();
          this.toastr.success('Deleted Successfully');
          this.reloadCurrentRoute()
        },
        (err) => {
          this.spinner.hide();
          this.toastr.error(err.message);
        }
      );
   
  }
  //Conact us Manage//

  //Conact Info Manage//
  getContactInfo() {
    this.spinner.show();
    
   return this.http.get('https://localhost:44351/api/contactinfo/')
  }

  CreateContactInfo(body: any) {
    this.spinner.show();
    
    this.http.post('https://localhost:44351/api/contactinfo/', body).subscribe(
      (res) => {
        this.toastr.success('Created Successfully');
        this.spinner.hide();
        this.reloadCurrentRoute()
      },
      (err) => {
        this.spinner.hide();
        this.toastr.error('Something is wrong');
      }
    );
  }

  updateContact(body: any) {
    this.spinner.show();
    this.http.put('https://localhost:44351/api/contactinfo/', body).subscribe(
      (res) => {
        this.toastr.success('Updated Successfully');
        this.spinner.hide();
        this.reloadCurrentRoute()
      },
      (err) => {
        this.spinner.hide();
        this.toastr.error('Something is wrong');
      }
    );
  }

  deleteContact(id: number) {
    this.spinner.show();
    
    this.http
      .delete('https://localhost:44351/api/contactinfo/delete/' + id)
      .subscribe(
        (res) => {
          this.toastr.success('Deleted Successfully');
          this.spinner.hide();
          this.reloadCurrentRoute()
        },
        (err) => {
          this.spinner.hide();
          this.toastr.error('Something is wrong');
        }
      );
  }

  //Conact Info Manage//

  //Report//


  //About us Manage//
  getAboutUs() {
    this.spinner.show();
    return this.http.get('https://localhost:44351/api/aboutus/')
  }

  createAbout(body: any) {
    this.spinner.show();
    
    body.imagePath1 = this.display_Image.imagePath1;
    body.imagePath2 = this.display_Image.imagePath2;
    body.imagePath3 = this.display_Image.imagePath3;
    this.http.post('https://localhost:44351/api/aboutus', body).subscribe(
      (res) => {
        this.spinner.hide();
        this.toastr.success('Created Succesfuly');
        this.reloadCurrentRoute()
      },
      (err) => {
        this.spinner.hide();
        this.toastr.error('Something is wrong');
      }
    );
    
  }

  UpdateAboutUs(body: any) {
    this.spinner.show();
    
    if (this.display_Image.imagePath1 != null)
      body.imagePath1 = this.display_Image.imagePath1;
    if (this.display_Image.imagePath2 != null)
      body.imagePath2 = this.display_Image.imagePath2;
    if (this.display_Image.imagePath3 != null)
      body.imagePath3 = this.display_Image.imagePath3;

    this.http.put('https://localhost:44351/api/aboutus', body).subscribe(
      (res) => {
        this.spinner.hide();
        this.toastr.success('Updated Succesfuly');
        this.reloadCurrentRoute()
      },
      (err) => {
        this.spinner.hide();
        this.toastr.error('Something is wrong');
      }
    );

  }

  DeleteAbout(id: number) {
    this.spinner.show();
    
    this.http
      .delete('https://localhost:44351/api/aboutus/delete/' + id)
      .subscribe(
        (res) => {
          this.toastr.success('Deleted Successfully');
          this.spinner.hide();
          this.reloadCurrentRoute()
        },
        (err) => {
          this.spinner.hide();
          this.toastr.error('Something is wrong');
        }
      );
  }

  //About us Manage//

  //Users//

  getUsers() {
    this.spinner.show();
   return this.http.get('https://localhost:44351/api/user/getalluser/')
  }

  getUserProfileById(id: number) {
    this.spinner.show();
    this.http
      .get('https://localhost:44351/api/user/GetUserProfileById/' + id)
      .subscribe(
        (res) => {
          this.user = res;
          this.spinner.hide();
        },
        (err) => {
          this.spinner.hide();
          this.toastr.error('Something is wrong');
        }
      );
  }

  GetUsernameAndEmail() {
    this.spinner.show();
    this.http
      .get('https://localhost:44351/api/user/GetUsernameAndEmail/')
      .subscribe(
        (res) => {
          this.UsernameAndEmail = res;
          this.spinner.hide();
        },
        (err) => {
          this.spinner.hide();
          this.toastr.error('Something is wrong');
        }
      );
  }
  UpdateUserProfile(body: any) {
    body.userName=body.userName.toLowerCase()
    body.user_Email=body.user_Email.toLowerCase()
    this.spinner.show();
    if (this.display_Image.userImagePath != null)
      body.userImagePath = this.display_Image.userImagePath;
    
    this.http
      .put('https://localhost:44351/api/user/UpdateUserProfile/', body)
      .subscribe(
        (res) => {
          
          this.spinner.hide();
          this.toastr.success('Updated Succesfuly');
          this.reloadCurrentRoute()
        },
        (err) => {
          this.spinner.hide();
          this.toastr.error('Something is wrong');
        }
      );
  
  }

  UpdateUserPassword(body: any) {
    this.spinner.show();

    
    this.http.put('https://localhost:44351/api/user/UpdatePassword/', body)
      .subscribe(
        (res) => {

          this.spinner.hide();
          this.toastr.success('Changed Succesfuly');
          this.reloadCurrentRoute()

        },
        (err) => {
          this.spinner.hide();
          this.toastr.error('Something is wrong try again');
        }
      );
    
  }

  //Users//

  // Testimonial //
  getTestimonial() {
    this.spinner.show();
  return  this.http
      .get('https://localhost:44351/api/testimonial/GetAllTestimonial')
      
  }

  ChangeStatus(body: any) {
    {
      this.spinner.show();
      this.http.put('https://localhost:44351/api/testimonial/', body).subscribe(
        (res) => {
          this.spinner.hide();
          this.toastr.success('Status Updated ');
        },
        (err) => {
          this.spinner.hide();
          this.toastr.error('Something is wrong');
        }
      );
    }
  }

  DeleteTestimonial(id: number) {
    {
      this.spinner.show();
      
      this.http
        .delete(
          'https://localhost:44351/api/testimonial/DeleteTestimonial/' + id
        )
        .subscribe(
          (res) => {
            this.toastr.success('Deleted Successfully');
            this.spinner.hide();
            this.reloadCurrentRoute()
          },
          (err) => {
            this.spinner.hide();
            this.toastr.error('Something is wrong');
          }
        );
    }
  }
  // Testimonial //

  //Website Pages//

  CreateWebsite(body: any) {
    this.spinner.show();
    this.obj.home_Id = Number(body.home_Id);
    this.obj.contactUs_Id = Number(body.contactUs_Id);
    this.obj.aboutUs_Id = Number(body.aboutUs_Id);
    this.obj.contactInfo_Id = Number(body.contactInfo_Id);
    this.obj.status = 'Disabled';
    this.obj.websitePagesName = body.websitePagesName;

    
    this.http
      .post('https://localhost:44351/api/websitepage', this.obj)
      .subscribe(
        (res) => {
          this.spinner.hide();
          this.toastr.success('Created Succesfuly');
          this.reloadCurrentRoute()
        },
        (err) => {
          this.spinner.hide();
          this.toastr.error('Something is wrong');
        }
      );
   
  }

  GetWebsite() {
    this.spinner.show();
    
    this.http.get('https://localhost:44351/api/websitepage/').subscribe(
      (res) => {
        this.Data = res;
        this.spinner.hide();
      },
      (err) => {
        this.spinner.hide();
        this.toastr.error('Something is wrong');
      }
    );
  }

  DeleteWebsite(id: number) {
    {
      this.spinner.show();
      
      this.http
        .delete('https://localhost:44351/api/websitepage/delete/' + id)
        .subscribe(
          (res) => {
            this.toastr.success('Deleted Successfully');
            this.spinner.hide();
            this.reloadCurrentRoute()
          },
          (err) => {
            this.spinner.hide();
            this.toastr.error('Something is wrong');
          }
        );
    }
  }

  UpdateWebsite(body: any) {
    
    this.spinner.show();
    this.obj.home_Id = Number(body.home_Id);
    this.obj.websitePagesId = Number(body.websitePagesId);
    this.obj.contactUs_Id = Number(body.contactUs_Id);
    this.obj.aboutUs_Id = Number(body.aboutUs_Id);
    this.obj.contactInfo_Id = Number(body.contactInfo_Id);
    this.obj.status = body.status;
    this.obj.websitePagesName = body.websitePagesName;

    this.spinner.show();
    
    this.http
      .put('https://localhost:44351/api/websitepage/', this.obj)
      .subscribe(
        (res) => {
          this.spinner.hide();
          this.reloadCurrentRoute()
        },
        (err) => {
          this.spinner.hide();
          this.toastr.error('Something is wrong');
        }
      );
   
  }

  //Website Pages//


// Passports //
GetPassport(){

  this.spinner.show()
 return this.http.get("https://localhost:44351/api/Passport/GetUserPassport")
}

  // Passports //

  // Generate Expired Passport //
  GenerateExpired() {
    this.http.get(
      'https://localhost:44351/api/Passport/GenerateExpiredPassport'
    );
  }

  // Generate Expired Passport //

  // Renwed Request//
  GetRequesus() {
    this.spinner.show();

   return this.http.get('https://localhost:44351/api/Passport/GetRequests')
  }

  UpdateRequest(obj: any) {
    this.http.put('https://localhost:44351/api/Passport/', obj).subscribe(
      (res) => {
        this.spinner.hide();
        this.reloadCurrentRoute()
      },
      (err) => {
        this.spinner.hide();
        this.toastr.error('Something is wrong');
      }
    );
   
  }

  DeleteRequest(id: number) {
    
      this.spinner.show();
      
      this.http
        .delete('https://localhost:44351/api/passport/delete/' + id)
        .subscribe(
          (res) => {
            this.toastr.success('Deleted Successfully');
            this.spinner.hide();
            this.reloadCurrentRoute()
          },
          (err) => {
            this.spinner.hide();
            this.toastr.error('Something is wrong');
          }
        );


  }
  // Renwed Request//
  searchDate(data:any,url:string)
  {
    this.spinner.show()
    
   return   this.http.post(url,data)
  
  }


  //Contact Us Form //
  GetFeedbacks() {
    this.spinner.show();

   return this.http.get("https://localhost:44351/api/feedback/GetAllFeedBack")
  }

  DeleteFeedback(id: number) {
    this.spinner.show();
    
    this.http.delete("https://localhost:44351/api/feedback/DeleteFeedBack/" + id).subscribe((res) => {
      this.toastr.success("Deleted Successfully")
      this.spinner.hide();
      this.reloadCurrentRoute()
    }, err => {
      this.spinner.hide();
      this.toastr.error("Something is wrong");
    });
  }

  //Contact Us Form //



}