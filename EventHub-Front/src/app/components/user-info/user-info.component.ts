import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.css']
})
export class UserInfoComponent implements OnInit {

  constructor(private service: UserService, private router: Router, private toastr: ToastrService) { }

  ngOnInit() {
    console.log(this.router.url);
  }

  
  twitterLogin() {
    this.service.twitterLogin("")
  }

}
