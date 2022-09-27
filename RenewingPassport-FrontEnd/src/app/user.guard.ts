import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserGuard implements CanActivate {
  constructor(private router:Router, private toaster:ToastrService){}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      const token = localStorage.getItem('token');
      if (token) {
        
        if (state.url.indexOf('user') >= 0) {
          let user: any = localStorage.getItem('user');
          if (user) {
            user = JSON.parse(user);
            if (user.role == 'User') {
              return true;
            }
            else {
              this.toaster.warning('You Are Not Authorized');  
              this.router.navigate(['admin']);
              return false;
            }
          }
        }
        else {
              this.toaster.warning('You Are Not Authorized');  
          return false;
        }
        return true;
      }
      else {
        this.router.navigate(['auth/']);
        this.toaster.warning('You Are Not Authorized you should be logged in')
        return false;
      }
  }
  
}
