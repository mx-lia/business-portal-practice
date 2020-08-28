import { NgModule } from '@angular/core';
import { SharedModule } from '@app/modules/shared/shared.module';
import { LoginComponent } from './components/login/login.component';
import { LoginRoutingModule } from '@app/modules/login/login-routing.module';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [LoginComponent],
  imports: [
    CommonModule,
    SharedModule,
    LoginRoutingModule
  ]
})
export class LoginModule { }
