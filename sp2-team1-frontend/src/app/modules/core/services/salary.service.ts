import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {environment} from '../../../../environments/environment.prod';
import {SalaryRequest} from '@app/modules/shared/models/salary-request';
import {SalaryResponse} from '@app/modules/shared/models/salary-response';
import {Region} from '@app/modules/shared/models/region';
import {Func} from '@app/modules/shared/models/function';
import {Salary} from '@app/modules/shared/models/salary';


@Injectable({providedIn: 'root'})
export class SalaryService {

  private salaryApiUrl = `${environment.endpoint}/Salary`;
  private regionsApiUrl = `${environment.endpoint}/Region`;
  private functionsApiUrl = `${environment.endpoint}/Function`;

  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  };

  constructor(private http: HttpClient) {
  }

  calculate(data: SalaryRequest): Observable<SalaryResponse> {
    return this.http.post<SalaryResponse>(this.salaryApiUrl, data, this.httpOptions);
  }

  calculateOnClient(data: SalaryRequest): Observable<SalaryResponse> {
    const result: Observable<SalaryResponse> = new Observable(sub => {
      const experience = data.experience;
      this.getSalaryByRegionAndFunc(data.regionId, data.functionId, data.isLead).subscribe(salaryData => {
        const leadAllowance = salaryData.function.isLead ? salaryData.max * 0.1 : 0;
        const generalAllowance = (salaryData.max - salaryData.min - leadAllowance) / 20;
        const resultMin = Math.round(experience / 5) * generalAllowance + salaryData.min;
        const resultMax = generalAllowance * experience + salaryData.min + leadAllowance;

        sub.next({
          fromValue: resultMin,
          toValue: resultMax
        });
      });
    });
    return result;
  }

  getRegions(): Observable<Region[]> {
    return this.http.get<Region[]>(this.regionsApiUrl);
  }

  getFunctions(): Observable<Func[]> {
    return this.http.get<Func[]>(this.functionsApiUrl);
  }

  getSalaryByRegionAndFunc(regionId: number, functionId: number, isLead: boolean): Observable<Salary> {
    return this.http.get<Salary>(`${this.salaryApiUrl}?regionId=${regionId}&functionId=${functionId}&isLead=${isLead}`);
  }

  sendCalculationData(frontendResponse: SalaryResponse, backendResponse: SalaryResponse, candidate) {
    return this.http.post(`${this.salaryApiUrl}/GetPdfFile`, {
      frontendMinSalary: frontendResponse.fromValue,
      frontendMaxSalary: frontendResponse.toValue,
      backendMinSalary: backendResponse.fromValue,
      backendMaxSalary: backendResponse.toValue,
      experience: candidate.experience,
      region: candidate.region,
      function: candidate.function,
      isLead: candidate.isLead
    }, {responseType: 'blob'});
  }
}
