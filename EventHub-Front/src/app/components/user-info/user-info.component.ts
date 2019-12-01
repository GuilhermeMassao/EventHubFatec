import { Component, OnInit, ApplicationRef, SimpleChanges } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.css']
})
export class UserInfoComponent implements OnInit {

  public hasTwitterLogin: boolean;
  public hasGoogleLogin: boolean;
  mySubscription: any;

  constructor(private service: UserService, private router: Router, private toastr: ToastrService, private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.hasTwitterLogin = JSON.parse(localStorage.getItem('user')).twitterLogin;
    this.hasGoogleLogin = JSON.parse(localStorage.getItem('user')).googleLogin;
    
    this.verifyTwitterCallback();
    this.verifyGoogleCallback();

    this.updateLayout()
  }
  
  twitterLogin() {
    this.service.getTwitterAuthorizeUrl(this.router.url).subscribe(
      res => {
        document.location.href = res.toString()
      }
    );
  }

  googleLogin() {
    this.service.getGoogleAuthorizeUrl(this.router.url).subscribe(
      res => {
        document.location.href = res.toString()
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
                  this.toastr.error('Erro ao tentar logar no Google!','Tente novamente mais tarde.');
                  this.router.navigateByUrl('eventhub/user/profile');
                }
                else {
                  console.log(err);
                  this.toastr.error('Erro ao tentar logar no Google!','Tente novamente mais tarde.');
                  this.router.navigateByUrl('eventhub/user/profile');
                }
              }
            )
          },
          err => {
            if (err.status == 400) {
              this.toastr.error('Erro ao tentar logar no Google!','Tente novamente mais tarde.');
              this.router.navigateByUrl('eventhub/user/profile');
            }
            else {
              console.log(err);
              this.toastr.error('Erro ao tentar logar no Google!','Tente novamente mais tarde.');
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

  ngOnDestroy() {
    if (this.mySubscription) {
      this.mySubscription.unsubscribe();
    }
  }
}
