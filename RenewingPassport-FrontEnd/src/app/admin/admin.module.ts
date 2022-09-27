import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminRoutingModule } from './admin-routing.module';
import { SidebarComponent } from './sidebar/sidebar.component';
import { ManageHomepageComponent } from './manage-homepage/manage-homepage.component';
import { HttpClientModule } from '@angular/common/http';
import { ManageContactInfoComponent } from './manage-contact-info/manage-contact-info.component';
import { FormsModule } from '@angular/forms';
import { MatDialogModule} from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { ManageAboutUsComponent } from './manage-about-us/manage-about-us.component';
import { ViewUsersComponent } from './view-users/view-users.component';
import { TestimonialComponent } from './testimonial/testimonial.component';
import { ManageContactUsPageComponent } from './manage-contact-us-page/manage-contact-us-page.component';
import { WebsitePagesComponent } from './website-pages/website-pages.component';
import { PassportsComponent } from './passports/passports.component';
import { RequestsComponent } from './requests/requests.component';
import { ChartGenderComponent } from './chart-gender/chart-gender.component';
import { ChartStatusComponent } from './chart-status/chart-status.component';
import { LayoutComponent } from './layout/layout.component';
import { ChartDateComponent } from './chart-date/chart-date.component';
import { ReportsComponent } from './reports/reports.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { ManageFeedbackComponent } from './manage-feedback/manage-feedback.component';
import { NavbarComponent } from './navbar/navbar.component';
import {MatSelectModule} from '@angular/material/select';
import { DataTablesModule } from 'angular-datatables';
import {  MatTableModule } from '@angular/material/table';


@NgModule({
  declarations: [
   SidebarComponent,
   ManageHomepageComponent,
   ManageContactInfoComponent,
   ManageAboutUsComponent,
   ManageContactUsPageComponent,
   ViewUsersComponent,
   TestimonialComponent,
   WebsitePagesComponent,
   PassportsComponent,
   RequestsComponent,
   ChartGenderComponent,
   ChartStatusComponent,
   LayoutComponent,
   ChartDateComponent,
   ReportsComponent,
   UserProfileComponent,
   ManageFeedbackComponent,
   NavbarComponent
   

  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    HttpClientModule,
    RouterModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatDialogModule,
    ReactiveFormsModule,
    MatSelectModule,
    DataTablesModule

  ],
  providers: [],
})
export class AdminModule { }
 