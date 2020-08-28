using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.RegionApi.Requests
{
    public class GetRegionsRequest : IRequest<IEnumerable<Region>> { }
    public class GetRegionsRequestHandler : IRequestHandler<GetRegionsRequest, IEnumerable<Region>>
    {
        IDbContext context;
        public GetRegionsRequestHandler(IDbContext dbContext)
        {
            context = dbContext;
        }

        public async Task<IEnumerable<Region>> Handle(GetRegionsRequest request, CancellationToken cancellationToken)
        {
            var regions = await context.Regions.ToListAsync();
            return regions;
        }
    }
}
