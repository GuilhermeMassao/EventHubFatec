import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(public service: UserService, private router: Router, private toastr: ToastrService) { }

  ngOnInit() {
    this.service.formModel.reset();
  }

  onSubmit() {
    this.service.register().subscribe(
      (res: any) => {
          this.service.formModel.reset();
          localStorage.setItem('user', JSON.stringify({id: res.id, userName: res.userName, email: res.email, twitterLogin: false, googleLogin: false}));
          this.router.navigateByUrl('eventhub/home');
      },
      err => {
        if(err.status == 400) {
          this.toastr.error('Ops! Erro ao realizar cadastro', 'Esse e-mail já foi cadastrado.');
        }
        else {
          console.log(err);
          this.toastr.error('Tente novamente mais tarde.', 'Ops! Erro ao realizar cadastro.');
        }
      }
    );
  }

}
