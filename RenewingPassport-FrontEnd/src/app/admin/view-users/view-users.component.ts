import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { AdminService } from 'src/app/Services/admin.service';

@Component({
  selector: 'app-view-users',
  templateUrl: './view-users.component.html',
  styleUrls: ['./view-users.component.css',
  '../../../assets/Dashboard/css/animate.css/css/animate.css',
  '../../../assets/Dashboard/css/bootstrap/css/bootstrap.min.css',
  '../../../assets/Dashboard/css/style.css',
  '../../../assets/Dashboard/css/jquery.mCustomScrollbar.css']
})
export class ViewUsersComponent implements OnInit {
  Data: any = [{}];
  dtOptions: DataTables.Settings = {};

  dtTrigger: Subject<any> = new Subject<any>();
  constructor(public service:AdminService) { }

  ngOnInit(): void {
    this.service.getUsers().subscribe(
      (res) => {
        this.Data = res;
        this.dtTrigger.next(this.Data)
        this.service.spinner.hide();
      },
      (err) => {
        this.service.spinner.hide();
        this.service.toastr.error('Something is wrong');
      }
    );;
  }

}
