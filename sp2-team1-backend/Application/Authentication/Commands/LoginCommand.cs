using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using MediatR;
using System;
using Domain.Entities;

// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Authentication.Commands
{
    public class LoginCommand : IRequest<User>
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, User>
    {
        private readonly IDbContext _dbContext;
        private readonly IHashService _hashService;
        public LoginCommandHandler(IDbContext dbcontext, IHashService hashService)
        {
            _dbContext = dbcontext;
            _hashService = hashService;
        }
       
        async Task<User> IRequestHandler<LoginCommand, User>.Handle(LoginCommand command, CancellationToken cancellationToken)
        {
          
            var user = _dbContext.Users.FirstOrDefault(item => item.UserName == command.UserName);
            if (user == null)
            {
                throw new Exception("Invalid userName");
            }
            if (!_hashService.Verify(command.Password, user.Password))
            {
                throw new Exception("Invalid password");
            }
            
            return user;

        }
    }
}