import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';

import { AdminComponent } from './admin.component';

fdescribe('AdminComponent', () => {
  let component: AdminComponent;
  let fixture: ComponentFixture<AdminComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminComponent ],
      imports: [HttpClientTestingModule,RouterTestingModule.withRoutes([])],
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  it('Check ApproveClick', () => {
    expect(component.ApproveDecline).toBeFalsy();
  });
  it('Check Decline Click Method', () => {
    expect(component.declinedClick).toBeTruthy();
  });
  it('Check Approve Method', () => {
    expect(component.approvedClick).toBeTruthy();
  });
  it('close modal on close click', () => {
    expect(component.closeClick).toBeTruthy();
  });
});
