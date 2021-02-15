import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { UserModel } from '../Models/user.model';
import { PostModel } from '../Models/post.model';
import { LoginModel } from '../Models/login.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { DataManagementService } from './data-management.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  //#region Members
  apiUrl: string | undefined;
  //#endregion

  //#region Initializations
  constructor(private httpClient: HttpClient, private dataManagementService: DataManagementService) {
    this.apiUrl = environment.apiUrl
  }
  //#endregion

  //#region Public Methods
  public GetAll(): Observable<any> {
    let headers = this.getHeaders();
    return this.httpClient.get(this.apiUrl + 'Posts/GetAll', { 'headers': headers });
  }

  public Login(loginModel: LoginModel): Observable<any> {
    console.log(this.apiUrl);
    return this.httpClient.post(this.apiUrl + 'Authentication/Login', loginModel);
  }

  public SignUp(userModel: UserModel): Observable<any> {
    return this.httpClient.post(this.apiUrl + 'Authentication/Signup', userModel);
  }

  public CreatePost(postModel: PostModel): Observable<any> {
    let headers = this.getHeaders();
    return this.httpClient.post(this.apiUrl + 'Posts/Create', postModel, { 'headers': headers });
  }

  public DeletePost(postModel: PostModel): Observable<any> {
    let headers = this.getHeaders();
    return this.httpClient.post(this.apiUrl + 'Posts/Delete', postModel, { 'headers': headers });
  }
  //#endregion

  //#region Private Methods
  private getHeaders() {
    let headers = new HttpHeaders();
    headers = headers.set('Authorization', this.dataManagementService.token);
    return headers;
  }
  //#endregion
}