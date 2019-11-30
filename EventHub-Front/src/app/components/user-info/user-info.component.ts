import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.css']
})
export class UserInfoComponent implements OnInit {

  hasTwitterLogin = JSON.parse(localStorage.getItem('user')).twitterLogin;

  constructor(private service: UserService, private router: Router, private toastr: ToastrService, private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.verifyTwitterCallback()
  }

  
  twitterLogin() {
    this.service.getTwitterAuthorizeUrl(this.router.url).subscribe(
      res => {
        console.log(res.toString())
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
                this.router.navigateByUrl('eventhub/user/profile');
              },
              err => {
                if (err.status == 400) {
                  this.toastr.error('Erro ao tentar logar no Twitter!','Tente novamente mais tarde.');
                  this.router.navigateByUrl('eventhub/user/profile');
                }
                else {
                  console.log(err);
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
            }
          }
        )
      }
    })
  }
}
