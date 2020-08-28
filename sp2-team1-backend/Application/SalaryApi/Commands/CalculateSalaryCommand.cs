using Application.Common.Interfaces;
using Application.SalaryApi.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SalaryApi.Commands
{
    public class CalculateSalaryCommand : IRequest<SalaryValuesDto>
    {
        public int FunctionId { get; set; }
        public int RegionId { get; set; }
        public double Experience { get; set; }
        public bool IsLead { get; set; }
    }

    public class CalculateSalaryCommandHandler : IRequestHandler<CalculateSalaryCommand, SalaryValuesDto>
    {
        private readonly IDbContext context;
        private readonly ISalaryCalculationService _salaryCalculationService;
        public CalculateSalaryCommandHandler(IDbContext dbContext, ISalaryCalculationService salaryCalculationService)
        {
            context = dbContext;
            _salaryCalculationService = salaryCalculationService;
        }
        public async Task<SalaryValuesDto> Handle(CalculateSalaryCommand command, CancellationToken cancellationToken)
        {
            var salary = context.Salaries.Include(item => item.Function).FirstOrDefault(
                item => item.Function.Id == command.FunctionId && 
                        item.Region.Id == command.RegionId && 
                        item.Function.IsLead == command.IsLead
                );

            if(salary == null)
            {
                throw new Exception("No salary information for this region and function");
            }

            SalaryValuesDto salaryValues = _salaryCalculationService.CalculateSalary(salary, command.Experience);

            return salaryValues;
        }
    }
}
