import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    private http: HttpClient,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService
  ) { }
  display_Image: any = {};
  user: any=[{}] ;
  passports:any;
  UsernameAndEmail: any = [{}];
  data:any;
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

 //User//

  getUserProfileById(id: number) {
    this.spinner.show();
    this.http.get('https://localhost:44351/api/user/GetUserProfileById/' + id).subscribe(
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
    this.spinner.show();
    if (this.display_Image.userImagePath != null)
      body.userImagePath = this.display_Image.userImagePath;
    
    this.http
      .put('https://localhost:44351/api/user/UpdateUserProfile/', body)
      .subscribe(
        (res) => {
          
          this.spinner.hide();
          this.toastr.success('Updated Succesfuly');
        },
        (err) => {
          this.spinner.hide();
          this.toastr.error('Something is wrong');
        }
      );
    window.location.reload();
  }

  UpdateUserPassword(body: any) {
    this.spinner.show();
    this.http.put('https://localhost:44351/api/user/UpdatePassword/', body).subscribe(
        (res) => {

            this.spinner.hide();
            this.toastr.success('Updated Succesfuly');

        },
        (err) => {
          this.spinner.hide();
          this.toastr.error('Something is wrong try again');
        }
      );
    window.location.reload();
  }

  //User//

  GetUserById(id:number){
    this.spinner.show();
    this.http.get('https://localhost:44351/api/user/GetUserById/' + id).subscribe(
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

//Generate new Passport
NewPassport(user:any,passport:any){
this.spinner.show();
if (this.display_Image.userImagePath != null)
  user.userImagePath = this.display_Image.userImagePath;

  if (this.display_Image.oldPassportPath != null)
  user.oldPassportPath = this.display_Image.oldPassportPath;

  if (this.display_Image.identityPath != null)
  user.identityPath = this.display_Image.identityPath;


this.http.put('https://localhost:44351/api/user/updateuserinfo/', user).subscribe(
    (res) => {
      this.http.post('https://localhost:44351/api/passport/', passport).subscribe(
        (res) => {
          this.spinner.hide();
          this.toastr.success('Submited Successfully');
          location.reload();

        },
        (err) => {
          this.spinner.hide();
          this.toastr.error('Something is wrong');
        }
      );
        },
    (err) => {
      this.spinner.hide();
      this.toastr.error('Something is wrong');
    }
  );

}

  
//Generate new Passport

GetPassport(id:number){
  this.spinner.show();
  this.http.get('https://localhost:44351/api/passport/GetPassport/'+id).subscribe(
      (res) => {
        this.passports = res;
        
        if(this.passports==null)

    {this.passports={
      status:"none"}
    }
        this.spinner.hide();

      },
      (err) => {
        this.spinner.hide();
        this.toastr.error('Something is wrong');
      }
    );
}


GetPassportInfo(id:number){
  this.spinner.show();
  this.http.get('https://localhost:44351/api/passport/GetPassportInfo/'+id).subscribe(
      (res) => {
        this.passports = res;
        
        if(this.passports==null)

    {this.passports={
      status:"none"}
    }
        this.spinner.hide();

      },
      (err) => {
        this.spinner.hide();
        this.toastr.error('Something is wrong');
      }
    );
}


//Check Visa
ChechVisa(body:any,data:any){
  this.spinner.show();
  
  this.http.post('https://localhost:44351/api/bank/',body).subscribe(
      (res) => {
        this.data=res;
        
        if(this.data.message=="payment succeed")
        {
          this.http.put('https://localhost:44351/api/passport/',data).subscribe(
            (res) => {
              this.spinner.hide();     
                  location.reload();
 
            },
            (err) => {
              this.spinner.hide();
              this.toastr.error('Something is wrong');
            }
          );
      
        }
        else if(this.data.message=="Low Balance"){
            this.spinner.hide();
            this.toastr.error('Low Balance');

          
        }
        else if(this.data.message=="Wrong visa information")
        {
          this.spinner.hide();
          this.toastr.error('Wrong visa information');

        
      }
      },
      (err) => {
        this.spinner.hide();
        this.toastr.error('Something is wrong');
      }
    );

}

}
