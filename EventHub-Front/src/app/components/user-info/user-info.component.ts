import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';
import { NgModel } from '@angular/forms';
import { EventService } from 'src/app/services/event.service';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.css'],
})
export class UserInfoComponent implements OnInit {

  public userEvents: Array<any>;

  public hasTwitterLogin: boolean;
  public hasGoogleLogin: boolean;
  public userId: BigInteger;
  public nameInput: NgModel;
  public usuario: string;
  public email: string;
  public senha: string;
  mySubscription: any;

  constructor(private service: UserService, private eventService: EventService, private router: Router, private toastr: ToastrService, private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.hasTwitterLogin = JSON.parse(localStorage.getItem('user')).twitterLogin;
    this.hasGoogleLogin = JSON.parse(localStorage.getItem('user')).googleLogin;
    this.userId = JSON.parse(localStorage.getItem('user')).id;
    this.verifyTwitterCallback();
    this.verifyGoogleCallback();
    this.updateLayout()
    this.setField();
    this.getUserEvents();
  }
  
  twitterLogin() {
    this.service.getTwitterAuthorizeUrl(this.router.url).subscribe(
      res => {
        document.location.href = res.toString()
      },
      err => {
        if (err.status == 400) {
          this.toastr.error('Tente novamente mais tarde.','Erro ao tentar logar no Twitter!');
          this.router.navigateByUrl('eventhub/user/profile');
        }
        else {
          console.log(err);
          this.toastr.error('Tente novamente mais tarde.','Erro ao tentar logar no Twitter!');
          this.router.navigateByUrl('eventhub/user/profile');
        } 
      }
    );
  }

  redirectChangePassword(){
    this.router.navigateByUrl('/eventhub/user/editar-senha');
  }

  saveUserInformation(){
      this.service.updateUserInformation(this.usuario,this.email,this.userId).subscribe(
        res => {
          this.toastr.success('Dados alterados com sucesso.','Sucesso!').onHidden.subscribe(() => {
              window.location.reload();
          });
        },
        err => {
          if (err.status == 400) {
            this.toastr.error('Esse e-mail já está em uso.','Ops! Erro ao tentar alterar seus dados!');
            this.router.navigateByUrl('eventhub/user/profile');
          }
          else {
            console.log(err);
            this.toastr.error('Tente novamente mais tarde.','Ops! Erro ao tentar alterar seus dados!');
            this.router.navigateByUrl('eventhub/user/profile');
          }
        }
      )
  }

  inactiveUser() {
    this.service.inactiveUser(this.userId).subscribe(
      (res: any) => {
        this.toastr.success('Conta removida com sucesso.','Sucesso!').onHidden.subscribe(() => {
          localStorage.removeItem('user');
          this.router.navigate(['/login']);
      });
      },
      err => {
        if(err.status == 200) {
          this.toastr.success('Conta removida com sucesso.','Sucesso!').onHidden.subscribe(() => {
            localStorage.removeItem('user');
            this.router.navigate(['/login']);
          });
        }
        if (err.status == 400) {
          console.log(err);
          this.toastr.error('Tente novamente mais tarde.','Ops! Algo deu errado!');
          //window.location.reload();
        }
        if (err.status == 500) {
          console.log(err);
          this.toastr.error('Tente novamente mais tarde.','Ops! Algo deu errado!');
          //window.location.reload();
        }
      }
    );
  }

  setField() {
     let user = this.service.getUserInformation(this.userId).subscribe(
       (res:any) => {
         this.usuario = res.userName;
         this.email = res.email;
         this.senha = res.senha;
       }
     );

    }
  twitterLogout() {
    this.service.saveTwitterAccessToken({accessToken: null, accessTokenSecret: null}, JSON.parse(localStorage.getItem('user')).id).subscribe(
      res => {
        let actualStorage = JSON.parse(localStorage.getItem('user'))
        actualStorage.twitterLogin = false;
        console.log(actualStorage)
        localStorage.setItem('user', JSON.stringify(actualStorage));
        this.router.navigateByUrl('eventhub/user/profile');
      },
      err => {
        if (err.status == 400) {
          this.toastr.error('Tente novamente mais tarde.','Erro ao tentar deslogar no Twitter!');
          this.router.navigateByUrl('eventhub/user/profile');
        }
        else {
          console.log(err);
          this.toastr.error('Tente novamente mais tarde.','Erro ao tentar deslogar no Twitter!');
          this.router.navigateByUrl('eventhub/user/profile');
        }
      }
    );
  }

  googleLogin() {
    this.service.getGoogleAuthorizeUrl(this.router.url).subscribe(
      res => {
        document.location.href = res.toString()
      },
      err => {
        if (err.status == 400) {
          this.toastr.error('Tente novamente mais tarde.','Erro ao tentar logar no Google!');
          this.router.navigateByUrl('eventhub/user/profile');
        }
        else {
          console.log(err);
          this.toastr.error('Tente novamente mais tarde.','Erro ao tentar logar no Google!');
          this.router.navigateByUrl('eventhub/user/profile');
        } 
      }
    );
  }

