import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {ReactiveFormsModule} from '@angular/forms';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatCardModule} from "@angular/material/card";
import {SharedModule} from "../shared/shared.module";
import {MatInputModule} from "@angular/material/input";
import {MatSelectModule} from "@angular/material/select";
import {MatButtonModule} from "@angular/material/button";
import {MatCheckboxModule} from "@angular/material/checkbox";

import {SalaryComponent} from './components/salary/salary.component';
import {SalaryRoutingModule} from './salary-routing.module';
import {CandidateInfoComponent} from './components/candidate-info/candidate-info.component';
import {ResultComponent} from './components/result/result.component';
import {MatGridListModule} from "@angular/material/grid-list";
import {MatDividerModule} from "@angular/material/divider";
import { DialogComponent } from './components/dialog/dialog.component';


@NgModule({
  declarations: [SalaryComponent, CandidateInfoComponent, ResultComponent, DialogComponent],
  imports: [
    CommonModule,
    SharedModule,
    SalaryRoutingModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatCardModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatCheckboxModule,
    MatGridListModule,
    MatDividerModule
  ]
})
export class SalaryModule {
}
