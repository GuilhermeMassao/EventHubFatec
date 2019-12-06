import { Component, OnInit, ApplicationRef, SimpleChanges, ViewChild } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';
import { Subject } from 'rxjs';
import { NgForm, NgModel } from '@angular/forms';
import { $ } from 'protractor';
import { AfterViewInit,ElementRef } from '@angular/core';
import { userInfo } from 'os';



@Component({
    selector: 'app-change-password',
    templateUrl: './change-password.component.html',
    styleUrls: ['./change-password.component.css'],
  })

export class ChangePasswordComponent  {

public hasTwitterLogin: boolean;
public hasGoogleLogin: boolean;
public userId: BigInteger;
public senhaAntinga: string;
public senhaNova: string;
public senhaNovaConf: string;
mySubscription: any;

constructor(private service: UserService, private router: Router, private toastr: ToastrService, private activatedRoute: ActivatedRoute) { }
ngOnInit() {
  this.userId = JSON.parse(localStorage.getItem('user')).id;
}
Voltar(){
  this.router.navigateByUrl('/eventhub/user/profile');
}
AlterarSenha(){
this.service.updateUserPasword(this.userId,this.senhaAntinga,this.senhaNova,this.senhaNovaConf);
}

}