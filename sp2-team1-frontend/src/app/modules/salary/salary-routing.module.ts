import { NgModule } from '@angular/core';
import { Route, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { SalaryComponent } from './components/salary/salary.component';

const routes: Route[] = [
  {
    path: '', component: SalaryComponent,
  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class SalaryRoutingModule { }
