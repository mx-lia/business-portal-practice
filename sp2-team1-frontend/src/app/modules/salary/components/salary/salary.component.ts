import {Component, OnInit, ViewChild} from '@angular/core';
import {SalaryResponse} from '@app/modules/shared/models/salary-response';
import {SalaryRequest} from '@app/modules/shared/models/salary-request';
import {SalaryService} from '@app/modules/core/services/salary.service';
import {DialogComponent} from '@app/modules/salary/components/dialog/dialog.component';
import {MatDialog} from '@angular/material/dialog';
import {CandidateInfoComponent} from '@app/modules/salary/components/candidate-info/candidate-info.component';

@Component({
  selector: 'app-salary',
  templateUrl: './salary.component.html',
  styleUrls: ['./salary.component.css']
})
export class SalaryComponent implements OnInit {
  frontendResponse: SalaryResponse;
  backendResponse: SalaryResponse;

  @ViewChild(CandidateInfoComponent, {static: false})
  private userInfoComponent: CandidateInfoComponent;

  constructor(private salaryService: SalaryService,
              public dialog: MatDialog) {
    this.frontendResponse = {
      fromValue: 0,
      toValue: 0
    };

    this.backendResponse = {
      fromValue: 0,
      toValue: 0
    };
  }

  ngOnInit(): void {
  }

  calculate(request: SalaryRequest) {
    this.salaryService.calculateOnClient(request).subscribe(data => {
      this.frontendResponse = data;
    }, error => {
      this.openDialog(error);
      this.resetSalaries();
    });

    this.salaryService.calculate(request).subscribe(data => {
      this.backendResponse = data;
    }, error => {
      console.log(error);
      this.openDialog(error);
      this.resetSalaries();
    });
  }

  openDialog(errorMsg: string): void {
    const dialogRef = this.dialog.open(DialogComponent, {
      width: '350px',
      data: {message: errorMsg}
    });
  }

  public resetSalaries() {
    this.frontendResponse.fromValue = 0;
    this.frontendResponse.toValue = 0;
    this.backendResponse.fromValue = 0;
    this.backendResponse.toValue = 0;
  }

  downloadFile(data) {
    const url = window.URL.createObjectURL(data);
    window.open(url);
  }

  sendInPdf() {
    this.salaryService.sendCalculationData(
      this.frontendResponse,
      this.backendResponse,
      this.userInfoComponent.getCandidateData()
    ).subscribe(data => {
      this.downloadFile(data);
    }, error => {
      console.log(error);
    });
  }
}
