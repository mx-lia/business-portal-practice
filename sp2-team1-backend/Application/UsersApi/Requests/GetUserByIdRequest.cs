using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UsersApi.Requests
{
    public class GetUserByIdRequest : IRequest<User>
    {
        public int? Id { get; set; }
    }

    public class GetUserByIdRequestHandler : IRequestHandler<GetUserByIdRequest, User>
    {
        private readonly IDbContext context;
        public GetUserByIdRequestHandler(IDbContext dbContext)
        {
            context = dbContext;
        }
        public async Task<User> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            // TODO: getting user info (by id)

            var isHasValue = await Task.FromResult(request.Id.HasValue);

            if (!isHasValue)
            {
                throw new InvalidDataException();
            }

            var user = context.Users
                            .Include(item => item.Role)
                            .Where(item => item.Id == request.Id.Value)
                            .FirstOrDefault();

            if (user != null)
                return user;
            else
                throw new Exception("User not found");
        }
    }
}