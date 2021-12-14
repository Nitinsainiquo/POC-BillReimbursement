import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminGuard } from './auth/admin.guard';
import { AuthGuard } from './auth/auth.guard';
import { AdminComponent } from './home/admin/admin.component';
import { EmployeeComponent } from './home/employee/employee.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './user/login/login.component';
import { RegisterComponent } from './user/register/register.component';
import { UserComponent } from './user/user.component';

const routes: Routes = [
  {path:'',redirectTo:'/user/register',pathMatch:'full'},
  {
    path: 'user', component:UserComponent,
    children: [
      { path: 'register', component:RegisterComponent },
      { path: 'login', component:LoginComponent }
    ]
  },
  {
    path:'home', component:HomeComponent,canActivate:[AuthGuard],
    children:[
      {path:'employee', component: EmployeeComponent},
      {path:'admin', component: AdminComponent,canActivate:[AdminGuard]}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
