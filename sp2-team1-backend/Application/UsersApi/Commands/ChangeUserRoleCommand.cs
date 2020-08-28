using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UsersApi.Commands
{
    public class ChangeUserRoleCommand: IRequest
    {
        public int? UserId { get; set; }
        public Role? NewRole { get; set; }
    }

    public class ChangeUserRoleCommandHandler : AsyncRequestHandler<ChangeUserRoleCommand>
    {
        private readonly IDbContext context;
        public ChangeUserRoleCommandHandler(IDbContext dbContext)
        {
            context = dbContext;
        }

        protected override async Task Handle(ChangeUserRoleCommand command, CancellationToken cancellationToken)
        {
            var isValidUserId = command.UserId.HasValue && command.UserId.Value > 0 && command.NewRole.HasValue ? true : false;
            

            if(!isValidUserId)
            {
                throw new InvalidDataException();
            }

            var user = context.Users.FirstOrDefault(item => item.Id == command.UserId.Value);
            user.Role = command.NewRole.Value;

            context.Users.Update(user);
            context.Save();
        }
    }
}
