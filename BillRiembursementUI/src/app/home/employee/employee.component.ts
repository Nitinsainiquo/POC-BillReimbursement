import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BillReimbursementService } from 'src/app/bill-reimbursement.service';
import { AppliedBill } from '../../../app/Shared/Models';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent implements OnInit {
  StatusFilter: string = "";

  constructor(private service : BillReimbursementService,private router :Router) { }
  BillList! : AppliedBill[];
  userid! : string;
  ModalTitle!:string;
  ActivateAddEditDepComp:boolean=false;
  bill! :AppliedBill
  StatusType = ["pending","approved","declined"];
  DepartmentIdFilter:string="";
  DepartmentNameFilter:string="";
  ListWithoutFilter:AppliedBill[]=[];

  ngOnInit(): void {
    this.refreshDepList();
    if (localStorage.getItem('token') != null){
      this.service.getUserProfile().subscribe(
        (res:any)=>{
          this.userid = res.emailId;
          if(res.role=="Admin")
            this.router.navigateByUrl('/home/admin');
        })
    }  
    
  }

  addClick(){
    this.bill={
      id : 0,
      emailId : "",
      applyDate : new Date(Date.now()),
      type:"",
      amount: 0,
      paymentMode : "",
      status: ""
    }
    this.ModalTitle="Add Bill";
    this.ActivateAddEditDepComp=true;
  }

  editClick(item:AppliedBill){
    this.bill=item;
    this.ModalTitle="Edit Bill";
    this.ActivateAddEditDepComp=true;
  }

  deleteClick(item:any){
    if(confirm('Are you sure??')){
      this.service.deleteBill(item.id).subscribe((data:any)=>{
        this.refreshDepList();
        
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
        this.service.getBill(this.userid).subscribe(
          (data : any) => {
            this.BillList = data;
            this.ListWithoutFilter = data;
          },
          (err:any)=>{
            console.log(err);
          }
        );
      },(err:any)=>{console.log(err)}
    )
    
  }

  FilterFn(){
   var StatusFilter = this.StatusFilter;


    this.BillList = this.ListWithoutFilter.filter(function (el:any){
        return el.status.toString().toLowerCase().includes(
          StatusFilter.toString().trim().toLowerCase()
        )
    });
  }

}
