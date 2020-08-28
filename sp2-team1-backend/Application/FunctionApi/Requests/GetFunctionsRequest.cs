using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.FunctionApi.Requests
{

    public class GetFunctionsRequest : IRequest<IEnumerable<Function>> { }
    public class GetFunctionsRequestHandler : IRequestHandler<GetFunctionsRequest, IEnumerable<Function>>
    {
        IDbContext context;
        public GetFunctionsRequestHandler(IDbContext dbContext)
        {
            context = dbContext;
        }

        public async Task<IEnumerable<Function>> Handle(GetFunctionsRequest request, CancellationToken cancellationToken)
        {
            var functions = await context.Functions.ToListAsync();
            return functions;
        }
    }
}
