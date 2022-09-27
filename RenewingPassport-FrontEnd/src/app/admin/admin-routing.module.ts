import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestimonialComponent } from '../admin/testimonial/testimonial.component';
import { ManageAboutUsComponent } from './manage-about-us/manage-about-us.component';
import { ChartGenderComponent } from './chart-gender/chart-gender.component';
import { LayoutComponent } from './layout/layout.component';
import { ManageContactInfoComponent } from './manage-contact-info/manage-contact-info.component';
import { ManageContactUsPageComponent } from './manage-contact-us-page/manage-contact-us-page.component';
import { ManageHomepageComponent } from './manage-homepage/manage-homepage.component';
import { PassportsComponent } from './passports/passports.component';
import { RequestsComponent } from './requests/requests.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { ViewUsersComponent } from './view-users/view-users.component';
import { WebsitePagesComponent } from './website-pages/website-pages.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { ManageFeedbackComponent } from './manage-feedback/manage-feedback.component';
import { ReportsComponent } from './reports/reports.component';



const routes: Routes = [
  { path: '', component:LayoutComponent},
  { path: 'dashboard', component:LayoutComponent},
  { path: 'report', component:ReportsComponent},
  {path:'chart',component:ChartGenderComponent},
  {path: 'ManageHome', component:ManageHomepageComponent},
  {path:'ManageContactInfo',component:ManageContactInfoComponent},
  {path:'ManageContactUs',component:ManageContactUsPageComponent},
  {path:'ManageAboutUs',component:ManageAboutUsComponent},
  {path:'Users',component:ViewUsersComponent},
  {path:'ManageTestimonial',component:TestimonialComponent},
  {path:'ManageWebsitePages',component:WebsitePagesComponent},
  {path:'Passports',component:PassportsComponent},
  {path:'Requests',component:RequestsComponent},
  {path:'UserProfile',component:UserProfileComponent},
  {path:'ManageContactUsForm',component:ManageFeedbackComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
