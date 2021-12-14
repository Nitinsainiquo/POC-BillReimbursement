import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';

import { EmployeeComponent } from './employee.component';

fdescribe('EmployeeComponent', () => {
  let component: EmployeeComponent;
  let fixture: ComponentFixture<EmployeeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeeComponent ],
      imports: [HttpClientTestingModule,RouterTestingModule.withRoutes([])],
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  it('Check Filter For status', () => {
    expect(component.FilterFn).toBeTruthy();
  });
  it('add bill on add click', () => {
    expect(component.addClick).toBeTruthy();
  });
  it('delete bill on delete click', () => {
    expect(component.deleteClick).toBeTruthy();
  });
  it('Edit bill on Edit click', () => {
    expect(component.editClick).toBeTruthy();
  });
});
