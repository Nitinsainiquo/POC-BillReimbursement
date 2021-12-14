import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { ToastrModule, ToastrService } from 'ngx-toastr';

import { LoginComponent } from './login.component';

fdescribe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LoginComponent ],
      imports: [HttpClientTestingModule,ToastrModule.forRoot(),ReactiveFormsModule,FormsModule,RouterTestingModule.withRoutes([]),],
      providers: [ToastrService,]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('Submit form check', () => {
    fixture.detectChanges();
    fixture.whenStable().then(() => {
      const confirmMethodMock = spyOn(component, 'onSubmit').and.callThrough();
      const formDetails: HTMLFormElement = fixture.debugElement.nativeElement.querySelector('#FormId');
      
      const confirmButton: HTMLButtonElement = fixture.debugElement.nativeElement.querySelector('#SubmitButton');
      confirmButton.click();
      fixture.detectChanges();
      
        expect(confirmMethodMock).toHaveBeenCalledTimes(1);
        expect(formDetails.length).toEqual(2);
    })
  })

});
