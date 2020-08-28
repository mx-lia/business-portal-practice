using Application.Common.Interfaces;
using Application.SalaryApi.Dtos;
using Domain.Entities;
using System;

namespace Infrastructure.Services
{
    class SalaryCalculationService : ISalaryCalculationService
    {
        public SalaryValuesDto CalculateSalary(Salary salary, double experience)
        {
            double extraCharge = salary.Function.IsLead ? salary.Max * 0.1 : 0.0;
            double coef = (salary.Max - salary.Min - extraCharge) / 20;
            double formValue = salary.Min + Math.Round(experience / 5) * coef;
            double toValue = coef * experience + salary.Min + extraCharge;
            return new SalaryValuesDto { FromValue = formValue, ToValue = toValue };
        }
    }
}
