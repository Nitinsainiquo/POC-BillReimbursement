import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BillReimbursementService } from 'src/app/bill-reimbursement.service';
import {EmployeeModel} from "../../Shared/Models";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  Employee! : EmployeeModel

  constructor(private service: BillReimbursementService, private toastr : ToastrService, private fb: FormBuilder,
    private router : Router) { }
  

  ngOnInit(): void {
    // if (localStorage.getItem('token') != null)
    //   this.router.navigateByUrl('/home/employee');
    this.formModel.reset();
    
  }
  formModel = this.fb.group({
    FullName: ['',Validators.required],
    Email: ['', [Validators.email,Validators.required]],
    Role: ['', Validators.required],
    Passwords: this.fb.group({
      Password: ['', [Validators.required, Validators.minLength(4)]],
      ConfirmPassword: ['', Validators.required]
    }, { validator: this.comparePasswords })

  });

  onSubmit() {
    this.Employee = {
      FullName : this.formModel.value.FullName,
      EmailId : this.formModel.value.Email.toLowerCase(),
      Password : this.formModel.value.Passwords.Password,
      Role : this.formModel.value.Role 
    }
    // console.log(this.Employee)


    this.service.register(this.Employee).subscribe( 
      (res: any) => {
          console.log(res.code);
          this.formModel.reset();
          this.toastr.success('New user created!', 'Registration successful.');
          this.router.navigateByUrl('user/login')
      },
      (err : any) => {
        console.log(err.error);
        this.toastr.error('Email Id already exist!', 'Registration Unsuccessful.');
      }
    );
  }

  comparePasswords(fb: FormGroup) {
    const confirmPswrdCtrl = fb.get('ConfirmPassword');
    if (confirmPswrdCtrl?.errors == null || 'passwordMismatch' in confirmPswrdCtrl.errors) {
      if (fb.get('Password')?.value != confirmPswrdCtrl?.value)
        confirmPswrdCtrl?.setErrors({ passwordMismatch: true });
      else
        confirmPswrdCtrl?.setErrors(null);
    }
  }
  clickurl(){
    console.log("clicked");
    this.router.navigateByUrl('user/login');
  }

}
