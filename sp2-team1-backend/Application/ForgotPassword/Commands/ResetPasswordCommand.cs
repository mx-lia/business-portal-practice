using Application.Common.Interfaces;
using FluentValidation.Results;
using MediatR;
using System;
using System.Linq;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ForgotPassword.Commands
{
    public class ResetPasswordCommand : IRequest
    {
        public string Token { get; set; }
        public string Password { get; set; }
    }
    public class ResetPasswordCommandHandler : AsyncRequestHandler<ResetPasswordCommand>
    {
        private readonly IDbContext _dbContext;
        private readonly IHashService _hashService;
        public ResetPasswordCommandHandler(IDbContext dbcontext, IHashService hashService)
        {
            _dbContext = dbcontext;
            _hashService = hashService;
        }
        protected override async Task Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var token = _dbContext.Tokens.FirstOrDefault(item => item.Token == request.Token);
            if (token == null)
            {
                throw new Exception("Invaild token");
            }

            var user = _dbContext.Users.FirstOrDefault(item => item.Email == token.Email);
            user.Password = _hashService.GetHash(request.Password);
            _dbContext.Users.Update(user);
            _dbContext.Save();

            _dbContext.Tokens.Remove(token);
            _dbContext.Save();
        }
    }
}
