using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Helpers;
using Application.Common.Interfaces;
using Application.UsersApi.Helpers;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.UsersApi.Commands
{
    public class EditUserCommand : IRequest<User>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public string OldPassword { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }

    public class EditUserCommandHandler : IRequestHandler<EditUserCommand, User>
    {
        private readonly IDbContext context;
        private readonly IHashService _hashService;
        public EditUserCommandHandler(IDbContext dbContext, IHashService hashService)
        {
            context = dbContext;
            _hashService = hashService;
        }
        public async Task<User> Handle(EditUserCommand command, CancellationToken cancellationToken)
        {
            // TODO: check for login do something if needed
           
            User user = context.Users.FirstOrDefault(item => item.Id == command.Id);

            if (user != null)
            {
                //if (Hash.Verify(command.OldPassword, user.Password))
                //{
                if (!user.UserName.Equals(command.UserName))
                {
                    if (UserHelpers.CheckForUniqueUserName(context, command.UserName))
                    {
                        user.UserName = command.UserName;
                    }
                    else
                    {
                        throw new Exception("User with the same Username already exists");
                    }
                }

                if (!user.Email.Equals(command.Email))
                {
                    if (UserHelpers.CheckForUniqueEmail(context, command.Email))
                    {
                        user.Email = command.Email;
                    }
                    else
                    {
                        throw new Exception("User with the same Email already exists");
                    }
                }

                if (command.Password != null && command.PasswordConfirmation != null)
                {
                    if (command.Password.Equals(command.PasswordConfirmation))
                    {
                        user.Password = _hashService.GetHash(command.Password);
                    }
                    else
                    {
                        throw new Exception("New passwords do not match");
                    }
                }

                if (command.Role != user.Role)
                {
                    user.Role = command.Role;
                }

                context.Users.Update(user);
                context.Save();
                return user;
                //}
                //else
                //{
                //    throw new Exception("Wrong Password");
                //}
            }
            else
            {
                throw new Exception("User not found");
            }
        }
    }
}