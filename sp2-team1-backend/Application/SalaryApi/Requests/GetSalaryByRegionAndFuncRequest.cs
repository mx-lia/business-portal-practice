using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SalaryApi.Requests
{
    public class GetSalaryByRegionAndFuncRequest: IRequest<Salary>
    {
        public int FunctionId { get; set; }
        public int RegionId { get; set; }
        public bool IsLead { get; set; }
    }

    public class GetSalariesRequestHandler : IRequestHandler<GetSalaryByRegionAndFuncRequest, Salary>
    {

        IDbContext context;

        public GetSalariesRequestHandler(IDbContext dbContext)
        {
            context = dbContext;
        }
        public async Task<Salary> Handle(GetSalaryByRegionAndFuncRequest request, CancellationToken cancellationToken)
        {            
            var region = context.Regions.FirstOrDefault(r => r.Id == request.RegionId);
            if(request == null)
            {
                throw new Exception("No information for this region");
            }
            var function = context.Functions.FirstOrDefault(f => f.Id == request.FunctionId && f.IsLead == request.IsLead);
            if (function == null)
            {
                throw new Exception("No information for this function in selected region");
            }
            var salary = context.Salaries.FirstOrDefault(s => s.Function.Id == request.FunctionId && s.Region.Id == request.RegionId);
            if(salary == null)
            {
                throw new Exception("No salary information for this function in selected region");
            }
            return salary;
        }
    }
}
