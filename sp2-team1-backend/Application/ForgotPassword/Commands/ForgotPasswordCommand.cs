using Application.Common.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using FluentValidation.Results;

namespace Application.ForgotPassword.Commands
{
    public class ForgotPasswordCommand : IRequest
    {
        public string Email { get; set; }
    }
    public class ForgotPasswordCommandHandler : AsyncRequestHandler<ForgotPasswordCommand>
    {
        private readonly IDbContext _dbContext;
        private readonly IHashService _hashService;
        private readonly IEmailService _emailService;
        public ForgotPasswordCommandHandler(IDbContext dbcontext, IHashService hashService, IEmailService emailService)
        {
            _dbContext = dbcontext;
            _hashService = hashService;
            _emailService = emailService;
        }
        protected override async Task Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = _dbContext.Users.FirstOrDefault(item => item.Email.Equals(request.Email));
            if (user == null)
            {
                throw new Exception("Invalid email address");
            }

            var token = _hashService.GetHash(user.UserName + user.Password);

            if (await _emailService.SendRecoveryPasswordMessage(token, user.Email, "Reset password"))
            {

                _dbContext.Tokens.Add(new ResetPasswordToken { Token = token, Email = user.Email });
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new Exception("Sending messages is currently unavailable");
            }

        }
    }
}
