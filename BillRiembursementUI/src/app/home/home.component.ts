import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BillReimbursementService } from '../bill-reimbursement.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(private router:Router,private service : BillReimbursementService) { }
  LoginUser : any ={}

  ngOnInit(): void {
    this.service.getUserProfile().subscribe(
      res => {
        console.log(res);
        this.LoginUser = res;
      },
      err => {
        console.log(err);
      },
    );
  }
  onlogout(){
    localStorage.removeItem('token');
    this.router.navigateByUrl('user/login')

  }

}
