import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';

import { AuthGuard } from './auth.guard';

fdescribe('AuthGuard', () => {
  let guard: AuthGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule,RouterTestingModule.withRoutes([])],
    });
    guard = TestBed.inject(AuthGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
  it('Check CanActivate', () => {
    expect(guard.canActivate).toBeTruthy();
  });
});
