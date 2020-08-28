using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Helpers;
using Application.Common.Interfaces;
using Application.UsersApi.Helpers;
using Domain.Entities;
using MediatR;

// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.UsersApi.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Role? Role { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IDbContext context;
        private readonly IHashService _hashService;
        public CreateUserCommandHandler(IDbContext dbContext, IHashService hashService)
        {
            context = dbContext;
            _hashService = hashService;
        }
        public async Task<User> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            // TODO: check for creating credentials
           
            if(!UserHelpers.CheckForUniqueUserName(context, command.UserName))
            {
                throw new Exception("User with the same Username already exists");
            }
            else if(!UserHelpers.CheckForUniqueEmail(context, command.Email))
            {
                throw new Exception("User with the same Email already exists");
            }
            else
            {
                User NewUser = new User();

                NewUser.UserName = command.UserName;
                NewUser.Email = command.Email;
                NewUser.Password = _hashService.GetHash(command.Password);
                if(command.Role != null)
                {
                    NewUser.Role = command.Role.Value;
                }
                else
                {
                    NewUser.Role = Role.User;
                }                

                context.Users.Add(NewUser);
                context.Save();

                return NewUser;
            }
        }
    }
}