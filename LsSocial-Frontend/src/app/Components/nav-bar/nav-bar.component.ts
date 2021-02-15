import { Router } from '@angular/router';
import { Component } from '@angular/core';
import { DataManagementService } from 'src/app/Services/data-management.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html'
})
export class NavBarComponent {
  //#region Initializations
  constructor(private router: Router, public dataManagementService: DataManagementService) { }
  //#endregion

  //#region Public Methods
  public logout() {
    this.dataManagementService.token = undefined;
    this.dataManagementService.userModel = undefined;
    this.router.navigate(['login']);
  }
  //#endregion
}