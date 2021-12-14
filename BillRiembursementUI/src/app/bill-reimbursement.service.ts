import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { AppliedBill, EmployeeModel, LoginModel } from './Shared/Models';

@Injectable({
  providedIn: 'root'
})
export class BillReimbursementService {
  
  constructor(private http: HttpClient) { }

  readonly BaseURI = 'https://localhost:7224/api';

  register(body : EmployeeModel) {
    console.log(body)
    return this.http.post(this.BaseURI + '/Employee', body);
  }

  login(body : LoginModel){
    return this.http.post(this.BaseURI + '/Employee/Login', body);
  }

  getUserProfile() {
    return this.http.get(this.BaseURI + '/UserProfile');
  }

  getBill(id : string){
    return this.http.get(this.BaseURI +'/ApplyBill'+ `/${id}`);
  }
  getAllBill(id : string){
    return this.http.get(this.BaseURI +'/ApplyBill');
  }

  deleteBill(id :any){
    return this.http.delete(this.BaseURI +'/ApplyBill'+ `/${id}`)
  }

  addBill(bill:AppliedBill){
    return this.http.post(this.BaseURI + '/ApplyBill', bill)
  }
  updateBill(bill:AppliedBill,id:number){
    return this.http.put(this.BaseURI +'/ApplyBill'+ `/${id}`, bill)
  }
  updateApprove(bill:AppliedBill,id:number){
    return this.http.put(this.BaseURI +'/Approve'+ `/${id}`, bill)
  }
  updateDecline(bill:AppliedBill,id:number){
    return this.http.put(this.BaseURI +'/Decline'+ `/${id}`, bill)
  }
}