  googleLogout() {
    this.service.saveGoogleAccessToken(null, JSON.parse(localStorage.getItem('user')).id).subscribe(
      res => {
        let actualStorage = JSON.parse(localStorage.getItem('user'))
        actualStorage.googleLogin = false;
        localStorage.setItem('user', JSON.stringify(actualStorage));
        this.router.navigateByUrl('eventhub/user/profile');
      },
      err => {
        if (err.status == 400) {
          this.toastr.error('Erro ao tentar deslogar no Google!','Tente novamente mais tarde.');
          this.router.navigateByUrl('eventhub/user/profile');
        }
        else {
          console.log(err);
          this.toastr.error('Erro ao tentar deslogar no Google!','Tente novamente mais tarde.');
          this.router.navigateByUrl('eventhub/user/profile');
        }
      }
    );
  }

  verifyTwitterCallback() {
    this.activatedRoute.queryParams.subscribe(params => {
      if(params.oauth_token != null && params.oauth_verifier != null) {
        this.service.getTwitterAccessToken(params.oauth_token, params.oauth_verifier).subscribe(
          res => {
            this.service.saveTwitterAccessToken(res, JSON.parse(localStorage.getItem('user')).id).subscribe(
              res => {
                let actualStorage = JSON.parse(localStorage.getItem('user'))
                actualStorage.twitterLogin = true;
                console.log(actualStorage)
                localStorage.setItem('user', JSON.stringify(actualStorage));
                this.router.navigateByUrl('eventhub/user/profile');
              },
              err => {
                if (err.status == 400) {
                  this.toastr.error('Erro ao tentar logar no Twitter!','Tente novamente mais tarde.');
                  this.router.navigateByUrl('eventhub/user/profile');
                }
                else {
                  console.log(err);
                  this.toastr.error('Erro ao tentar logar no Twitter!','Tente novamente mais tarde.');
                  this.router.navigateByUrl('eventhub/user/profile');
                }
              }
            )
          },
          err => {
            if (err.status == 400) {
              this.toastr.error('Erro ao tentar logar no Twitter!','Tente novamente mais tarde.');
              this.router.navigateByUrl('eventhub/user/profile');
            }
            else {
              console.log(err);
              this.toastr.error('Erro ao tentar logar no Twitter!','Tente novamente mais tarde.');
              this.router.navigateByUrl('eventhub/user/profile');
            }
          }
        )
      }
    })
  }
  verifyGoogleCallback() {
    this.activatedRoute.queryParams.subscribe(params => {
      if(params.code != null && params.scope != null) {
        this.service.getGoogleAccessToken(params.code, this.router.url.split('?')[0]).subscribe(
          (res :any) => {
            this.service.saveGoogleAccessToken(res.refreshToken, JSON.parse(localStorage.getItem('user')).id).subscribe(
              res => {
                let actualStorage = JSON.parse(localStorage.getItem('user'))
                actualStorage.googleLogin = true;
                localStorage.setItem('user', JSON.stringify(actualStorage));
                this.router.navigateByUrl('eventhub/user/profile');
              },
              err => {
                if (err.status == 400) {
                  this.toastr.error('Tente novamente mais tarde.','Erro ao tentar logar no Google!');
                  this.router.navigateByUrl('eventhub/user/profile');
                }
                else {
                  console.log(err);
                  this.toastr.error('Tente novamente mais tarde.','Erro ao tentar logar no Google!');
                  this.router.navigateByUrl('eventhub/user/profile');
                }
              }
            )
          },
          err => {
            if (err.status == 400) {
              this.toastr.error('Tente novamente mais tarde.','Erro ao tentar logar no Google!');
              this.router.navigateByUrl('eventhub/user/profile');
            }
            else {
              console.log(err);
              this.toastr.error('Tente novamente mais tarde.','Erro ao tentar logar no Google!');
                  this.router.navigateByUrl('eventhub/user/profile');
            }
          }
        )
      }
    })
  }

  updateLayout() {
    this.router.routeReuseStrategy.shouldReuseRoute = function () {
      return false;
    };

    this.mySubscription = this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.router.navigated = false;
      }
    });
  }

  getUserEvents() {
    this.eventService.getEventsByUserId(JSON.parse(localStorage.getItem('user')).id).subscribe(
      (res: any) => {
        console.log(res);
        this.userEvents = res;
      },
      err => {
        if(err.status == 400) {
          console.log("Error 400");
        }
        else {
          console.log("err");
        }
      }
    );
  }

  redirectEvent(id){
    this.router.navigateByUrl("/eventhub/evento?id=" + id);
  }

  ngOnDestroy() {
    if (this.mySubscription) {
      this.mySubscription.unsubscribe();
    }
  }
}
