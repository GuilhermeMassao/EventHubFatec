import { Component } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-change-password',
    templateUrl: './change-password.component.html',
    styleUrls: ['./change-password.component.css'],
  })

export class ChangePasswordComponent  {


  constructor(private service: UserService, private router: Router, private toastr: ToastrService, private activatedRoute: ActivatedRoute) { }
    ngOnInit() {}

    voltar(){
      this.router.navigateByUrl('/eventhub/user/profile');
    }

    changePassword(){
      this.service.updateUserPasword(JSON.parse(localStorage.getItem('user')).id).subscribe(
        res => {
          this.toastr.success('Senha alterada com sucesso.','Sucesso!').onHidden.subscribe(() => {
              window.location.reload();
          });
        },
        err => {
          if (err.status == 400) {
            this.toastr.error('Senha atual inválida.','Ops! Erro ao tentar alterar seus dados!');
          }
          else {
            console.log(err);
            this.toastr.error('Tente novamente mais tarde.','Ops! Erro ao tentar alterar seus dados!');
          } 
        }
      );
    }

}