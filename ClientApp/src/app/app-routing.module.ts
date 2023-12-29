import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { UserDashboardComponent } from './components/user-dashboard/user-dashboard.component';
import { TransactionFormComponent } from './components/user-dashboard/transaction-form/transaction-form.component';

const routes: Routes = [
  {path:"login", component: LoginComponent},
  {path:"registration", component: RegistrationComponent},
  {path:"user-dasboard", component: UserDashboardComponent},
  {path:"transaction-form", component: TransactionFormComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
