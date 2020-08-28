import {Component, Input, OnInit} from '@angular/core';
import {SalaryResponse} from '@app/modules/shared/models/salary-response';

@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.css']
})
export class ResultComponent implements OnInit {

  @Input() title: string;
  @Input() salary: SalaryResponse;

  constructor() {
  }

  ngOnInit(): void {
    this.title = this.title ? this.title : 'Result of calculation';
    this.salary.fromValue = this.salary ? this.salary.fromValue : 0;
    this.salary.toValue = this.salary ? this.salary.toValue : 0;
  }
}
