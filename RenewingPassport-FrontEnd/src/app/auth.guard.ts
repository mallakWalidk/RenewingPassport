import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private router:Router, private toaster:ToastrService){}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      const token = localStorage.getItem('token');
      if (token) {
        
        if (state.url.indexOf('auth') >= 0) {
          let user: any = localStorage.getItem('user');
          if (user) {
            user = JSON.parse(user);
            if (user.role == 'User') {
              this.toaster.warning('You Are Not Authorized');  
              this.router.navigate(['user']);
              return false;
            }
            else if (user.role == 'Admin'){
              this.toaster.warning('You Are Not Authorized');  
              this.router.navigate(['admin']);
              return false;
            }
          }
        }
        return true;
      }
      else {
        return true;
      }
  }
  
}
