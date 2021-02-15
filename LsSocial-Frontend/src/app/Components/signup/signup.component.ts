import { Router } from '@angular/router';
import { Component } from '@angular/core';

import { UserModel } from 'src/app/Models/user.model';
import { HttpService } from 'src/app/Services/http.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html'
})
export class SignupComponent {
  //#region Members
  userName: string | undefined;
  firstName: string | undefined;
  lastName: string | undefined;
  password: string | undefined;

  signupProgress: boolean = false;
  errorMessage: boolean = false;
  //#endregion

  //#region Initializations
  constructor(private httpService: HttpService, private router: Router) { }
  //#endregion

  //#region Public Methods
  public signup() {
    let userModel: UserModel = new UserModel();
    userModel.UserName = this.userName;
    userModel.FirstName = this.firstName;
    userModel.LastName = this.lastName;
    userModel.Password = this.password;

    if (!this.isModelValid(userModel)) {
      this.errorMessage = true;
      return;
    }

    this.signupProgress = true;
    this.errorMessage = false;

    this.httpService.SignUp(userModel).subscribe(
      () => {
        this.signupProgress = false;
        this.router.navigate(['login']);
      },
      (error) => {
        this.signupProgress = false;
        this.errorMessage = true;
        console.error(error);
      }
    );
  }

  public clear() {
    this.userName = undefined;
    this.firstName = undefined;
    this.lastName = undefined;
    this.password = undefined;
  }
  //#endregion

  //#region Private Methods.
  private isModelValid(userModel: UserModel) {
    console.log(userModel);
    if (userModel === null
      || userModel === undefined
      || this.isArgumentNullOrUndefined(userModel.UserName)
      || userModel.UserName === ''
      || this.isArgumentNullOrUndefined(userModel.Password)
      || userModel.Password === ''
      || this.isArgumentNullOrUndefined(userModel.FirstName)
      || userModel.FirstName === ''
      || this.isArgumentNullOrUndefined(userModel.LastName)
      || userModel.LastName === '') {
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