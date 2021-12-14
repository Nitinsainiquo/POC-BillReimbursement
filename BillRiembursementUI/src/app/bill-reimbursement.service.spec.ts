import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import {HttpClientModule} from '@angular/common/http';
import { BillReimbursementService } from './bill-reimbursement.service';

fdescribe('BillReimbursementService', () => {
  let service: BillReimbursementService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [BillReimbursementService]
    });
    
    service = TestBed.inject(BillReimbursementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should have getBill function', () => {
    expect(service.getBill).toBeTruthy();
  });

  it('should have updateApprove function', () => {
    expect(service.updateApprove).toBeTruthy();
  });

  it('should have getAllBill function', () => {
    expect(service.getAllBill).toBeTruthy();
  });
  it('should have deleteBill function', () => {
    expect(service.deleteBill).toBeTruthy();
  });
  it('should have getUserProfile function', () => {
    expect(service.getUserProfile).toBeTruthy();
  });
  it('should have login function', () => {
    expect(service.login).toBeTruthy();
  });
  it('should have updateApprove function', () => {
    expect(service.updateApprove).toBeTruthy();
  });
  it('should have register function', () => {
    expect(service.register).toBeTruthy();
  });
  it('should have updateDecline function', () => {
    expect(service.updateDecline).toBeTruthy();
  });
});
