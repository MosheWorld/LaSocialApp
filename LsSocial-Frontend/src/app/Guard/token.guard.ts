import { Injectable } from "@angular/core";
import { DataManagementService } from "../Services/data-management.service";
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot } from "@angular/router";

@Injectable({
    providedIn: 'root',
})
export class TokenGuard implements CanActivate {
    constructor(private dataManagementService: DataManagementService) { }

    canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        if (this.dataManagementService.token === null
            || this.dataManagementService.token === undefined
            || this.dataManagementService.token === '') {
            return false;
        } else {
            return true;
        }
    }
}