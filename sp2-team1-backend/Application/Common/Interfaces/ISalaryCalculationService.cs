using Application.SalaryApi.Dtos;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface ISalaryCalculationService
    {
        public SalaryValuesDto CalculateSalary(Salary salary, double experience);
    }
}
