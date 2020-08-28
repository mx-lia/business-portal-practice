import { NgModule } from '@angular/core';
import { Route, RouterModule } from '@angular/router';
import { LoginComponent } from '@app/modules/login/components/login/login.component';
import { CommonModule } from '@angular/common';

const routes: Route[] = [
  {
    path: '', component: LoginComponent,
  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class LoginRoutingModule { }
