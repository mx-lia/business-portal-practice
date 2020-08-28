import {Component, Inject, OnInit, Output, ViewChild} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';

import {SalaryService} from '../../../core/services/salary.service';
import {SalaryRequest} from '@app/modules/shared/models/salary-request';
import {Region} from '@app/modules/shared/models/region';
import {Func} from '@app/modules/shared/models/function';
import {EventEmitter} from '@angular/core';
import {SalaryComponent} from '@app/modules/salary/components/salary/salary.component';


@Component({
  selector: 'app-user-info',
  templateUrl: './candidate-info.component.html',
  styleUrls: ['./candidate-info.component.css']
})
export class CandidateInfoComponent implements OnInit {
  @Output() dataChanged: EventEmitter<any> = new EventEmitter();

  userInfoForm: FormGroup;
  request: SalaryRequest;
  regions: Region[];
  functions: Func[];

  constructor(private fb: FormBuilder,
              private salaryService: SalaryService,
              @Inject(SalaryComponent) private salaryComponent: SalaryComponent) {
  }

  ngOnInit(): void {
    this.createForm();
  }

  calculate() {
    const experience = this.userInfoForm.get('experience').value;
    const func = this.userInfoForm.get('function').value;
    const region = this.userInfoForm.get('region').value;
    const isLead = this.userInfoForm.get('isLead').value;

    this.request = {
      functionId: parseInt(func, 10),
      regionId: parseInt(region, 10),
      experience,
      isLead
    };

    this.dataChanged.emit(this.request);
  }

  createForm() {
    this.salaryService.getRegions().subscribe(data => {
      this.regions = data;
    });

    this.salaryService.getFunctions().subscribe(data => {
      this.functions = data;
    });

    this.userInfoForm = this.fb.group({
      title: ['Candidate information'],
      submitBtn: ['Calculate'],
      resetBtn: ['Reset'],
      experience: [0, [Validators.required, Validators.max(60), Validators.min(0)]],
      function: [this.functions ? this.functions : [], [Validators.required]],
      region: [this.regions ? this.regions : [], [Validators.required]],
      isLead: [false, []]
    });
  }

  public getCandidateData() {
    const experience = this.userInfoForm.get('experience').value;
    const func = this.userInfoForm.get('function').value;
    const region = this.userInfoForm.get('region').value;
    const isLead = this.userInfoForm.get('isLead').value;
    const candidate = {
      experience,
      function: func,
      region,
      isLead
    };

    return candidate;
  }

  reset() {
    this.createForm();
    this.salaryComponent.resetSalaries();
  }
}
