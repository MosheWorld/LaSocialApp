import { Router } from '@angular/router';
import { Component } from '@angular/core';

import { LoginModel } from 'src/app/Models/login.model';
import { HttpService } from 'src/app/Services/http.service';
import { DataManagementService } from 'src/app/Services/data-management.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent {
  //#region Members
  userName: string | undefined;
  password: string | undefined;

  loginProgress: boolean = false;
  errorMessage: boolean = false;
  //#endregion

  //#region Initializations
  constructor(private httpService: HttpService,
    private router: Router,
    private dataManagementService: DataManagementService) { }
  //#endregion

  //#region Public Methods
  public login() {
    let loginModel: LoginModel = new LoginModel();
    loginModel.UserName = this.userName;
    loginModel.Password = this.password;

    if (!this.isModelValid(loginModel)) {
      this.errorMessage = true;
      return;
    }

    this.loginProgress = true;
    this.errorMessage = false;

    this.httpService.Login(loginModel).subscribe(
      (result) => {
        this.dataManagementService.token = result.Token;
        this.dataManagementService.userModel = result.UserModel;
        this.loginProgress = false;
        this.router.navigate(['posts']);
      },
      (error) => {
        this.loginProgress = false;
        this.errorMessage = true;
        console.error(error);
      }
    );
  }

  public clear() {
    this.userName = undefined;
    this.password = undefined;
  }
  //#endregion

  //#region Private Methods.
  private isModelValid(loginModel: LoginModel) {
    if (loginModel === null
      || loginModel === undefined
      || this.isArgumentNullOrUndefined(loginModel.UserName)
      || loginModel.UserName === ''
      || this.isArgumentNullOrUndefined(loginModel.Password)
      || loginModel.Password === '') {
      return false;
    }
    else {
      return true;
    }
  }

  private isArgumentNullOrUndefined(arg: any) {
    if (arg === null || arg === undefined) {
      return true;
    }
    else {
      return false;
    }
  }
  //#endregion
}