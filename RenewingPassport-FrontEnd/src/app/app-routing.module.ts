import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WebsiteModule } from './website/website.module';
import { AdminModule } from './admin/admin.module';
import { UserModule } from './user/user.module';
import { AuthModule } from './auth/auth.module';
import { UserGuard } from './user.guard';
import { AdminGuard } from './admin.guard';
import { AuthGuard } from './auth.guard';



const routes: Routes = [
  {path:'',
  loadChildren:()=>WebsiteModule},
 {
    path:'admin',
   loadChildren:()=>AdminModule,
   canActivate:[AdminGuard]
   },
   {path:'user',
   loadChildren:()=>UserModule,
   canActivate:[UserGuard]
   },
   {path:'auth',
   loadChildren:()=>AuthModule,
   canActivate:[AuthGuard]
   },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  
})
export class AppRoutingModule { }
