import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PassportComponent } from './passport/passport.component';
import { RequestComponent } from './request/request.component';
import { UserProfileComponent } from './user-profile/user-profile.component';

const routes: Routes = [
  {path:'',component:UserProfileComponent},
  {path:'passport',component:PassportComponent},
  {path:'UserProfile',component:UserProfileComponent},
  {path:'request',component:RequestComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
