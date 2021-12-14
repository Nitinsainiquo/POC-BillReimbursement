import { ComponentFixture, TestBed } from '@angular/core/testing';
import {
  HttpClientTestingModule,
  HttpTestingController
} from "@angular/common/http/testing";
import { Toast, ToastrService, ToastPackage, ToastrModule } from 'ngx-toastr';
import { RegisterComponent } from './register.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { preserveWhitespacesDefault } from '@angular/compiler';

fdescribe('RegisterComponent', () => {
  let component: RegisterComponent;
  let fixture: ComponentFixture<RegisterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterComponent ],
      imports: [HttpClientTestingModule,ToastrModule.forRoot(), ReactiveFormsModule,RouterTestingModule.withRoutes([]),],
      providers: [ToastrService,]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should check Email is valid', () => {
    let email = component.formModel.controls['Email'];
    expect(email.valid).toBeFalsy();
    expect(email.pristine).toBeTruthy();
    expect(email.errors).toBeTruthy();
    email.setValue('abc');
    expect(email.errors).toBeTruthy();
  });

  it('should check Email is valid', () => {
    let email = component.formModel.controls['Email'];
    expect(email.valid).toBeFalsy();
    expect(email.pristine).toBeTruthy();
    expect(email.errors).toBeTruthy();
    email.setValue('abc');
    expect(email.errors).toBeTruthy();
  });

  it('should check Full Name is valid', () => {
    let FullName = component.formModel.controls['FullName'];
    expect(FullName.valid).toBeFalsy();
    expect(FullName.pristine).toBeTruthy();
    expect(FullName.errors).toBeTruthy();
    FullName.setValue('abc asd');
    expect(FullName.errors).toBeFalsy();
  }); 

  it('[FullName-check] - should check user correct Full Name is entered', () => {
    let FullName = component.formModel.controls['FullName'];
    FullName.setValue('abc asdasd');
    expect(FullName.errors).toBeNull();
  });

  it('[Email-check] - should check user correct email address is entered', () => {
    let email = component.formModel.controls['Email'];
    email.setValue('abc@gmail.com');
    expect(email.errors).toBeNull();
  });

  it('[Password-check] - should check Password Errors', () => { 
    let pws = component.formModel.controls['Passwords'];
    expect(pws.valid).toBeFalsy();
    component.formModel.get('Passwords.Password')?.setValue('123');
    expect(pws.errors).toBeNull();
  });
  it('[Password-check] - should check Password Validity', () => { 
    let pws = component.formModel.controls['Passwords'];
    expect(pws.valid).toBeFalsy();
    component.formModel.get('Passwords.Password')?.setValue('1234');
    component.formModel.get('Passwords.ConfirmPassword')?.setValue('1234');
    expect(pws.valid).toBeTruthy();
  });

  it('[Password-check] - should check Password Mismatch', () => { 
    let pws = component.formModel.controls['Passwords'];
    expect(pws.valid).toBeFalsy();
    component.formModel.get('Passwords.Password')?.setValue('1234');
    component.formModel.get('Passwords.ConfirmPassword')?.setValue('12322');
    expect(pws.valid).toBeFalsy();
  });

  it('[Form-check] - should check Form is valid or not if no values enetered', () => {
    expect(component.formModel.valid).toBeFalsy();
  });

  it('[Form-check] - should check Form is valid or not if when values enetered', () => {
    component.formModel.controls['FullName'].setValue('asc asd');
    component.formModel.controls['Email'].setValue('asc@asd.com');
    component.formModel.get('Passwords.Password')?.setValue('1234');
    component.formModel.get('Passwords.ConfirmPassword')?.setValue('1234');
    expect(component.formModel.valid).toBeFalsy();
  });


});
