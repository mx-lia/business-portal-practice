using Application.Common.Interfaces;
using Application.UsersApi.Dtos;
using Application.UsersApi.Helpers;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UsersApi.Requests
{
    public class GetByPageRequest : IRequest<UsersByPageDto>
    {
        public int? PageNum { get; set; } = 1;
        public int? PageSize { get; set; } = 15;
        public string SearchName { get; set; }
        public string SearchEmail { get; set; }
        public SortState SortOrder { get; set; } = SortState.UserNameAsc;
    }

    public class GetByPageRequestHandler : IRequestHandler<GetByPageRequest, UsersByPageDto>
    {
        IDbContext context;
        public GetByPageRequestHandler(IDbContext dbContext)
        {
            context = dbContext;
        }

        public async Task<UsersByPageDto> Handle(GetByPageRequest request, CancellationToken cancellationToken)
        {
            var credentialsIsValid = await Task.FromResult(request.PageNum.HasValue && request.PageSize.HasValue && request.PageNum.Value > 0 && request.PageSize.Value > 0);
            if (credentialsIsValid)
            {
                IQueryable<User> records = context.Users;
                
                // filtration
                if(!String.IsNullOrEmpty(request.SearchName))
                {
                    records = records.Where(s => s.UserName.Contains(request.SearchName));
                }
                if(!String.IsNullOrEmpty(request.SearchEmail))
                {
                    records = records.Where(s => s.Email.Contains(request.SearchEmail));
                }

                // sorting
                records = request.SortOrder switch
                {
                    SortState.UserNameAsc => records.OrderBy(s => s.UserName),
                    SortState.UserNameDesc => records.OrderByDescending(s => s.UserName),
                    SortState.EmailAsc => records.OrderBy(s => s.Email),
                    SortState.EmailDesc => records.OrderByDescending(s => s.Email),
                    SortState.IdAsc => records.OrderBy(s => s.Id),
                    SortState.IdDesc => records.OrderByDescending(s => s.Id),
                    _ => records.OrderBy(s => s.UserName)
                };
                
                // pagination
                var users = records.Skip((request.PageNum.Value - 1) * request.PageSize.Value).Take(request.PageSize.Value);
                var countOfRecords = records.Count();
                var countOfPages = (int)Math.Ceiling((double)countOfRecords / request.PageSize.Value);

                UsersByPageDto result = new UsersByPageDto();
                result.Users = users;
                result.CountOfPages = countOfPages;
                result.CountOfRecords = countOfRecords;

                return result;
            }
            else
            {
                // return new UsersByPageDto();
                throw new InvalidDataException("Check query parameters, 'PageNum' and 'PageSize' cannot be a zero or negative values");
            }
        }

        
    }
}
