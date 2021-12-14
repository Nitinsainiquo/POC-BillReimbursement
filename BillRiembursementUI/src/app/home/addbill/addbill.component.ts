import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BillReimbursementService } from 'src/app/bill-reimbursement.service';
import { AppliedBill } from '../../../app/Shared/Models';

@Component({
  selector: 'app-addbill',
  templateUrl: './addbill.component.html',
  styleUrls: ['./addbill.component.scss']
})
export class AddbillComponent implements OnInit {

  EmployeeId!:string;
  newdatemin! :any
  datemin : Date = new Date(Date.now());
  datemax : Date = new Date(Date.now());
  EmployeeName!:string;
  Department!:string;
  DateOfJoining!:string;
  PhotoFileName!:string;
  PhotoFilePath!:string; 
  BillType = ["food","travel","medical"]
  PaymentType = ["upi","cash","check","banktransfer"]

  constructor(private service : BillReimbursementService,
    private router : Router) { }

  @Input() _bill! : AppliedBill;

  bill! : AppliedBill

  ngOnInit(): void {
    this.datemin = new Date(new Date(Date.now()).setMonth(this.datemin.getMonth()-3));
    this.formatDate();
    console.log(this.datemax,this.datemin)
    this.load();
    this.bill = this._bill;
    this.service.getUserProfile().subscribe(
      (res:any)=>{
        this.bill.emailId = res.emailId;
        this.bill.status = "pending";
      },
      (err:any)=>{
        console.log(err);
      }
    );
  }

  load(){
  }

  addBill(){
    this.service.addBill(this.bill).subscribe(res=>{
      window.location.reload();
    });
  }

  updateBill(){
    this.service.updateBill(this.bill,this.bill.id).subscribe(res=>{
      window.location.reload();
    });
  }

  formatDate() {
    var d = new Date(this.datemin),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2) 
        month = '0' + month;
    if (day.length < 2) 
        day = '0' + day;
    
  

   this.newdatemin = Date.parse([year, month, day].join('-'));
   console.log(this.newdatemin)
}

}
