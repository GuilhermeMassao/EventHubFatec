import { ToastrService } from 'ngx-toastr';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  formModel = {
    Email: '',
    UserPassword: ''
  }

  constructor(private service: UserService, private router: Router, private toastr: ToastrService) { }

  ngOnInit() {
    //console.log(localStorage.getItem('user'));
    if (localStorage.getItem('user') != null)
        this.router.navigateByUrl('eventhub/home');
  }

  onSubmit(form: NgForm) {
    this.service.login(form.value).subscribe(
      (res: any) => {
        localStorage.setItem('user', JSON.stringify({id: res.id, userName: res.userName, email: res.email, twitterLogin: res.hasTwitterLogin}));
        this.router.navigateByUrl('eventhub/home');
      },
      err => {
        if (err.status == 400)
          this.toastr.error('Email ou senha incorretos');
        else
          console.log(err);
      }
    );
  }

}
