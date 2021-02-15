import { Injectable } from '@angular/core';
import { UserModel } from '../Models/user.model';

@Injectable({
  providedIn: 'root'
})
export class DataManagementService {
  token: string | any;
  userModel: UserModel | any;
}