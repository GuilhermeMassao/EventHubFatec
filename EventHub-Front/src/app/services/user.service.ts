import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpParams } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private fb: FormBuilder, private http: HttpClient) { }
  readonly BaseURI = 'http://localhost:61096';
  readonly BaseFrontURI = "http://localhost:4200";

  //Form de login
  formModel = this.fb.group({
    UserName: ['', Validators.required],
    Email: ['', Validators.email],
    Passwords: this.fb.group({
      Password: ['', [Validators.required, Validators.minLength(4)]],
      ConfirmPassword: ['', Validators.required]
    }, { validator: this.comparePasswords })
  });

  //Form edição das informações do Usuario
  formUsuario = this.fb.group({
    UserName: ['', Validators.required],
    Email: ['', Validators.email],
  });
  

  comparePasswords(fb: FormGroup) {
    let confirmPswrdCtrl = fb.get('ConfirmPassword');
    if (confirmPswrdCtrl.errors == null || 'passwordMismatch' in confirmPswrdCtrl.errors) {
      if (fb.get('Password').value != confirmPswrdCtrl.value)
        confirmPswrdCtrl.setErrors({ passwordMismatch: true });
      else
        confirmPswrdCtrl.setErrors(null);
    }
  }

  register() {
    var body = {
      UserName: this.formModel.value.UserName,
      Email: this.formModel.value.Email,
      UserPassword: this.formModel.value.Passwords.Password
    };
    return this.http.post(this.BaseURI + '/api/user', body);
  }

  login(formData) {
    return this.http.post(this.BaseURI + '/login', formData);
  }

  getTwitterAuthorizeUrl(callBackUrl: string) {
    const params = new HttpParams().set('callbackUrl', (this.BaseFrontURI + callBackUrl));
    return this.http.get(this.BaseURI + '/twitter', {params, responseType: 'text'});
  }

  getTwitterAccessToken(oauthToken: string, oauthVerifier: string) {
    var body = {
      Token: oauthToken,
      TokenVerifier: oauthVerifier
    };
    return this.http.post(this.BaseURI + '/twitter/access', body);
  }

  saveTwitterAccessToken(data: any, id: string) {
    var body = {
      TwitterAcessToken: data.accessToken,
      TwitterAcessTokenSecret: data.accessTokenSecret
    };
    return this.http.put(this.BaseURI + '/twitter/token/' + id, body);
  }

  getGoogleAuthorizeUrl(callBackUrl: string) {
    const params = new HttpParams().set('callbackUrl', (this.BaseFrontURI + callBackUrl));
    return this.http.get(this.BaseURI + '/google', {params, responseType: 'text'});
  }

  getGoogleAccessToken(code: string, callBackUrl: string) {
    var body = {
      Code: code,
      CallbackUrl: this.BaseFrontURI + callBackUrl
    };
    return this.http.post(this.BaseURI + '/google/access', body);
  }

  getUserInformation(id:BigInteger){
    return this.http.get(this.BaseURI + '/api/user/' + id);
  }
  
  
updateUserInformation(nome:string,email:string,id:BigInteger){
  var body = {
    UserName:nome,
    Email:email,
  };
  return this.http.put(this.BaseURI + '/api/user/' + id,body);
}
updateUserPasword(id:BigInteger,oldPass:string,newPass:string,confNewPass:string){
  debugger;
  this.getUserInformation(id).subscribe(
  (res:any)=>{
    console.log(res);
    if(res.userPassword == oldPass && newPass == confNewPass){
      var input = {
        UserName: "string",
        Email: "string",
        UserPassword: newPass,
      };
      return this.http.put(this.BaseURI + '/api/user/password/' + id,input);
    }
  });
}

  saveGoogleAccessToken(refreshToken: any, id: string) {
    var body = {
      RefreshToken: refreshToken
    };
    return this.http.put(this.BaseURI + '/google/token/' + id, body);
  }
}
