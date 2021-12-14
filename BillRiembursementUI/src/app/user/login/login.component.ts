import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginModel } from '../../Shared/Models';
import { BillReimbursementService } from 'src/app/bill-reimbursement.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  LoginForm : LoginModel = {
    EmailId : "",
    Password : ""
  }

  constructor(private router : Router,private toastr : ToastrService, private service : BillReimbursementService) { }

  ngOnInit(): void {
    if (localStorage.getItem('token') != null)
      this.router.navigateByUrl('/home/employee');
  }

  onSubmit(form: NgForm) {
    console.log(form.value)
    this.LoginForm = {
      EmailId : form.value.EmailId,
      Password : form.value.Password
    }
    this.service.login(this.LoginForm).subscribe(
      (res: any) => {
        localStorage.setItem('token', res.token);
        this.router.navigate(["/home/employee"]);
        this.toastr.success('User Login!', 'successfully Logged In');
      },
      (err : any) => {
        if (err.status == 400 || err.status == 401)
          this.toastr.error('Incorrect username or password.', 'Authentication failed.');
        else
          console.log(err);
      }
    );
  }


}
