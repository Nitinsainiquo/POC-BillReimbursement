import { BoundTextAst } from '@angular/compiler';
import { Injectable, OnInit } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanActivateChild, CanDeactivate, CanLoad, Route, Router, RouterStateSnapshot, UrlSegment, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { BillReimbursementService } from '../bill-reimbursement.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate, OnInit  {
  
  Role!:string;
  constructor(private router : Router, private service: BillReimbursementService) {   
  }

  ngOnInit(): void {
    this.service.getUserProfile().subscribe(
      (res:any)=>{
        this.Role = res.role;
      });
  }
  
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot):boolean {
    if (localStorage.getItem('token') != null){
      return true;
    }else {
      this.router.navigate(['/user/login']);
      return false;
    }
  }
}
