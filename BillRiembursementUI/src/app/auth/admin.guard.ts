import { ThrowStmt } from '@angular/compiler';
import { Injectable, OnInit } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { BillReimbursementService } from '../bill-reimbursement.service';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate, OnInit {

 Role!:string;
  constructor(private router : Router, private service: BillReimbursementService) {   
  }

  ngOnInit(): void {
    
  }
  

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {
      

      if (localStorage.getItem('token')!=null){
        if(this.service.getUserProfile().subscribe(
          (res:any) : boolean =>{
            console.log(res.role)
            if(res.role=="Admin"){ 
              console.log("In sus true"); return true;}
            else return false;
          })) {
            console.log("final true")
            return true;
          }
        else{
          this.router.navigate(['/home/employee']);
          console.log(" false in")
          return false;
        } 
      }else{
        this.router.navigate(['/user/login']);
        return false;
      }
      





      // if (localStorage.getItem('token') != null&&this.Role=="Admin"){
      //   console.log(this.Role,"trueeadmin")
      //   return true;
      // }else {
      //   console.log(this.Role,"falseadmin")
      //   if (localStorage.getItem('token') != null&&this.Role=="User") {this.router.navigate(["/home/employee"])}
      //   else this.router.navigate(['/user/login']);
      //   return false;
      // }  
  }
  
}
