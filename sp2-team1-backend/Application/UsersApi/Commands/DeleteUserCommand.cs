using System.IO;
using System.Linq;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.UsersApi.Commands
{
    public class DeleteUserCommand : IRequest
    {
        public int? Id { get; set; }
    }

    public class DeleteUserCommandHandler : AsyncRequestHandler<DeleteUserCommand>
    {
        private readonly IDbContext context;
        public DeleteUserCommandHandler(IDbContext dbContext)
        {
            context = dbContext;
        }
        protected override async Task Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            // TODO: check for User ID and deleting user if all right
            var isHasValue= await Task.FromResult(command.Id.HasValue);

            if (!isHasValue)
            {
                throw new InvalidDataException();
            }

            User user = new User() { Id = command.Id.Value };
            context.Users.Attach(user);            
            context.Users.Remove(user);

            context.Save();
        }
    }
}