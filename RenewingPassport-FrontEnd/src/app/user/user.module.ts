import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { RouterModule } from '@angular/router';
import { UserRoutingModule } from './user-routing.module';
import { PassportComponent } from './passport/passport.component';
import { WebsiteModule } from '../website/website.module';
import { HeaderComponent } from '../website/header/header.component';
import { RequestComponent } from './request/request.component';


@NgModule({
  declarations: [

    UserProfileComponent,
    PassportComponent,
    RequestComponent
  ],
  imports: [
    CommonModule,
    UserRoutingModule,
    HttpClientModule,
    RouterModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatDialogModule,
    ReactiveFormsModule,
    MatSelectModule,
    WebsiteModule,
  ]
})
export class UserModule { }
