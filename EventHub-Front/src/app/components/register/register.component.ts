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
        console.log('res = ' + res);
          this.service.formModel.reset();
          this.toastr.success('Novo usuário criado com sucesso');
          localStorage.setItem('user', JSON.stringify({id: res.id, userName: res.userName, email: res.email}));
          this.router.navigateByUrl('home');
      },
      err => {
        if(err.status == 400)
        this.toastr.error('Erro usuário já está na base');
        else
          console.log(err);
      }
    );
  }

}
