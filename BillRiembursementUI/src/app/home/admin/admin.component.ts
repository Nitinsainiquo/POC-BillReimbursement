import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BillReimbursementService } from 'src/app/bill-reimbursement.service';
import { AppliedBill } from 'src/app/Shared/Models';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {

  constructor(private service : BillReimbursementService,private router: Router) { }
  BillList : AppliedBill[] = [];
  userid! : string;
  ModalTitle!:string;
  ActivateAddEditDepComp:boolean=false;
  ApproveDecline:boolean=false;
  bill! :AppliedBill
  EmailFilter :string = "";
  PaymentFilter :string = "";
  FullNameFilter:string="";
  TypeFilter:string = "";
  greaterthanFilter:number = 0;
  lessthanFilter:number = 300000;
  StatusFilter:string = "pending";
  // ToDate : Date =  new Date(new Date(Date.now()).setMonth(new Date().getMonth()-3));
  // FromDate: Date =  new Date(new Date(Date.now()).setMonth(new Date().getMonth()+3));

  ToDate! : Date 
  FromDate!: Date 
  BillType = ["food","travel","medical"]
  StatusType = ["pending","approved","declined"]
  paymentMode =["upi","cash","check","banktransfer"]
  modalHead = ""
  ModalRemarks?:string;

  DepartmentIdFilter:string="";
  DepartmentNameFilter:string="";
  ListWithoutFilter:AppliedBill[] = [];

  ngOnInit(): void {
    this.refreshDepList();
    if (localStorage.getItem('token') != null){
      this.service.getUserProfile().subscribe(
        (res:any)=>{
          this.userid = res.emailId;
          if(res.role=="User")
            this.router.navigateByUrl('/home/employee');
        })
    }  
  }

  approvedClick(item:AppliedBill){
    this.bill=item;
    this.ApproveDecline  = true;
    this.ModalTitle="Are you sure You Want to Approve?";
    this.modalHead = "Approve Bill"
    this.ModalRemarks = item.remarks;
  }

  declinedClick(item:AppliedBill){
    this.bill=item;
    this.ApproveDecline  = false;
    this.ModalTitle="Are you sure You Want to Decline?";
    this.modalHead = "Decline Bill"
    this.ModalRemarks = item.remarks;
  }
  approvedecline(){
    if(this.ApproveDecline){
      this.service.getUserProfile().subscribe(
        (res:any)=>{
          this.bill.modifiedBy = res.emailId
          this.service.updateApprove(this.bill,this.bill.id).subscribe((data:any)=>{
            this.refreshDepList();})
        ,(err:any)=>{console.log(err)}
      })
    }else{
      this.service.getUserProfile().subscribe(
        (res:any)=>{
          this.bill.modifiedBy = res.emailId
          this.service.updateDecline(this.bill,this.bill.id).subscribe((data:any)=>{
            this.refreshDepList();})
        ,(err:any)=>{console.log(err)}
      })
    }
  }

  closeClick(){
    this.ActivateAddEditDepComp=false;
    this.refreshDepList();
  }


  refreshDepList(){
    this.service.getUserProfile().subscribe(
      (res:any)=>{
        this.userid = res.emailId;
        this.service.getAllBill(this.userid).subscribe(
          (data : any) => {
            this.BillList = data;
            this.ListWithoutFilter = data;
            this.FilterFn();
          },
          (err:any)=>{
            console.log(err);
          }
        );
      },(err:any)=>{console.log(err)}
    ) 
  }

  FilterFn(){
    var EmailFilter = this.EmailFilter;
    var FullNameFilter = this.FullNameFilter;
    var TypeFilter = this.TypeFilter;
    var StatusFilter = this.StatusFilter;
    var PaymentFilter = this.PaymentFilter;
    var greaterthanFilter =this.greaterthanFilter;
    var lessthanFilter = this.lessthanFilter;
    // var ToDate = this.ToDate;
    // var FromDate = this.FromDate;


    this.BillList = this.ListWithoutFilter.filter(function (el){
        return el.emailId.toString().toLowerCase().includes(
          EmailFilter.toString().trim().toLowerCase()
        )&&
        el.fullName?.toString().toLowerCase().includes(
          FullNameFilter.toString().trim().toLowerCase()
        )&&
        el.type.toString().toLowerCase().includes(
          TypeFilter.toString().trim().toLowerCase()
        )&&
        ((el.amount) >= greaterthanFilter)&&
        ((el.amount) <= lessthanFilter)&&
        // ((el.applyDate) >= ToDate)&&
        // ((el.applyDate) <= FromDate)
        // &&
        el.paymentMode.toString().toLowerCase().includes(
          PaymentFilter.toString().trim().toLowerCase()
        )&&
        el.status.toString().toLowerCase().includes(
          StatusFilter.toString().trim().toLowerCase()
        )
    });
  }
}
