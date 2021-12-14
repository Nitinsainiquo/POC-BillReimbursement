import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';

import { AddbillComponent } from './addbill.component';

describe('AddbillComponent', () => {
  let component: AddbillComponent;
  let fixture: ComponentFixture<AddbillComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddbillComponent ],
      imports: [HttpClientTestingModule,ReactiveFormsModule,FormsModule,RouterTestingModule.withRoutes([])],
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddbillComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    fixture.detectChanges();
    fixture.whenStable().then(() => {
    expect(component).toBeTruthy();
    })
  });
  it('Submit form check', () => {
    fixture.detectChanges();
    fixture.whenStable().then(() => {
      const confirmMethodMock = spyOn(component, 'addBill').and.callThrough();
      const formDetails: HTMLFormElement = fixture.debugElement.nativeElement.querySelector('#FormId');
      
      const confirmButton: HTMLButtonElement = fixture.debugElement.nativeElement.querySelector('#SubmitForm');
      confirmButton.click();
      fixture.detectChanges();
      
        expect(confirmMethodMock).toHaveBeenCalledTimes(1);
        expect(formDetails.length).toEqual(2);
    })
  })
});
